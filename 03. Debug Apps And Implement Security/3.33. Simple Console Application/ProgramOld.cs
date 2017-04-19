using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

class ProgramOld
{
    static void MainOld()
    {
        //OnlyInDebug(); // Will only execute in debug mode

#pragma warning disable
        while (false)
        {
            Console.WriteLine("blablab");
        }
#pragma warning restore

#line hidden
        Timer t = new Timer(TimerCallBack, null, 0, 2000);
        Console.ReadLine();

        // Remove these line and build in debug and 
        // realease mode to see the diference
        //Console.WriteLine(t);
        //Console.ReadLine();

        //DebugDirective();
    }

    static void TimerCallBack(object o)
    {
        Console.WriteLine("In TimerCallBack: " + DateTime.Now.ToLocalTime());
        GC.Collect();
    }
    
    [Conditional("DEBUG")]
    static void OnlyInDebug()
    {
        Console.WriteLine("Debug Mode");
    }

    static void DebugDirective()
    {
#if DEBUG
        Console.WriteLine("Debug mode");
#else
        Console.WriteLine("Not debug");
#endif
    }
}
