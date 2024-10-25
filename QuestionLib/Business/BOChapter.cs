using System;
using System.Collections;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x0200001D RID: 29
	public class BOChapter : BOBase
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000434B File Offset: 0x0000334B
		public BOChapter(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00005214 File Offset: 0x00004214
		public IList LoadFillBlankQuestionByChapter(int chapterId)
		{
			QuestionType questionType = QuestionType.FILL_BLANK_ALL;
			QuestionType questionType2 = QuestionType.FILL_BLANK_GROUP;
			QuestionType questionType3 = QuestionType.FILL_BLANK_EMPTY;
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Question q Where (q.QType=:type1 OR q.QType=:type2 OR q.QType=:type3)  AND ChapterId=:chapterId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("type1", questionType);
				query.SetParameter("type2", questionType2);
				query.SetParameter("type3", questionType3);
				query.SetParameter("chapterId", chapterId.ToString());
				result = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000052E0 File Offset: 0x000042E0
		public IList LoadQuestionByChapter(QuestionType qt, int chapterId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Question q Where q.QType=:type and ChapterId=:chapterId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("type", qt);
				query.SetParameter("chapterId", chapterId.ToString());
				result = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00005378 File Offset: 0x00004378
		public IList LoadPassageByChapter(int chapterId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Passage p Where ChapterId=:chapterId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("chapterId", chapterId);
				result = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return result;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000053FC File Offset: 0x000043FC
		public IList LoadMatchQuestionByChapter(int chapterId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from MatchQuestion m Where ChapterId=:chapterId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("chapterId", chapterId);
				result = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return result;
		}
	}
}
