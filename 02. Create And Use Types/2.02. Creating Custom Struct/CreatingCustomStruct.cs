using System;

class CreatingCustomStruct
{
    struct Point
    {
        public int x, y;

        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    class PointClass
    {
        public int x, y;

        public PointClass(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    static void Main()
    {
        Console.WriteLine("Structs:");
        var p = new Point(5, 2);
        var d = p;
        Console.WriteLine("d.x = " + d.x);
        d.x = 10;
        Console.WriteLine("d.x = " + d.x);
        Console.WriteLine("p.x = " + p.x);

        Console.WriteLine();
        Console.WriteLine("Classes:");

        var q = new PointClass(5, 2);
        var e = q;
        Console.WriteLine("e.x = " + e.x);
        e.x = 10;
        Console.WriteLine("e.x = " + e.x);
        Console.WriteLine("q.x = " + q.x);
    }
}