using System;

namespace QuestionLib.Entity
{
	// Token: 0x0200000F RID: 15
	public class Course
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x000036DA File Offset: 0x000026DA
		public Course()
		{
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003788 File Offset: 0x00002788
		public Course(string _cid, string _name)
		{
			this._cid = _cid;
			this._name = _name;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000037A0 File Offset: 0x000027A0
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x000037B8 File Offset: 0x000027B8
		public string CID
		{
			get
			{
				return this._cid;
			}
			set
			{
				this._cid = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000037C4 File Offset: 0x000027C4
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000037DC File Offset: 0x000027DC
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x04000055 RID: 85
		private string _cid;

		// Token: 0x04000056 RID: 86
		private string _name;
	}
}
