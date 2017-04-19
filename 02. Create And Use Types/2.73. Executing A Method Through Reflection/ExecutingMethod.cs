using System;
using System.Reflection;

class ExecutingMethod
{
    class Person
    {
        public string Name { get; set; }

        public void Greetings()
        {
            Console.WriteLine("{0} says: Hello!", this.Name);
        }

        private void Whisper(string text)
        {
            Console.WriteLine("{0} whispers: {1}", this.Name, text);
        }
    }

    static void Main()
    {
        int i = 42;
        MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo",
            new Type[] { typeof(int) });
        int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
        Console.WriteLine(result);
        Console.WriteLine(i.CompareTo(41));

        Person pesho = new Person() { Name = "Pesho" };
        pesho.Greetings();
        //pesho.Whisper(); // Compiler Error

        MethodInfo personGreetingsMethod = typeof(Person).GetMethod("Greetings");
        personGreetingsMethod.Invoke(pesho, new object[] { });

        MethodInfo[] personMethods = typeof(Person).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (MethodInfo method in personMethods)
        {
            //Console.WriteLine(method.Name);
            var parameters = method.GetParameters();
            if (parameters.Length == 1)
            {
                method.Invoke(pesho, new object[] { "Shhht!" });
            }
        }
    }
}