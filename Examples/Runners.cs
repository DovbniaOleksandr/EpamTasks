using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UI;
using ExceptionTasks;
using IO;
using SerializationTasks;
using StructsTasks;
using NLog;


namespace Examples
{
    class Runners:IEnumerable<IRunner>
    {
        private NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        public IEnumerator<IRunner> GetEnumerator()
        {
            yield return new StructsRunner(new ConsoleUserInterface(), _logger);
            yield return new ExceptionsRunner(new ConsoleUserInterface(), _logger);
            yield return new DirectoriesRunner(new ConsoleUserInterface(), _logger);
            yield return new SerializationRunner(new ConsoleUserInterface(), _logger);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
