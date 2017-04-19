using System;

interface IExample
{
    string GetResult();

    int Value { get; set; }

    event EventHandler ResultRetrieved;

    int this[string index] { get; set; }
}

class ExampleImplementation : IExample
{
    public string Name { get; set; }

    public string GetResult()
    {
        ResultRetrieved(this, EventArgs.Empty);
        return "Result from " + this.Name;
    }

    public int Value { get; set; }

    public event EventHandler ResultRetrieved;

    public int this[string index]
    {
        get
        {
            return (int)index[0];
        }

        set { }
    }
}

class CreatingAndImplementingInterface
{
    static void Main()
    {
        var obj = new ExampleImplementation();
        obj.Name = "Test42";
        obj.ResultRetrieved += LogResult;
        string result = obj.GetResult();
        Console.WriteLine(result);
    }

    static void LogResult(object sender, EventArgs e)
    {
        Console.WriteLine("Result retrieved from {0}.", ((ExampleImplementation)sender).Name);
    }
}