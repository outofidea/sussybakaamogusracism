using System;
using System.Collections;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x0200001F RID: 31
	public class BOEssayQuestion : BOBase
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000434B File Offset: 0x0000334B
		public BOEssayQuestion(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005594 File Offset: 0x00004594
		public EssayQuestion Load(int eqid)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from EssayQuestion q Where q.EQID=:eqid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("eqid", eqid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((EssayQuestion)list[0]) : null;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00005634 File Offset: 0x00004634
		public IList LoadByCourse(string courseId)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from EssayQuestion q Where CourseId=:courseId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("courseId", courseId);
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

		// Token: 0x06000174 RID: 372 RVA: 0x000056B8 File Offset: 0x000046B8
		public IList LoadByChapter(int chapterId)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from EssayQuestion q Where ChapterId=:chapterId";
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

		// Token: 0x06000175 RID: 373 RVA: 0x00005740 File Offset: 0x00004740
		public void Delete(int eqid)
		{
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = "from EssayQuestion q Where q.EQID=" + eqid.ToString();
				this.session.Delete(query);
				transaction.Commit();
				this.session.Close();
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				this.session.Close();
				throw ex;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000057C8 File Offset: 0x000047C8
		public bool SaveList(IList list)
		{
			ISession session = this.sessionFactory.OpenSession();
			ITransaction transaction = session.BeginTransaction();
			bool result;
			try
			{
				foreach (object obj in list)
				{
					EssayQuestion obj2 = (EssayQuestion)obj;
					session.Save(obj2);
				}
				transaction.Commit();
				result = true;
			}
			catch
			{
				transaction.Rollback();
				result = false;
			}
			return result;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00005864 File Offset: 0x00004864
		public void DeleteQuestionInChapter(int chapterId)
		{
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = "from EssayQuestion q Where q.ChapterId=" + chapterId.ToString();
				this.session.Delete(query);
				transaction.Commit();
				this.session.Close();
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				this.session.Close();
				throw ex;
			}
		}
	}
}
