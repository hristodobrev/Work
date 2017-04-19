using System;

class ResourceReader : IDisposable
{
    public ResourceReader(string resourceName)
    {
        this.ResourceName = resourceName;
    }

    public string ResourceName { get; private set; }

    public void Read()
    {
        Console.WriteLine("Reading from a resource: {0}.", this.ResourceName);
    }

    public void Dispose()
    {
        Console.WriteLine("Stream to resource {0} closed.", this.ResourceName);
    }
}