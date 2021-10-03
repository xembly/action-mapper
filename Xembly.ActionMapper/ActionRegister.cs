using System;
using Xembly.ActionMapper.Internals;

namespace Xembly.ActionMapper
{
	/// <summary>
	///  Helper class for registering actions.
	/// </summary>
	public sealed class ActionRegister
	{
		internal ProcessIdentifier Identifier { get; init; }
		internal string ProcessValue { get; init; }
		internal KeyMap KeyMap { get; init; }
		internal Action<ActionEventArgs> Action { get; init; }

		private static IKeyActionMapper _keyActionMapper;

		public static IKeyActionMapper KeyActionMapper()
		{
			if (_keyActionMapper == null) _keyActionMapper = new KeyActionMapper();
			return _keyActionMapper;
		}

		/// <summary>
		///  Action that will fire no matter the focused window.
		/// </summary>
		/// <param name="modifiers"></param>
		/// <param name="keyCode"></param>
		/// <param name="action"></param>
		/// <param name="onKeyDown"></param>
		/// <returns></returns>
		public static ActionRegister All(KeyModifiers modifiers, int keyCode, Action<ActionEventArgs> action, bool onKeyDown = false) => new()
		{
			Identifier = ProcessIdentifier.None,
			KeyMap = new KeyMap(modifiers, keyCode, onKeyDown),
			Action = action
		};

		/// <summary>
		///  Actiont that will fire when the current process is the focused window.
		/// </summary>
		/// <param name="modifiers"></param>
		/// <param name="keyCode"></param>
		/// <param name="action"></param>
		/// <param name="onKeyDown"></param>
		/// <returns></returns>
		public static ActionRegister Self(KeyModifiers modifiers, int keyCode, Action<ActionEventArgs> action, bool onKeyDown = false) => new()
		{
			Identifier = ProcessIdentifier.Id,
			ProcessValue = Environment.ProcessId.ToString(),
			KeyMap = new KeyMap(modifiers, keyCode, onKeyDown),
			Action = action
		};

		/// <summary>
		///  Action that will fire when the process with the given ID is the focused window.
		/// </summary>
		/// <param name="processId"></param>
		/// <param name="keyMap"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static ActionRegister ById(int processId, KeyModifiers modifiers, int keyCode, Action<ActionEventArgs> action, bool onKeyDown = false) => new()
		{
			Identifier = ProcessIdentifier.Id,
			ProcessValue = processId.ToString(),
			KeyMap = new KeyMap(modifiers, keyCode, onKeyDown),
			Action = action
		};

		/// <summary>
		///  Action that will fire when the process with the given process name is the focused window.
		///  This is the name WITHOUT the extension!
		/// </summary>
		/// <param name="processName"></param>
		/// <param name="keyMap"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static ActionRegister ByName(string processName, KeyModifiers modifiers, int keyCode, Action<ActionEventArgs> action, bool onKeyDown = false) => new()
		{
			Identifier = ProcessIdentifier.Name,
			ProcessValue = processName,
			KeyMap = new KeyMap(modifiers, keyCode, onKeyDown),
			Action = action
		};

		/// <summary>
		///  Action that will fire when the process with the given process window name contains the name of the focused window.
		/// </summary>
		/// <param name="processWindowTitle"></param>
		/// <param name="keyMap"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static ActionRegister ByWindowName(string processWindowTitle, KeyModifiers modifiers, int keyCode, Action<ActionEventArgs> action, bool onKeyDown = false) => new()
		{
			Identifier = ProcessIdentifier.Name,
			ProcessValue = processWindowTitle,
			KeyMap = new KeyMap(modifiers, keyCode, onKeyDown),
			Action = action
		};
	}
}
