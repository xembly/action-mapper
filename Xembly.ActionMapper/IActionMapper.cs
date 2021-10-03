using System;

namespace Xembly.ActionMapper
{
	public interface IActionMapper
	{
		void Start();
		void Stop();
		void Add(params ActionRegister[] actions);
		void Remove(params Action<ActionEventArgs>[] actions);
	}

	// https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c
	public interface IKeyActionMapper : IActionMapper
	{ }

	// https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-mouse-hook-in-c
	public interface IMouseActionMapper : IActionMapper
	{ }
}
