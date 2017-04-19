using System;
using System.Threading;
using System.Threading.Tasks;

class ContiuationOfCanceledTasks
{
    static void Main()
    {
        Task longRunning = Task.Run(() => Thread.Sleep(100));
        Task shortRunning = Task.Run(() => Thread.Sleep(1));
        int index = Task.WaitAny(new[] { longRunning, shortRunning }, 1000);

        if (index == -1)
        {
            Console.WriteLine("Task timed out");
        }
        else
        {
            Console.WriteLine(index + 1 + " tasks was finnished");
        }

        return;

        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task task = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }
        }, token).ContinueWith((t) =>
        {
            t.Exception.Handle((e) => true);
            Console.WriteLine("You have canceled the task");
        }, TaskContinuationOptions.OnlyOnCanceled);

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