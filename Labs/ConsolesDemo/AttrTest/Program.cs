using System;

namespace AttrTest
{
    internal class Program
    {
        public Program(){}

        static void Main(string[] args)
        {
            var t10 = F2(10);

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

        static int F2(int n)
        {
            switch (n)
            {
                case 1: return 1;
                case 2: return 1;
                default:
                    int a = 1;
                    int b = 1;
                    int c = 0;

                    for (int i = 3; i <= n; i++)
                    {
                        c = a + b;
                        a = b;
                        b = c;
                    }
                    return c;
            }
        }

        public static void StaticWriteYes()
        {
            Console.WriteLine("YES");
        }
    }
}
