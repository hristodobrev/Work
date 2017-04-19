using System;
using System.Threading;
using System.Threading.Tasks;
class ContinuationTasks
{
    static void Main()
    {
        var tokenSource = new CancellationTokenSource();
        CancellationToken ct = tokenSource.Token;

        Task<int> t = Task.Run(() =>
        {
            // throw new Exception("Thread Killed"); // Cause the task to fault

            ct.ThrowIfCancellationRequested();

            return 42;
        }, tokenSource.Token);

        // tokenSource.Cancel(); // Cancel the task

        t.ContinueWith((i) =>
        {
            Console.WriteLine("Canceled");
        }, TaskContinuationOptions.OnlyOnCanceled);

        t.ContinueWith((i) =>
        {
            Console.WriteLine("Faulted");
        }, TaskContinuationOptions.OnlyOnFaulted);

        var completedTask = t.ContinueWith((i) =>
        {
            Console.WriteLine("Continued");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        completedTask.Wait();
    }
}