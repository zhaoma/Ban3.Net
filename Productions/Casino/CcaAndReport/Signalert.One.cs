#nullable enable
using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.CcaAndReport;

/// <summary>
/// 单标的处置
/// </summary>
public partial class Signalert
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="prices"></param>
    /// <param name="formulas"></param>
    /// <param name="dailySets"></param>
    public static bool ParseOne(
        Stock stock,
        List<Price>? prices,
        Full? formulas,
        out List<StockSets>? dailySets)
    {
        dailySets = null;
        try
        {
            var dailyPrices = prices
                              ?? Calculator.LoadPricesForIndicators(stock.Code, StockAnalysisCycle.DAILY);

            if (dailyPrices.SplitWeeklyAndMonthly(out var weeklyPrices, out var monthlyPrices))
            {
                weeklyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.WEEKLY));

                monthlyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.MONTHLY));

                var dailyLine = dailyPrices.CalculateIndicators(formulas)
                    .SaveFor(stock, StockAnalysisCycle.DAILY);

                dailySets = dailyLine.LineToSets(stock);

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

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error($"Parser one :{stock.Code} fault.");
            Logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="days"></param>
    public static void CreateAmountDiagram(Stock stock, int days = 5)
    {
        var dailyPrices = typeof(StockPrice).LocalFile(stock.Code).ReadFileAs<List<Price>>();

        if (dailyPrices != null && dailyPrices.SplitAmount(days, out var dailyAmounts))
        {
            var fileName = $"{stock.Code}.Amount";
            var line = dailyAmounts.CalculateIndicators()
                .SaveEntity(_ => fileName);

            if (line != null)
            {
                line.LineToSets(stock)
                    .SaveEntities(fileName);

                dailyAmounts.CreateCandlestickDiagram(line, stock)
                    .SaveFor(fileName);
            }
        }
    }
}