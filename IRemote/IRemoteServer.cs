using System;
using QuestionLib;

namespace IRemote
{
	// Token: 0x02000007 RID: 7
	public interface IRemoteServer
	{
		// Token: 0x0600000E RID: 14
		EOSData ConductExam(RegisterData rd);

		// Token: 0x0600000F RID: 15
		SubmitStatus Submit(SubmitPaper submitPaper, ref string msg);

		// Token: 0x06000010 RID: 16
		void SaveCaptureImage(byte[] img, string examCode, string login);
	}
}
