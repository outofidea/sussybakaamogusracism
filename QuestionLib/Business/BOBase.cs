using System;
using System.Collections;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x0200001C RID: 28
	public class BOBase
	{
		// Token: 0x0600015D RID: 349 RVA: 0x000036DA File Offset: 0x000026DA
		public BOBase()
		{
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004D2E File Offset: 0x00003D2E
		public BOBase(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004D40 File Offset: 0x00003D40
		public object SaveOrUpdate(object obj)
		{
			this.session = this.sessionFactory.OpenSession();
			using (ITransaction transaction = this.session.BeginTransaction())
			{
				try
				{
					this.session.SaveOrUpdate(obj);
					this.session.Flush();
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
			return obj;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004DDC File Offset: 0x00003DDC
		public object Save(object obj)
		{
			this.session = this.sessionFactory.OpenSession();
			using (ITransaction transaction = this.session.BeginTransaction())
			{
				try
				{
					this.session.Save(obj);
					this.session.Flush();
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
			return obj;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004E78 File Offset: 0x00003E78
		public object Save(object obj, ISession mySession)
		{
			try
			{
				mySession.Save(obj);
				mySession.Flush();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return obj;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004EB0 File Offset: 0x00003EB0
		public object Update(object obj)
		{
			this.session = this.sessionFactory.OpenSession();
			using (ITransaction transaction = this.session.BeginTransaction())
			{
				try
				{
					this.session.Update(obj);
					this.session.Flush();
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
			return obj;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004F4C File Offset: 0x00003F4C
		public object Update(object obj, ISession mySession)
		{
			try
			{
				mySession.Update(obj);
				mySession.Flush();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return obj;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004F84 File Offset: 0x00003F84
		public void Load(object obj, object id)
		{
			this.session = this.sessionFactory.OpenSession();
			try
			{
				this.session.Load(obj, id);
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004FE4 File Offset: 0x00003FE4
		public void Delete(object obj)
		{
			this.session = this.sessionFactory.OpenSession();
			using (ITransaction transaction = this.session.BeginTransaction())
			{
				try
				{
					this.session.Delete(obj);
					this.session.Flush();
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

		// Token: 0x06000166 RID: 358 RVA: 0x00005084 File Offset: 0x00004084
		public IList List(string typeName)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			using (ITransaction transaction = this.session.BeginTransaction())
			{
				IQuery query = this.session.CreateQuery("from " + typeName);
				result = query.List();
				transaction.Commit();
				this.session.Close();
			}
			return result;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005108 File Offset: 0x00004108
		public IList ListID(string typeName, QuestionType qt, int chapterID)
		{
			IList result = null;
			bool flag = qt == QuestionType.READING;
			string text;
			string text2;
			if (flag)
			{
				text = "pid";
				text2 = "=0";
			}
			else
			{
				bool flag2 = qt == QuestionType.MULTIPLE_CHOICE;
				if (flag2)
				{
					text = "qid";
					text2 = "=1";
				}
				else
				{
					bool flag3 = qt == QuestionType.INDICATE_MISTAKE;
					if (flag3)
					{
						text = "qid";
						text2 = "=2";
					}
					else
					{
						bool flag4 = qt == QuestionType.MATCH;
						if (flag4)
						{
							text = "mid";
							text2 = "=3";
						}
						else
						{
							text = "qid";
							text2 = ">3";
						}
					}
				}
			}
			string text3 = string.Concat(new object[]
			{
				"SELECT ",
				text,
				" FROM ",
				typeName,
				" WHERE chapterId=",
				chapterID,
				" AND qType=",
				text2
			});
			SqlConnection sqlConnection = (SqlConnection)this.sessionFactory.ConnectionProvider.GetConnection();
			return result;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000051FC File Offset: 0x000041FC
		public IList ListID(string typeName, QuestionType qt, string courseID)
		{
			return null;
		}

		// Token: 0x040000A9 RID: 169
		protected ISessionFactory sessionFactory;

		// Token: 0x040000AA RID: 170
		protected ISession session;
	}
}
