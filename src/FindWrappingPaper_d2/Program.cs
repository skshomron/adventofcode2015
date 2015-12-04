using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FindWrappingPaper_d2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var fileName = "AllDimensions.txt";
            if (File.Exists(fileName))
            {
                var s = File.ReadLines(fileName).ToList();
                List<List<int>> lwh = new List<List<int>>();
                s.ForEach(x =>
                {
                    List<int> l = new List<int>();
                    x.Split('x').ToList().ForEach(xx => l.Add(int.Parse(xx)));
                    lwh.Add(l);
                });

                ComputeTotalSheet(lwh);


                ComputeTotalRibbon(lwh);
            }
            Console.ReadKey();
        }

        private static void ComputeTotalSheet(List<List<int>> lwh)
        {
            
            var total = 0;
            lwh.ForEach(x =>
            {
                total += ComputeArea(x[0], x[1], x[2]) + ComputeExtraSheet(x);
            });

            Console.WriteLine($"total sheet area = {total}");
        }

        private static void ComputeTotalRibbon(List<List<int>> lwh)
        {
            var total = 0;
            lwh.ForEach(x =>
            {
                total += ComputeCubicFeet(x) + ComputeSmalestPerimeter(x);
            });

            Console.WriteLine($"total ribbon Lenght = {total}");

        }

        private static int ComputeSmalestPerimeter(List<int> ints)
        {
            ints.Remove(ints.Max());
            return 2*(ints.Sum());
        }

        private static int ComputeCubicFeet(List<int> ints)
        {
            var total = 1;
            ints.ForEach(x => total *= x);
            return total;
        }

        static int ComputeArea(int l, int h, int w)
        {
            int area = 0;
            area = 2*(l*h + l*w + h*w);
            return area;
        }

        static int ComputeExtraSheet(IList<int> dims )
        {
            var max = dims.Max();
            dims.Remove(max);
            if (dims.Count == 2)
            {
                var extra = dims[0]*dims[1];
                dims.Add(max);
                return extra;
            }
            throw new Exception();
        }
    }
}
