using NLog;

namespace Examples
{
    internal class Program
    {
        private static void Main()
        {
            var runners = new Runners();
            foreach (var runner in runners) runner.Run();
            LogManager.Shutdown();
        }
    }
}