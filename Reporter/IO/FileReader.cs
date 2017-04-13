using Reporter.Exceptions;
using Reporter.Models;
using System;
using System.Collections.Generic;
using System.IO;
namespace Reporter.IO
{
    public class FileReader : IReader
    {
        public FileReader(string folderName, string fileName)
        {
            this.FolderName = folderName;
            this.FileName = fileName;
        }

        public string FolderName { get; set; }

        public string FileName { get; set; }

        public string Read()
        {
            string directoryName = string.Format(@"{0}/{1}", Config.Config.DBFolder, this.FolderName);
            Directory.CreateDirectory(directoryName);
            string fileName = string.Format(@"{0}/{1}", directoryName, this.FileName);
            
            if (!File.Exists(fileName))
            {
                return "";
            }

            return File.ReadAllText(fileName);
        }
    }
}
