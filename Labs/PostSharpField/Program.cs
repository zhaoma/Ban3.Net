using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;

namespace PostSharpMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            People p = new People();
            p.Name = "Mike1";
            Console.WriteLine(p.Name);
            Console.ReadLine();
        }

    }
    public class People
    {
        [TestAspect]
        public string Name { get; set; }
    }

}
