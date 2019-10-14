using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace UI
{
    public interface IRunner
    {
        UserInterface _ui { get; }
        bool Succeed { get; }
        IList<string> Errors { get;}
        void Run();
    }
}
