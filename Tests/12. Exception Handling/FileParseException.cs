using System;
using System.IO;

public class FileParseException : Exception
{
    public FileParseException()
        : base()
    {
    }

    public FileParseException(string message)
        : base(message)
    {
    }

    public FileParseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public FileParseException(string message, string fileName, int lineNumber)
        : base(message)
    {
        this.FileName = fileName;
        this.LineNumber = lineNumber;
    }

    public FileParseException(string message, string fileName, int lineNumber, Exception innerException)
        : base(message, innerException)
    {
        this.FileName = fileName;
        this.LineNumber = lineNumber;
    }

    public string FileName { get; set; }

    public int LineNumber { get; set; }
}