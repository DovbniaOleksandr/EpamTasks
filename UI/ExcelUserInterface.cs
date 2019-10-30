using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UI
{
    public class ExcelUserInterface : IUserInterface
    {
        private readonly string path;
        private readonly string sheetName;
        private int rowIndex;
        private readonly int columnIndex;

        public ExcelUserInterface(string path, string sheetName, int rowIndex, int columnIndex)
        {
            if (path == null || sheetName == null)
                throw new ArgumentException();
            if (!File.Exists(path))
                throw new DirectoryNotFoundException();
            if(rowIndex <= 0 || columnIndex <= 0)
                throw new ArgumentException();
            this.path = path;
            this.sheetName = sheetName;
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string str)
        {
            if(String.IsNullOrEmpty(str))
                throw new ArgumentException();
            using (var excelPack = new ExcelPackage(new FileInfo(path)))
            {
                var ws = excelPack.Workbook.Worksheets[sheetName];
                if (ws == null)
                    ws = excelPack.Workbook.Worksheets.Add(sheetName);
                ws.Cells[rowIndex, columnIndex].Value = str;
                ++rowIndex;
                excelPack.Save();
            }
        }
    }
}
