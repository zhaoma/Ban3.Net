using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var f = "D:\\DayData_SH_V43.dat";

            var length = 1024;
            var arr = new byte[length];
            var p = 0;

            using (var fs = new FileStream(f, FileMode.Open))
            {
                Console.WriteLine($"fs.Length={fs.Length}");

                int readBytes;
                while ((readBytes = fs.Read(arr, 0, length)) > 0)
                {
                    //Console.WriteLine($"{readed}--{arr.Length}");
                    p++; //Console.WriteLine(p);

                    $"page {p}:".WriteColorLine(ConsoleColor.DarkRed);
                    Encoding.UTF8.GetString(arr).WriteColorLine(ConsoleColor.DarkYellow);
                    Console.ReadKey();
                }
            }
        }
    }
}
