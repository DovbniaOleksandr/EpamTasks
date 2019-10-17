using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class InfoDetalization : IDetalization
    {
        public string GetExceptionDetails(Exception e) => $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("h:mm:ss")}: {e.Source} -> {e.Message}";
    }
}
