using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Xembly.ActionMapper.Helpers;

namespace Xembly.ActionMapper.Internals
{
	internal sealed class KeyboardListener : IDisposable
	{
		#pragma warning disable IDE1006 // Naming Styles
		private const int WH_KEYBOARD_LL = 13;
		private const int WM_KEYDOWN = 0x100;
		private const int WM_KEYUP = 0x101;
		private const int WM_SYSKEYDOWN = 0x104;
		private const int WM_SYSKEYUP = 0x105;
		#pragma warning restore IDE1006 // Naming Styles

		private readonly IntPtr _hookId;
		private readonly Action<KeyMap> _callback;
		private readonly User32.LowLevelHook _proc; // has exist so the GC doesn't collect it
		private readonly Dictionary<int, KeyMap> _downKeys = new();
		private KeyModifiers _downModifierKeys = 0;

		public KeyboardListener(Action<KeyMap> callback)
		{
			_callback = callback;

			using var currentProcess = Process.GetCurrentProcess();
			using var currentModudle = currentProcess.MainModule;
			var currentModuleId = User32.GetModuleHandle(currentModudle.ModuleName);
			_proc = HookHandler;
			_hookId = User32.SetWindowsHookEx(WH_KEYBOARD_LL, _proc, currentModuleId, 0);
		}

		/// <summary>
		/// KeyboardProc callback function <see href="https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644984(v=vs.85)"/>
		/// </summary>
		/// <param name="nCode">A code the hook procedure uses to determine how to process the message.</param>
		/// <param name="wParam">The virtual-key code of the key that generated the keystroke message. <see href="https://msdn.microsoft.com/en-us/library/dd375731(v=vs.85)"/></param>
		/// <param name="lParam">The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag. <see href="https://msdn.microsoft.com/en-us/library/ms646267(v=vs.85)"/></param>
		/// <returns></returns>
		private IntPtr HookHandler(int nCode, IntPtr wParam, IntPtr lParam)
		{
			// Per documentation if code is less than zero, the hook procedure must
			// pass the message to the CallNextHookEx function without further
			// processing and should return the value returned by CallNextHookEx.
			if (nCode >= 0)
			{
				var key = Marshal.ReadInt32(lParam);
				// To prevent slowing keyboard input down, we use handle keyboard inputs in a separate thread
				ThreadPool.QueueUserWorkItem(KeyHander, (key, wParam));
			}

			// Chain to the next hook. Otherwise other applications that
			// are listening to this hook will not get notified
			return User32.CallNextHookEx(_hookId, nCode, wParam, lParam);
		}

		private void KeyHander(object keyInputParams)
		{
			var (key, wParam) = ((int, IntPtr)) keyInputParams;
			var wParamAsInt = wParam.ToInt32();
			var onKeyDown = wParamAsInt == WM_KEYDOWN || wParamAsInt == WM_SYSKEYDOWN;
			var onKeyUp = wParamAsInt == WM_KEYUP || wParamAsInt == WM_SYSKEYUP;

			var modifierKey = key switch
			{
				(int) KeyModifiers.LControlKey => KeyModifiers.Control,
				(int) KeyModifiers.RControlKey => KeyModifiers.Control,
				(int) KeyModifiers.LShiftKey => KeyModifiers.Shift,
				(int) KeyModifiers.RShiftKey => KeyModifiers.Shift,
				(int) KeyModifiers.LMenu => KeyModifiers.Alt,
				(int) KeyModifiers.RMenu => KeyModifiers.Alt,
				_ => KeyModifiers.None
			};

			// track modifier key presses and return
			if (modifierKey != KeyModifiers.None)
			{
				if (onKeyDown) _downModifierKeys |= modifierKey;
				else _downModifierKeys &= ~modifierKey;
				return;
			}

			if (onKeyDown)
			{
				_downKeys[key] = new KeyMap(_downModifierKeys, key, true);
				_callback.Invoke(_downKeys[key]);
			}
			else if (onKeyUp)
			{
				try
				{
					_callback.Invoke(_downKeys[key].OnKeyUpEvent());
					_downKeys.Remove(key);
				}
				catch
				{
					// log exception for missing key?
					_callback.Invoke(new KeyMap(_downModifierKeys, key));
				}
			}
			else
			{
				// log???
			}
		}

		public void Dispose()
		{
			if (_hookId != IntPtr.Zero)
				User32.UnhookWindowsHookEx(_hookId);
		}
	}
}
