using System;
using System.Collections.Generic;

class WhereClause
{
    class MyClass<T>
        where T : class, new()
    {
        public MyClass()
        {
            this.MyProperty = new T();
        }

        public T MyProperty { get; set; }
    }

    static void Main()
    {
        var myClass = new MyClass<List<int>>();
        myClass.MyProperty.Add(5);
        myClass.MyProperty.Add(156);
        myClass.MyProperty.Add(6436);

        Console.WriteLine(string.Join(", ", myClass.MyProperty));
    }
}