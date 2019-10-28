using System;
using System.IO;
using NLog;
using UI;

namespace IO
{
    public class DirectoriesRunner : IRunner
    {
        public DirectoriesRunner(IUserInterface ui, ILogger logger)
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
                _ui.Write("Input path to directory");
                var dirPath = _ui.Read();
                DirectoryVisualizer.GetContentFromDirectory(dirPath,
                    new ConsoleUserInterface(), 0);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            try
            {
                _ui.Write("Input path to directory");
                var dirPath = _ui.Read();
                DirectoryVisualizer.FindTxtFileByPartialName(dirPath, "t", new ConsoleUserInterface());
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}