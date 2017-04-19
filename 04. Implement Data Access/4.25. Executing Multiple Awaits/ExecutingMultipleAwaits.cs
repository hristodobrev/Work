using System;
using System.Net.Http;
using System.Threading.Tasks;

class ExecutingMultipleAwaits
{
    static void Main()
    {
        ExecuteMultipleRequests();
    }

    static async Task ExecuteMultipleRequests()
    {
        HttpClient client = new HttpClient();

        string google = await client.GetStringAsync("http://www.google.com");
        string youtube = await client.GetStringAsync("http://www.youtube.com");
        string stackoverflow = await client.GetStringAsync("http://www.stackoverflow.com");
    }

    static async Task ExecuteMultipleRequestsInParallel()
    {
        HttpClient client = new HttpClient();

        Task google = client.GetStringAsync("http://www.google.com");
        Task youtube = client.GetStringAsync("http://www.youtube.com");
        Task stackoverflow = client.GetStringAsync("http://www.stackoverflow.com");

        await Task.WhenAll(google, youtube, stackoverflow);
    }
}