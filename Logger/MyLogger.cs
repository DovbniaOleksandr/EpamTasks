using System;

namespace Logger
{
    public class MyLogger : ILoggerHelper
    {
        private readonly IDetalization detalization;
        private readonly ILogBase logBase;

        public MyLogger(ILogBase logBase, IDetalization detalization)
        {
            this.logBase = logBase;
            this.detalization = detalization;
        }

        public void LogException(Exception e)
        {
            var details = detalization.GetExceptionDetails(e);
            logBase.WriteMessage(details);
        }

        public void LogException(string Message)
        {
            logBase.WriteMessage(Message);
        }
    }
}