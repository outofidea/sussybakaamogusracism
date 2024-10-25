using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000019 RID: 25
	public class TestTemplate
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000133 RID: 307 RVA: 0x0000426E File Offset: 0x0000326E
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00004276 File Offset: 0x00003276
		public int TestTemplateID { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000135 RID: 309 RVA: 0x0000427F File Offset: 0x0000327F
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00004287 File Offset: 0x00003287
		public string CID { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004290 File Offset: 0x00003290
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004298 File Offset: 0x00003298
		public string TestTemplateName { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000042A1 File Offset: 0x000032A1
		// (set) Token: 0x0600013A RID: 314 RVA: 0x000042A9 File Offset: 0x000032A9
		public string CreatedBy { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600013B RID: 315 RVA: 0x000042B2 File Offset: 0x000032B2
		// (set) Token: 0x0600013C RID: 316 RVA: 0x000042BA File Offset: 0x000032BA
		public DateTime CreatedDate { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600013D RID: 317 RVA: 0x000042C3 File Offset: 0x000032C3
		// (set) Token: 0x0600013E RID: 318 RVA: 0x000042CB File Offset: 0x000032CB
		public int DistinctWithLastTest { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600013F RID: 319 RVA: 0x000042D4 File Offset: 0x000032D4
		// (set) Token: 0x06000140 RID: 320 RVA: 0x000042DC File Offset: 0x000032DC
		public int Duration { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000042E5 File Offset: 0x000032E5
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000042ED File Offset: 0x000032ED
		public string Note { get; set; }
	}
}
