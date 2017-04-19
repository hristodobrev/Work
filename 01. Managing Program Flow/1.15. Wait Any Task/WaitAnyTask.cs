using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
class WaitAnyTask
{
    static void Main()
    {
        Task<int>[] tasks = new Task<int>[3];

        tasks[0] = Task.Run(() =>
        {
            Thread.Sleep(500);
            return 1;
        });

        tasks[1] = Task.Run(() =>
        {
            Thread.Sleep(500);
            return 2;
        });

        tasks[2] = Task.Run(() =>
        {
            Thread.Sleep(500);
            return 3;
        });

        while (tasks.Length > 0)
        {
            int i = Task.WaitAny(tasks);
            Task<int> completedTask = tasks[i];

            Console.WriteLine("Task #{0} finnished working.", completedTask.Result);
            var temp = tasks.ToList();
            temp.RemoveAt(i);
            tasks = temp.ToArray();
        }
    }
}
