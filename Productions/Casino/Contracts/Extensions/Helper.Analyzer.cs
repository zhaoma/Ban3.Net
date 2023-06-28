using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using System;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IAnalyzer扩展方法，分析相关
/// </summary>
public static partial class Helper
{
    #region 生成每日操作建议

    /// <summary>
    /// 根据策略与每日特征生成每日操作建议
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="everydayKeys"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperate> OutputDailyOperates(
        this IAnalyzer _,
        Profile profile,
        List<StockSets> everydayKeys,
        string code)
    {
        try
        {
            if (everydayKeys != null && everydayKeys.Any())
            {
                var operates = everydayKeys.Select(o => new StockOperate
                {
                    MarkTime = o.MarkTime,
                    Operate = Infrastructures.Indicators.Enums.StockOperate.Left,
                    Close = o.Close
                }).ToList();

                var currentOp = Infrastructures.Indicators.Enums.StockOperate.Left;
                for (int op = 0; op < operates.Count(); op++)
                {
                    operates[op].Operate = GetOperate(everydayKeys[op].SetKeys, profile.BuyingJudge, profile.SellingJudge,
                        currentOp);
                    currentOp = operates[op].Operate;
                }

                $"{code}.{profile.Identity}"
                    .DataFile<StockOperate>()
                    .WriteFile(operates.ObjToJson());

                return operates;
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"fault when OutputDailyOperates {code}");
            Logger.Error(ex);
        }

        return null;
    }

    /// <summary>
    /// 根据前一记录和策略生成当前操作建议
    /// </summary>
    /// <param name="codeKeys"></param>
    /// <param name="buyingJudge"></param>
    /// <param name="sellingJudge"></param>
    /// <param name="prevOperation"></param>
    /// <returns></returns>
    static Infrastructures.Indicators.Enums.StockOperate GetOperate(
        IEnumerable<string> codeKeys,
        Func<StockSets, bool> buyingJudge,
        Func<StockSets, bool> sellingJudge,
        Infrastructures.Indicators.Enums.StockOperate prevOperation)
    {
        switch (prevOperation)
        {
            case Infrastructures.Indicators.Enums.StockOperate.Buy:
            case Infrastructures.Indicators.Enums.StockOperate.Keep:
                return //codeKeys.AllFoundIn(filterSell)
                    buyingJudge(new StockSets { SetKeys = codeKeys })
                        ? Infrastructures.Indicators.Enums.StockOperate.Sell
                        : Infrastructures.Indicators.Enums.StockOperate.Keep;

            case Infrastructures.Indicators.Enums.StockOperate.Sell:
            case Infrastructures.Indicators.Enums.StockOperate.Left:
                return //codeKeys.AllFoundIn(filterBuy)
                    sellingJudge(new StockSets { SetKeys = codeKeys })
                        ? Infrastructures.Indicators.Enums.StockOperate.Buy
                        : Infrastructures.Indicators.Enums.StockOperate.Left;
        }

        return Infrastructures.Indicators.Enums.StockOperate.Left;
    }

    /// <summary>
    /// 加载每日操作建议记录
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperate> LoadDailyOperates(
        this IAnalyzer _,
        Profile profile,
        string code)
    {
        return $"{code}.{profile.Identity}"
            .DataFile<StockOperate>()
            .ReadFileAs<List<StockOperate>>();
    }

    /// <summary>
    /// 根据每日操作建议记录创建操作纪录
    /// </summary>
    /// <param name="stockOperates"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord> ConvertOperates2Records(
        this List<StockOperate>? stockOperates, Profile profile, string code)
    {
        try
        {
            var tradeRecords = new List<StockOperationRecord>();

            if (stockOperates != null && stockOperates.Any())
            {

                foreach (var op in stockOperates)
                {
                    var latest = tradeRecords.Any()
                        ? tradeRecords.Last()
                        : null;

                    if (op.Operate == Infrastructures.Indicators.Enums.StockOperate.Buy)
                    {
                        if (latest == null || latest.SellPrice > 0)
                        {
                            latest = new StockOperationRecord
                            {
                                BuyDate = op.MarkTime,
                                BuyPrice = op.Close,

                            };
                            tradeRecords.Add(latest);
                        }
                    }

                    if (op.Operate == Infrastructures.Indicators.Enums.StockOperate.Sell)
                    {
                        if (latest != null)
                        {
                            latest.SellDate = op.MarkTime;
                            latest.SellPrice = op.Close;
                        }
                    }
                }

                if (profile.Persistence)
                    $"{code}.{profile.Identity}"
                        .DataFile<StockOperationRecord>()
                        .WriteFile(tradeRecords.ObjToJson());
            }

            return tradeRecords;
        }
        catch (Exception ex)
        {
            Logger.Error($"fault when ConvertOperates2Records {code}");
            Logger.Error(ex);
        }

        return null;
    }

    /// <summary>
    /// 加载操作纪录
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord> LoadOperationRecords(
        this IAnalyzer _,
        Profile profile,
        string code)
    {
        return $"{code}.{profile.Identity}"
            .DataFile<StockOperationRecord>()
            .ReadFileAs<List<StockOperationRecord>>();
    }

    #endregion


}