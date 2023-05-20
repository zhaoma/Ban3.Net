using System.Reflection;

namespace Attre
{
    internal class Program
    {
        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs e)
            {

                Console.WriteLine(e.Name);

                return Assembly.LoadFile(@"D:\GIT\Ban3.Net\Labs\ConsolesDemo\Lost\bin\Debug\netstandard2.0\Lost.dll");

            };


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Lost.Deleted.Found();

            Console.ReadKey();
        }
    }
}