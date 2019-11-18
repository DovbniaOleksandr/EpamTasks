using System;
using NLog;
using UI;

namespace CustomIoC
{
    public class IoCRunner:IRunner
    {
        public IoCRunner(IUserInterface ui, ILogger logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public ILogger _logger { get; }
        public IUserInterface _ui { get; }

        public void Run()
        {
            try
            {
                IIoc container = new SimpleIoC();
                container.Register<Welcomer>();
                container.Register<IUserInterface, ConsoleUserInterface>();
                var welcomer = container.Create<Welcomer>();
                welcomer.SayHelloTo("Alex");
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }
    }
}
