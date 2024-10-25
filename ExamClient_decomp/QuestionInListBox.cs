using System;
using QuestionLib.Entity;

namespace ExamClient
{
	// Token: 0x0200001B RID: 27
	public class QuestionInListBox
	{
		// Token: 0x06000178 RID: 376 RVA: 0x00012D43 File Offset: 0x00011D43
		public QuestionInListBox(Question question, int number)
		{
			this._question = question;
			this._number = number;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00012D5C File Offset: 0x00011D5C
		public override string ToString()
		{
			return this._number.ToString();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00012D7C File Offset: 0x00011D7C
		public Question GetQuestion()
		{
			return this._question;
		}

		// Token: 0x04000174 RID: 372
		private int _number;

		// Token: 0x04000175 RID: 373
		private Question _question;
	}
}
