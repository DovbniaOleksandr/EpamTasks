using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using UI;

namespace ExceptionTasks
{
    public class ExceptionsRunner:IRunner
    {
        public ILoggerHelper _logger { get; }
        public UserInterface _ui { get; private set; }
        public ExceptionsRunner(UserInterface ui, ILoggerHelper logger)
        {
            _logger = logger;
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
                _logger.LogException(e);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            try
            {
                MethodsWithExceptions.OutOfRangeMethod(new int[] { 1, 2, 4, 5, 6, 7 });
            }
            catch (IndexOutOfRangeException e)
            {
                _logger.LogException(e);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            try
            {
                MethodsWithExceptions.DoSomeMath(-2, 15);
            }
            catch (ArgumentException e)
                when(e.ParamName == "a")
            {
                _logger.LogException(e);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                _logger.LogException(e);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }
        }
    }
}
