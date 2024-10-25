using System;

namespace QuestionLib
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class ImagePaperAnswer
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000259A File Offset: 0x0000159A
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000025A2 File Offset: 0x000015A2
		public string Answer { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000025AB File Offset: 0x000015AB
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000025B3 File Offset: 0x000015B3
		public int PartCount { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000025BC File Offset: 0x000015BC
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000025C4 File Offset: 0x000015C4
		public bool IsLongAnswer { get; set; }
	}
}
