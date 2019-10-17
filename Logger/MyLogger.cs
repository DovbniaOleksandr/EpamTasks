using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class MyLogger:ILoggerHelper
    {
        ILogBase logBase;
        IDetalization detalization;
        public MyLogger(ILogBase logBase, IDetalization detalization)
        {
            this.logBase = logBase;
            this.detalization = detalization;
        }

        public void LogException(Exception e)
        {
            string details = detalization.GetExceptionDetails(e);
            logBase.WriteMessage(details);
        }

        public void LogException(string Message)
        {
            logBase.WriteMessage(Message);
        }
    }
}
