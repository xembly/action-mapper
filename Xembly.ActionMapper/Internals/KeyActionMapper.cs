using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xembly.ActionMapper.Helpers;

namespace Xembly.ActionMapper.Internals
{
	internal sealed class KeyActionMapper : IKeyActionMapper, IDisposable
	{
		private readonly KeyboardListener _keyboardListener;
		private readonly Dictionary<Action<ActionEventArgs>, ActionRegister> _actions = new();
		private bool _running = false;

		public KeyActionMapper() => _keyboardListener = new(Handler);

		public void Dispose() => _keyboardListener?.Dispose();

		public void Start() => _running = true;

		public void Stop() => _running = false;

		public bool IsRunning => _running;

		public void Add(params ActionRegister[] actions) => actions.ForEach(r => _actions.Add(r.Action, r));

		public void Remove(params Action<ActionEventArgs>[] actions) => actions.ForEach(a => _actions.Remove(a));

		private void Handler(KeyMap keyMap)
		{
			if (!_running) return;
			var process = ProcessUtils.GetForegroundProcess();
			var windowTitle = ProcessUtils.ForegroundWindowTitle();
			foreach (var action in _actions.AsParallel())
			{
				if (!action.Value.KeyMap.Equals(keyMap)) continue;
				if (!FocusedWindowCheck(process, windowTitle, action.Value)) continue;
				try
				{
					action.Key.Invoke(new ActionEventArgs
					{
						ProcessId = process.Id,
						ProcessName = process.ProcessName,
						WindowTitle = windowTitle,
						Modifiers = keyMap.Modifiers,
						Key = keyMap.KeyCode
					});
				}
				catch
				{
					// suppress? log?
				}
			}
		}

		private static bool FocusedWindowCheck(Process process, string windowTitle, ActionRegister actionRegister)
		{
			return actionRegister.Identifier switch
			{
				ProcessIdentifier.Id => int.TryParse(actionRegister.ProcessValue, out var id) && id == process.Id,
				ProcessIdentifier.Name => actionRegister.ProcessValue.Equals(process.ProcessName, StringComparison.InvariantCultureIgnoreCase),
				ProcessIdentifier.WindowTitle => windowTitle.Contains(actionRegister.ProcessValue, StringComparison.InvariantCultureIgnoreCase),
				_ => true
			};
		}
	}
}
