using System;
using System.Collections;
using NHibernate;

namespace QuestionLib.Business
{
	// Token: 0x0200001E RID: 30
	public class BOCourse : BOBase
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000434B File Offset: 0x0000334B
		public BOCourse(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00005480 File Offset: 0x00004480
		public IList LoadChapterByCourse(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Chapter ch Where CID=:courseId";
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

		// Token: 0x06000170 RID: 368 RVA: 0x00005500 File Offset: 0x00004500
		public bool IsCourseExists(string courseId)
		{
			bool result = false;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Course c Where CID=:courseId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("courseId", courseId);
				IList list = query.List();
				this.session.Close();
				bool flag = list.Count > 0;
				if (flag)
				{
					result = true;
				}
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
