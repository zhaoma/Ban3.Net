using System.Security.AccessControl;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using log4net;

namespace Ban3.Labs.Casino.CcarAgent;

internal class Program
{
    static void Main(string[] args)
    {
        //await Signalert.ExecuteDailyJob();
        
        var allCodes = Signalert.Collector.LoadAllCodes();
        Console.WriteLine($"{allCodes.Count}");
        
        Console.WriteLine("PrepareAllSets");
        var now = DateTime.Now;
       Signalert.PrepareAllSets(allCodes);

       Console.WriteLine(DateTime.Now.Subtract(now).TotalMilliseconds + " ms");
    }
}