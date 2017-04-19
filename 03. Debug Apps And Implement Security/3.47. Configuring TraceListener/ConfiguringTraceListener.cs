using System;
using System.Diagnostics;
using System.IO;

class ConfiguringTraceListener
{
    static void Main()
    {
        Stream outputFile = File.Create("tracefile.txt");
        TextWriterTraceListener textListener = new TextWriterTraceListener(outputFile);

        TraceSource traceSource = new TraceSource("TraceSource", SourceLevels.All);

        traceSource.Listeners.Clear();
        traceSource.Listeners.Add(textListener);

        traceSource.TraceInformation("Trace output");
        traceSource.TraceData(TraceEventType.Error, 0, "Trace Error data");
        traceSource.TraceData(TraceEventType.Warning, 1,
            new object[] { "Text information", new { errorCode = -1 } });

        traceSource.Flush();
        traceSource.Close();
    }
}