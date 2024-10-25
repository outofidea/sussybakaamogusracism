using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using QuestionLib.Entity;

namespace QuestionLib
{
	// Token: 0x0200000B RID: 11
	public class QuestionHelper
	{
		// Token: 0x06000070 RID: 112 RVA: 0x000027AC File Offset: 0x000017AC
		public static void SaveSubmitPaper(string folder, SubmitPaper submitPaper)
		{
			submitPaper.SubmitTime = DateTime.Now;
			string path = folder + submitPaper.LoginId + ".dat";
			FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(fileStream, submitPaper);
			fileStream.Flush();
			fileStream.Close();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002800 File Offset: 0x00001800
		public static SubmitPaper LoadSubmitPaper(string savedFile)
		{
			FileStream fileStream = new FileStream(savedFile, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			SubmitPaper result = (SubmitPaper)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002838 File Offset: 0x00001838
		private static Passage GetPassage(Paper oPaper, int pid)
		{
			foreach (object obj in oPaper.ReadingQuestions)
			{
				Passage passage = (Passage)obj;
				bool flag = passage.PID == pid;
				if (flag)
				{
					return passage;
				}
			}
			return null;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000028AC File Offset: 0x000018AC
		private static bool ReConstructQuestion(Question sq, Question oq)
		{
			bool flag = sq.QID == oq.QID;
			bool result;
			if (flag)
			{
				sq.QBID = oq.QBID;
				sq.CourseId = oq.CourseId;
				sq.Text = oq.Text;
				sq.ImageData = oq.ImageData;
				sq.ImageSize = oq.ImageSize;
				bool flag2 = false;
				bool flag3 = sq.QType == QuestionType.FILL_BLANK_ALL;
				if (flag3)
				{
					flag2 = true;
				}
				bool flag4 = sq.QType == QuestionType.FILL_BLANK_GROUP;
				if (flag4)
				{
					flag2 = true;
				}
				bool flag5 = sq.QType == QuestionType.FILL_BLANK_EMPTY;
				if (flag5)
				{
					flag2 = true;
				}
				foreach (object obj in sq.QuestionAnswers)
				{
					QuestionAnswer questionAnswer = (QuestionAnswer)obj;
					foreach (object obj2 in oq.QuestionAnswers)
					{
						QuestionAnswer questionAnswer2 = (QuestionAnswer)obj2;
						bool flag6 = questionAnswer.QAID == questionAnswer2.QAID;
						if (flag6)
						{
							bool flag7 = flag2;
							if (flag7)
							{
								string text = QuestionHelper.RemoveSpaces(questionAnswer.Text).Trim().ToLower();
								string value = QuestionHelper.RemoveSpaces(questionAnswer2.Text).Trim().ToLower();
								bool flag8 = text.Equals(value);
								if (flag8)
								{
									questionAnswer.Chosen = true;
									questionAnswer.Selected = true;
								}
							}
							else
							{
								questionAnswer.Text = questionAnswer2.Text;
								questionAnswer.Chosen = questionAnswer2.Chosen;
							}
							break;
						}
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002AAC File Offset: 0x00001AAC
		private static void ReConstructEssay(EssayQuestion sEssay, EssayQuestion oEssay)
		{
			bool flag = sEssay.EQID == oEssay.EQID;
			if (flag)
			{
				sEssay.QBID = oEssay.QBID;
				sEssay.CourseId = oEssay.CourseId;
				sEssay.Question = oEssay.Question;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002AF5 File Offset: 0x00001AF5
		private static void ReConstructImagePaper(ImagePaper sIP, ImagePaper oIP)
		{
			sIP.Image = oIP.Image;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002B08 File Offset: 0x00001B08
		public static Paper Re_ConstructPaper(Paper oPaper, SubmitPaper submitPaper)
		{
			Paper spaper = submitPaper.SPaper;
			foreach (object obj in spaper.ReadingQuestions)
			{
				Passage passage = (Passage)obj;
				Passage passage2 = QuestionHelper.GetPassage(oPaper, passage.PID);
				passage.QBID = passage2.QBID;
				passage.Text = passage2.Text;
				passage.CourseId = passage2.CourseId;
				foreach (object obj2 in passage.PassageQuestions)
				{
					Question sq = (Question)obj2;
					foreach (object obj3 in passage2.PassageQuestions)
					{
						Question oq = (Question)obj3;
						bool flag = QuestionHelper.ReConstructQuestion(sq, oq);
						if (flag)
						{
							break;
						}
					}
				}
			}
			foreach (object obj4 in spaper.MatchQuestions)
			{
				MatchQuestion matchQuestion = (MatchQuestion)obj4;
				foreach (object obj5 in oPaper.MatchQuestions)
				{
					MatchQuestion matchQuestion2 = (MatchQuestion)obj5;
					bool flag2 = matchQuestion.MID == matchQuestion2.MID;
					if (flag2)
					{
						matchQuestion.QBID = matchQuestion2.QBID;
						matchQuestion.CourseId = matchQuestion2.CourseId;
						matchQuestion.ColumnA = matchQuestion2.ColumnA;
						matchQuestion.ColumnB = matchQuestion2.ColumnB;
						matchQuestion.Solution = matchQuestion2.Solution;
						break;
					}
				}
			}
			foreach (object obj6 in spaper.GrammarQuestions)
			{
				Question sq2 = (Question)obj6;
				foreach (object obj7 in oPaper.GrammarQuestions)
				{
					Question oq2 = (Question)obj7;
					bool flag3 = QuestionHelper.ReConstructQuestion(sq2, oq2);
					if (flag3)
					{
						break;
					}
				}
			}
			foreach (object obj8 in spaper.IndicateMQuestions)
			{
				Question sq3 = (Question)obj8;
				foreach (object obj9 in oPaper.IndicateMQuestions)
				{
					Question oq3 = (Question)obj9;
					bool flag4 = QuestionHelper.ReConstructQuestion(sq3, oq3);
					if (flag4)
					{
						break;
					}
				}
			}
			foreach (object obj10 in spaper.FillBlankQuestions)
			{
				Question sq4 = (Question)obj10;
				foreach (object obj11 in oPaper.FillBlankQuestions)
				{
					Question oq4 = (Question)obj11;
					bool flag5 = QuestionHelper.ReConstructQuestion(sq4, oq4);
					if (flag5)
					{
						break;
					}
				}
			}
			bool flag6 = oPaper.EssayQuestion != null;
			if (flag6)
			{
				QuestionHelper.ReConstructEssay(spaper.EssayQuestion, oPaper.EssayQuestion);
			}
			bool flag7 = oPaper.ImgPaper != null;
			if (flag7)
			{
				QuestionHelper.ReConstructImagePaper(spaper.ImgPaper, oPaper.ImgPaper);
			}
			spaper.OneSecSilence = oPaper.OneSecSilence;
			spaper.ListAudio = oPaper.ListAudio;
			return spaper;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002FBC File Offset: 0x00001FBC
		public static string RemoveSpaces(string s)
		{
			s = s.Trim();
			string text;
			do
			{
				text = s;
				s = s.Replace("  ", " ");
			}
			while (s.Length != text.Length);
			return s;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003004 File Offset: 0x00002004
		public static string RemoveAllSpaces(string s)
		{
			s = s.Trim();
			string text;
			do
			{
				text = s;
				s = s.Replace(" ", "");
			}
			while (s.Length != text.Length);
			return s;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000304C File Offset: 0x0000204C
		public static bool IsFillBlank(QuestionType qt)
		{
			bool flag = qt == QuestionType.FILL_BLANK_ALL;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = qt == QuestionType.FILL_BLANK_GROUP;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = qt == QuestionType.FILL_BLANK_EMPTY;
					result = flag3;
				}
			}
			return result;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003084 File Offset: 0x00002084
		private static string RemoveNewLine(string s)
		{
			s = s.Replace(Environment.NewLine, "");
			s = QuestionHelper.RemoveSpaces(s);
			return s;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000030B4 File Offset: 0x000020B4
		public static string WordWrap(string str, int width)
		{
			string pattern = QuestionHelper.fillBlank_Pattern;
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			MatchCollection matchCollection = regex.Matches(str);
			str = regex.Replace(str, "(###)");
			string[] array = QuestionHelper.SplitLines(str);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				string str2 = array[i];
				bool flag = i < array.Length - 1;
				if (flag)
				{
					str2 = array[i] + Environment.NewLine;
				}
				ArrayList arrayList = QuestionHelper.Explode(str2, QuestionHelper.splitChars);
				int num = 0;
				for (int j = 0; j < arrayList.Count; j++)
				{
					string text = (string)arrayList[j];
					bool flag2 = num + text.Length > width;
					if (flag2)
					{
						bool flag3 = num > 0;
						if (flag3)
						{
							bool flag4 = !stringBuilder.ToString().EndsWith(Environment.NewLine);
							if (flag4)
							{
								stringBuilder.Append(Environment.NewLine);
							}
							num = 0;
						}
						while (text.Length > width)
						{
							stringBuilder.Append(text.Substring(0, width - 1) + "-");
							text = text.Substring(width - 1);
							bool flag5 = !stringBuilder.ToString().EndsWith(Environment.NewLine);
							if (flag5)
							{
								stringBuilder.Append(Environment.NewLine);
							}
							stringBuilder.Append(Environment.NewLine);
						}
						text = text.TrimStart(new char[0]);
					}
					stringBuilder.Append(text);
					num += text.Length;
				}
			}
			str = stringBuilder.ToString();
			pattern = "\\(###\\)";
			regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			for (int k = 0; k < matchCollection.Count; k++)
			{
				string replacement = QuestionHelper.RemoveNewLine(matchCollection[k].Value);
				str = regex.Replace(str, replacement, 1);
			}
			return str;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000032C4 File Offset: 0x000022C4
		private static ArrayList Explode(string str, char[] splitChars)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			for (;;)
			{
				int num2 = str.IndexOfAny(splitChars, num);
				bool flag = num2 == -1;
				if (flag)
				{
					break;
				}
				string text = str.Substring(num, num2 - num);
				char c = str.Substring(num2, 1)[0];
				bool flag2 = char.IsWhiteSpace(c);
				if (flag2)
				{
					arrayList.Add(text);
					arrayList.Add(c.ToString());
				}
				else
				{
					arrayList.Add(text + c.ToString());
				}
				num = num2 + 1;
			}
			arrayList.Add(str.Substring(num));
			return arrayList;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003370 File Offset: 0x00002370
		private static string[] SplitLines(string str)
		{
			string newLine = Environment.NewLine;
			Regex regex = new Regex(newLine, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			return regex.Split(str);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003398 File Offset: 0x00002398
		public static string[] GetFillBlankWord(string text)
		{
			string pattern = QuestionHelper.fillBlank_Pattern;
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			MatchCollection matchCollection = regex.Matches(text);
			string[] array = new string[matchCollection.Count];
			for (int i = 0; i < matchCollection.Count; i++)
			{
				string text2 = matchCollection[i].Value.Remove(0, 1);
				text2 = text2.Remove(text2.Length - 1, 1);
				array[i] = text2;
			}
			return array;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000341C File Offset: 0x0000241C
		public static string Sec2TimeString(int sec)
		{
			int num = sec / 3600;
			int num2 = sec % 3600 / 60;
			int num3 = sec % 60;
			string text = "0" + num;
			text = text.Substring(text.Length - 2, 2);
			string text2 = "0" + num2;
			text2 = text2.Substring(text2.Length - 2, 2);
			string text3 = "0" + num3;
			text3 = text3.Substring(text3.Length - 2, 2);
			return string.Concat(new string[]
			{
				text,
				":",
				text2,
				":",
				text3
			});
		}

		// Token: 0x04000038 RID: 56
		public static char[] lo_deli = new char[]
		{
			';'
		};

		// Token: 0x04000039 RID: 57
		public static string[] MultipleChoiceQuestionType = new string[]
		{
			"Grammar",
			"Indicate Mistake"
		};

		// Token: 0x0400003A RID: 58
		public static string fillBlank_Pattern = "\\([0-9a-zA-Z;:=?<>/`,'’ .+_~!@#$%^&*\\r\\n-]+\\)";

		// Token: 0x0400003B RID: 59
		private static char[] splitChars = new char[]
		{
			' ',
			'-',
			'\t'
		};

		// Token: 0x0400003C RID: 60
		public static int LineWidth = 100;
	}
}
