/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（MA）
 * reference:
    /// MA:ma(CLOSE, DAYS);
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Interfaces;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials;

/// <summary>
/// 均线
/// </summary>
public class MA : Communal, IIndicatorFormula
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
    public List<Line>? Details { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MA()
    {
        this.Title = "MA(5,10,20,30)";
        Details = new List<Line>
        {
            //new MALine {ParamId=1,Days=3 },
            new (5),
            new (10),
            new (20),
            new (30),
            //new MALine {ParamId=6,Days=60 },
            //new MALine {ParamId=7,Days=120 },
            //new MALine {ParamId=8,Days=250 }
        };
        Result = new List<Outputs.Values.MA>();
    }

    public MA(int d1 = 5, int d2 = 10, int d3 = 20, int d4 = 30)
    {
        this.Title = $"MA({d1},{d2},{d3},{d4})";
        Details = new List<Line>
        {
            new(d1),
            new(d2),
            new(d3),
            new(d4)
        };
        Result = new List<Outputs.Values.MA>();
    }

    [JsonIgnore] public List<Outputs.Values.MA> Result { get; set; }
    
    /// <summary>
    /// 计算最后的指标值
    /// </summary>
    /// <param name="stockCode"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateLastValues(string stockCode, List<Inputs.Price> prices)
    {
        CalculateAll(prices);
        /*
        for (var i = prices.Count - 1; i < prices.Count; i++)
        {
            try
            {
                #region Calc

                var oneDay = new Defines.Calc.Indexes.MA
                {
                    MarkTime = prices[i].MarkTime,
                    RefPrices = new List<Entries.LineWithValue>()
                };
                foreach (var detail in Details)
                {
                    if (i >= detail.Days - 1)
                    {
                        var d = 0M;
                        for (int r = i; r > i - detail.Days; r--)
                        {
                            d += prices[r].Close.Value;
                        }

                        if (oneDay.RefPrices.All(o => o.ParamId != detail.ParamId))
                        {
                            oneDay.RefPrices.Add(
                                new Entries.LineWithValue
                                {
                                    ParamId = detail.ParamId,
                                    Ref = Math.Round(d / detail.Days, 2),
                                    Days = detail.Days
                                });
                        }
                    }
                }

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
    /// 计算MA
    /// MA:ma(CLOSE, DAYS);
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateAll(List<Inputs.Price> prices)
    {
        Result = prices.Select(o => new Outputs.Values.MA
        {
            TradeDate = o.TradeDate,
            RefPrices = new List<LineWithValue>()
        }).ToList();

        if (Details == null) return;

        for (var i = 0; i < prices.Count; i++)
        {
            foreach (var detail in Details)
            {
                if (i >= detail.Days - 1)
                {
                    var ma = DescRangeCloseAverage(prices, i, detail.Days);

                    if (Result[i].RefPrices.All(o => o.Days != detail.Days))
                    {
                        Result[i].RefPrices.Add(
                            new LineWithValue
                            {
                                Ref = Math.Round(ma, 2),
                                Days = detail.Days
                            });
                    }
                }
            }
        }

    }
}