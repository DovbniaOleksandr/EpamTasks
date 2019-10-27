using System;

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