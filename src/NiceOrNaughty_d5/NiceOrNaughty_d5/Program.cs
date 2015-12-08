using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NiceOrNaughty_d5
{
    class Program
    {
        static void Main(string[] args)
        {

            var entryData = File.ReadAllLines("data.txt").ToList();
            //var entryData = new[]
            //{
            //    "ugknbfddgicrmopn",
            //    "aaa",
            //    "jchzalrnumimnmhp",
            //    "haegwjzuvuyypxyu",
            //    "dvszwmarrgswjxmb"
            //};

            var niceStrings = 0;

            foreach (var entry in entryData)
            {
                //niceStrings += Contains3Voyels(entry) && ContainsDoubleCharInRow(entry) && !ContainsBadSequence(entry) ? 1 : 0;
                niceStrings += ContainsBodygards(entry) && ContainsTwins(entry) ? 1 : 0;
            }

            Console.Write(niceStrings);
            Console.ReadKey();
        }

        private static bool ContainsTwins(string entry)
        {
            string token, restant;
            int index = 0;
            GetChunk(entry,index,out token, out restant);
            while (!restant.Contains(token)&& index<entry.Length-3)
            {
                index++;
                GetChunk(entry, index, out token, out restant);
            }
            return index < entry.Length - 3;
        }

        private static void GetChunk(string entry, int index, out string token, out string restant)
        {
            token = entry.Substring(index, 2);
            restant = entry.Substring(index + 2);
        }

        private static bool ContainsBodygards(string entry)
        {
            for (int i = 0; i < entry.Length - 2; i++)
            {
                if (entry[i] == entry[2 + i])
                    return true;
            }
            return false;
        }

        private static bool Contains3Voyels(string entry)
        {
            var voyels = new[] {'a', 'e', 'i', 'o', 'u'};
            var count = entry.Count(x => voyels.Any(y => x == y)) >= 3;
            return count;
        }

        private static bool ContainsDoubleCharInRow(string entry)
        {
            for (int i = 0; i < entry.Length-1; i++)
            {
                if (entry[i] == entry[1 + i])
                    return true;
            }
            return false;
        }

        private static bool ContainsBadSequence(string entry)
        {
            return entry.Contains("ab") || entry.Contains("cd") || entry.Contains("pq") || entry.Contains("xy");
        }
    }
}
