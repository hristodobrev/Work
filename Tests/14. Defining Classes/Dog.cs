public class Dog
{
    private static int dogsCount;

    public Dog()
        : this("Unknown")
    {
    }

    public Dog(string name)
    {
        dogsCount++;
        this.Name = name;
    }

    private string name;

    public string Name
    {
        get { return this.name; }

        private set { this.name = value; }
    }

    public static int Count
    {
        get { return dogsCount; }
    }

    public void Bark()
    {
        System.Console.WriteLine("wow-wow!");
    }

    public void DoSth()
    {
        this.Bark();
    }
    // UDNT
    // CME
}