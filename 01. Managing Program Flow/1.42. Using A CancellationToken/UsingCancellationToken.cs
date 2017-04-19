using System;
using System.Threading;
using System.Threading.Tasks;

class UsingCancellationToken
{
    static void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;


        Task task = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }

            token.ThrowIfCancellationRequested();
        }, token);

        try
        {
            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();

            cts.Cancel();
            task.Wait();
        }
        catch (AggregateException e)
        {
            Console.WriteLine(e.InnerExceptions[0].Message);
        }

        Console.WriteLine("Press enter to end the appliction");
        Console.ReadLine();
    }
}