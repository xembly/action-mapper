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
		private readonly Dictionary<Guid, ActionRegister> _actions = new();
		private bool _running = false;

		public KeyActionMapper() => _keyboardListener = new(Handler);

		public void Dispose() => _keyboardListener?.Dispose();

		public void Start() => _running = true;

		public void Stop() => _running = false;

		public bool IsRunning => _running;

		public Guid[] Add(params ActionRegister[] actions) =>
			actions.Select(a => { var id = Guid.NewGuid(); _actions.Add(id, a); return id; }).ToArray();

		public void Remove(params Guid[] actionIds) => actionIds.ForEach(id => _actions.Remove(id));

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
					action.Value.Action.Invoke(new ActionEventArgs
					{
						ActionId = action.Key,
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
