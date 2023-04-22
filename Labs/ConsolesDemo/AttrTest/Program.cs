using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttrTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new TargetType();

            Console.WriteLine($"before {t.R}");

            t.R = 100;

            Console.WriteLine($"after {t.R}");

            Console.ReadKey();
        }
    }
}
