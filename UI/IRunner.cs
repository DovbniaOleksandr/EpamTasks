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