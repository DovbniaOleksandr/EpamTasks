using System;
using System.Diagnostics;
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
        public IUserInterface _ui { get; private set; }

        public void Run()
        {
            var watch = Stopwatch.StartNew();
            var fileInspector = new CustomFileInspector();
            try
            {
                if (configuration["ui"] == "Console")
                    _ui = new ConsoleUserInterface();
                if (configuration["ui"] == "Excel")
                    _ui = new ExcelUserInterface(configuration["pathToExcelFile"], "files", 1, 1);
                _ui.Write("Duplicates:");
                FileWriter.Write(
                    fileInspector.GetDuplicateFiles(configuration["directory1"], configuration["directory2"]), _ui);
                _ui.Write("Unique:");
                FileWriter.Write(fileInspector.GetUniqueFiles(configuration["directory1"], configuration["directory2"]),
                    _ui);
                _ui.Write("Total time to work with folders(in seconds) :" + Math.Round(watch.Elapsed.TotalSeconds, 5));
            }
            catch (IOException e)
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
            finally
            {
                watch.Stop();
            }
        }
    }
}