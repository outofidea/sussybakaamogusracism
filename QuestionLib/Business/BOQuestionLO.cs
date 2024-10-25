using System;
using System.Collections;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000025 RID: 37
	public class BOQuestionLO : BOBase
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000434B File Offset: 0x0000334B
		public BOQuestionLO(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00006DE0 File Offset: 0x00005DE0
		public IList LoadLO(QuestionType qType, int qid)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from QuestionLO qlo Where qlo.QType=:qType and qlo.QID=:qid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("qType", qType);
				query.SetParameter("qid", qid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			ArrayList arrayList = new ArrayList();
			BOLO bolo = new BOLO(NHHelper.GetSessionFactory());
			foreach (object obj in list)
			{
				QuestionLO questionLO = (QuestionLO)obj;
				LO value = bolo.Load(questionLO.LOID);
				arrayList.Add(value);
			}
			return arrayList;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00006EF0 File Offset: 0x00005EF0
		public void DeleteQuestionLO(int qid, QuestionType qType)
		{
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = string.Concat(new object[]
				{
					"from QuestionLO qlo Where qlo.QType=",
					(int)qType,
					" and qlo.QID=",
					qid
				});
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
