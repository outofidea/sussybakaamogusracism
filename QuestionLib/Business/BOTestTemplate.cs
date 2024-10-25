using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NHibernate;

namespace QuestionLib.Business
{
	// Token: 0x02000027 RID: 39
	public class BOTestTemplate : BOBase
	{
		// Token: 0x0600019E RID: 414 RVA: 0x0000434B File Offset: 0x0000334B
		public BOTestTemplate(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000071CC File Offset: 0x000061CC
		public bool IsTestTemplateExists(string testTemplateName)
		{
			this.session = this.sessionFactory.OpenSession();
			IList list;
			try
			{
				string queryString = "from TestTemplate t Where TestTemplateName=:testTemplateName";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("testTemplateName", testTemplateName);
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

		// Token: 0x060001A0 RID: 416 RVA: 0x00007260 File Offset: 0x00006260
		public static DataTable LoadTestTemplate(string CID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT tt.TestTemplateID, tt.TestTemplateName AS 'Template name', tt.CID, c.Name AS 'Course name', tt.CreatedBy, tt.CreatedDate, tt.DistinctWithLastTest AS 'Distinct last tests',tt.Duration, tt.Note FROM TestTemplate AS tt INNER JOIN Course AS c ON tt.CID = c.CID WHERE tt.CID = @CID";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("CID", SqlDbType.NVarChar);
			sqlCommand.Parameters["CID"].Value = CID;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlConnection.Close();
			return dataTable;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000072DC File Offset: 0x000062DC
		public static bool Delete(int testTemplateID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			string cmdText = "DELETE FROM TestTemplateDetails WHERE TestTemplateID = @testTemplateID";
			string cmdText2 = "DELETE FROM TestTemplate WHERE TestTemplateID = @testTemplateID";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("testTemplateID", SqlDbType.Int);
			sqlCommand.Parameters["testTemplateID"].Value = testTemplateID;
			sqlCommand.Transaction = sqlTransaction;
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand2.Parameters.Add("testTemplateID", SqlDbType.Int);
			sqlCommand2.Parameters["testTemplateID"].Value = testTemplateID;
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

		// Token: 0x060001A2 RID: 418 RVA: 0x000073DC File Offset: 0x000063DC
		public static List<string> GetDistinctTestIds(string courseID, int testTemplateID, string conStr)
		{
			List<string> list = new List<string>();
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT DistinctWithLastTest FROM TestTemplate WHERE TestTemplateID = @testTemplateID";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("testTemplateID", SqlDbType.Int);
			sqlCommand.Parameters["testTemplateID"].Value = testTemplateID;
			object obj = sqlCommand.ExecuteScalar();
			int num = Convert.ToInt32(obj.ToString());
			cmdText = "SELECT TOP " + num + " TestID FROM Test WHERE CourseID=@courseID ORDER BY InsertOrder DESC";
			sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("courseID", SqlDbType.NVarChar);
			sqlCommand.Parameters["courseID"].Value = courseID;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				list.Add(sqlDataReader.GetString(0));
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return list;
		}
	}
}
