using System;
using  StructsTasks;
using UI;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            StructsTasks.Example structsExample = new Example(new ConsoleUserInterface());
            structsExample.Run();
        }
    }
}
