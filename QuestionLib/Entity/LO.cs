using System;

namespace QuestionLib.Entity
{
	// Token: 0x02000011 RID: 17
	public class LO
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000038C8 File Offset: 0x000028C8
		// (set) Token: 0x060000BD RID: 189 RVA: 0x000038E0 File Offset: 0x000028E0
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

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000038EC File Offset: 0x000028EC
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003904 File Offset: 0x00002904
		public string CID
		{
			get
			{
				return this._CID;
			}
			set
			{
				this._CID = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003910 File Offset: 0x00002910
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003928 File Offset: 0x00002928
		public string LO_Name
		{
			get
			{
				return this._LO_Name;
			}
			set
			{
				this._LO_Name = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003934 File Offset: 0x00002934
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x0000394C File Offset: 0x0000294C
		public string LO_Desc
		{
			get
			{
				return this._LO_Desc;
			}
			set
			{
				this._LO_Desc = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003958 File Offset: 0x00002958
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00003970 File Offset: 0x00002970
		public string Dec_No
		{
			get
			{
				return this._Dec_No;
			}
			set
			{
				this._Dec_No = value;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000397C File Offset: 0x0000297C
		public override string ToString()
		{
			return this.LO_Name + " - " + this.LO_Desc;
		}

		// Token: 0x04000061 RID: 97
		private int _LOID;

		// Token: 0x04000062 RID: 98
		private string _CID;

		// Token: 0x04000063 RID: 99
		private string _LO_Name;

		// Token: 0x04000064 RID: 100
		private string _LO_Desc;

		// Token: 0x04000065 RID: 101
		private string _Dec_No;
	}
}
