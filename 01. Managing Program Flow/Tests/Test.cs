using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#region Custom Exceptions

class MessageQueueException : Exception
{
    public MessageQueueException()
        : base()
    {

    }

    public MessageQueueException(string message)
        : base(message)
    {

    }

    public MessageQueueException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}

class OrderProcessingException : Exception
{
    public OrderProcessingException()
        : base()
    {

    }

    public OrderProcessingException(string message)
        : base(message)
    {

    }

    public OrderProcessingException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}

#endregion

#region Models

public class Person : IEnumerable
{
    public delegate void TestDelegate(int a, int b);

    // public Action OnChange { get; set; } // Using this syntax anyone who has access to this property can raise the event.

    public event TestDelegate OnChangeWithParams; // Using this syntax the event can be raised only from this class.

    public event Action OnChange; // Using this syntax the event can be raised only from this class.

    public int Age { get; set; }

    public string Name { get; set; }

    public void RaiseWithParams(int a, int b)
    {
        if (this.OnChangeWithParams != null)
        {
            this.OnChangeWithParams(a, b);
        }
    }

    public void Raise()
    {
        if (this.OnChange != null)
        {
            this.OnChange();
        }
    }

    public IEnumerator GetEnumerator()
    {
        PropertyInfo[] properties = this.GetType().GetProperties();
        foreach (var prop in properties)
        {
            yield return prop.Name.ToString() + ": " + prop.GetValue(this).ToString();
        }
    }
}

class Student : Person
{
    public string StudentNumber { get; set; }
}

class Teacher : Person
{
    public IEnumerable<string> Lectures { get; set; }
}

public class MyArgs : EventArgs
{
    public MyArgs(int value)
    {
        this.Value = value;
    }

    public int Value { get; set; }
}

public class RectangleArgs : EventArgs
{
    public RectangleArgs(object oldValue, object newValue, string propertyName)
    {
        this.OldValue = oldValue;
        this.NewValue = newValue;
        this.PropertyName = propertyName;
    }

    public object OldValue { get; set; }

    public object NewValue { get; set; }

    public string PropertyName { get; set; }
}

class Pub
{
    public event EventHandler<MyArgs> OnChange = delegate { };

    public void Raise()
    {
        this.OnChange(this, new MyArgs(42));
    }
}

class Rectangle
{
    private int width;
    private int height;
    private string color;

    private event EventHandler<RectangleArgs> onChange = delegate { };

    public event EventHandler<RectangleArgs> OnChange
    {
        add
        {
            lock (onChange)
            {
                Console.WriteLine("A subscriber has been added to an event.");
                onChange += value;
            }
        }
        remove
        {
            lock (onChange)
            {
                Console.WriteLine("A subscriber has been removed from an event.");
                onChange -= value;
            }
        }
    }

    public Rectangle(int width, int height, string color)
    {
        this.Width = width;
        this.Height = height;
        this.Color = color;
    }

    public int Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.RaiseOnChange(this.width, value, "Width");

