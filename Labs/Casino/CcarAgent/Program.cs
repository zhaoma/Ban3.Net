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
        await Signalert.ExecuteDailyJob();
        Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds + " ms");
        // var allCodes = Signalert.Collector.LoadAllCodes();
        // Console.WriteLine($"{allCodes.Count}");

        // Console.WriteLine("PrepareAllSets");
        // 
        //Signalert.PrepareAllSets(allCodes);

        //Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds + " ms");

        //var x=Signalert.Collector.Sites.Pre("688004.SH");
        //var y = Signalert.Collector.Sites.LoadOnesDailyPrices("688004.SH");
        //x.ObjToJson().WriteColorLine(ConsoleColor.Red);
        //y.ObjToJson().WriteColorLine(ConsoleColor.Red);
    }
}