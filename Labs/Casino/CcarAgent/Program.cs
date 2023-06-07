using System.Security.AccessControl;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using log4net;

namespace Ban3.Labs.Casino.CcarAgent;

internal class Program
{
    static async Task Main(string[] args)
    {
        var now = DateTime.Now;
        
        //Signalert.ExecuteDailyJob();


        var r=Signalert.PrepareList();
        Console.WriteLine(r);

        var s = Signalert.LoadList();
        s.ObjToJson().WriteColorLine(ConsoleColor.Red);

        Console.WriteLine(s.Count);

        Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds + " ms");
        // var allCodes = Signalert.Collector.LoadAllCodes();
        // Console.WriteLine($"{allCodes.Count}");

        // Console.WriteLine("PrepareAllSets");
        // 
        //Signalert.PrepareAllSets(allCodes);

        //Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds + " ms");


    }
}