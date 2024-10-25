using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ScreenShot
{
	// Token: 0x0200001F RID: 31
	public class ScreenCapture
	{
		// Token: 0x06000197 RID: 407 RVA: 0x000135D4 File Offset: 0x000125D4
		public Image CaptureScreen()
		{
			return this.CaptureWindow(ScreenCapture.User32.GetDesktopWindow());
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000135F4 File Offset: 0x000125F4
		public Image CaptureWindow(IntPtr handle)
		{
			IntPtr windowDC = ScreenCapture.User32.GetWindowDC(handle);
			ScreenCapture.User32.RECT rect = default(ScreenCapture.User32.RECT);
			ScreenCapture.User32.GetWindowRect(handle, ref rect);
			int nWidth = rect.right - rect.left;
			int nHeight = rect.bottom - rect.top;
			IntPtr intPtr = ScreenCapture.GDI32.CreateCompatibleDC(windowDC);
			IntPtr intPtr2 = ScreenCapture.GDI32.CreateCompatibleBitmap(windowDC, nWidth, nHeight);
			IntPtr hObject = ScreenCapture.GDI32.SelectObject(intPtr, intPtr2);
			ScreenCapture.GDI32.BitBlt(intPtr, 0, 0, nWidth, nHeight, windowDC, 0, 0, 13369376);
			ScreenCapture.GDI32.SelectObject(intPtr, hObject);
			ScreenCapture.GDI32.DeleteDC(intPtr);
			ScreenCapture.User32.ReleaseDC(handle, windowDC);
			Image result = Image.FromHbitmap(intPtr2);
			ScreenCapture.GDI32.DeleteObject(intPtr2);
			return result;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0001369C File Offset: 0x0001269C
		public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
		{
			Image image = this.CaptureWindow(handle);
			image.Save(filename, format);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000136BC File Offset: 0x000126BC
		public void CaptureScreenToFile(string filename, ImageFormat format)
		{
			Image image = this.CaptureScreen();
			image.Save(filename, format);
		}

		// Token: 0x02000032 RID: 50
		private class GDI32
		{
			// Token: 0x060001CD RID: 461
			[DllImport("gdi32.dll")]
			public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

			// Token: 0x060001CE RID: 462
			[DllImport("gdi32.dll")]
			public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

			// Token: 0x060001CF RID: 463
			[DllImport("gdi32.dll")]
			public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

			// Token: 0x060001D0 RID: 464
			[DllImport("gdi32.dll")]
			public static extern bool DeleteDC(IntPtr hDC);

			// Token: 0x060001D1 RID: 465
			[DllImport("gdi32.dll")]
			public static extern bool DeleteObject(IntPtr hObject);

			// Token: 0x060001D2 RID: 466
			[DllImport("gdi32.dll")]
			public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

			// Token: 0x040001BC RID: 444
			public const int SRCCOPY = 13369376;
		}

		// Token: 0x02000033 RID: 51
		private class User32
		{
			// Token: 0x060001D4 RID: 468
			[DllImport("user32.dll")]
			public static extern IntPtr GetDesktopWindow();

			// Token: 0x060001D5 RID: 469
			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowDC(IntPtr hWnd);

			// Token: 0x060001D6 RID: 470
			[DllImport("user32.dll")]
			public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

			// Token: 0x060001D7 RID: 471
			[DllImport("user32.dll")]
			public static extern IntPtr GetWindowRect(IntPtr hWnd, ref ScreenCapture.User32.RECT rect);

			// Token: 0x02000035 RID: 53
			public struct RECT
			{
				// Token: 0x040001BD RID: 445
				public int left;

				// Token: 0x040001BE RID: 446
				public int top;

				// Token: 0x040001BF RID: 447
				public int right;

				// Token: 0x040001C0 RID: 448
				public int bottom;
			}
		}
	}
}
