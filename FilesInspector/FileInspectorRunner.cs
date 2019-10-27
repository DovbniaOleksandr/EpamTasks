using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;
using UI;

namespace FilesInspector
{
    public class FileInspectorRunner : IRunner
    {
        private readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();

        public FileInspectorRunner(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger _logger { get; }
        public UserInterface _ui { get; private set; }

        public void Run()
        {
            if(configuration["ui"] == "Console")
                _ui = new ConsoleUserInterface();
            var fileInspector = new CustomFileInspector();
            try
            {
                _ui.Write("Duplicates:");
                FileWriter.Write(
                    fileInspector.GetDuplicateFiles(configuration["directory1"], configuration["directory2"]), _ui);
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
                FileWriter.Write(fileInspector.GetUniqueFiles(configuration["directory1"], configuration["directory2"]), _ui);
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