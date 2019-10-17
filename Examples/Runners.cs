using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UI;
using ExceptionTasks;
using IO;
using Logger;
using StructsTasks;


namespace Examples
{
    class Runners:IEnumerable<IRunner>
    {
        public IEnumerator<IRunner> GetEnumerator()
        {
            yield return new StructsRunner(new ConsoleUserInterface(), new MyLogger(new ConsoleBase(), new InfoDetalization()));
            yield return new ExceptionsRunner(new ConsoleUserInterface(), new MyLogger(new ConsoleBase(), new InfoDetalization()));
            yield return new DirectoriesRunner(new ConsoleUserInterface(), new MyLogger(new ConsoleBase(), new InfoDetalization()));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
