#nullable enable
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Productions.Casino.Contracts.Extensions;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="prices"></param>
    /// <param name="formulas"></param>
    public static void SpecialParse(Stock stock, List<Price>? prices,Full? formulas)
    {
        var dailyPrices = prices
                          ?? Calculator.LoadPricesForIndicators(stock.Code, StockAnalysisCycle.DAILY);

        if (dailyPrices.SplitWeeklyAndMonthly(out var weeklyPrices, out var monthlyPrices))
        {
            weeklyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.WEEKLY));

            monthlyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.MONTHLY));

            var dailyLine = dailyPrices.CalculateIndicators(formulas)
                .SaveFor(stock, StockAnalysisCycle.DAILY);

            var dailySets = dailyLine.LineToSets(stock);

            var weeklyLine = weeklyPrices.CalculateIndicators()
                .SaveFor(stock, StockAnalysisCycle.WEEKLY);
            var weeklySets = weeklyLine.LineToSets(stock);

            var monthlyLine = monthlyPrices.CalculateIndicators()
                .SaveFor(stock, StockAnalysisCycle.MONTHLY);
            var monthlySets = monthlyLine.LineToSets(stock);

            dailySets.MergeWeeklyAndMonthly(weeklySets, monthlySets)
                .SaveFor(stock);
            
            dailyPrices.CreateCandlestickDiagram(dailyLine!, stock)
                .SaveFor(stock, StockAnalysisCycle.DAILY);

            weeklyPrices.CreateCandlestickDiagram(weeklyLine!, stock)
                .SaveFor(stock, StockAnalysisCycle.WEEKLY);

            monthlyPrices.CreateCandlestickDiagram(monthlyLine!, stock)
                .SaveFor(stock, StockAnalysisCycle.MONTHLY);
        }
    }
}