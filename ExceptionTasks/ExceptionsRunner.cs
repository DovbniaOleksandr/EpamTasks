using System;
using System.Collections.Generic;
using System.Text;
using Logger;
using NLog;
using UI;

namespace ExceptionTasks
{
    public class ExceptionsRunner:IRunner
    {
        public ILogger _logger { get; }
        public UserInterface _ui { get; private set; }
        public ExceptionsRunner(UserInterface ui, ILogger logger)
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
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            try
            {
                MethodsWithExceptions.OutOfRangeMethod(new int[] { 1, 2, 4, 5, 6, 7 });
            }
            catch (IndexOutOfRangeException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            try
            {
                MethodsWithExceptions.DoSomeMath(-2, 15);
            }
            catch (ArgumentException e)
                when(e.ParamName == "a")
            {
                _logger.Error(e.Message);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}
