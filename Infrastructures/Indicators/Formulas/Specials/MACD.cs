﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（MACD）
 * reference:
    /// DIFF线　收盘价短期、长期指数平滑移动平均线间的差
    /// DEA线 DIFF线的M日指数平滑移动平均线
    /// MACD线 DIFF线与DEA线的差，彩色柱状线
    /// 
    /// 参数：SHORT(短期)、LONG(长期)、M 天数，一般为12、26、9
    /// 
    /// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
    /// DEA:EMA(DIF, MID);
    /// MACD:(DIF-DEA)*2,COLORSTICK;
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials;

/// <summary>
/// 平滑异同平均
/// </summary>
public class MACD : Communal, IIndicatorFormula
{
    /// <summary>
    /// SHORT(短期)
    /// </summary>
    [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
    public int SHORT { get; set; }

    /// <summary>
    /// LONG(长期)
    /// </summary>
    [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
    public int LONG { get; set; }

    /// <summary>
    /// M 天数
    /// </summary>
    [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
    public int MID { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public MACD()
    {
        Title = "MACD(12,26,9)";

        SHORT = 12;
        LONG = 26;
        MID = 9;

        Result = new List<Outputs.Values.MACD>();
    }

    public MACD( int s = 12, int l = 26, int m = 9 )
    {
        Title = $"MACD({s},{l},{m})";

        SHORT = s;
        LONG = l;
        MID = m;

        Result = new List<Outputs.Values.MACD>();
    }

    [JsonIgnore]
    public List<Outputs.Values.MACD> Result { get; set; }
    
    /// <summary>
    /// 计算最后的指标值
    /// </summary>
    /// <param name="stockCode"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateLastValues( string stockCode, List<Inputs.Price> prices )
    {
        CalculateAll( prices );
        /*
        for (var i = prices.Count-1; i < prices.Count; i++)
        {
                try
                {
                    #region Calc
                    var oneDay = new Indexes.MACD
                    {
                        MarkTime = prices[i].MarkTime,
                        RefEMAShort =
                                EMA(prices[i].Close.Value,
                                    Result[i - 1].RefEMAShort, i, SHORT),
                        RefEMALong =
                                EMA(prices[i].Close.Value,
                                  Result[i - 1].RefEMALong, i, LONG)
                    };

                    oneDay.RefDIF = Math.Round(oneDay.RefEMAShort - oneDay.RefEMALong, 4);
                    oneDay.RefDEA =
                            Math.Round(
                                Result[i - 1].RefDEA * (MID - 1) / (MID + 1) + oneDay.RefDIF * 2 / (MID + 1), 4);
                    oneDay.RefMACD = Math.Round(2 * (oneDay.RefDIF - oneDay.RefDEA), 4);

                    var exists = Result.FindLast(o => o.MarkTime.DateEqual(oneDay.MarkTime));
                    if (exists == null) { Result.Add(oneDay); } else { exists = oneDay; }

                    #endregion
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
        }
        */
    }

    /// <summary>
    /// 计算MACD
    /// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
    /// DEA:EMA(DIF,MID);
    /// MACD:(DIF-DEA)*2,COLORSTICK;
    /// 默认 SHORT=12 LONG=26 MID=9
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateAll( List<Inputs.Price> prices )
    {
        Result = new List<Outputs.Values.MACD>();

        Result.AddRange( new Outputs.Values.MACD[ prices.Count ] );

        var emaShortYest = 0D;
        var emaLongYest = 0D;
        var deaYest = 0D;

        for (var i = 0; i < prices.Count; i++)
        {
            if (i == 0)
            {
                Result[i] = new Outputs.Values.MACD
                {
                    TradeDate = prices[i].TradeDate,
                    RefEMAShort = prices[i].Close!.Value,
                    RefEMALong = prices[i].Close!.Value
                };
            }
            else
            {
                Result[i] = new Outputs.Values.MACD
                {
                    TradeDate = prices[i].TradeDate,
                    RefEMAShort = EMA(prices[i].Close!.Value, emaShortYest, SHORT),
                    RefEMALong = EMA(prices[i].Close!.Value, emaLongYest, LONG)
                };

                Result[i].RefDIF = Math.Round(Result[i].RefEMAShort - Result[i].RefEMALong, 3);
                Result[i].RefDEA = Math.Round(deaYest * (MID - 1) / (MID + 1) + Result[i].RefDIF * 2 / (MID + 1), 3);
                Result[i].RefMACD = Math.Round(2 * (Result[i].RefDIF - Result[i].RefDEA), 3);
            }

            emaShortYest = Result[i].RefEMAShort;
            emaLongYest = Result[i].RefEMALong;
            deaYest = Result[i].RefDEA;
        }
    }
}