using System;
using System.Collections;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000026 RID: 38
	public class BOTest : BOBase
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0000434B File Offset: 0x0000334B
		public BOTest(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00006F98 File Offset: 0x00005F98
		public IList LoadTest(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Test t Where CourseId=:courseId";
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

		// Token: 0x0600019B RID: 411 RVA: 0x00007018 File Offset: 0x00006018
		public Test LoadTestByTestId(string testId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from Test t Where TestId=:testId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("testId", testId);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			bool flag = list.Count > 0;
			Test result;
			if (flag)
			{
				result = (Test)list[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000070B8 File Offset: 0x000060B8
		public IList LoadTestByCourse(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Test t Where CourseId=:courseId";
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

		// Token: 0x0600019D RID: 413 RVA: 0x00007138 File Offset: 0x00006138
		public bool IsTestExists(string testId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from Test t Where TestId=:testId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("testId", testId);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			bool flag = list.Count == 0;
			return !flag;
		}
	}
}