            this.width = value;
        }
    }

    public int Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.RaiseOnChange(this.height, value, "Height");

            this.height = value;
        }
    }

    public string Color
    {
        get
        {
            return this.color;
        }
        set
        {
            if (this.color != null)
            {
                this.RaiseOnChange(this.color, value, "Color");
            }

            this.color = value;
        }
    }

    public void RaiseOnChange(object oldValue, object newValue, string propertyName)
    {
        RectangleArgs args = new RectangleArgs(oldValue, newValue, propertyName);

        this.onChange(this, args);

        foreach (var handler in this.onChange.GetInvocationList())
        {
            var exceptions = new List<Exception>();

            try
            {
                handler.DynamicInvoke();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}

#region Reflection Test Classes

public class Foo
{
    public string Bar { get; set; }
}

public class Building
{
    public override string ToString()
    {
        StringBuilder result = new StringBuilder(this.GetType().Name + Environment.NewLine);

        var props = this.GetType().GetProperties();

        foreach (var prop in props)
        {
            result.AppendLine(" - " + prop.Name + ": " + prop.GetValue(this));
        }

        return result.ToString();
    }
}

public class House : Building
{
    public int Rooms { get; set; }

    public int Families { get; set; }

    private string PrivateProperty { get; set; }

    public void Method()
    {

    }

    private void PrivateMethod(string message, int num)
    {
        Console.WriteLine("This method can be executed only from this class. Ujjj. String Argument: {0}, Integer Argument: {1}", message, num);
    }

    public override string ToString()
    {
        return base.ToString() + string.Format(" - PrivateProperty: " + this.PrivateProperty);
    }
}

public class Hotel : Building
{
    public int Floors { get; set; }

    public int Clients { get; set; }

    //public override string ToString()
    //{
    //    return string.Format("{0}{1} - Floors: {2}{1} - Clients: {3}",
    //        this.GetType().Name,
    //        Environment.NewLine,
    //        this.Floors,
    //        this.Clients);
    //}
}

public class Office : Building
{
    public int Managers { get; set; }

    public int Employees { get; set; }

    //public override string ToString()
    //{
    //    return string.Format("{0}{1} - Managers: {2}{1} - Employees: {3}",
    //        this.GetType().Name,
    //        Environment.NewLine,
    //        this.Managers,
    //        this.Employees);
    //}
}

#endregion

#endregion

class Test
{
    #region Fields

    private static int _flag = 0;
    private static int _value = 0;

    private static List<Person> persons = new List<Person>();

    private delegate int Calculate(int x, int y);

    private delegate Person GetPersonByName(string name);

    delegate void VoidDelegate();

    #endregion

    static void Main()
    {

    }

    #region Reflection Tests

    // Hacks
    private static void ExecutePrivateMethods()
    {
        Type type = Type.GetType("House", true);

        object instance = Activator.CreateInstance(type);

        MethodInfo methodInfo = type.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);

        methodInfo.Invoke(instance, new object[] { "Message", 34 });
    }

    private static void SetPrivatePropertyExample()
    {
        Type type = Type.GetType("House", true);

        object instance = Activator.CreateInstance(type);

        foreach (var propertyInfo in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            propertyInfo.SetValue(instance, Convert.ChangeType("HACKED!", propertyInfo.PropertyType), null);
        }

        foreach (var methodInfo in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(methodInfo);
        }

        Console.WriteLine(instance);
    }

    private static void RuntimeObjectGenerator()
    {
        string s = Console.ReadLine();

        while (s.ToLower() != "end")
        {
            try
            {
                string[] args = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 0)
                {
                    throw new FormatException("Invalid command.");
                }

                string cmd = args[0];
                switch (cmd.ToLower())
                {
                    case "create":
                        CreateObject(args.Skip(1).ToArray());
                        break;
                    default:
                        throw new FormatException("Invalid command.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                s = Console.ReadLine();
            }
        }
    }

    #region Object Creator Methods

    private static void CreateObject(string[] args)
    {
        string className = FirstCharToUpper(args[0]);

        // Console.WriteLine("Class: " + className);

        Type type = Type.GetType(className, true);

        object instance = Activator.CreateInstance(type);

        foreach (string pair in args.Skip(1))
        {
            string[] pairTokens = pair.Split(new char[] { ':', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string propName = FirstCharToUpper(pairTokens[0]);
            string propValue = FirstCharToUpper(pairTokens[1]);

            PropertyInfo prop = type.GetProperty(propName);

            prop.SetValue(instance, Convert.ChangeType(propValue, prop.PropertyType), null);
        }

        Console.WriteLine(instance.ToString());
    }

    public static string FirstCharToUpper(string input)
    {
        if (String.IsNullOrEmpty(input))
            return input;

        return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
    }

    #endregion

    private static void SimpleReflectionExample()
    {
        string name = "Foo";
        string property = "Bar";
        string value = "Value";

        Type type = Type.GetType(name, true);

        object instance = Activator.CreateInstance(type);

        PropertyInfo prop = type.GetProperty(property);

        prop.SetValue(instance, value, null);

        Console.WriteLine(((Foo)instance).Bar);
    }

    #endregion

    #region Exception Handling

    private static void ExceptionDispatchExample()
    {
        ExceptionDispatchInfo possibleException = null;

        try
        {
            int a = int.Parse(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            possibleException = ExceptionDispatchInfo.Capture(ex);
        }

        if (possibleException != null)
        {
            possibleException.Throw();
        }
    }

    private static void ThrowExceptionWithInnerExceptionExample()
    {
        try
        {
            TryProcessOrder();
        }
        catch (OrderProcessingException ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void TryProcessOrder()
    {
        try
        {
            ProcessOrder();
        }
        catch (MessageQueueException ex)
        {
            throw new OrderProcessingException("Couldn't process the order.", ex);
        }
    }

    private static void ProcessOrder()
    {
        throw new MessageQueueException("Failed to add message to the queue.");
    }

    private static void HandleAndLogExceptionsExample()
    {
        try
        {
            HandleExceptionsExample();
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    private static void LogException(Exception ex)
    {
        using (StreamWriter writer = new StreamWriter("log.txt", true))
        {
            writer.WriteLine(ex.Message);
            writer.WriteLine(ex.StackTrace);
            writer.WriteLine();
        }
    }

    private static void HandleExceptionsExample()
    {
        try
        {
            Console.WriteLine(OpenAndParse("sample.txt"));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine("The directory does not exist.");
            throw ex;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("The file does not exist.");
            throw ex;
        }
    }

    private static string OpenAndParse(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException("fileName", "Filename is required.");
        }

        return File.ReadAllText(fileName);
    }

    private static void HandlingExceptionsProperlyExample()
    {
        // Handling exceptions at lower layer could accidentally swallow an important exception
        int num = ParseNumWithHandlingExceptions(Console.ReadLine());

        // Handling exceptions at higher layer is better
        try
        {
            num = ParseNumber(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static int ParseNumWithHandlingExceptions(string numString)
    {
        int num = 0;

        try
        {
            num = int.Parse(numString);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return num;
    }

    private static int ParseNumber(string numString)
    {
        return int.Parse(numString);
    }

    private static void FailFastExample()
    {
        string s = Console.ReadLine();

        try
        {
            int i = int.Parse(s);

            if (i == 42)
            {
                Environment.FailFast("Special number entered.", new ArgumentException("Special number entered."));
            }
        }
        finally
        {
            Console.WriteLine("Program complete.");
        }
    }

    private static void ExceptionHandlingExample()
    {
        while (true)
        {
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("You must type something.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("{0} is not valid integer, please try again.", s);
            }
        }
    }

    private static void FinallyPreventExample()
    {
        PreventFinallyBlockTest();
        Console.WriteLine("After method call.");
    }

    private static void PreventFinallyBlockTest()
    {
        try
        {
            Console.WriteLine("In try block.");
            return;
        }
        finally
        {
            Thread.Sleep(1000);
            Console.WriteLine("In finally block.");
        }
    }

    #endregion

    #region Delegates

    private static void RectangleOnChange(object sender, RectangleArgs e)
    {
        Console.WriteLine("Changed {0} from {1} to {2}", e.PropertyName, e.OldValue, e.NewValue);
    }

    private static void DelegateExamples()
    {
        try
        {
            var rect = new Rectangle(7, 8, "Red");

            rect.OnChange += RectangleOnChange;

            rect.OnChange += (s, e) => { throw new Exception("Exception from subscriber."); };

            rect.OnChange += (s, e) => { Console.WriteLine("Changed."); };

            rect.Height = 10;
            rect.Width = 3;
            rect.Color = "Green";

            rect.OnChange -= RectangleOnChange;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions.Count);
        }

        Func<int, int, string> calc = (x, y) => x + " + " + y + " = " + (x + y);

        Action<char, int> repeat = (value, count) => Console.WriteLine(new String(value, count));

        Console.WriteLine(calc(3, 4));

        repeat('*', 10);

        var person = new Person();

        person.OnChangeWithParams += (a, b) => Console.WriteLine("A person has been changed. Properties: a = {0}, b = {1}", a, b);

        person.OnChangeWithParams += (a, b) => Console.WriteLine("Logging the change. Properties: a = {0}, b = {1}", a, b);

        person.RaiseWithParams(3, 6);

        person.OnChange += () => Console.WriteLine("A person has been changed.");

        person.OnChange += () => Console.WriteLine("Logging the change.");

        person.Raise();

        var pub = new Pub();

        pub.OnChange += (sender, e) => Console.WriteLine("Sender: {0}, Args: {1}", sender.GetType().Name, e.Value);

        pub.Raise();

        //Calculate calc = (x, y) => x + y;

        //Console.WriteLine(calc(4, 5));

        //calc = (x, y) => x % y;

        //Console.WriteLine(calc(147, 7));

        //persons.Add(new Teacher() { Name = "Pesho", Age = 28 });

        //GetPersonByName getPersonByName = GetTeacherByName;

        //var p = getPersonByName("Pesho");

        //Console.WriteLine(p.Name);

        //int a = 5;

        //VoidDelegate voidDel = () => { a++; Console.WriteLine(a); };

        //ClosureTest(voidDel);
        //ClosureTest(voidDel);
        //ClosureTest(voidDel);

        //Console.WriteLine(a);
    }

    private static Student GetStudentByName(string name)
    {
        return (Student)persons.FirstOrDefault(p => p.Name == name);
    }

    private static Teacher GetTeacherByName(string name)
    {
        return (Teacher)persons.FirstOrDefault(p => p.Name == name);
    }

    private static int Add(int x, int y)
    {
        Console.WriteLine("Adding...");
        return x + y;
    }

    private static int Multiply(int x, int y)
    {
        Console.WriteLine("Multiplying...");
        return x * y;
    }

    private static void ClosureTest(VoidDelegate voidDel)
    {
        voidDel();
    }

    #endregion

    #region Streams

    private static void ReadWithCatch()
    {
        string fileName = "sample.txt";
        try
        {
            StreamReader reader = new StreamReader(fileName);

            using (reader)
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Cannot find file {0}", fileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Cannot open the file {0}", fileName);
        }
    }

    private static void WriteToFileExample()
    {
        StreamWriter writer = new StreamWriter("numbers.txt");

        using (writer)
        {
            for (int i = 1; i <= 20; i++)
            {
                writer.WriteLine("Номер " + i);
            }
        }
    }

    private static void ReadFromFileExample()
    {
        //FileStream
        //BinaryReader
        //BinaryWriter

        //TextReader <- //StreamReader
        //TextWriter <- //StreamWriter

        StreamReader reader = new StreamReader("cyrilic-sample-ansi.txt", Encoding.GetEncoding("Windows-1251"));

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);

                line = reader.ReadLine();
            }
        }
    }

    #endregion

    #region Other

    private static void IterateThroughIEnumerableExample()
    {
        var person = new Person() { Age = 10, Name = "Pesho" };

        foreach (var item in person)
        {
            Console.WriteLine(item);
        }

        var personEnumerator = person.GetEnumerator();

        try
        {
            while (personEnumerator.MoveNext())
            {
                Console.WriteLine(personEnumerator.Current);
            }
        }
        finally
        {
            System.IDisposable d = personEnumerator as System.IDisposable;
            if (d != null)
            {
                d.Dispose();
            }
        }
    }

    private static void EncodeDecodeExample()
    {
        var toEncode = "Ickata:123456";
        byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(toEncode);
        string encoded = Convert.ToBase64String(encodedBytes);
        Console.WriteLine(encoded);

        byte[] decodedBytes = Convert.FromBase64String(encoded);
        string decoded = System.Text.Encoding.UTF8.GetString(decodedBytes);
        Console.WriteLine(decoded);
    }

    private static bool CheckRemoteFileExists(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    #endregion

    #region Logic

    private static void SymetricOptimisationExample()
    {
        var num = 1;
        switch (num)
        {
            case 1:
                Console.WriteLine("Case 1");
                goto case 2;
            case 2:
                Console.WriteLine("Case 2");
                break;
        }

        var arr = Enumerable.Range(0, 30000000).ToArray();
        var newArr = arr.Concat(arr.Reverse()).ToArray();

        Console.WriteLine(isSymetric(newArr));
    }

    private static bool isSymetric<T>(T[] collection)
    {
        for (int left = 0, right = collection.Length - 1; left < right; left++, right--)
        {
            if (!collection[left].Equals(collection[right]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool GetResult()
    {
        Console.WriteLine("GetResult executed.");

        return true;
    }

    #endregion

    #region Multithreading

    private static void CountinueWithCancellationTokenExample()
    {
        var source = new CancellationTokenSource();
        var token = source.Token;

        Task task = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }
        }, token).ContinueWith(t =>
        {
            t.Exception.Handle(e => true);
            Console.WriteLine("You have canceled the task");
        }, TaskContinuationOptions.OnlyOnCanceled);

        Console.ReadKey();
        source.Cancel();

        task.Wait();
    }

    private static void CatchingCancellationExceptionExample()
    {
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;

        Task task = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }

            token.ThrowIfCancellationRequested();
        }, token);

        try
        {
            Console.ReadLine();

            source.Cancel();
            task.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerException.Message);
        }
    }

    private static void UsingCancellationTokenExample()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = cancellationTokenSource.Token;
        Console.Write("Loading: ");
        Console.SetCursorPosition(0, 1);

        Task task = Task.Run(() =>
        {
            var cursorOffset = "Loading: ".Length;
            while (!token.IsCancellationRequested)
            {
                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                Console.SetCursorPosition(cursorOffset, 0);
                Console.Write("=");
                cursorOffset++;
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Thread.Sleep(500);
            }

            Console.WriteLine("Token has been canceled.");
        }, token);

        Task userInput = Task.Run(() =>
        {
            string line = Console.ReadLine();
            while (line.ToLower() != "exit")
            {
                if (line.ToLower() == "cancel token")
                {
                    cancellationTokenSource.Cancel();
                }

                switch (line.ToLower())
                {
                    case "time":
                        Console.WriteLine(DateTime.Now.ToLocalTime());
                        break;
                    case "date":
                        Console.WriteLine(DateTime.Now.ToLongDateString());
                        break;
                    default:
                        Console.WriteLine("Unkown command");
                        break;
                }

                line = Console.ReadLine();
            }

            cancellationTokenSource.Cancel();
        });

        Task.WaitAll(task, userInput);
    }

    private static void InterlockedOperationsExample()
    {
        int n = 0;

        var up = Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                InterlockedIncrement(ref n);
            }
        });


        for (int i = 0; i < 1000000; i++)
        {
            InterlockedDecrement(ref n);
        }

        up.Wait();
        Console.WriteLine(n);

        int isInUse = 5;

        if (Interlocked.Exchange(ref isInUse, 2) == 5)
        {
            Console.WriteLine("Exchanged");
            Console.WriteLine("New value: {0}", isInUse);
        }
        else
        {
            Console.WriteLine("Old value: {0}", isInUse);
        }

        int value = 1;

        Task t1 = Task.Run(() =>
        {
            if (value == 1)
            {
                Thread.Sleep(1000);
                Interlocked.CompareExchange(ref value, 2, 3);
            }
        });

        Task t2 = Task.Run(() =>
        {
            Thread.Sleep(1);
            value = 3;
        });

        Task.WaitAll(t1, t2);
        Console.WriteLine(value);
    }

    private static object _lock = new object();

    private static void InterlockedIncrement(ref int n)
    {
        lock (_lock)
        {
            n++;
        }
    }

    private static void InterlockedDecrement(ref int n)
    {
        lock (_lock)
        {
            n--;
        }
    }

    private static void Thread1()
    {
        _value = 5;
        _flag = 1;
    }

    public static void Thread2()
    {
        if (_flag == 1)
        {
            Console.WriteLine(_value);
        }
    }

    public static bool IsEven(int i)
    {
        if (i % 10 == 0)
        {
            throw new ArgumentException("i");
        }

        return i % 2 == 0;
    }

    #endregion
}