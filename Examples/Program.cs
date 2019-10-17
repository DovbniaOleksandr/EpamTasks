using System;
using  StructsTasks;
using UI;
using ExceptionTasks;
using IO;
using Logger;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            Runners runners = new Runners();
            foreach (var runner in runners)
            {
                runner.Run();
            }
        }
    }
}
