using System;

namespace Xembly.ActionMapper.Helpers
{
	internal static class ArrayExtensions
	{
		public static void ForEach<T>(this T[] source, Action<T> action)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (action == null) throw new ArgumentNullException(nameof(action));
			foreach (var item in source) action(item);
		}
	}
}
