using System.IO;

namespace Logger
{
    public class FileBase : ILogBase
    {
        private readonly string src;

        public FileBase(string srcFileName)
        {
            src = srcFileName;
            if (!File.Exists(srcFileName))
                File.Create(srcFileName);
        }

        public void WriteMessage(string message)
        {
            using (var writer = File.AppendText(src))
            {
                writer.WriteLine(message);
            }
        }
    }
}