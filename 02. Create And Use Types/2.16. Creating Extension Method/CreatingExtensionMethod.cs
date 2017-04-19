using System;

public interface ITestable
{
    string Name { get; }

    void Test();
}

public class TestC : ITestable
{
    public TestC(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public virtual void Test()
    {
        Console.WriteLine("Testing {0}...", this.Name);
    }
}

public class FreakTest : TestC
{
    public FreakTest(string name, int freakScale)
        : base(name)
    {
        this.FreakScale = freakScale;
    }

    public int FreakScale { get; set; }

    public override void Test()
    {
        Console.WriteLine("Testing freakness level: {0}", this.FreakScale);
    }

    public string Name { get; set; }
}

public static class TestExtensionMethods
{
    public static void ExtendTest(this ITestable test)
    {
        Console.WriteLine("Extended test on {0}", test.Name);
    }
}

public class Product
{
    public decimal Price { get; set; }
}

public static class ProductExtensions
{
    public static decimal Discount(this Product product)
    {
        return product.Price * 0.9m;
    }
}

class CreatingExtensionMethod
{
    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }

    static void Main()
    {
        ITestable t = new TestC("Guas");
        ITestable t2 = new FreakTest("Freaked Guas", 3);
        t.Test();
        t2.Test();

        Console.WriteLine();

        t.ExtendTest();
        t2.ExtendTest();
    }
}