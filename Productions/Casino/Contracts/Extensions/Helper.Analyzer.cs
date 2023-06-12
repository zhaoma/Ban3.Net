
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using System;
using Ban3.Infrastructures.Indicators.Inputs;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{

    static Infrastructures.Indicators.Enums.StockOperate GetOperate(
        IEnumerable<string> codeKeys,
        IEnumerable<string[]> filterBuy,
        IEnumerable<string[]> filterSell,
        Infrastructures.Indicators.Enums.StockOperate prevOperation)
    {
        switch (prevOperation)
        {
            case Infrastructures.Indicators.Enums.StockOperate.Buy:
            case Infrastructures.Indicators.Enums.StockOperate.Keep:
                return codeKeys.AllFoundIn(filterSell)
                    ? Infrastructures.Indicators.Enums.StockOperate.Sell
                    : Infrastructures.Indicators.Enums.StockOperate.Keep;

            case Infrastructures.Indicators.Enums.StockOperate.Sell:
            case Infrastructures.Indicators.Enums.StockOperate.Left:
                return codeKeys.AllFoundIn(filterBuy)
                    ? Infrastructures.Indicators.Enums.StockOperate.Buy
                    : Infrastructures.Indicators.Enums.StockOperate.Left;
        }

        return Infrastructures.Indicators.Enums.StockOperate.Left;
    }


    ///
    public static List<StockOperate> OutputDailyOperates(
        this Profile profile,
        List<StockSets> everydayKeys,
        string code)
    {
        try
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
                operates[op].Operate = GetOperate(everydayKeys[op].SetKeys, profile.BuySets, profile.SellSets, currentOp);
                currentOp = operates[op].Operate;
            }

            $"{code}.{profile.Identity}"
                .DataFile<StockOperate>()
                .WriteFile(operates.ObjToJson());

            return operates;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    public static List<StockOperate> LoadDailyOperates(
        this Profile profile, string code)
    {
        return $"{code}.{profile.Identity}"
            .DataFile<StockOperate>()
            .ReadFileAs<List<StockOperate>>();
    }

    ///
    public static List<StockOperationRecord> ConvertOperates2Records(
        this List<StockOperate> stockOperates, Profile profile, string code)
    {
        var tradeRecords = new List<StockOperationRecord>();

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

        return tradeRecords;
    }

    public static List<StockOperationRecord> LoadOperationRecords(
        this Profile profile, string code)
    {
        return $"{code}.{profile.Identity}"
            .DataFile<StockOperationRecord>()
            .ReadFileAs<List<StockOperationRecord>>();
    }
}