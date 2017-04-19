#define MySymbol

using System;
using System.Diagnostics;
using System.Threading;


class Program
{
    static void Main()
    {
        //Timer t = new Timer(TimerCallBack, null, 0, 2000);
        //Console.ReadKey();

        CheckSymbol();
        CheckSymbol1();

        Debug.WriteLine("Test");

    }

    static void CheckSymbol1()
    {
#if MySymbol1
        Console.WriteLine("MySymbol1 is defined");
#else
        Console.WriteLine("MySymbol1 is not defined");
#endif
    }
    static void CheckSymbol()
    {
#if MySymbol
        Console.WriteLine("MySymbol is defined");
#else
        Console.WriteLine("MySymbol is not defined");
#endif
    }

    static void TimerCallBack(object o)
    {
        Console.WriteLine("In TimerCallBack: " + DateTime.Now.ToLocalTime());
        GC.Collect();
    }
}
