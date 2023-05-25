using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Emit;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Consoles.Entries;

namespace Lcmonitor
{
    internal class Program
    {
        private const string SomarisBin = @"D:\CTS\Development\ICS\SHA.SERV\bin\Debug";
        private const string ExeFile = @"syngo.Common.LCMService.exe";
        private static List<string> SupportedExts = new List<string> { ".dll", "exe" };

        private static Assembly RequestResolve(object sender, ResolveEventArgs e)
        {
                //e.RequestingAssembly.ManifestModule.Name;
            var targetName =
                e.Name.Split(',')[0].Trim();
            targetName.WriteColorLine(ConsoleColor.Red);

            var lib =
                SupportedExts
                    .Select(o => Path.Combine(SomarisBin, targetName + o))
                    .First(o => File.Exists(o));
            $"{e.Name}->{lib}".WriteColorLine(ConsoleColor.DarkBlue);
            if (File.Exists(lib))
            {
                return Assembly.LoadFile(lib);
            }

            return null;
        }

        private static void AfterLoaded(object sender, AssemblyLoadEventArgs e)
        {
            var info = $"{e.LoadedAssembly.FullName}";
            info.WriteColorLine(ConsoleColor.Green);
        }

        public static Assembly RequestResolveType(object sender, ResolveEventArgs e)
        {
            Console.WriteLine("RequestResolveType");
            var targetName = e.Name.Split(',')[0].Trim();
            targetName.WriteColorLine(ConsoleColor.DarkYellow);

            var lib =
                SupportedExts
                    .Select(o => Path.Combine(SomarisBin, targetName + o))
                    .First(o => File.Exists(o));

            if (File.Exists(lib))
            {
                return Assembly.LoadFile(lib);
            }

            return null;
        }

        public static void OnException(object sender, UnhandledExceptionEventArgs e)
        {
            $"error b".WriteErrorLine();
        }

        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += RequestResolve;
            AppDomain.CurrentDomain.AssemblyLoad += AfterLoaded;
            AppDomain.CurrentDomain.TypeResolve += RequestResolveType;
            AppDomain.CurrentDomain.UnhandledException += OnException;
        }

        static void Main(string[] args)
        {
            InvokeLcm();

            //InvokeSystemMonitor();

            Console.ReadKey();
        }

        static void InvokeSystemMonitor()
        {
            var assembly = Assembly.LoadFile(Path.Combine(SomarisBin, @"CT.AppCommon.SystemMonitor.Application.exe"));
            var entryType = assembly.GetType("CT.AppCommon.SystemMonitor.Application.App", true, true);
            var entryPoint = assembly.EntryPoint;
            if (entryPoint != null)
            {
                entryType.InvokeMember(
                    entryPoint.Name,
                    BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                    null,
                    null,
                    null);
            }
        }

        static void InvokeLcm()
        {
            var assembly = Assembly.LoadFile(Path.Combine(SomarisBin, ExeFile));
            var selectedType = assembly.GetType("syngo.Common.LCMService.Program", true, true);
            var method = assembly.EntryPoint;
            //selectedType.GetMethod("Fibonacci", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            if (method != null)
            {

                //Action a = (Action)method.CreateDelegate(typeof(Action));
                //a();

                selectedType.InvokeMember(
                    "Main",
                    BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                    null,
                    null,
                    null);

                //method.Invoke()

            }
            else
            {
                $"NOT found".WriteColorLine(ConsoleColor.Red);
            }
        }
    }
}
