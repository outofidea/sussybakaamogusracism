using System;
using System.Collections;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000021 RID: 33
	public class BOMatchQuestion : BOBase
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0000434B File Offset: 0x0000334B
		public BOMatchQuestion(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005CD4 File Offset: 0x00004CD4
		public MatchQuestion LoadMatch(int mid)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from MatchQuestion mq Where  mq.MID=:mid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("mid", mid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((MatchQuestion)list[0]) : null;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005D70 File Offset: 0x00004D70
		public IList LoadMatchOfCourse(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from MatchQuestion mq Where  mq.CourseId=:courseId";
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

		// Token: 0x06000182 RID: 386 RVA: 0x00005DF0 File Offset: 0x00004DF0
		public bool SaveList(IList list)
		{
			ISession session = this.sessionFactory.OpenSession();
			ITransaction transaction = session.BeginTransaction();
			bool result;
			try
			{
				foreach (object obj in list)
				{
					MatchQuestion matchQuestion = (MatchQuestion)obj;
					session.Save(matchQuestion);
					matchQuestion.QuestionLOs = BOLO.RemoveDupLO(matchQuestion.QuestionLOs);
					foreach (object obj2 in matchQuestion.QuestionLOs)
					{
						QuestionLO questionLO = (QuestionLO)obj2;
						questionLO.QID = matchQuestion.MID;
						questionLO.QType = QuestionType.MATCH;
						session.Save(questionLO);
					}
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

		// Token: 0x06000183 RID: 387 RVA: 0x00005F10 File Offset: 0x00004F10
		public bool Delete(int chapterID, string conStr)
		{
			int num = 3;
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			string cmdText = string.Concat(new object[]
			{
				"DELETE FROM QuestionLO WHERE QType = ",
				num,
				" AND qid IN (SELECT mid FROM MatchQuestion WHERE chapterID=",
				chapterID,
				")"
			});
			string cmdText2 = "DELETE FROM MatchQuestion WHERE chapterID=" + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Transaction = sqlTransaction;
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand2.Transaction = sqlTransaction;
			bool result;
			try
			{
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				sqlTransaction.Commit();
				sqlConnection.Close();
				result = true;
			}
			catch (Exception ex)
			{
				sqlTransaction.Rollback();
				sqlConnection.Close();
				throw ex;
			}
			return result;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005FEC File Offset: 0x00004FEC
		public void Delete(MatchQuestion m)
		{
			int mid = m.MID;
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = "from MatchQuestion mq Where mq.MID=" + mid.ToString();
				this.session.Delete(query);
				int num = 3;
				query = string.Concat(new object[]
				{
					"from QuestionLO qlo Where qlo.QType=",
					num,
					" and qlo.QID=",
					mid
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
