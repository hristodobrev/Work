using System;

interface IInterfaceA
{
    void MyMethod();
}

interface IInterfaceB
{
    void MyMethod();
}

class Implementation : IInterfaceA, IInterfaceB
{
    //public void MyMethod()
    //{
    //    Console.WriteLine("Implementation.MyMethod()");
    //}

    void IInterfaceA.MyMethod()
    {
        Console.WriteLine("IInterfaceA.MyMethod()");
    }

    void IInterfaceB.MyMethod()
    {
        Console.WriteLine("IInterfaceB.MyMethod()");
    }
}

class Program
{
    static void Main()
    {
        Implementation i = new Implementation();
        IInterfaceA ia = (IInterfaceA)i;
        IInterfaceB ib = (IInterfaceB)i;
        //i.MyMethod();
        ia.MyMethod();
        ib.MyMethod();
    }
}