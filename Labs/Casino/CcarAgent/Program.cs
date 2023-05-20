using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Labs.Casino.CcarAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var l = Productions.Casino.Contracts.Extensions.Helper.LoadAllCodes(null);
            Console.WriteLine(l.Count);
            
        }
    }
}