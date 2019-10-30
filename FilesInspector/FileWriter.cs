using System;
using System.Collections.Generic;
using UI;

namespace FilesInspector
{
    public static class FileWriter
    {
        public static void Write(ICollection<string> FileNames, IUserInterface ui)
        {
            if (FileNames.Count == 0)
                throw new ArgumentException("Collection is empty", nameof(FileNames));
            if (FileNames == null || ui == null)
                throw new ArgumentNullException();

            foreach (var f in FileNames) ui.Write(f);
            ui.Write("Collection contains " + FileNames.Count + " files.");
        }
    }
}