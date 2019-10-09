using System;
using  StructsTasks;
using UI;
using ExceptionTasks;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            StructsTasks.Example structsExample = new StructsTasks.Example(new ConsoleUserInterface());
            structsExample.Run();
            ExceptionTasks.Example exceptionExample = new ExceptionTasks.Example( new ConsoleUserInterface());
            exceptionExample.Run();

        }
    }
}
