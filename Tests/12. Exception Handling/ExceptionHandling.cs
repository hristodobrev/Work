using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

class ExceptionHandling
{
    static void Main()
    {
        //ReadPositiveIntegerNumber();
        //ReadNumbers();
        //Console.WriteLine(ReadFileContent("reports.log"));
        //ReadBinaryFile("reports1.log");
        //byte[] fileBytes = ReadBinaryFile("reports1.log");
        //WriteFileFromBytes(fileBytes, "reports1_BACKUP.log");
        CustomExceptionExample();
    }

    static void CustomExceptionExample()
    {
        try
        {
            var nums = ReadNumbersFromFile("nums.txt");
            Console.WriteLine(string.Join(", ", nums));
        }
        catch (FileParseException ex)
        {
            Console.WriteLine("{0} at line {1} in {2}.", ex.Message, ex.LineNumber, ex.FileName);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    static List<int> ReadNumbersFromFile(string fileName)
    {
        List<int> nums = new List<int>();
        using (TextReader reader = new StreamReader(fileName))
        {
            int lineNumber = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                int num;
                bool parsed = int.TryParse(line, out num);

                if (!parsed)
                {
                    throw new FileParseException("Invalid number", fileName, lineNumber);
                }

                nums.Add(num);

                line = reader.ReadLine();
                lineNumber++;
            }
        }

        return nums;
    }

    static void WriteFileFromBytes(byte[] fileBytes, string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            fs.Write(fileBytes, 0, fileBytes.Length);
        }
    }

    static byte[] ReadBinaryFile(string fileName)
    {
        byte[] fileBytes = File.ReadAllBytes(fileName);

        return fileBytes;
    }

    static string ReadFileContent(string fileName)
    {
        StringBuilder fileContent = new StringBuilder(string.Empty);
        using (TextReader reader = new StreamReader(fileName))
        {
            while (!((StreamReader)reader).EndOfStream)
            {
                string line = reader.ReadLine();
                fileContent.AppendLine(line);
            }

            //string line = reader.ReadLine();
            //while (line != null)
            //{
            //    fileContent.AppendLine(line);
            //    line = reader.ReadLine();
            //}
        }

        return fileContent.ToString();
    }

    static void ReadNumbers()
    {
        int currentMin = 1;
        int currentMax = 99;
        int[] numbers = new int[10];
        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                numbers[i] = ReadNumber(currentMin, currentMax);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            currentMin = numbers[i] + 1;
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        int num;
        bool parsed = int.TryParse(input, out num);
        if (!parsed || num < start || num > end)
        {
            throw new FormatException(input + " is not a valid number.");
        }

        return num;
    }

    static void ReadPositiveIntegerNumber()
    {
        try
        {
            uint num = uint.Parse(Console.ReadLine());
            Console.WriteLine(Math.Sqrt(num));
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid Number");
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }
    }

    static void OldTest()
    {
        string fileName = "reports1.log";
        //string fileName = "reports1.log"; // This will throw an exception
        //WriteToLog(fileName);
        //ReadFromLog(fileName);

        using (ResourceReader rr1 = new ResourceReader("Resource1"), rr2 = new ResourceReader("Resource2"))
        {
            rr1.Read();
            rr2.Read();
        }

        //int result = Test();
        //Console.WriteLine(result);

        //try
        //{
        //    ReadFile("WrongFile.wrong");
        //}
        //catch (Exception e)
        //{
        //    throw new ApplicationException("Something bad happened.", e);
        //}


        // Proper exceptions
        GetNumFromArray();

        ReadNumsFromFile();
    }

    static void ReadNumsFromFile()
    {
        string fileName = "nums.txt";
        using (TextReader reader = new StreamReader(fileName))
        {
            int lineNum = 1;
            try
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    int num;
                    bool parsedNum = int.TryParse(line, out num);
                    if (!parsedNum)
                    {
                        throw new FormatException(
                            string.Format("Invalid character at line {0} in {1}. " +
                            "Number expected but '{2}' found.", lineNum, fileName, line));
                    }

                    Console.WriteLine(num);

                    line = reader.ReadLine();
                    lineNum++;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    static void GetNumFromArray()
    {
        int[] arr = new int[] { 1, 2, 43, 6, 34, 7 };
        int index = 5;
        try
        {
            int num = GetNumFromArray(arr, index);
            Console.WriteLine(num);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static int GetNumFromArray(int[] arr, int index) // Proper exception with proper description
    {
        if (index >= arr.Length)
        {
            throw new IndexOutOfRangeException(
                String.Format("Cannot access element at index {0} from array with {1} elements", index, arr.Length));
        }

        int num = arr[index];

        return num;
    }

    static int Test()
    {
        try
        {
            // throw new Exception("Error!!");
            return 5;
        }
        catch (ArgumentException)
        {

        }
        finally
        {
            Console.WriteLine("I was executed!");
        }

        return 10;
    }

    static void ReadFile(string fileName)
    {
        try
        {
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("The file '{0}' does not exist.", fileName);
        }
    }

    static void WriteToLog(string fileName, bool append = true)
    {
        TextWriter writer = new StreamWriter(fileName, append);
        string line = Console.ReadLine();
        var date = DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        writer.WriteLine(date + " - " + line);
        writer.Close();
    }

    static void ReadFromLog(string fileName)
    {
        try
        {
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);

                line = reader.ReadLine();
            }
            reader.Close();
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.StackTrace);
        }
    }
}