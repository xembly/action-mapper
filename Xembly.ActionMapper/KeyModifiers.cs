using System;

namespace Xembly.ActionMapper
{
	[Flags]
	public enum KeyModifiers
	{
		/// <summary>
		///  No Modifiers.
		/// </summary>
		None = 0x00,

		/// <summary>
		///  The bit mask to extract a key code from a key value.
		/// </summary>
		KeyCode = 0x0000FFFF,

		/// <summary>
		///  The bit mask to extract modifiers from a key value.
		/// </summary>
		Modifiers = unchecked((int) 0xFFFF0000),

		/// <summary>
		///  The SHIFT key.
		/// </summary>
		ShiftKey = 0x10,

		/// <summary>
		///  The left SHIFT key.
		/// </summary>
		LShiftKey = 0xA0,

		/// <summary>
		///  The right SHIFT key.
		/// </summary>
		RShiftKey = 0xA1,

		/// <summary>
		///  The CTRL key.
		/// </summary>
		ControlKey = 0x11,

		/// <summary>
		///  The left CTRL key.
		/// </summary>
		LControlKey = 0xA2,

		/// <summary>
		///  The right CTRL key.
		/// </summary>
		RControlKey = 0xA3,

		/// <summary>
		///  The ALT key.
		/// </summary>
		Menu = 0x12,

		/// <summary>
		///  The left ALT key.
		/// </summary>
		LMenu = 0xA4,

		/// <summary>
		///  The right ALT key.
		/// </summary>
		RMenu = 0xA5,

		/// <summary>
		///  The left Windows logo key (Microsoft Natural Keyboard).
		/// </summary>
		LWin = 0x5B,

		/// <summary>
		///  The right Windows logo key (Microsoft Natural Keyboard).
		/// </summary>
		RWin = 0x5C,

		/// <summary>
		///  The SHIFT modifier key.
		/// </summary>
		Shift = 0x00010000,

		/// <summary>
		///  The  CTRL modifier key.
		/// </summary>
		Control = 0x00020000,

		/// <summary>
		///  The ALT modifier key.
		/// </summary>
		Alt = 0x00040000,
	}
}
