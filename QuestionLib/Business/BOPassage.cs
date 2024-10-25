using System;
using System.Collections;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000022 RID: 34
	public class BOPassage : BOBase
	{
		// Token: 0x06000185 RID: 389 RVA: 0x0000434B File Offset: 0x0000334B
		public BOPassage(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000060BC File Offset: 0x000050BC
		public Passage LoadPassage(int pid)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from Passage p Where p.PID=:pid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("pid", pid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((Passage)list[0]) : null;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006158 File Offset: 0x00005158
		public IList LoadPassageByCourse(string courseId)
		{
			this.session = this.sessionFactory.OpenSession();
			IList result;
			try
			{
				string queryString = "from Passage p Where CourseId=:courseId";
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

		// Token: 0x06000188 RID: 392 RVA: 0x000061D8 File Offset: 0x000051D8
		public void Delete(int pid, int[] qid_list)
		{
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = "from Passage p Where p.PID=" + pid.ToString();
				this.session.Delete(query);
				query = "from Question q Where q.PID=" + pid.ToString();
				this.session.Delete(query);
				foreach (int num in qid_list)
				{
					query = "from QuestionAnswer qa Where qa.QID=" + num.ToString();
					this.session.Delete(query);
					int num2 = 0;
					query = string.Concat(new object[]
					{
						"from QuestionLO qLO Where Qtype=",
						num2,
						" and qLO.QID=",
						num.ToString()
					});
					this.session.Delete(query);
				}
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

		// Token: 0x06000189 RID: 393 RVA: 0x000062F8 File Offset: 0x000052F8
		public bool Delete(int chapterID, string conStr)
		{
			int num = 0;
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			string cmdText = string.Concat(new object[]
			{
				"DELETE FROM QuestionLO WHERE QType = ",
				num,
				" AND qid IN (SELECT qid FROM Question WHERE pid IN (SELECT pid FROM Passage WHERE chapterID=",
				chapterID,
				"))"
			});
			string cmdText2 = "DELETE FROM QuestionAnswer WHERE qid IN (SELECT qid FROM Question WHERE pid IN (SELECT pid FROM Passage WHERE chapterID=" + chapterID + "))";
			string cmdText3 = "DELETE FROM Question WHERE pid IN (SELECT pid FROM Passage WHERE chapterID=" + chapterID + ")";
			string cmdText4 = "DELETE FROM Passage WHERE chapterID=" + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Transaction = sqlTransaction;
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand2.Transaction = sqlTransaction;
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			sqlCommand3.Transaction = sqlTransaction;
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
			sqlCommand4.Transaction = sqlTransaction;
			bool result;
			try
			{
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				sqlCommand3.ExecuteNonQuery();
				sqlCommand4.ExecuteNonQuery();
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

		// Token: 0x0600018A RID: 394 RVA: 0x00006438 File Offset: 0x00005438
		public bool SaveList(IList list)
		{
			ISession session = this.sessionFactory.OpenSession();
			ITransaction transaction = session.BeginTransaction();
			bool result;
			try
			{
				foreach (object obj in list)
				{
					Passage passage = (Passage)obj;
					session.Save(passage);
					foreach (object obj2 in passage.PassageQuestions)
					{
						Question question = (Question)obj2;
						question.PID = passage.PID;
						session.Save(question);
						foreach (object obj3 in question.QuestionAnswers)
						{
							QuestionAnswer questionAnswer = (QuestionAnswer)obj3;
							questionAnswer.QID = question.QID;
							session.Save(questionAnswer);
						}
						question.QuestionLOs = BOLO.RemoveDupLO(question.QuestionLOs);
						foreach (object obj4 in question.QuestionLOs)
						{
							QuestionLO questionLO = (QuestionLO)obj4;
							questionLO.QID = question.QID;
							questionLO.QType = question.QType;
							session.Save(questionLO);
						}
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
	}
}
