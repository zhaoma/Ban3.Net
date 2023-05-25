using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using Ban3.Infrastructures.Consoles;

namespace Lcmonitor
{
    internal class Program
    {
        private static List<string> LibPathList =new List<string>
        {
            @"D:\CTS\Development\ICS\SHA.SERV\bin\Debug",
            @"D:\GIT\Ban3.Net\Labs\ConsolesDemo\Lost\bin\Debug\netstandard2.0"
        };
        private const string ExePath = @"syngo.Common.LCMService.exe";

        private static Assembly? ResolveRequest(object? sender, ResolveEventArgs e)
        {
            Console.WriteLine("ResolveRequest");
            var targetName = e.Name.Split(",")[0].Trim() + ".dll";
            targetName.WriteColorLine(ConsoleColor.Red);

            foreach (var path in LibPathList)
            {
                var lib = Path.Combine(path, targetName);
                if (File.Exists(lib))
                {
                    return Assembly.LoadFile(lib);
                }
            }

            return null;
        }

        private static void AfterLoaded(object? sender, AssemblyLoadEventArgs e)
        {
            var info = $"{sender?.GetType().Name}-{e.LoadedAssembly.FullName}";
            info.WriteColorLine(ConsoleColor.Green);
        }

        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += ResolveRequest;
            AppDomain.CurrentDomain.AssemblyLoad += AfterLoaded;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("HE");
            Lost.Deleted.Found();

            Console.ReadKey();
        }
    }
}