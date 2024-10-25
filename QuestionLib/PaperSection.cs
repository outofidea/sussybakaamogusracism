using System;
using System.Collections.Generic;

namespace QuestionLib
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class PaperSection
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000025CD File Offset: 0x000015CD
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000025D5 File Offset: 0x000015D5
		public int SectionNo { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000025DE File Offset: 0x000015DE
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000025E6 File Offset: 0x000015E6
		public int QFrom { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000025EF File Offset: 0x000015EF
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000025F7 File Offset: 0x000015F7
		public int QTo { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002600 File Offset: 0x00001600
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002608 File Offset: 0x00001608
		public string InAnyOrderGroup { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002611 File Offset: 0x00001611
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002619 File Offset: 0x00001619
		public List<ImagePaperAnswer> Answers { get; set; }

		// Token: 0x06000056 RID: 86 RVA: 0x00002624 File Offset: 0x00001624
		public int GetAnswerCount()
		{
			return this.QTo - this.QFrom + 1;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002645 File Offset: 0x00001645
		public PaperSection()
		{
			this.Answers = new List<ImagePaperAnswer>();
		}
	}
}
