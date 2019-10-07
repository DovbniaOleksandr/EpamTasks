using System;

namespace UI
{
    public class ConsoleUserInterface : UserInterface
    {
        public string Read() => Console.ReadLine();

        public void Write(string str) => Console.WriteLine(str);
    }
}
