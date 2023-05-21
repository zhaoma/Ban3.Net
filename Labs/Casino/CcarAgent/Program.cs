using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Extensions;

namespace Ban3.Labs.Casino.CcarAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Signalert.Collector.Sites.PrepareAllCodesFromTushare();

            var allCodes = Productions.Casino.Contracts.Extensions.Helper.LoadAllCodes(null);
            Console.WriteLine(allCodes.Count);

            //Signalert.Collector.Sites.DownloadAllIcons();

            var codes = allCodes.Take(1).Select(o => o.Code).ToList();

            var s = DateTime.Now.AddMonths(-1).ToString("yyyyMMdd");
            var e = DateTime.Now.ToString("yyyyMMdd");

            Signalert.Collector.Sites.GetDailyPrices(codes,s,e);
        }
    }
}