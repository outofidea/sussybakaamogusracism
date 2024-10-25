using System;
using System.Data;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x02000028 RID: 40
	public class BOTestTemplateDetails : BOBase
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x0000434B File Offset: 0x0000334B
		public BOTestTemplateDetails(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000074D8 File Offset: 0x000064D8
		public static DataTable LoadTestTemplateDetails(string testTemplateID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT tt.TestTemplateName AS 'Test template name', tt.CID, ch.Name AS 'Chapter', ttd.NoQInTest, tmp.QString AS 'Question type' FROM TestTemplateDetails AS ttd INNER JOIN TestTemplate AS tt ON tt.TestTemplateID = ttd.TestTemplateID INNER JOIN Chapter AS ch ON ch.ChID = ttd.ChapterID INNER JOIN (SELECT 0 AS QType, 'Reading' AS QString UNION SELECT 1 AS QType, 'Multiple choice' AS QString UNION SELECT 2 AS QType, 'Indicate mistake' AS QString UNION SELECT 3 AS QType, 'Match' AS QString UNION SELECT 4 AS QType, 'Fill blank' AS QString ) AS tmp ON ttd.QuestionType = tmp.QType WHERE tt.TestTemplateID = @testTemplateID";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("testTemplateID", SqlDbType.Int);
			sqlCommand.Parameters["testTemplateID"].Value = testTemplateID;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlConnection.Close();
			return dataTable;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007554 File Offset: 0x00006554
		public static DataTable LoadTestTemplateDetails(QuestionType questionType, int testTemplateID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT ChapterId,QuestionType,NoQInTest FROM TestTemplateDetails WHERE TestTemplateID = @testTemplateID AND QuestionType = @questionType ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("testTemplateID", SqlDbType.Int);
			sqlCommand.Parameters["testTemplateID"].Value = testTemplateID;
			sqlCommand.Parameters.Add("questionType", SqlDbType.Int);
			sqlCommand.Parameters["questionType"].Value = questionType;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlConnection.Close();
			return dataTable;
		}
	}
}
