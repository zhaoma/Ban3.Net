using System;

namespace AttrTest
{
    internal class Program
    {
        public Program(){}

        static void Main(string[] args)
        {
            var t10 = Fibonacci(10);

            Console.WriteLine($"#.10={t10}");

            Console.ReadKey();
        }

        static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void StaticWriteYes()
        {
            Console.WriteLine("YES");
        }
    }
}
