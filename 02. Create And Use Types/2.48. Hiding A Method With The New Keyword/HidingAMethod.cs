using System;

class Base
{
    public void Execute()
    {
        Console.WriteLine("Base.Execute");
    }
}

class Derived : Base
{
    public new void Execute()
    {
        Console.WriteLine("Derived.Execute");
    }
}

class HidingAMethod
{
    static void Main()
    {
        Base b = new Base();
        b.Execute();
        b = new Derived();
        b.Execute();
        
        Derived d = new Derived();
        d.Execute();

    }
}