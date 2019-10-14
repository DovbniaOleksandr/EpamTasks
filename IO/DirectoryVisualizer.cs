using System;
using System.IO;
using System.Linq;
using UI;

namespace IO
{
    public static class DirectoryVisualizer
    {
        public static void GetContentFromDirectory(string path, UserInterface ui, int tabs)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Empty path");
            DirectoryInfo dir = new DirectoryInfo(path);
            ui.Write(new String('\t', tabs) + dir.Name + " :");
            foreach (var file in dir.GetFiles().OrderBy(x => x.Name))
                ui.Write(new String('\t', tabs) + file.Name);
            foreach (var subDir in dir.GetDirectories().OrderBy(x => x.Name))
                GetContentFromDirectory(subDir.FullName, ui, tabs + 1);
        }

        public static void FindTxtFileByPartialName(string path, string filename, UserInterface ui)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Empty filename");
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] filesInDir = dir.GetFiles("*" + filename + "*.txt");
            foreach (var file in filesInDir)
            {
                ui.Write(file.Name);
            }
        }
    }
}
