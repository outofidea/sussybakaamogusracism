using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GetProcesses
{
	// Token: 0x02000017 RID: 23
	public class User32Helper
	{
		// Token: 0x060000D4 RID: 212
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x060000D5 RID: 213
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

		// Token: 0x060000D6 RID: 214
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool EnumDesktopWindows(IntPtr hDesktop, User32Helper.EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

		// Token: 0x060000D7 RID: 215 RVA: 0x000048E4 File Offset: 0x000038E4
		public static List<DesktopWindow> GetDesktopWindows()
		{
			List<DesktopWindow> collection = new List<DesktopWindow>();
			User32Helper.EnumDelegate lpEnumCallbackFunction = delegate(IntPtr hWnd, int lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(255);
				User32Helper.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity + 1);
				string title = stringBuilder.ToString();
				bool isVisible = User32Helper.IsWindowVisible(hWnd);
				collection.Add(new DesktopWindow
				{
					Handle = hWnd,
					Title = title,
					IsVisible = isVisible
				});
				return true;
			};
			User32Helper.EnumDesktopWindows(IntPtr.Zero, lpEnumCallbackFunction, IntPtr.Zero);
			return collection;
		}

		// Token: 0x0200002D RID: 45
		// (Invoke) Token: 0x060001C4 RID: 452
		public delegate bool EnumDelegate(IntPtr hWnd, int lParam);
	}
}
