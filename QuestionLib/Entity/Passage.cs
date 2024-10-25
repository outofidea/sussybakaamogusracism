using System;
using System.Collections;
using NHibernate;
using QuestionLib.Business;

namespace QuestionLib.Entity
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class Passage
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003B60 File Offset: 0x00002B60
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003B78 File Offset: 0x00002B78
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

		// Token: 0x060000E1 RID: 225 RVA: 0x00003B82 File Offset: 0x00002B82
		public Passage()
		{
			this._passageQuestions = new ArrayList();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00003B98 File Offset: 0x00002B98
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00003BB0 File Offset: 0x00002BB0
		public int PID
		{
			get
			{
				return this._pid;
			}
			set
			{
				this._pid = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00003BBC File Offset: 0x00002BBC
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00003BD4 File Offset: 0x00002BD4
		public string CourseId
		{
			get
			{
				return this._courseId;
			}
			set
			{
				this._courseId = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00003BE0 File Offset: 0x00002BE0
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00003BF8 File Offset: 0x00002BF8
		public int ChapterId
		{
			get
			{
				return this._chapterId;
			}
			set
			{
				this._chapterId = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00003C04 File Offset: 0x00002C04
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00003C1C File Offset: 0x00002C1C
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003C28 File Offset: 0x00002C28
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00003C40 File Offset: 0x00002C40
		public ArrayList PassageQuestions
		{
			get
			{
				return this._passageQuestions;
			}
			set
			{
				this._passageQuestions = value;
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003C4C File Offset: 0x00002C4C
		public override string ToString()
		{
			return this._pid.ToString();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003C6C File Offset: 0x00002C6C
		public void LoadQuestions(ISessionFactory sessionFactory)
		{
			BOQuestion boquestion = new BOQuestion(sessionFactory);
			this._passageQuestions = (ArrayList)boquestion.LoadPassageQuestion(this._pid);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003C98 File Offset: 0x00002C98
		public void Preapare2Submit()
		{
			this.Text = null;
			this.CourseId = null;
			foreach (object obj in this.PassageQuestions)
			{
				Question question = (Question)obj;
				question.Preapare2Submit();
			}
		}

		// Token: 0x04000070 RID: 112
		private int _pid;

		// Token: 0x04000071 RID: 113
		private string _courseId;

		// Token: 0x04000072 RID: 114
		private int _chapterId;

		// Token: 0x04000073 RID: 115
		private string _text;

		// Token: 0x04000074 RID: 116
		private ArrayList _passageQuestions;

		// Token: 0x04000075 RID: 117
		private int _QBID;
	}
}
