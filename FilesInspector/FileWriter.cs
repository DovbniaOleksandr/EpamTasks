using System;
using System.Collections.Generic;
using UI;

namespace FilesInspector
{
    public static class FileWriter
    {
        public static void Write(ICollection<string> Files, IUserInterface ui)
        {
            if (Files.Count == 0)
                throw new ArgumentException("Collection is empty", nameof(Files));
            if (Files == null || ui == null)
                throw new ArgumentNullException();

            foreach (var f in Files) ui.Write(f);
            ui.Write("Collection contains " + Files.Count + " files.");
        }
    }
}