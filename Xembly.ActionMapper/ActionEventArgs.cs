namespace Xembly.ActionMapper
{
	public sealed class ActionEventArgs
	{
		public int ProcessId { get; internal set; }
		public string ProcessName { get; internal set; }
		public string WindowTitle { get; internal set; }
		public KeyModifiers Modifiers { get; internal set; }
		public int Key { get; internal set; }

		public override string ToString()
		{
			return $"{WindowTitle} - {ProcessName}[{ProcessId}]";
		}
	}
}
