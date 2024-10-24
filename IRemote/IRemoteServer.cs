using System;
using QuestionLib;

namespace IRemote
{
    public interface IRemoteServer
    {
        EOSData ConductExam(RegisterData rd);

        SubmitStatus Submit(SubmitPaper submitPaper, ref string msg);

        //was not in initial interface (added in newer eos version)
        //added from decompiled file
        void SaveCaptureImage(byte[] img, string examCode, string login);
        
    }
}
