using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var t = SleepAsyncB(3000);
        t.Wait();

        Console.WriteLine("Finish");
    }

    public static Task SleepAsyncA(int millisecondsTimeout)
    {
        return Task.Run(() => Thread.Sleep(millisecondsTimeout));
    }

    public static Task SleepAsyncB(int millisecondsTimeout)
    {
        TaskCompletionSource<bool> tcs = null;
        var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
        tcs = new TaskCompletionSource<bool>(t);
        t.Change(millisecondsTimeout, -1);
        return tcs.Task;
    }
}