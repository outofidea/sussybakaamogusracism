using System;
using System.Collections.Generic;

namespace QuestionLib
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class ImagePaper
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000265B File Offset: 0x0000165B
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002663 File Offset: 0x00001663
		public List<PaperSection> Sections { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000266C File Offset: 0x0000166C
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002674 File Offset: 0x00001674
		public byte[] Image { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000267D File Offset: 0x0000167D
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002685 File Offset: 0x00001685
		public int NumberOfPage { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000268E File Offset: 0x0000168E
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002696 File Offset: 0x00001696
		public string LongAnswerGuide { get; set; }

		// Token: 0x06000060 RID: 96 RVA: 0x0000269F File Offset: 0x0000169F
		public void Preapare2Submit()
		{
			this.Image = null;
		}
	}
}
