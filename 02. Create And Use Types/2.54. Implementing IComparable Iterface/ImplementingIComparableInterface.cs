using System;
using System.Linq;
using System.Collections.Generic;

class Order : IComparable
{
    public DateTime Created { get; set; }

    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 1;
        }

        Order o = obj as Order;

        if (o == null)
        {
            throw new ArgumentException("Object is not an Order.");
        }

        return this.Created.CompareTo(o.Created);
    }
}

class Scale : IComparable
{
    public Scale(int value)
    {
        this.Value = value;
    }

    public int Value { get; set; }

    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 1;
        }

        Scale o = obj as Scale;

        if (o == null)
        {
            throw new ArgumentException("Object is not an Scale.");
        }

        return this.Value.CompareTo(o.Value);
    }
}

class ImplementingIComparableInterface
{
    static void Main()
    {
        List<Order> orders = new List<Order>()
        {
            new Order { Created = new DateTime(2012, 12, 1) },
            new Order { Created = new DateTime(2012, 1, 6) },
            new Order { Created = new DateTime(2012, 7, 8) },
            new Order { Created = new DateTime(2012, 2, 20) },
        };

        orders.Sort();
        Console.WriteLine(string.Join(" | ", orders.Select(o => o.Created.ToShortDateString())));


        List<Scale> scales = new List<Scale>()
        {
            new Scale(5),
            new Scale(8),
            new Scale(4),
            new Scale(3),
            new Scale(11),
            new Scale(2),
            new Scale(1),
        };

        scales.Sort();
        Console.WriteLine(string.Join(", ", scales.Select(s => s.Value)));


        List<object> objects = new List<object>()
        {
            12,
            5,
            "balbla",
            'c'
        };
        // objects.Sort(); // Runtime error
    }
}