using System;
using System.Collections;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000023 RID: 35
	public class BOQuestion : BOBase
	{
		// Token: 0x0600018B RID: 395 RVA: 0x0000434B File Offset: 0x0000334B
		public BOQuestion(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000666C File Offset: 0x0000566C
		public IList LoadPassageQuestion(int pid)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Question q Where q.PID=:pid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("pid", pid);
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

		// Token: 0x0600018D RID: 397 RVA: 0x000066F4 File Offset: 0x000056F4
		public Question Load(int qid)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Question q Where q.QID=:qid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("qid", qid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((Question)list[0]) : null;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00006794 File Offset: 0x00005794
		public IList LoadByType(QuestionType type)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Question q Where q.QType=:type";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("type", type);
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

		// Token: 0x0600018F RID: 399 RVA: 0x0000681C File Offset: 0x0000581C
		public IList LoadByTypeOfCourse(QuestionType type, string courseId)
		{
			IList result = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Question q Where q.QType=:type and CourseId=:courseId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("type", type);
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

		// Token: 0x06000190 RID: 400 RVA: 0x000068B0 File Offset: 0x000058B0
		public IList LoadFillBlankByTypeOfCourse(string courseId)
		{
			IList result = null;
			QuestionType questionType = QuestionType.FILL_BLANK_ALL;
			QuestionType questionType2 = QuestionType.FILL_BLANK_EMPTY;
			QuestionType questionType3 = QuestionType.FILL_BLANK_GROUP;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Question q Where (q.QType=:type1 OR q.QType=:type2 OR q.QType=:type3) and CourseId=:courseId";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("type1", questionType);
				query.SetParameter("type2", questionType2);
				query.SetParameter("type3", questionType3);
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

		// Token: 0x06000191 RID: 401 RVA: 0x00006978 File Offset: 0x00005978
		public void Delete(int qid, QuestionType qt)
		{
			this.session = this.sessionFactory.OpenSession();
			ITransaction transaction = this.session.BeginTransaction();
			try
			{
				string query = "from Question q Where q.QID=" + qid.ToString();
				this.session.Delete(query);
				query = "from QuestionAnswer qa Where qa.QID=" + qid.ToString();
				this.session.Delete(query);
				query = string.Concat(new object[]
				{
					"from QuestionLO qlo Where qlo.QType=",
					(int)qt,
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

		// Token: 0x06000192 RID: 402 RVA: 0x00006A5C File Offset: 0x00005A5C
		public bool SaveList(IList list)
		{
			ISession session = this.sessionFactory.OpenSession();
			ITransaction transaction = session.BeginTransaction();
			bool result;
			try
			{
				foreach (object obj in list)
				{
					Question question = (Question)obj;
					session.Save(question);
					foreach (object obj2 in question.QuestionAnswers)
					{
						QuestionAnswer questionAnswer = (QuestionAnswer)obj2;
						questionAnswer.QID = question.QID;
						session.Save(questionAnswer);
					}
					question.QuestionLOs = BOLO.RemoveDupLO(question.QuestionLOs);
					foreach (object obj3 in question.QuestionLOs)
					{
						QuestionLO questionLO = (QuestionLO)obj3;
						questionLO.QID = question.QID;
						questionLO.QType = question.QType;
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

		// Token: 0x06000193 RID: 403 RVA: 0x00006C14 File Offset: 0x00005C14
		public bool Delete(int chapterID, QuestionType qt, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			string cmdText = string.Concat(new object[]
			{
				"DELETE FROM QuestionAnswer WHERE qid in (SELECT qid FROM Question WHERE QType=",
				(int)qt,
				" AND chapterId=",
				chapterID,
				")"
			});
			string cmdText2 = string.Concat(new object[]
			{
				"DELETE FROM QuestionLO WHERE qid in (SELECT qid FROM Question WHERE QType=",
				(int)qt,
				" AND chapterId=",
				chapterID,
				")"
			});
			string cmdText3 = string.Concat(new object[]
			{
				"DELETE FROM Question WHERE QType=",
				(int)qt,
				" AND chapterID=",
				chapterID
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Transaction = sqlTransaction;
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand2.Transaction = sqlTransaction;
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			sqlCommand3.Transaction = sqlTransaction;
			bool result;
			try
			{
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				sqlCommand3.ExecuteNonQuery();
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
	}
}
