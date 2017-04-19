using System;
using System.Linq;

class UsingWeakReference
{
    static WeakReference data;

    static void Main()
    {
        object result = GetData();
        //Console.WriteLine(string.Join(", ", (int[])result));

        GC.Collect();

        //result = GetData();
        Console.WriteLine(string.Join(", ", (int[])result));
    }

    private static object GetData()
    {
        if (data == null)
        {
            data = new WeakReference(LoadLargeList());
        }

        if (data.Target == null)
        {
            data.Target = LoadLargeList();
        }

        return data.Target;
    }

    private static object LoadLargeList()
    {
        int[] nums = Enumerable.Range(1, 100).ToArray();
        return nums;
    }
}