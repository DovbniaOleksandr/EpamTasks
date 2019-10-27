using System.Collections.Generic;

namespace FilesInspector
{
    public interface IFileInspector
    {
        ICollection<string> GetDuplicateFiles(string directoryPath1, string directoryPath2);
        ICollection<string> GetUniqueFiles(string directoryPath1, string directoryPath2);
    }
}