﻿using System;
using System.Diagnostics;

class WritingDataToEventLog
{
    static void Main()
    {
        EventLog applicationLog = new EventLog("Application", ".", "testEventLogEvent");
        applicationLog.EntryWritten += (sender, e) =>
        {
            Console.WriteLine(e.Entry.Message);
        };
        applicationLog.EnableRaisingEvents = true;
        applicationLog.WriteEntry("Test message", EventLogEntryType.Information);

        Console.ReadKey();

        return;

        EventLog log = new EventLog("MyNewLog");

        Console.WriteLine("Total entries: " + log.Entries.Count);
        EventLogEntry last = log.Entries[log.Entries.Count - 1];
        Console.WriteLine("Index: " + last.Index);
        Console.WriteLine("Source: " + last.Source);
        Console.WriteLine("Type: " + last.EntryType);
        Console.WriteLine("Time: " + last.TimeWritten);
        Console.WriteLine("Message: " + last.Message);

        return;

        if (!EventLog.SourceExists("MySource"))
        {
            EventLog.CreateEventSource("MySource", "MyNewLog");
            Console.WriteLine("CreatedEventSource");
            Console.WriteLine("Please restart the application");
            Console.ReadKey();
            return;
        }

        EventLog myLog = new EventLog();
        myLog.Source = "MySource";
        myLog.WriteEntry("Log event!");
    }
}