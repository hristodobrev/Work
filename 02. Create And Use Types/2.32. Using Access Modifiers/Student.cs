public class Student : Person
{
    public Student(string name)
        : base(name)
    {

    }

    public void AppendToName(string name)
    {
        this.name += name;
    }

    public void SayName()
    {
        System.Console.WriteLine(this.Name);
    }
}