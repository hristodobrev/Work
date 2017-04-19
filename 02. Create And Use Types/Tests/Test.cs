#define TESTCONDITION
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

using Code;
using System.Dynamic;
using System.Reflection;
using System.Linq.Expressions;
using System.IO;
using System.Text.RegularExpressions;

namespace Tests
{
    static class ExtensionMethods
    {
        public static bool Test(this int a)
        {
            return a > 5;
        }
    }

    class PointClass
    {
        public int x, y;

        public PointClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct PointStruct
    {
        public int x, y;

        public PointStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Money : IFormattable
    {
        public Money(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static explicit operator int(Money money)
        {
            return (int)Math.Round(money.Amount);
        }

        public static implicit operator Money(int amount)
        {
            return new Money(amount);
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount);
        }

        public override string ToString()
        {
            return string.Format("Amount: {0}", this.Amount);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("Amount: {0}", this.Amount);
        }
    }

    interface IInterfaceA
    {
        void Method();
    }

    interface IRight
    {
        void Move();
    }

    interface ILeft
    {
        void Move();
    }

    class Implementation : IInterfaceA
    {
        public void Method()
        {
            Console.WriteLine("Method executed.");
        }
    }

    class MoveableObject : ILeft, IRight
    {
        void IRight.Move()
        {
            Console.WriteLine("Moving Right");
        }

        void ILeft.Move()
        {
            Console.WriteLine("Moving Left");
        }
    }

    interface IIndexable<K, V>
    {
        V this[K index] { get; set; }
    }

    class Indexable<K, V> : IIndexable<K, V>
    {
        private Dictionary<K, V> values;

        public Indexable()
        {
            this.values = new Dictionary<K, V>();
        }

        public V this[K index]
        {
            get
            {
                return this.values[index];
            }
            set
            {
                this.values.Add(index, value);
            }
        }
    }

    class Base
    {
        public void Execute()
        {
            Console.WriteLine("Base.Execute");
        }

        public virtual void VirtualExecute()
        {
            Console.WriteLine("Base.VirtualExecute");
        }
    }

    class Derived : Base
    {
        public new void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }

        public override void VirtualExecute()
        {
            Console.WriteLine("Derived.VirtualExecute");
        }
    }

    abstract class Abstract
    {
        public void SomeBaseMethod()
        {
            Console.WriteLine("Some abstract method");
        }
    }

    class DerivedFromAbstract : Abstract
    {
        public void SomeDerivedMethod()
        {
            Console.WriteLine("Some derived method");
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class TestAttribute : Attribute
    {
        public TestAttribute(string arg)
        {
            this.Argument = arg;
        }

        public string Argument { get; set; }
    }

    [Serializable]
    [Test("Some Other Argument")]
    [Test("Some Yet Another Argument")]
    class Car
    {
        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        ~Car()
        {
            Console.WriteLine("Car was destroyed.");
        }
    }

    interface IPlugin
    {
        string Name { get; }

        string Description { get; }
    }

    class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "My Plugin"; }
        }

        public string Description
        {
            get { return "My Sample Plugin"; }
        }
    }

    class MyOtherPlugin : IPlugin
    {
        public string Name
        {
            get { return "My Other Plugin"; }
        }

        public string Description
        {
            get { return "My Other Sample Plugin"; }
        }
    }

    class MyYetAnotherPlugin : IPlugin
    {
        public string Name
        {
            get { return "My Yet Another Plugin"; }
        }

        public string Description
        {
            get { return "My Yet Another Sample Plugin"; }
        }
    }

    class Test
    {

        static void Main()
        {
            StreamWriter writer = File.CreateText("temp.dat");
            writer.Write("Some text");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            File.Delete("temp.dat");

            Car car = new Car();

            GC.Collect();

            car.Brand = "Subaru";
            car.Model = "Impreza WRX STi";
        }

