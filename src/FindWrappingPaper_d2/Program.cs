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
            int total = 0;
            var fileName = "AllDimensions.txt";
            if (File.Exists(fileName))
            {
                var s = File.ReadLines(fileName).ToList();
                
                s.ForEach(x =>
                {
                    List<int>lwh = new List<int>(); 
                    x.Split('x').ToList().ForEach(xx=>lwh.Add(int.Parse(xx)));
                    total += ComputeArea(lwh[0], lwh[1], lwh[2]) + ComputeExtraSheet(lwh);
                });
            }

            Console.WriteLine($"{total}");
            Console.ReadKey();
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
            if(dims.Count == 2)
                return dims[0]*dims[1];
            throw new Exception();
        }
    }
}
