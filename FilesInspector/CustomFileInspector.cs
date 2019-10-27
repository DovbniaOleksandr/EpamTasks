using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FilesInspector
{
    public class CustomFileInspector : IFileInspector
    {
        public ICollection<string> GetDuplicateFiles(string directoryPath1, string directoryPath2)
        {
            ValidateArguments(directoryPath1, directoryPath2);
            HashSet<string> filesFromFirstDirectory = Directory.GetFiles(directoryPath1, "*",SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToHashSet();
            HashSet<string> filesFromSecondDirectory = Directory.GetFiles(directoryPath2, "*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToHashSet();
            filesFromFirstDirectory.IntersectWith(filesFromSecondDirectory);
            return filesFromFirstDirectory;
        }

        public ICollection<string> GetUniqueFiles(string directoryPath1, string directoryPath2)
        {
            ValidateArguments(directoryPath1, directoryPath2);
            HashSet<string> filesFromFirstDirectory = Directory.GetFiles(directoryPath1, "*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToHashSet();
            HashSet<string> filesFromSecondDirectory = Directory.GetFiles(directoryPath2, "*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToHashSet();
            filesFromFirstDirectory.SymmetricExceptWith(filesFromSecondDirectory);
            return filesFromFirstDirectory;
        }

        private void ValidateArguments(string directoryPath1, string directoryPath2)
        {
            if (String.IsNullOrEmpty(directoryPath1))
                throw new ArgumentNullException(nameof(directoryPath1));
            if (String.IsNullOrEmpty(directoryPath2))
                throw new ArgumentNullException(nameof(directoryPath2));
            if (!File.Exists(directoryPath1))
                throw new DirectoryNotFoundException("Directory number 1 doesn't exist'");
            if (!File.Exists(directoryPath2))
                throw new DirectoryNotFoundException("Directory number 2 doesn't exist'");
        }
    }
}
