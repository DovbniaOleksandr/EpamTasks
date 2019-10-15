using System;
using System.Collections.Generic;
using System.Text;
using UI;

namespace ExceptionTasks
{
    public class ExceptionsRunner:IRunner
    {
        public IList<string> Errors { get; private set; }

        public UserInterface _ui { get; private set; }
        public ExceptionsRunner(UserInterface ui)
        {
            _ui = ui;
            Errors = new List<string>();
        }

        public void Run()
        {
            try
            {
                MethodsWithExceptions.RecursiveMethod(100);
            }
            catch (StackOverflowException e)
            {
                Errors.Add(e.Message);
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }

            try
            {
                MethodsWithExceptions.OutOfRangeMethod(new int[] { 1, 2, 4, 5, 6, 7 });
            }
            catch (IndexOutOfRangeException e)
            {
                Errors.Add(e.Message);
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }

            try
            {
                MethodsWithExceptions.DoSomeMath(-2, 15);
            }
            catch (ArgumentException e)
                when(e.ParamName == "a")
            {
                Errors.Add(e.Message);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                Errors.Add(e.Message);
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }
        }
    }
}
