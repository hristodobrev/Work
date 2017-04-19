using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class CompressingData
{
    static void Main()
    {
        string folder = "temp";
        string uncompressedFilePath = "uncompressed.dat";
        string compressedFilePath = "compressed.gz";
        byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

        using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
        {
            uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
        }

        using (FileStream compressedFileStream = File.Create(compressedFilePath))
        {
            using (GZipStream compressionStream = new GZipStream(
                compressedFileStream, CompressionMode.Compress))
            {
                compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
            }
        }

        FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
        FileInfo compressedFile = new FileInfo(compressedFilePath);

        Console.WriteLine(uncompressedFile.Length);
        Console.WriteLine(compressedFile.Length);
    }
}