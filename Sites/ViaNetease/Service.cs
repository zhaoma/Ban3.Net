using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease;
using Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Netease;
using Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Netease;
using log4net;

namespace Ban3.Sites.ViaNetease
{
    public class Service
        :Interfaces.Platforms.INetease
    {
        private readonly ILog _logger;
        private readonly IDataCollection _collector;

        /// 
        public Service(ILog logger, IDataCollection collector)
        {
            _logger = logger;
            _collector = collector;
        }

        public DownloadDailyPricesResult DownloadDailyPrices(DownloadDailyPrices request)
        {
            var bytes = _collector.Download(request.NetResource());

            return new DownloadDailyPricesResult { Data=bytes};
        }

        public ReadRealtimePricesResult ReadRealtimePrices(ReadRealTime request)
        {
            var js = _collector.GetContent(request.NetResource());
            var json = js.Substr("_ntes_quote_callback(", "})");

            return new ReadRealtimePricesResult { Data = json.JsonToObj<Dictionary<string, StockRecord>>() };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Netease StockFinance List</returns>
        public DownloadFinancesResult DownloadFinances(DownloadFinances request)
        {
            var csv= _collector.GetContent(request.NetResource());
            return new DownloadFinancesResult { Data=ParseFinances(csv)};
        }

        List<StockFinance> ParseFinances(string csv)
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
}