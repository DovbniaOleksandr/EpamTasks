using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;
using UI;

namespace FilesInspector
{
    public class ExcelInspectorRunner : IRunner
    {
        private readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();

        public ILogger _logger { get; }
        public IUserInterface _ui { get; private set; }

        public ExcelInspectorRunner(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            var watch = Stopwatch.StartNew();
            var excelInspector = new CustomExcelInspector(int.Parse(configuration["originalColumnNumber"]),
                int.Parse(configuration["comparableColumnNumber"]),
                1, "files");
            try
            {
                if (configuration["ui"] == "Console")
                    _ui = new ConsoleUserInterface();
                if (configuration["ui"] == "Excel")
                    _ui = new ExcelUserInterface(configuration["pathToWriteExcelFile"], "filesFromExcelInspector",
                        int.Parse(configuration["startRowToWriteData"]),
                        int.Parse(configuration["startColumnToWriteData"]));
                _ui.Write("Unique:");
                FileWriter.Write(
                    excelInspector.GetUniqueFiles(configuration["pathToReadableExcelFile"],
                        configuration["pathToReadableExcelFile"]), _ui);
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