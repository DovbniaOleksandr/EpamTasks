using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileBase : ILogBase
    {
        string src;

        public FileBase(string srcFileName)
        {
            src = srcFileName;
            if (!File.Exists(srcFileName))
                File.Create(srcFileName);
        }

        public void WriteMessage(string message)
        {
            using (StreamWriter writer = File.AppendText(src))
            {
                writer.WriteLine(message);
            }
        }
    }
}
