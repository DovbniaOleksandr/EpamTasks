using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NLog;
using UI;

namespace IO
{
    public class DirectoriesRunner:IRunner
    {
        public DirectoriesRunner(UserInterface ui, ILogger logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public ILogger _logger { get; private set; }

        public UserInterface _ui { get; private set; }

        public void Run()
        {
            try
            {
                DirectoryVisualizer.GetContentFromDirectory(@"D:\Vikings.(S02).1080p.NewStudio", new ConsoleUserInterface(), 0);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }
            catch(DirectoryNotFoundException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            try
            {
                DirectoryVisualizer.FindTxtFileByPartialName(@"D:\Matlab", "t", new ConsoleUserInterface());
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
