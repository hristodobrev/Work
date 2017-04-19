using System;

interface IReadOnlyInterface
{
    int Value { get; }
}

struct ReadAndWriteImplementation : IReadOnlyInterface
{
    public int Value { get; set; }
}

class AdditionalSetAccessor
{
    static void Main()
    {
        ReadAndWriteImplementation rawi = new ReadAndWriteImplementation();
        rawi.Value = 5;
        Console.WriteLine(rawi.Value);

        IReadOnlyInterface roi = (IReadOnlyInterface)rawi;
        // roi.Value = 10; // Compiler error
        Console.WriteLine(roi.Value);
    }
}