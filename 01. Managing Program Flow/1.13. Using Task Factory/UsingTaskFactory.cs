﻿using System;
using System.Threading;
using System.Threading.Tasks;

class UsingTaskFactory
{
    static void Main()
    {
        Task<int[]> parent = Task.Run(() =>
        {
            var results = new int[3];

            TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);

            tf.StartNew(() => results[0] = 0);
            tf.StartNew(() => results[1] = 1);
            tf.StartNew(() => results[2] = 2);

            Task.Factory.StartNew(() =>
            {
                results[2] = 3;
            }, new CancellationTokenSource().Token);

            return results;
        });

        var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                {
                    Console.WriteLine(i);
                }
            });

        finalTask.Wait();
    }
}