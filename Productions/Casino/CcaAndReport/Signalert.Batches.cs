using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Extensions;
using System.Collections.Generic;
using System;
using Ban3.Productions.Casino.Contracts;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    #region 计算复权因子并重新计算行情

    public static void PrepareEventsAndSeeds(List<Contracts.Entities.Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        Collector.PrepareAllEvents(allCodes);

        ReinstateAllPrices(allCodes);
    }
    
    public static bool ReinstateAllPrices(List<Contracts.Entities.Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        var result = true;

        allCodes.ParallelExecute((stock) =>
        {
            try
            {
                var ps = Collector.LoadDailyPrices(stock.Code);

                var reinstateOne = Calculator.ReinstatePrices(stock.Code, stock.Symbol, ps);

                result = result && reinstateOne;
            }
            catch (Exception ex)
            {
                Logger.Error(stock.Code);
                Logger.Error(ex);
            }
        },
            Config.MaxParallelTasks);

        return result;
    }

    #endregion
}