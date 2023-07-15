using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.Charts.Entries;

public class CandlestickData
{
    public List<CandlestickRecord>? Records { get; set; }

    public object? ChartData()
        => Records?
            .Select(o => new object[] { o.Open, o.Close, o.Low, o.High})
            .ToList();

    public object? CategoryData()
        => Records?
            .Select(o => o.TradeDate.ToYmd())
            .ToList();
}