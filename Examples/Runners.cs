using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UI;
using ExceptionTasks;
using IO;
using StructsTasks;


namespace Examples
{
    class Runners:IEnumerable<IRunner>
    {
        public IEnumerator<IRunner> GetEnumerator()
        {
            yield return new StructsRunner(new ConsoleUserInterface());
            yield return new ExceptionsRunner(new ConsoleUserInterface());
            yield return new DirectoriesRunner(new ConsoleUserInterface());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
