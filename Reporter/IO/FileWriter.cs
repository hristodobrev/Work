using System;
using System.IO;

namespace Reporter.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter(string folderName, string fileName)
        {
            this.FolderName = folderName;
            this.FileName = fileName;
        }

        public string FolderName { get; set; }

        public string FileName { get; set; }

        public void WriteText(string text)
        {
            string directoryName = string.Format(@"{0}/{1}", Config.Config.DBFolder, this.FolderName);
            Directory.CreateDirectory(directoryName);

            string fileName = string.Format(@"{0}/{1}", directoryName, this.FileName);

            File.WriteAllText(fileName, text);
        }
    }
}
