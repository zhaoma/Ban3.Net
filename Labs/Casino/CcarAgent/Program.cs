using Ban3.Infrastructures.Common.Attributes;
using Ban3.Productions.Casino.CcaAndReport;

namespace Ban3.Labs.Casino.CcarAgent;

[TracingIt]
internal class Program
{
    static async Task Main(string[] args)
    {
        

        await Signalert.ExecuteDailyJob();

    }
}