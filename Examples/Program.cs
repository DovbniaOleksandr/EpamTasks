using System;
using  StructsTasks;
using UI;
using ExceptionTasks;
using IO;

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
                Console.WriteLine();
                foreach (var ex in runner.Errors)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        runner._ui.Write(ex);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
            }
        }
    }
}
