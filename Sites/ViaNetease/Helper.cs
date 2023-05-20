using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaNetease.Entries;
using Ban3.Sites.ViaNetease.Request;
using Ban3.Sites.ViaNetease.Response;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaNetease;

public static class Helper
{
    public static async Task<DownloadDailyPricesResult> DownloadDailyPrices(DownloadDailyPrices request)
    {
        var host = new TargetHost
        {
            Anonymous = true
        };

        var savePath = typeof(StockPrice).LocalFile(request.Code, ".csv");
        savePath = await host.Download(request, savePath);

        return new DownloadDailyPricesResult { Path = savePath };
    }

    public static async Task<ReadRealtimePricesResult> ReadRealtimePrices(ReadRealTime request)
    {
        var dic = await new TargetHost
        {
            Anonymous = true
        }.RequestGeneric<Dictionary<string, StockRecord>>(request);

        return new ReadRealtimePricesResult { Data = dic };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Netease StockFinance List</returns>
    public static async Task<DownloadFinancesResult> DownloadFinances(DownloadFinances request)
    {
        var csv = await new TargetHost
        {
            Anonymous = true
        }.ReadContent(request);
        return new DownloadFinancesResult { Data = ParseFinances(csv) };
    }

    static List<StockFinance> ParseFinances(string csv)
    {
        var result = new List<StockFinance>();
        var lines = csv.Split((char)13);
        if (lines.Length >= 20)
        {
            var a = lines[0].Split(',');
            var b = lines[1].Split(',');
            var c = lines[2].Split(',');
            var d = lines[11].Split(',');
            var e = lines[14].Split(',');
            var f = lines[16].Split(',');
            var g = lines[19].Split(',');

            for (int i = a.Length - 1; i > 0; i--)
            {
                if (!string.IsNullOrEmpty(a[i]))
                {
                    result.Add(new StockFinance
                    {
                        Date = a[i].ToDateTime(),
                        Earnings = b[i].ToDecimal(),
                        Equity = c[i].ToDecimal(),
                        Assets = e[i].ToDecimal() * 10000,
                        Debts = f[i].ToDecimal() * 10000,
                        Profits = d[i].ToDecimal() * 10000,
                        RateOfReturn = g[i].ToDecimal()
                    });
                }
            }
        }

        return result.OrderBy(o => o.Date).ToList();
    }
}