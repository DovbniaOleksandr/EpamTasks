using System;

namespace Logger
{
    public class InfoDetalization : IDetalization
    {
        public string GetExceptionDetails(Exception e)
        {
            return $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("h:mm:ss")}: {e.Source} -> {e.Message}";
        }
    }
}