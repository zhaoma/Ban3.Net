using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b = new List<int> { 4, 5, 6, 7, 8, 9 };

            // Act
            var c = new List<List<int>> { a, b }.UnionAll();

            Console.WriteLine(c.ObjToJson());

            Console.WriteLine(a.ObjToJson());
            a.AppendDistinct(a.RandomResortList());
            Console.WriteLine(a.ObjToJson());

            a.AppendDistinct(100);
            Console.WriteLine(a.ObjToJson());

            Console.ReadKey();
        }
    }
}
