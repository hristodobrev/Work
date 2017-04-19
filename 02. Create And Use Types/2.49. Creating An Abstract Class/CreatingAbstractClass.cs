using System;

abstract class Base
{
    public virtual void ImplementedMethod()
    {
        Console.WriteLine("This is method implemented in the base abstract class.");
    }

    public abstract void AbstractMethod();
}

class Derived : Base
{
    public override void AbstractMethod()
    {
        Console.WriteLine("This is abstract method implemented in the derived class.");
    }

    public override void ImplementedMethod()
    {
        base.ImplementedMethod();
        Console.WriteLine("[This is addition from the derived class to the line above]");
    }
}

class CreatingAbstractClass
{
    static void Main()
    {
        Base b = new Derived();
        b.AbstractMethod();
        b.ImplementedMethod();
    }
}