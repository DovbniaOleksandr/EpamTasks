using NLog;

namespace UI
{
    public interface IRunner
    {
        ILogger _logger { get; }
        IUserInterface _ui { get; }
        void Run();
    }
}