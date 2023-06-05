using Ban3.Infrastructures.Common.Attributes;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;

namespace Ban3.Labs.Casino.CcarAgent;

[TracingIt]
internal class Program
{
    static async Task Main(string[] args)
    {
        

        //await Signalert.ExecuteDailyJob();

        var code = "688004.SH";
        var s = Signalert.Collector.LoadAllCodes()
            .FindLast(o => o.Code ==code);
        Signalert.PrepareOnesDiagram(s);
    }
}