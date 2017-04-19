using System;

class Base
{
    public virtual void Execute()
    {
        Console.WriteLine("Executing from the base class...");
    }
}

class Derived : Base
{
    public override void Execute()
    {
        this.Log("Executing from derived before the base class...");
        base.Execute();
        this.Log("Executing from derived after the base class...");
    }

    private void Log(string message)
    {
        Console.WriteLine("Log: {0}", message);
    }
}

class OverridingAVirtualMethod
{
    static void Main()
    {
        Base b = new Derived();
        b.Execute();
    }
}