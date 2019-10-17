using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Logger;

namespace UI
{
    public interface IRunner
    {
        ILoggerHelper _logger { get; }
        UserInterface _ui { get; }
        void Run();
    }
}
