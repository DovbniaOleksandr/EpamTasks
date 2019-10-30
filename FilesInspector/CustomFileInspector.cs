using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesInspector
{
    public class CustomFileInspector : IInspector
    {
        public ICollection<string> GetDuplicateFiles(string PathToOriginalData, string PathToComparableData)
        {
            ValidateArguments(PathToOriginalData, PathToComparableData);
            var filesFromOriginalDirectory = Directory.GetFiles(PathToOriginalData, "*", SearchOption.AllDirectories)
                .Select(f => Path.GetFileName(f)).ToHashSet();
            var filesFromComparableDirectory = Directory.GetFiles(PathToComparableData, "*", SearchOption.AllDirectories)
                .Select(f => Path.GetFileName(f)).ToHashSet();
            filesFromOriginalDirectory.IntersectWith(filesFromComparableDirectory);
            return filesFromOriginalDirectory;
        }

        public ICollection<string> GetUniqueFiles(string PathToOriginalData, string PathToComparableData)
        {
            ValidateArguments(PathToOriginalData, PathToComparableData);
            var filesFromOriginalDirectory = Directory.GetFiles(PathToOriginalData, "*", SearchOption.AllDirectories)
                .Select(f => Path.GetFileName(f)).ToHashSet();
            var filesFromComparableDirectory = Directory.GetFiles(PathToComparableData, "*", SearchOption.AllDirectories)
                .Select(f => Path.GetFileName(f)).ToHashSet();
            filesFromOriginalDirectory.SymmetricExceptWith(filesFromComparableDirectory);
            return filesFromOriginalDirectory;
        }

        private void ValidateArguments(string PathToOriginalData, string PathToComparableData)
        {
            if (string.IsNullOrEmpty(PathToOriginalData))
                throw new ArgumentNullException(nameof(PathToOriginalData));
            if (string.IsNullOrEmpty(PathToComparableData))
                throw new ArgumentNullException(nameof(PathToComparableData));
            if (!Directory.Exists(PathToOriginalData))
                throw new DirectoryNotFoundException("Original data doesn't exist'");
            if (!Directory.Exists(PathToComparableData))
                throw new DirectoryNotFoundException("Comparable data 2 doesn't exist'");
        }
    }
}