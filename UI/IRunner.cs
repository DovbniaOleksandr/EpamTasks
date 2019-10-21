using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NLog;

namespace UI
{
    public interface IRunner
    {
        ILogger _logger { get; }
        UserInterface _ui { get; }
        void Run();
    }
}
