using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShortenURLTests
{

    class Program
    {
       
        //[Microsoft.SqlServer.Server.SqlFunction]
        //public static Dictionary<long, string> Generate(SqlInt64 last)
        //{
        //    return encode(last.Value + 1);
        //}

        //[Microsoft.SqlServer.Server.SqlFunction]
        //public static SqlInt64 Decode(string hash)
        //{
        //    return new SqlInt64(decode(hash));
        //}

        //public static long decode(string hash)
        //{
        //    return Decode(hash);
        //}

        //public static Dictionary<long, string> encode(long uniqueId)
        //// generates a unique, random, and alphanumeric token
        //{
        //    const string availableChars =
        //        "0123456789abcdefghijklmnopqrstuvwxyz";
        //    var idWithToken = new Dictionary<long, string>();

        //    using (var generator = new RNGCryptoServiceProvider())
        //    {
        //        var bytes = new byte[5];
        //        generator.GetBytes(bytes);
        //        var chars = bytes
        //            .Select(b => availableChars[b % availableChars.Length]);
        //        var token = new string(chars.ToArray());

        //        if (!idWithToken.ContainsKey(uniqueId))
        //            idWithToken[uniqueId] = token;

        //        return idWithToken;
        //    }
        //}

        private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            Console.WriteLine(Generate(2176782334));
            Console.WriteLine(Generate(2176782335));
            Console.WriteLine(Generate(2176782336));
            Console.WriteLine(Generate(2176782337));
            Console.WriteLine(Generate(1));
            Console.WriteLine(Generate(56800235584));
        }


        [Microsoft.SqlServer.Server.SqlFunction]
        public static string Generate(SqlInt64 last)
        {
            return encode(last.Value + 1);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 Decode(string hash)
        {
            Console.WriteLine(hash);
            int index = hash.IndexOf('-');
            hash = hash.Substring(index + 1, hash.Length - index - 1);
            Console.WriteLine(hash);
            return new SqlInt64(decode(hash));
        }

        private static string encode(long input)
        {
            char[] clistarr = CharList.ToCharArray();
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(clistarr[input % CharList.Length]);
                input /= CharList.Length;
            }
            if (result.Count() < 6)
            {
                result.Push('-');
                var random = new Random();
                while (result.Count() < 6)
                {
                    var randomChars = CharList[random.Next(CharList.Length)];
                    result.Push(randomChars);
                }
            }
            return new string(result.ToArray());
        }

        private static long decode(string input)
        {
            var reversed = input.ToLower().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(CharList.Length, pos);
                pos++;
            }
            return result;
        }
    }
}

