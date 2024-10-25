using System;
using System.Collections;
using NHibernate;

namespace QuestionLib.Business
{
	// Token: 0x02000024 RID: 36
	public class BOQuestionAnswer : BOBase
	{
		// Token: 0x06000194 RID: 404 RVA: 0x0000434B File Offset: 0x0000334B
		public BOQuestionAnswer(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006D5C File Offset: 0x00005D5C
		public IList LoadAnswer(int qid)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from QuestionAnswer qa Where qa.QID=:qid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("qid", qid);
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
