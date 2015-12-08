using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventCoins_d4
{
    class Program
    {
        static MD5 m_d5 = MD5.Create();
        static void Main(string[] args)
        {
            var entrySource = "ckczppom";

            bool found = false;
            int index = -1;
            while (!found)
            {
                index++;
                found = IsFound(GenerateHash(entrySource + index));
            }

            Console.WriteLine(index);
            Console.ReadKey();
        }

        private static string GenerateHash(string s)
        {
            var result = m_d5.ComputeHash(Encoding.UTF8.GetBytes(s));
            var hexa = "";
            result.ToList().ForEach(x => hexa += x.ToString("X2"));
            return hexa;
        }

        private static bool IsFound(string generateHash)
        {
            return generateHash.StartsWith("000000");
        }
    }
}
