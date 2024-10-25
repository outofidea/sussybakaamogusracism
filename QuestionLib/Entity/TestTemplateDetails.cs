using System;

namespace QuestionLib.Entity
{
	// Token: 0x0200001A RID: 26
	public class TestTemplateDetails
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000144 RID: 324 RVA: 0x000042F6 File Offset: 0x000032F6
		// (set) Token: 0x06000145 RID: 325 RVA: 0x000042FE File Offset: 0x000032FE
		public int TestTemplateDetailsID { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00004307 File Offset: 0x00003307
		// (set) Token: 0x06000147 RID: 327 RVA: 0x0000430F File Offset: 0x0000330F
		public int TestTemplateID { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00004318 File Offset: 0x00003318
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00004320 File Offset: 0x00003320
		public int ChapterId { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00004329 File Offset: 0x00003329
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00004331 File Offset: 0x00003331
		public QuestionType QuestionType { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600014C RID: 332 RVA: 0x0000433A File Offset: 0x0000333A
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00004342 File Offset: 0x00003342
		public int NoQInTest { get; set; }
	}
}
