using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	public class EssayQuestion
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000037E6 File Offset: 0x000027E6
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000037EE File Offset: 0x000027EE
		public int EQID { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000037F7 File Offset: 0x000027F7
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000037FF File Offset: 0x000027FF
		public string CourseId { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003808 File Offset: 0x00002808
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00003810 File Offset: 0x00002810
		public int ChapterId { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003819 File Offset: 0x00002819
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003821 File Offset: 0x00002821
		public byte[] Question { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000382A File Offset: 0x0000282A
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003832 File Offset: 0x00002832
		public int QuestionFileSize { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000383B File Offset: 0x0000283B
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003843 File Offset: 0x00002843
		public string Name { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000384C File Offset: 0x0000284C
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00003854 File Offset: 0x00002854
		public byte[] Guide2Mark { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000385D File Offset: 0x0000285D
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00003865 File Offset: 0x00002865
		public int Guide2MarkFileSize { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000386E File Offset: 0x0000286E
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00003876 File Offset: 0x00002876
		public string Development { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003880 File Offset: 0x00002880
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00003898 File Offset: 0x00002898
		public int QBID
		{
			get
			{
				return this._QBID;
			}
			set
			{
				this._QBID = value;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000038A2 File Offset: 0x000028A2
		public void Preapare2Submit()
		{
			this.CourseId = null;
			this.Question = null;
			this.Name = null;
			this.Guide2Mark = null;
		}

		// Token: 0x04000060 RID: 96
		private int _QBID;
	}
}
