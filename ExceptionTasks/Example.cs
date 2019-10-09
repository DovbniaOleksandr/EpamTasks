using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace ExceptionTasks
{
    public class Example
    {
        public UserInterface UI { get; set; }

        public Example(UserInterface ui)
        {
            UI = ui;
        }

        public void Run()
        {
            try
            {
                MethodsWithExceptions.RecursiveMethod(100);
            }
            catch (StackOverflowException e)
            {
                UI.Write(e.Message);
            }

            try
            {
                MethodsWithExceptions.OutOfRangeMethod(new int[] { 1, 2, 4, 5, 6, 7 });
            }
            catch (IndexOutOfRangeException e)
            {
                UI.Write(e.Message);
            }

            try
            {
                MethodsWithExceptions.DoSomeMath(-2, 15);
            }
            catch (ArgumentException e)
                when(e.ParamName == "a")
            {
                UI.Write(e.Message);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                UI.Write(e.Message);
            }
        }
    }
}
