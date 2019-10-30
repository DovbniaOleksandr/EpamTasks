using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Text;
using System.IO;

namespace FilesInspector
{
    public class CustomExcelInspector : IInspector
    {
        public int OriginalColumn { get; set; }
        public int ComparableColumn { get; set; }
        public int StartRowIndex { get; set; }
        public string Sheet { get; set; }

        public CustomExcelInspector(int originalColumn, int comparableColumn, int startRowIndex, string sheet)
        {
            if (String.IsNullOrEmpty(sheet))
                throw new ArgumentException();
            if (originalColumn <= 0 || comparableColumn <= 0 || startRowIndex <= 0)
                throw new ArgumentException();
            if(originalColumn == comparableColumn)
                throw new ArgumentException();
            OriginalColumn = originalColumn;
            ComparableColumn = comparableColumn;
            StartRowIndex = startRowIndex;
            Sheet = sheet;
        }

        public ICollection<string> GetDuplicateFiles(string PathToOriginalData, string PathToComparableData)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetUniqueFiles(string PathToOriginalData, string PathToComparableData)
        {
            HashSet<string> filesFromOriginalColumn = GetValues(PathToOriginalData, OriginalColumn);
            HashSet<string> filesFromComparableColumn = GetValues(PathToComparableData, ComparableColumn);
            filesFromOriginalColumn.SymmetricExceptWith(filesFromComparableColumn);
            return filesFromOriginalColumn;
        }

        private HashSet<string> GetValues(string PathToData, int columnIndex)
        {
            HashSet<string> filesSet = new HashSet<string>();
            using (var excelPack = new ExcelPackage(new FileInfo(PathToData)))
            {
                var ws = excelPack.Workbook.Worksheets[Sheet];
                if (ws == null)
                    throw new ArgumentException("Sheet doesn't exist");
                for (int rowIndex = StartRowIndex; ; rowIndex++)
                {
                    if (ws.Cells[rowIndex, columnIndex].Value == null)
                        break;
                    else
                    {
                        filesSet.Add(ws.Cells[rowIndex, columnIndex].Value.ToString());
                    }
                }
            }

            return filesSet;
        }
    }
}
