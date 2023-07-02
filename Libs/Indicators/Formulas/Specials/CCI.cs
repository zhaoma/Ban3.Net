/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（CCI）
 * reference:
    /// TYP:=(HIGH+LOW+CLOSE)/3;
    /// CCI:(TYP-MA(TYP, N))/(0.015* AVEDEV(TYP, N));
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials;

/// <summary>
/// 商品路径指标
/// </summary>
public class CCI : Communal, IIndicatorFormula
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
    public int N { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public int ParamIdCCI { get; set; } = 20;

    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public int ParamIdTYP { get; set; } = 26;

    /// <summary>
    /// 
    /// </summary>
    public CCI()
    {
        N = 14;
        Title = "CCI(14)";
        Result = new List<Outputs.Values.CCI>();
    }

    public CCI(int n = 14)
    {
        N = n;
        Title = $"CCI({n})";
        Result = new List<Outputs.Values.CCI>();
    }

    [JsonIgnore]
    public List<Outputs.Values.CCI> Result { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paramValues"></param>
    /// <returns></returns>
    public void ConvertFrom(List<RecordWithValue> paramValues)
    {
        Result = new List<Outputs.Values.CCI>();

        foreach (var pv in paramValues)
        {
            var r = Result.FindLast(o => o.MarkTime == pv.MarkTime);
            if (r == null)
            {
                r = new Outputs.Values.CCI { MarkTime = pv.MarkTime };
                Result.Add(r);
            }

            if (pv.ParamId == ParamIdCCI)
            {
                r.RefCCI =(decimal) pv.Ref;
            }

            if (pv.ParamId == ParamIdTYP)
            {
                r.RefTYP =(decimal) pv.Ref;
            }
        }
    }

    /// <summary>
    /// 计算最后的指标值
    /// 先把历史数据给Result
    /// </summary>
    /// <param name="values"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateLastValues(string stockCode, List<Inputs.Price> prices)
    {
        CalculateAll(prices);
        /*
        for (int i = Math.Max(prices.Count - 1, N - 1); i < prices.Count; i++)
        {
            var oneDay = new Defines.Calc.Indexes.CCI
            {
                MarkTime = prices[i].MarkTime,
                RefTYP = (prices[i].CurrentHigh.Value + prices[i].CurrentLow.Value + prices[i].CurrentClose.Value) / 3
            };

            var rr = new List<decimal>();
            for (int r = i; r > i - N; r--)
            {
                rr.Add(Result[r].RefTYP);
            }

            oneDay.RefCCI = AVEDEV(Result[i].RefTYP, rr);

            var exists = Result.FindLast(o => o.MarkTime.DateEqual(oneDay.MarkTime));
            if (exists == null) { Result.Add(oneDay); } else { exists = oneDay; }
        }
        */
    }

    /// <summary>
    /// 计算CCI
    /// 
    /// TYP:=(HIGH+LOW+CLOSE)/3;
    /// CCI:(TYP-MA(TYP, N))/(0.015*AVEDEV(TYP, N));
    /// 
    /// 默认参数：N=14
    /// AVEDEV
    /// 绝对平均偏差= 1/n * (求和：|xi-x均|，i=1,2,3...n)
    /// 比如说三个数，59，60，61，平均值为60
    /// 绝对平均偏差就是 1/3 * ( |59-60| + |60-60|+ |61-60|)=0.667=0.7
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateAll(List<Inputs.Price> prices)
    {
        Result = prices.Select(o => new Outputs.Values.CCI
        {
            MarkTime = o.MarkTime,
            RefTYP = Math.Round((o.CurrentHigh!.Value + o.CurrentLow!.Value + o.CurrentClose!.Value) / 3, 3)
        }).ToList();

        #region Calculate

        for (var i = Math.Max(0, N - 1); i < Result.Count; i++)
        {
            var rr = new List<decimal>();
            for (int r = i; r > i - N; r--)
            {
                rr.Add(Result[r].RefTYP);
            }

            Result[i].RefCCI = AVEDEV(Result[i].RefTYP, rr);
        }

        #endregion
    }
}