        private static void BlockExpressionExample()
        {
            BlockExpression blockExp = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(string) }),
                    Expression.Constant("Hello ")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                    Expression.Constant("World!")
                )
            );

            Expression.Lambda<Action>(blockExp).Compile()();

            GetAction()();

            Func<int, int, string> func = (a, b) => string.Format("{0} + {1} = {2}", a, b, a + b);

            Console.WriteLine(func(34, 4326));
        }

        private static Action GetAction()
        {
            return () => Console.WriteLine("Some Action Executed.");
        }

        private static void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                Console.WriteLine("{0}: {1}", field.Name, field.GetValue(obj));
            }
        }

        private static void IterateThroughAssemblyTypes()
        {
            Assembly pluginAssembly = Assembly.Load("Tests");

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (var pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;

                Console.WriteLine(plugin.Name);
            }

            Console.WriteLine(typeof(Base).IsAssignableFrom(typeof(Derived)));
        }

        private static void AttributesTest()
        {
            DerivedFromAbstract abstr = new DerivedFromAbstract();

            abstr.SomeDerivedMethod();

            ConditionalMethod();

            TestCondtionMethod();

            Console.WriteLine(Attribute.IsDefined(typeof(Car), typeof(ConditionalAttribute)));

            TestAttribute[] testAttributes = Attribute.GetCustomAttributes(typeof(Car), typeof(TestAttribute)).Select(x => (TestAttribute)x).ToArray();

            foreach (var attr in testAttributes)
            {
                Console.WriteLine(attr.Argument);
            }
        }

        [Conditional("DEBUG")]
        private static void ConditionalMethod()
        {
            Console.WriteLine("This method is only executed at debug mode.");
        }

        [Conditional("TESTCONDITION")]
        private static void TestCondtionMethod()
        {
            Console.WriteLine("This method is only executed at TESTCONDITION");
        }

        private static void Inheritance()
        {
            Base b = new Base();
            Derived d = new Derived();
            Base baseFromDerived = new Derived();

            b.Execute();
            b.VirtualExecute();

            d.Execute();
            d.VirtualExecute();

            baseFromDerived.Execute();
            baseFromDerived.VirtualExecute();
        }

        private static void InterfaceImplementation()
        {
            Implementation imp = new Implementation();

            imp.Method();

            MoveableObject mr = new MoveableObject();

            ((IRight)mr).Move();

            ((ILeft)mr).Move();

            Indexable<string, int> wordsCount = new Indexable<string, int>();
            wordsCount["Pesho"] = 4;
            wordsCount["Gosho"] = 10;
            wordsCount["Gosho"] = 20;

            Console.WriteLine(wordsCount["Gosho"]);
        }

        private static void WriteToExcel()
        {
            var entities = new List<dynamic> { 
                new 
                {
                    ColumnA = 1,
                    ColumnB = "Foo"
                },
                new 
                {
                    ColumnA = 2,
                    ColumnB = "Bar"
                }
            };

            DisplayInExcel(entities);
        }

        private static void DisplayInExcel(IEnumerable<dynamic> entities)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            dynamic workSheet = excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "Header A";
            workSheet.Cells[1, "B"] = "Header B";

            var row = 1;
            foreach (var entity in entities)
            {
                row++;
                workSheet.Cells[row, "A"] = entity.ColumnA;
                workSheet.Cells[row, "B"] = entity.ColumnB;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
        }

        private static void ConvertingTypes()
        {
            Money money = new Money(4585.83m);

            int intMoney = (int)money;

            decimal decMoney = money;

            Console.WriteLine("Decimal Money: {0}", decMoney);
            Console.WriteLine("Integer Money: {0}", intMoney);

            Money moneyFromDec = decMoney;
            Money moneyFromInt = intMoney;

            Console.WriteLine(moneyFromDec.ToString());
            Console.WriteLine(moneyFromInt.ToString());
        }

        #region TESTREGION

        private static void BoxingAndUnboxingExamples()
        {
            double a = 4.534532142;
            double b = a;
            object oa = a;
            object ob = b;

            var p = new Person("Pesho", 17);
            var p1 = p;

            Console.WriteLine(a == b);
            Console.WriteLine(oa == ob);

            Console.WriteLine(p == p1);

            var ps = new PointStruct(1, 1);
            object ops = ps;
            ps.x = 10;
            Console.WriteLine(((PointStruct)ops).x);

            var pc = new PointClass(1, 1);
            object opc = pc;
            pc.x = 10;
            Console.WriteLine(((PointClass)opc).x);
        }

        private static void ChangingObjectTest()
        {
            int a = 5;

            var b = new { num = a };

            TestChangeObject(b);
        }

        private static void TestChangeObject(object obj)
        {
            var a = new { num = 0 };
            a = Cast(a, obj);
        }

        private static T Cast<T>(T typeHolder, object x)
        {
            return (T)x;
        }

        private static T GetDefault<T>()
        {
            return default(T);
        }

        static void TestMethod()
        {
            Console.WriteLine("This is test method.");
        }

        static int TestMethod(int a)
        {
            return a * 2;
        }

        private static void AutoCompleteTest()
        {
            var keywords = new string[] { "install", "exit", "quit", "end" };

            while (true)
            {
                string line = string.Empty;
                StringBuilder cmd = new StringBuilder();
                while (true)
                {
                    var key = Console.ReadKey(
                        //true
                        );
                    if (key.Key == ConsoleKey.Enter)
                    {
                        line = cmd.ToString();
                        break;
                    }
                    else if (key.Key == ConsoleKey.Tab)
                    {
                        foreach (var keyword in keywords)
                        {
                            if (keyword.IndexOf(cmd.ToString()) != -1)
                            {
                                var suffix = keyword.Substring(cmd.Length - 1);
                                Console.SetCursorPosition(Console.CursorLeft - 7, Console.CursorTop);
                                Console.Write(suffix);
                                cmd.Append(suffix);
                            }
                        }
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {

                    }
                    else
                    {
                        cmd.Append(key.KeyChar);
                        if (key.Key != ConsoleKey.Tab)
                        {
                            //Console.Write(key.KeyChar);
                        }
                    }
                }

                if (line.ToLower() == "end" || line.ToLower() == "exit" || line.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        #endregion

        #region Class vs Struct Measurements

        private static void CompareStructVsClass()
        {
            Console.WriteLine("Created 500 000 000 instances of PointClass for {0:f3} seconds", MeasureMethodExecution(MeasurePointClass) / 1000f);

            Console.WriteLine("Created 500 000 000 instances of PointStruct for {0:f3} seconds", MeasureMethodExecution(MeasurePointStruct) / 1000f);
        }

        private static void MeasurePointClass()
        {
            for (int i = 0; i < 500000000; i++)
            {
                PointClass p = new PointClass(i, i);
            }
        }

        private static void MeasurePointStruct()
        {
            for (int i = 0; i < 500000000; i++)
            {
                PointStruct p = new PointStruct(i, i);
            }
        }

        private static long MeasureMethodExecution(Action func)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            func();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        #endregion

        #region Enums

        private static void EnumsExample()
        {
            Days sat = Days.Sat;
            if ((int)sat == 1)
            {
                Console.WriteLine("It is Saturday today.");
            }

            Days days = Days.Sat | Days.Wed;
            if (days == Days.Sat)
            {
                Console.WriteLine("Day is Sat.");
            }
            if (days == Days.Wed)
            {
                Console.WriteLine("Day is Wed.");
            }
            if ((int)days == (int)(Days.Sat | Days.Wed))
            {
                Console.WriteLine("Day is Sat | Wed");
            }
            Console.WriteLine("Sat: " + (int)Days.Sat);
            Console.WriteLine("Wed: " + (int)Days.Wed);
            Console.WriteLine("Sat | Wed: " + (int)days);
        }

        #endregion

        #region Other

        private static void UsingNewOnClassMethodExample()
        {
            var collection = new NameValueCollection();
            NameValuePair nvp = new NameValuePair();
            nvp.Value = 20;
            nvp.Name = "Counter";
            NameValuePair nvp1 = new NameValuePair();
            nvp1.Value = 13;
            nvp1.Name = "Stars";
            NameValuePair nvp2 = new NameValuePair();
            nvp2.Value = 75;
            nvp2.Name = "Fans";

            collection.Add(nvp, nvp1, nvp2);

            Console.WriteLine(string.Join(", ", collection));

            var person = new Person("Pesho", 19);
            Console.WriteLine(person.SayHello());

            var student = new Student("Gosho", 21, 125443);
            Console.WriteLine(student.SayHello());
        }

        #endregion

    }
}
