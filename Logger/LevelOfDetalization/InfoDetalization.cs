using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class InfoDetalization : IDetalization
    {
        public string GetExceptionDetails(Exception e) => e.Message;
    }
}
