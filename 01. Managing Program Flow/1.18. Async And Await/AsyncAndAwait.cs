using System;
using System.Net.Http;
using System.Threading.Tasks;
class AsyncAndAwait
{
    static void Main()
    {
        string result = DownloadContent().Result;
        Console.WriteLine(result);
    }

    public static async Task<string> DownloadContent()
    {
        using (HttpClient client = new HttpClient())
        {
            string result = await client.GetStringAsync("http://www.google.com");
            return result;
        }
    }
}
