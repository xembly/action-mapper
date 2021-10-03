using System;
using System.Diagnostics;
using System.Text;

namespace Xembly.ActionMapper.Helpers
{
	internal static class ProcessUtils
	{
		public static Process GetForegroundProcess()
		{
			IntPtr hWnd = User32.GetForegroundWindow();                        // Get foreground window handle
			_ = User32.GetWindowThreadProcessId(hWnd, out var processId);      // Get PID from window handle; returns the thread ID
			return Process.GetProcessById(Convert.ToInt32(processId));  // Get it as a C# obj
		}

		public static string ForegroundWindowTitle()
		{
			var window = User32.GetForegroundWindow();
			var title = new StringBuilder(1024);

			var textLength = User32.GetWindowText(window, title, title.Capacity);
			if (textLength <= 0 || textLength > title.Length)
				return "Unknown";

			return title.ToString();
		}

		// TODO :: surface as helper function for non-english keyboard layouts???
		//public static CultureInfo GetCurrentKeyboardLayout()
		//{
		//	try
		//	{
		//		var foregroundWindow = User32.GetForegroundWindow();
		//		var foregroundWindowIntPtr = (IntPtr) foregroundWindow;
		//		uint foregroundProcess = User32.GetWindowThreadProcessId(foregroundWindowIntPtr, IntPtr.Zero);
		//		int keyboardLayout = User32.GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
		//		return new CultureInfo(keyboardLayout);
		//	}
		//	catch
		//	{
		//		return new CultureInfo(1033); // Assume English if something went wrong.
		//	}
		//}
	}
}
