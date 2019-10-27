using System;
using System.Collections.Generic;
using System.Text;

namespace FilesInspector
{
    public interface IFileInspector
    { 
        ICollection<string> GetDuplicateFiles(string directoryPath1, string directoryPath2);
        ICollection<string> GetUniqueFiles(string directoryPath1, string directoryPath2);
    }
}
