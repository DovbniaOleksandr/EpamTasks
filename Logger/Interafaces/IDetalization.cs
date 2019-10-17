using System;

namespace Logger
{
    public interface IDetalization
    {
        string GetExceptionDetails(Exception e);
    }
}