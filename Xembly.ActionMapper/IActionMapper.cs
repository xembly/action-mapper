using System;

namespace Xembly.ActionMapper
{
	public interface IActionMapper
	{
		void Start();
		void Stop();
		Guid[] Add(params ActionRegister[] actions);
		void Remove(params Guid[] actionIds);
	}

	// https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-keyboard-hook-in-c
	public interface IKeyActionMapper : IActionMapper
	{ }

	// https://docs.microsoft.com/en-us/archive/blogs/toub/low-level-mouse-hook-in-c
	public interface IMouseActionMapper : IActionMapper
	{ }
}
