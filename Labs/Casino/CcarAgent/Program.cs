using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Extensions;

namespace Ban3.Labs.Casino.CcarAgent;

internal class Program
{
    static void Main(string[] args)
    {
        //Signalert.Collector.Sites.FixAllDailyPrices();

        var r=Signalert.Collector.PrepareAllCodes();
        Console.WriteLine(r);
    }

    /*
     *
     *
     *
        //Signalert.Collector.Sites.PrepareAllCodesFromTushare();

        //var allCodes = Productions.Casino.Contracts.Extensions.Helper.LoadAllCodes(null);
        //Console.WriteLine(allCodes.Count);

        //allCodes.ParallelExecute((stock) =>
        //{
        //    $"{stock.Code}:{stock.Name} start parse...".WriteColorLine(ConsoleColor.Red);
        //    Signalert.Collector.Sites.PrepareOnesDailyPrices(stock.Code);
        //},Config.MaxParallelTasks);

        //allCodes.ForEach(stock =>
        //{
        //    $"{stock.Code}:{stock.Name} start parse...".WriteColorLine(ConsoleColor.Red);
        //    Signalert.Collector.Sites.PrepareOnesDailyPrices(stock.Code);
        //});
     *
     *        var c = allCodes.Take(1).ToList();

        var code = c[0].Code;
        code.WriteColorLine(ConsoleColor.DarkYellow);

        Signalert.Collector.Sites.PrepareOnesDailyPrices(code);

        var ps = Signalert.Collector.Sites.LoadOnesDailyPrice(code);

        var dup = ps.GroupBy(o => o.TradeDate).Where(o=>o.Count()>1).Select(o => o.Key).ToList();

        Console.WriteLine($"{ps.Count} prices;{dup.Count} dup.");

        ps.ForEach(o => { $"{o.TradeDate}:{o.Close}".WriteColorLine(ConsoleColor.DarkRed); });
     *
     *
     *
     *
     *
     *
     *
     */
}