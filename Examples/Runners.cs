using System.Collections;
using System.Collections.Generic;
using ExceptionTasks;
using FilesInspector;
using IO;
using NLog;
using SerializationTasks;
using StructsTasks;
using UI;

namespace Examples
{
    internal class Runners : IEnumerable<IRunner>
    {
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public IEnumerator<IRunner> GetEnumerator()
        {
            yield return new StructsRunner(new ConsoleUserInterface(), _logger);
            yield return new ExceptionsRunner(new ConsoleUserInterface(), _logger);
            yield return new DirectoriesRunner(new ConsoleUserInterface(), _logger);
            yield return new SerializationRunner(new ConsoleUserInterface(), _logger);
            yield return new FileInspectorRunner(_logger);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}