using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

    class WritingAsyncrounouslyToFile
    {
        static void Main()
        {
            CreateAndWriteAsyncToFile();
            ReadAsyncHttpRequest();
        }

        public static async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("test.dat", FileMode.Create,
                FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        public static async Task ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.google.com");
            Console.WriteLine(result);
        }
    }