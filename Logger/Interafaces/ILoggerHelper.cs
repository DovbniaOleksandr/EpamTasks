using System;

namespace Logger
{
    public interface ILoggerHelper
    {
        void LogException(Exception e);
        void LogException(string Message);
    }
}