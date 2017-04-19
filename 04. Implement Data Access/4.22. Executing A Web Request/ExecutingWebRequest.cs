using System;
using System.IO;
using System.Net;
using System.Text;

    class ExecutingWebRequest
    {
        static void Main()
        {
            WebRequest request = WebRequest.Create("http://www.google.com");
            WebResponse response = request.GetResponse();

            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();

            using (FileStream fs = File.Create("googlePage.html"))
            {
                byte[] dataToWrite = Encoding.UTF8.GetBytes(responseText);
                fs.Write(dataToWrite, 0, dataToWrite.Length);
            }

            Console.WriteLine(responseText);
            response.Close();
        }
    }