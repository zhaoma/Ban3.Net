using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Productions.Casino.Contracts.Request;
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

    private static readonly Func<string, RenderView, bool> StrFilter =
        (str, filter) =>
        {
            var result =  (string.IsNullOrEmpty(filter.StartsWith) ||str.StartsWithIn(filter.StartsWith.Split(',')));
            result = result && (string.IsNullOrEmpty(filter.EndsWith) || str.EndsWith(filter.EndsWith));
            result = result && (string.IsNullOrEmpty(filter.Id) || str == filter.Id);
            return result;
        };

    private static readonly Func<DotInfo, RenderView, bool> DotFilter =
        (dot, filter) =>
        {
            var result = (filter.RedOnly is 0 or null || dot.ChangePercent > 0);
            result = result && (filter.GreenOnly is 0 or null || dot.ChangePercent < 0);
            result = result && StrFilter(dot.Code,filter);

            return result;
        };


}