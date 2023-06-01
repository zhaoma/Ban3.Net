using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Labs.Casino.CcarAgent;

[TracingIt]
internal class Program
{
    static async Task Main(string[] args)
    {
        //await Signalert.ExecuteDailyJob();
        var allCodes = Signalert.Collector.LoadAllCodes();

        var stock = allCodes.FindLast(o => o.Symbol == "688004");
        var d=Signalert.PrepareDiagram(stock);
        
        d.ObjToJson().WriteColorLine(ConsoleColor.Red);

        stock.Code.DataFile<Diagram>()
            .WriteFile(d.ObjToJson());


        //Signalert.Collector.Sites.FixAllDailyPrices();
        //Signalert.Collector.ReadRealtime();
        //var reinstate= await Signalert.ReinstateAllPrices();

        //if (reinstate)
        //{
        //    var allCodes = Signalert.Collector.LoadAllCodes();

        //    await allCodes.ParallelExecuteAsync((stock) =>
        //    {
        //        Signalert.Calculator.GenerateIndicatorLine(stock.Code);
        //    }, Config.MaxParallelTasks);

        //}
    }

    /*
     *        var r=Signalert.Collector.PrepareAllCodes();
        Console.WriteLine(r);
     *
        allCodes.ParallelExecute((o) =>
        {
            o.Code.WriteColorLine(ConsoleColor.Blue);
            var ps = Signalert.Collector.Sites.LoadOnesDailyPrices(o.Code);

            var newList=new List<StockPrice>();

            foreach (var stockPrice in ps)
            {
                if(newList.All(x => x.TradeDate != stockPrice.TradeDate))
                    newList.Add(stockPrice);
            }

            newList.SetsFile(o.Code)
                .WriteFile(newList.ObjToJson());
        },50);
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