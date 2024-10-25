using System;
using System.Runtime.InteropServices;

namespace ExamClient
{
	// Token: 0x0200001C RID: 28
	public class Win32
	{
		// Token: 0x0600017B RID: 379
		[DllImport("user32.dll")]
		public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

		// Token: 0x0600017C RID: 380
		[DllImport("user32.dll")]
		public static extern int GetForegroundWindow();

		// Token: 0x0600017D RID: 381
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(int hWnd);

		// Token: 0x0600017E RID: 382
		[DllImport("user32.dll")]
		public static extern bool SetActiveWindow(int hWnd);

		// Token: 0x04000176 RID: 374
		public const int WM_SYSCOMMAND = 274;

		// Token: 0x04000177 RID: 375
		public const int SC_CLOSE = 61536;

		// Token: 0x04000178 RID: 376
		public const int SC_MINIMIZE = 61472;
	}
}
