using System;
using System.Diagnostics;

class UsingDebugClass
{
    static void Main()
    {
        UsingTraceSource();
        return;

        Debug.WriteLine("Starting application");
        Debug.Indent();
        int i = 1 + 2;
        Debug.Assert(i == 3);
        //Debug.Assert(i != 3); // Uncomment this line to see what happens when the assert fails
        Debug.WriteLineIf(i > 0, "i is greater than 0");
    }

    static void UsingTraceSource()
    {
        TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

        traceSource.TraceInformation("Tracing application...");
        traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
        traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });
        
        traceSource.Flush();
        traceSource.Close();
    }
}