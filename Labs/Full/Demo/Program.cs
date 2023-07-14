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
using log4net;

namespace Demo
{
    internal class Program
    {
        static readonly ILog Logger = LogManager.GetLogger(typeof(Program));


        static void Main(string[] args)
        {
            Logger.Debug("DEBUG line 22");

            if (Ban3.Infrastructures.Common.Config.LoggerStandby)
            {
                Logger.Debug("DEBUG line 26");
            }

            Console.ReadKey();
        }


        /*
         *
            var f = "D:\\Program.cs";
            var sourceCodeLines =new string[]{ f.ReadFile()};

            var assembly = sourceCodeLines.CompileSourceCodes(new List<string>()
            {
                "System.dll"
            });

            if (assembly != null)
            {
                var target = assembly.CreateInstance("AttrTest.Program");
                target.InvokeMethod("Fibonacci", new object[]{10});
            }

            Console.ReadKey();
         *            var f = "D:\\DayData_SH_V43.dat";

            var length = 516;
            var arr = new byte[length];
            var p = 0;

            using (var fs = new FileStream(f, FileMode.Open))
            {
                Console.WriteLine($"fs.Length={fs.Length}");

                int readBytes;

                while ((readBytes = fs.Read(arr,0, p==0?40:length)) > 0)
                {
                    p++; 

                    $"page {p}:{readBytes}".WriteColorLine(ConsoleColor.DarkRed);
                    Convert(arr).WriteColorLine(ConsoleColor.DarkYellow);
                    //Console.ReadKey();
                    
                }
            }
         *
         */
        static string Convert(byte[] bytes)
        {
            return string.Join( "-", bytes);
        }
    }
}
