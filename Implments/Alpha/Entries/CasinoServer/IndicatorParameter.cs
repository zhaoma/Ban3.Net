//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;
using Ban3.Implements.Alpha.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 
/// </summary>
public class IndicatorParameter
{
    /// see interface
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public AMOUNT AMOUNT { get; set; }

    /// see interface
    [JsonProperty("ma", NullValueHandling = NullValueHandling.Ignore)]
    public MA MA { get; set; }

    /// see interface
    [JsonProperty("macd", NullValueHandling = NullValueHandling.Ignore)]
    public MACD MACD { get; set; }

    /// see interface
    [JsonProperty("mx", NullValueHandling = NullValueHandling.Ignore)]
    public MX MX { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IndicatorParameter()
    {
        AMOUNT = new AMOUNT();
        MA = new MA();
        MACD = new MACD();
        MX = new MX();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dailyPrices"></param>
    /// <returns></returns>
    public List<Remark> GenerateRemarks(List<Price> dailyPrices)
    {
        var remarks = new List<Remark>();

        var weekly = new List<Price>();

        var monthly = new List<Price>();

        var dailyIndex = Serials(dailyPrices);

        for (int i = 0; i < dailyPrices.Count; i++)
        {
            weekly.AppendLatest(dailyPrices[i], CycleIs.Weekly);

            monthly.AppendLatest(dailyPrices[i], CycleIs.Monthly);

            remarks.Add(
                new Remark
                {
                    DayPrice = dailyPrices[i],
                    Suggest = SuggestIs.Skip,
                    DayOutput=dailyIndex[i],
                    WeekOutput=Serials(weekly).Last(),
                    MonthOutput=Serials(monthly).Last()
                });
        }

        return remarks;
    }

    private List<Output> Serials(List<Price> prices)
    {
        var outputs = prices.Select((p, index) => new Output
        {
            AMOUNT = new Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues.AMOUNT
            {
                Short = prices.MA((p) => p.Amount, index, AMOUNT.Parameters["SHORT"]),
                Long = prices.MA((p) => p.Amount, index, AMOUNT.Parameters["LONG"])
            },
            MA = new Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues.MA
            {
                Short = prices.MA((p) => p.Close, index, MA.Parameters["SHORT"]),
                Long = prices.MA((p) => p.Close, index, MA.Parameters["LONG"])
            },
            MACD = new Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues.MACD
            {
                DIF = prices.EMA((p) => p.Close, index, MACD.Parameters["SHORT"])
                    - prices.EMA((p) => p.Close, index, MACD.Parameters["LONG"])
            },
            MX = new Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues.MX()
        }).ToList();

        var mxs = prices.Select((p) => (2 * p.Close + p.High + p.Low) / 4).ToList();

        var mx1 = mxs.Select((p, index) => mxs.EMA(index, MX.Parameters["M"])).ToList();
        var mx2 = mx1.Select((p, index) => mx1.EMA(index, MX.Parameters["M"])).ToList();
        var mx3 = mx2.Select((p, index) => mx2.EMA(index, MX.Parameters["M"])).ToList();

        var buy = mx3.Select((p, index) => index > 0 && mx3[index - 1] > 0 ? (mx3[index] - mx3[index - 1]) / mx3[index - 1] * 100m : 0).ToList();

        for (var i = 0; i < outputs.Count; i++)
        {
            outputs[i].MACD.DEA = outputs.Select(o => o.MACD.DIF).ToList().EMA(i, MACD.Parameters["MID"]);
            outputs[i].MACD.Histogram = outputs[i].MACD.DIF - outputs[i].MACD.DEA;

            if (i > 0)
            {
                outputs[i].MX.Buy = buy[i];
                outputs[i].MX.Sell = buy.MA(i, MX.Parameters["N"]);
            }
        }

        return outputs;
    }
}
