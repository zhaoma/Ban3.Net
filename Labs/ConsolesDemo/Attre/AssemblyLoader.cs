using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace Attre
{
    internal class AssemblyLoader:AssemblyLoadContext
    {
        static AssemblyLoader()
        {
            Console.WriteLine("AssemblyLoader");
        }

        public static void Attach()
        {
            Console.WriteLine("attach");
            
            AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs e)
            {

                Console.WriteLine(e.Name);
                
                return Assembly.LoadFile(@"D:\GIT\Ban3.Net\Labs\ConsolesDemo\Lost\bin\Debug\netstandard2.0\Lost.dll");

            };
        }
    }
}