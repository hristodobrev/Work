using Reporter.Models;
using System;
using System.Collections.Generic;
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
        
        public void WriteLine(string line)
        {
            string fileName = Path.Combine(this.FolderName, this.FileName);
            
            using (StreamWriter fw = File.AppendText(fileName))
            {
                fw.WriteLine(line);
            }
        }
    }
}
