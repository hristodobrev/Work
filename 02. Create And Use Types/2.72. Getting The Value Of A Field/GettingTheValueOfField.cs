using System;
using System.Reflection;

public class Test
{
    private int privateInt;
    public int publicInt;

    public Test(int publicInt, int privateInt)
    {
        this.PublicInt = publicInt;
        this.PrivateInt = privateInt;
    }

    public int PublicInt
    {
        get
        {
            return this.privateInt;
        }
        set
        {
            this.privateInt = value;
        }
    }

    private int PrivateInt
    {
        get
        {
            return this.publicInt;
        }
        set
        {
            this.publicInt = value;
        }
    }

    private void PrivateMethod(int num)
    {
        Console.WriteLine("I am private Method! #{0}", num);
    }
}

class GettingTheValueOfField
{
    static void Main()
    {
        var test = new Test(43, 6);
        DumpObject(test);
    }

    static void DumpObject(object obj)
    {
        FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(int))
            {
                Console.WriteLine("Private field: " + field.GetValue(obj));
            }
        }

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(int))
            {
                Console.WriteLine("Private property: " + property.GetValue(obj));
            }
        }

        MethodInfo[] privateMethods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (MethodInfo method in privateMethods)
        {
            //Console.WriteLine(method.Name);
            object result = null;
            ParameterInfo[] parameters = method.GetParameters();
            //object classInstance = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType(), null);

            if (parameters.Length == 0)
            {
                var test = new Test(43, 54);
                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine("Blablalb");
                    Console.WriteLine(parameter.GetType());
                }
                // result = method.Invoke(test, null);
            }

        }
    }
}