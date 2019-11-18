using System;
using UI;

namespace CustomIoC
{
    class Welcomer:IWelcomer
    {
        private IUserInterface ui;

        public Welcomer(IUserInterface ui)
        {
            this.ui = ui;
        }

        public void SayHelloTo(string name)
        {
            ui.Write($"Hello {name}!");
        }
    }
}
