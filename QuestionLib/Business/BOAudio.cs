using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NHibernate;
using QuestionLib.Entity;

namespace QuestionLib.Business
{
	// Token: 0x0200001B RID: 27
	public class BOAudio : BOBase
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000434B File Offset: 0x0000334B
		public BOAudio(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004358 File Offset: 0x00003358
		public Audio Load(int auid)
		{
			IList list = null;
			this.session = this.sessionFactory.OpenSession();
			try
			{
				string queryString = "from Audio a Where a.AuID=:auid";
				IQuery query = this.session.CreateQuery(queryString);
				query.SetParameter("auid", auid);
				list = query.List();
				this.session.Close();
			}
			catch (Exception ex)
			{
				this.session.Close();
				throw ex;
			}
			return (list.Count > 0) ? ((Audio)list[0]) : null;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000043F8 File Offset: 0x000033F8
		public DataTable LoadAllChapterAudio(int chid, string conStr)
		{
			IList list = new ArrayList();
			SqlConnection sqlConnection = new SqlConnection(conStr);
			string selectCommandText = "SELECT AuID, AudioFile, AudioSize, AudioLength, RepeatTime, PaddingTime, PlayOrder FROM Audio WHERE ChID = " + chid;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlConnection.Close();
			return dataTable;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000444C File Offset: 0x0000344C
		public Audio LoadAudio(int auid, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioFile, AudioSize, AudioLength, AudioData, RepeatTime, PaddingTime, PlayOrder FROM Audio WHERE AuID= " + auid;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			Audio audio = null;
			bool flag = sqlDataReader.Read();
			if (flag)
			{
				audio = new Audio();
				audio.AudioFile = sqlDataReader["AudioFile"].ToString();
				audio.AudioSize = (int)sqlDataReader["AudioSize"];
				audio.AudioData = new byte[audio.AudioSize];
				sqlDataReader.GetBytes(3, 0L, audio.AudioData, 0, audio.AudioSize);
				audio.AudioLength = (int)sqlDataReader["AudioLength"];
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return audio;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000452C File Offset: 0x0000352C
		public List<AudioInPaper> LoadChapterAudio(int chapterID, string conStr)
		{
			List<AudioInPaper> list = new List<AudioInPaper>();
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioSize, AudioData, AudioLength, RepeatTime, PaddingTime, PlayOrder FROM Audio WHERE ChID= " + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				AudioInPaper audioInPaper = new AudioInPaper();
				audioInPaper.AudioSize = (int)sqlDataReader["AudioSize"];
				audioInPaper.AudioData = new byte[audioInPaper.AudioSize];
				sqlDataReader.GetBytes(1, 0L, audioInPaper.AudioData, 0, audioInPaper.AudioSize);
				audioInPaper.AudioLength = (int)sqlDataReader["AudioLength"];
				audioInPaper.RepeatTime = (byte)sqlDataReader["RepeatTime"];
				audioInPaper.PaddingTime = (int)sqlDataReader["PaddingTime"];
				audioInPaper.PlayOrder = (byte)sqlDataReader["PlayOrder"];
				list.Add(audioInPaper);
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return list;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000465C File Offset: 0x0000365C
		public static bool Delete(int auid, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "DELETE FROM Audio WHERE AuID= " + auid;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			int num = sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			return num > 0;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000046AC File Offset: 0x000036AC
		public static bool AudioExist(int auid, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT * FROM Audio WHERE AuID= " + auid;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			bool hasRows = sqlDataReader.HasRows;
			bool result;
			if (hasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = true;
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004720 File Offset: 0x00003720
		public static bool AudioFileExist(int chapterID, string audioFile, int audioSize, int audioLength, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT * FROM Audio WHERE ChID= @chapterID AND AudioFile=@audioFile AND AudioSize = @audioSize AND AudioLength = @audioLength";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.Add("chapterID", SqlDbType.Int);
			sqlCommand.Parameters["chapterID"].Value = chapterID;
			sqlCommand.Parameters.Add("audioFile", SqlDbType.NVarChar);
			sqlCommand.Parameters["audioFile"].Value = audioFile;
			sqlCommand.Parameters.Add("audioSize", SqlDbType.Int);
			sqlCommand.Parameters["audioSize"].Value = audioSize;
			sqlCommand.Parameters.Add("audioLength", SqlDbType.Int);
			sqlCommand.Parameters["audioLength"].Value = audioLength;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			bool hasRows = sqlDataReader.HasRows;
			bool result;
			if (hasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = true;
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000483C File Offset: 0x0000383C
		public static string GetAudioFile(int auid, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioFile FROM Audio WHERE AuID= " + auid;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			bool flag = sqlDataReader.Read();
			string result;
			if (flag)
			{
				string text = sqlDataReader["AudioFile"].ToString();
				sqlDataReader.Close();
				sqlConnection.Close();
				result = text;
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = null;
			}
			return result;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000048C4 File Offset: 0x000038C4
		public static string GetChapterAudioFile(int chapterID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioFile FROM Audio WHERE ChID= " + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			string text = null;
			while (sqlDataReader.Read())
			{
				bool flag = text == null;
				if (flag)
				{
					text = sqlDataReader["AudioFile"].ToString();
				}
				else
				{
					text = text + ", " + sqlDataReader["AudioFile"].ToString();
				}
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return text;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004968 File Offset: 0x00003968
		public static int GetAudioLength(int chapterID, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioLength, RepeatTime, PaddingTime FROM Audio WHERE ChID= " + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 0;
			while (sqlDataReader.Read())
			{
				int num2 = Convert.ToInt32(sqlDataReader["AudioLength"].ToString());
				int num3 = (int)Convert.ToByte(sqlDataReader["RepeatTime"].ToString());
				int num4 = Convert.ToInt32(sqlDataReader["PaddingTime"].ToString());
				num += (num2 + num4) * num3;
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return num;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004A20 File Offset: 0x00003A20
		public static int GetFileAudioLength(int auid, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioLength FROM Audio WHERE AuID= " + auid;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int result = 0;
			bool flag = sqlDataReader.Read();
			if (flag)
			{
				result = Convert.ToInt32(sqlDataReader["AudioLength"].ToString());
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return result;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004A9C File Offset: 0x00003A9C
		public static bool UpdateAudioPlayingInfo(List<Audio> listAudio, string conStr)
		{
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "UPDATE Audio SET RepeatTime=@repeatTime, PaddingTime=@paddingTime, PlayOrder=@playOrder WHERE AuID= @auID";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			bool result;
			try
			{
				sqlCommand.Parameters.Add("repeatTime", SqlDbType.TinyInt);
				sqlCommand.Parameters.Add("paddingTime", SqlDbType.Int);
				sqlCommand.Parameters.Add("playOrder", SqlDbType.TinyInt);
				sqlCommand.Parameters.Add("auID", SqlDbType.Int);
				sqlCommand.Transaction = sqlConnection.BeginTransaction();
				foreach (Audio audio in listAudio)
				{
					sqlCommand.Parameters["repeatTime"].Value = audio.RepeatTime;
					sqlCommand.Parameters["paddingTime"].Value = audio.PaddingTime;
					sqlCommand.Parameters["playOrder"].Value = audio.PlayOrder;
					sqlCommand.Parameters["auID"].Value = audio.AuID;
					sqlCommand.ExecuteNonQuery();
				}
				sqlCommand.Transaction.Commit();
				sqlConnection.Close();
				result = true;
			}
			catch
			{
				sqlCommand.Transaction.Rollback();
				sqlConnection.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004C4C File Offset: 0x00003C4C
		public static bool CheckAudioPlayingInfo(int chapterID, string conStr)
		{
			bool result = true;
			SqlConnection sqlConnection = new SqlConnection(conStr);
			sqlConnection.Open();
			string cmdText = "SELECT AudioLength, RepeatTime, PaddingTime, PlayOrder FROM Audio WHERE ChID= " + chapterID;
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				int num = Convert.ToInt32(sqlDataReader["AudioLength"].ToString());
				int num2 = (int)Convert.ToByte(sqlDataReader["RepeatTime"].ToString());
				int num3 = Convert.ToInt32(sqlDataReader["PaddingTime"].ToString());
				int num4 = Convert.ToInt32(sqlDataReader["PlayOrder"].ToString());
				bool flag = num * num2 * num3 * num4 == 0;
				if (flag)
				{
					result = false;
					break;
				}
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			return result;
		}
	}
}
