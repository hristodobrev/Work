namespace Reflection_Tests
{
    using SomeAssembly;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    class ReflectionTests
    {
        public class Person
        {
            public Person()
            {

            }

            public Person(int val)
            {
                this.Value = val;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            private int Value { get; set; }

            private void Greeting(string val)
            {
                Console.WriteLine("Hello, I am {0} and I am {1} {2} old.", this.Name, this.Age, this.Age > 1 ? "years" : "year");
            }

            private void PrivateMethod(int count = 10, char character = 't')
            {
                Console.WriteLine(new string(character, count));
            }
        }

        static void Main()
        {
            Assembly assembly = Assembly.LoadFrom("SomeAssembly.dll");
            Type type = assembly.GetType("SomeAssembly.ITestable");

            foreach (var prop in type.GetMembers(BindingFlags.Instance))
            {
                Console.WriteLine(prop.Name);
            }

            var names = new string[] { "Pesho", "Gosho", "Ivanka", "Ivanina" };
            Sort(names);
            Console.WriteLine(string.Join(", ", names));

            var nums = new int[] { 4, 64, 2, 8, 5, 3, 5, 74, 34 };
            Sort(nums);
            Console.WriteLine(string.Join(", ", nums));

            var textbox = TextboxService.TextboxFor(new Person() { Name = "Pesho", Age = 18 }, p => p.Name);
            Console.WriteLine(textbox);

            var person = new Person() { Name = "Pesho", Age = 19 };
            var personType = person.GetType();
            foreach (MethodInfo privateMethod in personType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var methodParamsArg = new List<object>();
                var methodParams = privateMethod.GetParameters();
                foreach (var mParam in methodParams)
                {
                    methodParamsArg.Add(mParam.ParameterType.IsValueType ? Activator.CreateInstance(mParam.ParameterType) : null);
                }
                privateMethod.Invoke(person, methodParamsArg.ToArray());
            }

            var testPerson = new Person(10) { Name = "Test", Age = 0 };
            var testPerson1 = new Person(100);
            foreach (var prop in personType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine(prop.GetValue(testPerson));
                Console.WriteLine(prop.GetValue(testPerson1));
            }
        }

        private static void Sort<T>(IList<T> items) where T : IComparable<T>
        {
            bool swapped = true;

            do
            {
                swapped = false;
                for (int i = 0; i < items.Count - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        var temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
