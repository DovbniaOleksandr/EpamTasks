using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace ExceptionTasks
{
    public class ExceptionsRunner:IRunner
    {
        private UserInterface _ui;

        public ExceptionsRunner(UserInterface ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            try
            {
                MethodsWithExceptions.RecursiveMethod(100);
            }
            catch (StackOverflowException e)
            {
                _ui.Write(e.Message);
            }

            try
            {
                MethodsWithExceptions.OutOfRangeMethod(new int[] { 1, 2, 4, 5, 6, 7 });
            }
            catch (IndexOutOfRangeException e)
            {
                _ui.Write(e.Message);
            }

            try
            {
                MethodsWithExceptions.DoSomeMath(-2, 15);
            }
            catch (ArgumentException e)
                when(e.ParamName == "a")
            {
                _ui.Write(e.Message);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                _ui.Write(e.Message);
            }
        }
    }
}
