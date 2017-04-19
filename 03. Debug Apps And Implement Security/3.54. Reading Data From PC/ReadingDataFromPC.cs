using System;
using System.Diagnostics;

class ReadingDataFromPC
{
    static void Main()
    {
        if (CreatePerformanceCounters())
        {
            Console.WriteLine("Created performance counters");
            Console.WriteLine("Please restart application");
            Console.ReadKey();
            return;
        }

        var totalOperationsCounter = new PerformanceCounter(
            "MyCategory",
            "# operations executed",
            "",
            false);

        var operationsPerSecondCounter = new PerformanceCounter(
            "MyCategory",
            "# operations / sec",
            "",
            false);

        totalOperationsCounter.Increment();
        operationsPerSecondCounter.Increment();
    }

    static bool CreatePerformanceCounters()
    {
        if (!PerformanceCounterCategory.Exists("MyCategory"))
        {
            CounterCreationDataCollection counters = new CounterCreationDataCollection
            {
                new CounterCreationData(
                    "# operations executed",
                    "Total number of operations executed",
                    PerformanceCounterType.NumberOfItems32),
                new CounterCreationData(
                    "# operations / sec",
                    "Number of operations executed per second",
                    PerformanceCounterType.RateOfCountsPerSecond32),
            };

            PerformanceCounterCategory.Create("MyCategory",
                "Sample category for Codeproject", counters);

            return true;
        }

        return false;
    }
}
