using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000017 RID: 23
	public class QuestionLO
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00004108 File Offset: 0x00003108
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00004120 File Offset: 0x00003120
		public int QuestionLOID
		{
			get
			{
				return this._QuestionLOID;
			}
			set
			{
				this._QuestionLOID = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000412C File Offset: 0x0000312C
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00004144 File Offset: 0x00003144
		public QuestionType QType
		{
			get
			{
				return this._QType;
			}
			set
			{
				this._QType = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00004150 File Offset: 0x00003150
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00004168 File Offset: 0x00003168
		public int QID
		{
			get
			{
				return this._QID;
			}
			set
			{
				this._QID = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00004174 File Offset: 0x00003174
		// (set) Token: 0x06000124 RID: 292 RVA: 0x0000418C File Offset: 0x0000318C
		public int LOID
		{
			get
			{
				return this._LOID;
			}
			set
			{
				this._LOID = value;
			}
		}

		// Token: 0x04000092 RID: 146
		private int _QuestionLOID;

		// Token: 0x04000093 RID: 147
		private QuestionType _QType;

		// Token: 0x04000094 RID: 148
		private int _QID;

		// Token: 0x04000095 RID: 149
		private int _LOID;
	}
}
