using System;

namespace GetProcesses
{
	// Token: 0x02000016 RID: 22
	public class DesktopWindow
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000CD RID: 205 RVA: 0x000048AE File Offset: 0x000038AE
		// (set) Token: 0x060000CE RID: 206 RVA: 0x000048B6 File Offset: 0x000038B6
		public IntPtr Handle { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000048BF File Offset: 0x000038BF
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000048C7 File Offset: 0x000038C7
		public string Title { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x000048D0 File Offset: 0x000038D0
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000048D8 File Offset: 0x000038D8
		public bool IsVisible { get; set; }
	}
}
