using System.Collections.Generic;

namespace FilesInspector
{
    public interface IInspector
    {
        ICollection<string> GetDuplicateFiles(string PathToOriginalData, string PathToComparableData);
        ICollection<string> GetUniqueFiles(string PathToOriginalData, string PathToComparableData);
    }
}