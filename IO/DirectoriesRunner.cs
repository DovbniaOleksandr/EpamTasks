using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UI;

namespace IO
{
    public class DirectoriesRunner:IRunner
    {
        public DirectoriesRunner(UserInterface ui, ILoggerHelper logger)
        {
            _logger = logger;
            _ui = ui;
        }

        public ILoggerHelper _logger { get; private set; }

        public UserInterface _ui { get; private set; }

        public void Run()
        {
            try
            {
                DirectoryVisualizer.GetContentFromDirectory(@"D:\Vikings.(S02).1080p.NewStudio", new ConsoleUserInterface(), 0);
            }
            catch (ArgumentException e)
            {
                _logger.LogException(e);
            }
            catch(DirectoryNotFoundException e)
            {
                _logger.LogException(e);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }

            try
            {
                DirectoryVisualizer.FindTxtFileByPartialName(@"D:\Matlab", "t", new ConsoleUserInterface());
            }
            catch (ArgumentException e)
            {
                _logger.LogException(e);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.LogException(e);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }
        }
    }
}
