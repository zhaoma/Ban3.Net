using System.Collections.Generic;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static Diagram CreateOnesDiagram(
        this IReportor _,
        Stock stock,
        List<StockPrice> prices,
        LineOfPoint indicatorValue)
    {
        var diagram=Infrastructures.Charts.Helper.CreateDiagram(SeriesType.Candlestick.cre)

        diagram.AddSeries()

        return diagram;
    }
}