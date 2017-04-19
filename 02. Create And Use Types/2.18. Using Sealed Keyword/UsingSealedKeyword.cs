using System;
using System.Net.Http;
class Base
{
    public virtual int MyMethod()
    {
        return 42;
    }
}

class Derived : Base
{
    public void Test()
    {
        Console.WriteLine("Test");
    }

    public sealed override int MyMethod()
    {
        return base.MyMethod() * 2;
    }
}

class Derived2 : Derived
{
    // This would give compiler error
    // public override int MyMethod() { return 1; }
}

class UsingSealedKeyword
{
    static void Main()
    {
        Base b = new Base();
        Base b1 = new Derived();
        Derived d = new Derived();
        Derived2 d2 = new Derived2();

        Console.WriteLine(b is Base);
        Console.WriteLine(b is Derived);
        Console.WriteLine(d2 is Base);
        Console.WriteLine(d2 is Derived);
        Console.WriteLine(d is Derived2);

        if (b1 as Derived != null)
        {
            (b1 as Derived).Test();
        }
    }
}