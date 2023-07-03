using System.Collections.Generic;
using System.Linq;
using Ban3.Sites.ViaTushare.Entries;
using log4net;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));
    static object _lock = new();

    public static List<StockPrice> CloneNew(this List<StockPrice> prices, int len)
    {
       return prices.Take(len)
            .Select(o => new StockPrice
            {
                Code = o.Code,
                TradeDate = o.TradeDate,
                Open = o.Open,
                High = o.High,
                Low = o.Low,
                Close = o.Close,
                PreClose = o.PreClose,
                Change = o.Change,
                ChangePercent = o.ChangePercent,
                Vol = o.Vol,
                Amount = o.Amount
            }).ToList();
    }
}