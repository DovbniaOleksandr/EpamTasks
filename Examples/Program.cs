using System;
using  StructsTasks;
using UI;
using ExceptionTasks;
using IO;
using Logger;
using SerializationTasks;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            //Runners runners = new Runners();
            //foreach (var runner in runners)
            //{
            //    runner.Run();
            //}
            SerializationRunner runner = new SerializationRunner(new ConsoleUserInterface(), new MyLogger(new ConsoleBase(), new InfoDetalization()));
            runner.Run();
        }
    }
}
