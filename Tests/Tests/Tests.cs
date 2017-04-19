namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Web.Script.Serialization;
    using System.Linq;

    class DebugTest
    {

    }

    class Tests
    {
        class Project
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        static void Main()
        {
            List<int> nums = new List<int>();
            Console.WriteLine(nums.Max());

            return;

            List<Project> projects = new List<Project>();
            projects.Add(new Project() { Id = 0, Name = "Debtor" });
            projects.Add(new Project() { Id = 1, Name = "Retail Finance" });
            projects.Add(new Project() { Id = 2, Name = "Dashboard" });

            string json = new JavaScriptSerializer().Serialize(projects);
            Console.WriteLine(json);
            return;

            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine(assemblyVersion);

            return;
            throw new NotSupportedException();

            var person = new Student("Pesho", 20, 432643);
            // PrintStudentThroughAbstractClass(person);
            var p = Person.Parse("Pesho, 20");
            var p1 = new Person("Pesho", 20);
            var p2 = p1;

            Console.WriteLine(p == p1);
            Console.WriteLine(p.Equals(p1));

            Console.WriteLine(p1 == p2);

            try
            {
                Console.WriteLine(p1.Equals(person));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(p1.Equals(p));

            Console.WriteLine(Sum(new List<int>() { 1, 2, 3, 4 }));
        }

        private static int Sum(List<int> nums, int index = 0, int sum = 0)
        {
            if (index >= nums.Count)
            {
                return sum;
            }

            sum += Sum(nums, index + 1, sum) + nums[index];

            return sum;
        }

        static void PrintStudentThroughAbstractClass(Person person) // Explicit casting test
        {
            if (person is Student)
            {
                Console.WriteLine((Student)person);
            }
            else
            {
                Console.WriteLine("The person is not Student");
            }
        }

        static void OldMain() // Old tests
        {
            int[] a = new[] { 1, 2, 3, 4 };
            ChangeValue(a);

            Person person = new Person("Pencho");
            Person anotherPerson = person ?? new Person("Default Person"); // Create new default person if the current is null
            Console.WriteLine(anotherPerson);
            string name = "Ivan";
            string anotherName = name;
            anotherName = "Pesho";

            Console.WriteLine(name);
            Console.WriteLine(anotherName);

            int number = 5;
            int anotherNumber = number;
            anotherNumber = 10;

            Console.WriteLine(number);
            Console.WriteLine(anotherNumber);

            object obj = 12;
            object anotherObj = obj;
            anotherObj = 15;

            Console.WriteLine(obj);

            var hexNum = 0xF0;

            Console.WriteLine(hexNum);

            Console.WriteLine(new String('=', Console.BufferWidth - 1));
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Char {0} -> {1}", (char)i, i);
            }
            Console.WriteLine(new String('=', Console.BufferWidth - 1));

            Console.WriteLine(person);

            int num = 5;
            int? notNum = null;

            if (notNum.HasValue)
            {
                num = notNum.Value;
            }
            else
            {
                Console.WriteLine("The number hasn't got any value.");
            }

            Console.WriteLine(num);

            Console.WriteLine(String.Join(", ", a));
        }

        static void ChangeValue(int[] nums)
        {
            nums[0] = 0;
        }
    }

    public class Test
    {
        public Test(int value)
        {
            this.SecretValue = value;
        }

        public int SecretValue { get; set; }
    }
}