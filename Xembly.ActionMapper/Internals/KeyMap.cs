using System;

namespace Xembly.ActionMapper.Internals
{
	internal sealed class KeyMap : IEquatable<KeyMap>
	{
		/// <summary>
		///  Initializes a new instance of the <see cref='KeyMap'/> class.
		/// </summary>
		public KeyMap(KeyModifiers modifiers, int keyCode)
		{
			Modifiers = modifiers;
			KeyCode = keyCode;
		}

		/// <summary>
		///  Initializes a new instance of the <see cref='KeyMap'/> class.
		/// </summary>
		public KeyMap(KeyModifiers modifiers, int keyCode, bool onKeyDown)
		{
			Modifiers = modifiers;
			KeyCode = keyCode;
			OnKeyDown = onKeyDown;
			OnKeyUp = !onKeyDown;
		}

		/// <summary>
		///  Gets the modifier flags for a KeyDown or KeyUp event.
		///  This indicates which modifier keys (CTRL, SHIFT, and/or ALT) were pressed.
		/// </summary>
		public KeyModifiers Modifiers { get; }

		/// <summary>
		///  Gets the keyboard code for a KeyDown or KeyUp event.
		/// </summary>
		public int KeyCode { get; }

		/// <summary>
		///  Gets a value indicating if active ran/runs on key down. Default: false
		/// </summary>
		public bool OnKeyDown { get; private set; } = false;

		/// <summary>
		///  Gets a value indicating if active ran/runs on key up. Default: true
		/// </summary>
		public bool OnKeyUp { get; private set; } = true;

		/// <summary>
		///  Gets a value indicating whether the SHIFT key was pressed.
		/// </summary>
		public bool Shift => (Modifiers & KeyModifiers.Shift) == KeyModifiers.Shift;

		/// <summary>
		///  Gets a value indicating whether the CONTROL key was pressed.
		/// </summary>
		public bool Control => (Modifiers & KeyModifiers.Control) == KeyModifiers.Control;

		/// <summary>
		///  Gets a value indicating whether the ALT key was pressed.
		/// </summary>
		public bool Alt => (Modifiers & KeyModifiers.Alt) == KeyModifiers.Alt;

		internal KeyMap OnKeyUpEvent()
		{
			OnKeyDown = false;
			OnKeyUp = true;
			return this;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as KeyMap);
		}

		public bool Equals(KeyMap obj)
		{
			var keyMap = obj;
			return KeyCode == keyMap.KeyCode
				&& OnKeyDown == keyMap.OnKeyDown
				&& OnKeyUp == keyMap.OnKeyUp
				&& Shift == keyMap.Shift
				&& Control == keyMap.Control
				&& Alt == keyMap.Alt;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(KeyCode, OnKeyDown, OnKeyUp, Shift, Control, Alt);
		}
	}
}
