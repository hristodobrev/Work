public class Person
{
    public Person()
        : this(null)
    {
    }

    public Person(string name)
    {
        this.Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
        return string.Format("#{0}: {1}", this.Id, this.Name);
    }
}