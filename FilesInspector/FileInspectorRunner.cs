using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using NLog;
using UI;

namespace FilesInspector
{
    public class FileInspectorRunner : IRunner

    {
        public ILogger _logger { get; }
        public UserInterface _ui { get; private set; }

        public FileInspectorRunner(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            CustomFileInspector fileInspector = new CustomFileInspector();
            try
            {
                _ui.Write("Duplicates:");
                FileWriter.Write(fileInspector.GetDuplicateFiles("", ""), _ui);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.Error(e.Message);
            }
            catch (ArgumentNullException e)
            {
                _logger.Error(e.Message);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e.Message);
            }

            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            try
            {
                _ui.Write("Unique:");
                FileWriter.Write(fileInspector.GetUniqueFiles("", ""), _ui);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.Error(e.Message);
            }
            catch (ArgumentNullException e)
            {
                _logger.Error(e.Message);
            }
            catch (ArgumentException e)
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
