using System;
using System.Collections;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000020 RID: 32
	public class BOLO : BOBase
	{
		// Token: 0x06000178 RID: 376 RVA: 0x0000434B File Offset: 0x0000334B
		public BOLO(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000058EC File Offset: 0x000048EC
		public LO Load(int loid)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from LO lo Where lo.LOID=:loid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("loid", loid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((LO)list[0]) : null;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000598C File Offset: 0x0000498C
		public int GetLOID(string lo_name, string CID)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from LO lo Where lo.LO_Name=:lo_name And lo.CID=:CID";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("lo_name", lo_name.Trim());
				query.SetParameter("CID", CID);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			LO lo = (LO)list[0];
			return lo.LOID;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005A3C File Offset: 0x00004A3C
		public IList LoadLOByCourse(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from LO lo Where lo.CID=:courseId";
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

		// Token: 0x0600017C RID: 380 RVA: 0x00005ABC File Offset: 0x00004ABC
		public bool IsLOExists(string CID, string lo_name)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from LO lo Where lo.CID=:CID And lo.LO_Name=:lo_name";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("lo_name", lo_name);
				query.SetParameter("CID", CID);
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

		// Token: 0x0600017D RID: 381 RVA: 0x00005B5C File Offset: 0x00004B5C
		public bool IsLODescriptionExists(string CID, string lo_desc)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from LO lo Where lo.CID=:CID And lo.LO_Desc=:lo_desc";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("lo_desc", lo_desc);
				query.SetParameter("CID", CID);
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

		// Token: 0x0600017E RID: 382 RVA: 0x00005BFC File Offset: 0x00004BFC
		public static ArrayList RemoveDupLO(ArrayList listLO)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in listLO)
			{
				QuestionLO questionLO = (QuestionLO)obj;
				bool flag = false;
				foreach (object obj2 in arrayList)
				{
					QuestionLO questionLO2 = (QuestionLO)obj2;
					bool flag2 = questionLO.LOID == questionLO2.LOID;
					if (flag2)
					{
						flag = true;
						break;
					}
				}
				bool flag3 = !flag;
				if (flag3)
				{
					arrayList.Add(questionLO);
				}
			}
			return arrayList;
		}
	}
}
