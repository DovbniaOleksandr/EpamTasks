using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleBase : ILogBase
    {

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
