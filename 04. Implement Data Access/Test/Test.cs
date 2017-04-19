
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
namespace Test
{
    class Test
    {
        static void Main()
        {
            using (FileStream stream = new FileStream("D:/tesst.txt", FileMode.OpenOrCreate))
            {
                string text = "Some text";
                byte[] byteText = Encoding.UTF8.GetBytes(text);
                stream.Write(byteText, 0, byteText.Length);
            }
            
        }

        private static void RegexTest()
        {
            string pattern = @"<Status>([0-9]+)</status>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string text = @"<xml><head><status>9</status></head><body><status>18</status><p><status>12</status></p></body></xml>";

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }

        private static void CompareSwitchAndIf()
        {
            MeasureByIterations(100000);
            Console.WriteLine();
            MeasureByIterations(1000000);
            Console.WriteLine();
            MeasureByIterations(2000000);
            Console.WriteLine();
            MeasureByIterations(5000000);
        }

        private static void MeasureByIterations(int iterations)
        {
            string[] randomNames = new string[]{
                "Pesho",
                "Gosho",
                "Tosho",
                "Petq",
                "Mariq",
                "Stamat",
                "Ignat",
                "Zaprqn",
                "Djintaro",
                "Miroslav",
                "Galena"
            };

            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                string name = randomNames[new Random().Next(randomNames.Length)];
                string asignName = string.Empty;
                switch (name)
                {
                    case "Pesho":
                        asignName = name;
                        break;
                    case "Gosho":
                        asignName = name;
                        break;
                    case "Tosho":
                        asignName = name;
                        break;
                    case "Petq":
                        asignName = name;
                        break;
                    case "Mariq":
                        asignName = name;
                        break;
                    case "Stamat":
                        asignName = name;
                        break;
                    case "Ignat":
                        asignName = name;
                        break;
                    case "Zaprqn":
                        asignName = name;
                        break;
                    case "Djintaro":
                        asignName = name;
                        break;
                    case "Miroslav":
                        asignName = name;
                        break;
                    case "Galena":
                        asignName = name;
                        break;
                }
            }
            timer.Stop();
            Console.WriteLine("Switch-Case Time: {0}ms for {1} iterations", timer.ElapsedMilliseconds, iterations);

            timer.Reset();

            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                string name = randomNames[new Random().Next(randomNames.Length)];
                string asignName = string.Empty;
                if (name == "Pesho")
                    asignName = name;
                else if (name == "Gosho")
                    asignName = name;
                else if (name == "Tosho")
                    asignName = name;
                else if (name == "Petq")
                    asignName = name;
                else if (name == "Mariq")
                    asignName = name;
                else if (name == "Stamat")
                    asignName = name;
                else if (name == "Ignat")
                    asignName = name;
                else if (name == "Zaprqn")
                    asignName = name;
                else if (name == "Djintaro")
                    asignName = name;
                else if (name == "Miroslav")
                    asignName = name;
                else if (name == "Galena")
                    asignName = name;
            }
            timer.Stop();
            Console.WriteLine("If-Else Time: {0}ms for {1} iterations", timer.ElapsedMilliseconds, iterations);
        }

        private static void IterableTest()
        {
            var nums = NextNum();

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> NextNum()
        {
            var num = 1;
            while (true)
            {
                yield return num++;
            }
        }

        private static void PopulateFile()
        {
            using (StreamWriter sw = new StreamWriter("file.txt", true))
            {
                for (int i = 0; i < 100000; i++)
                {
                    sw.WriteLine("Some random line...");
                }
            }
        }

        private static List<string> ReadFile()
        {
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list;
        }

        private static IEnumerable<string> YieldReadFile()
        {
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
