using System;
using System.Globalization;
using System.IO;
using System.Text;

class CreateAndUseFileStream
{
    static void Main()
    {
        string path = @"test.dat";

        using (FileStream fs = new FileStream(path, FileMode.Append))
        {
            string myValue = 
                "Log: " + 
                DateTime.Now.ToString(CultureInfo.InvariantCulture) + 
                Environment.NewLine;

            byte[] data = Encoding.UTF8.GetBytes(myValue);
            fs.Write(data, 0, data.Length);
        }
    }
}