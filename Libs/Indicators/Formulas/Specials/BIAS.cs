/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（BIAS）
 * reference:

    /// BIAS :(CLOSE-MA(CLOSE,N))/MA(CLOSE,N)*100;
    /// BIASMA :MA(BIAS, M);
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
/// 乖离率
/// </summary>
public class BIAS : Communal, IIndicatorFormula
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
    public int N { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("m", NullValueHandling = NullValueHandling.Ignore)]
    public int M { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public BIAS()
    {
        Title = "BIAS(6,6)";

        N = 6;
        M = 6;

        Result = new List<Outputs.Values.BIAS>();
    }

    public BIAS(int n = 6, int m = 6)
    {
        Title = $"BIAS({n},{m})";
        N = n;
        M = m;
        Result = new List<Outputs.Values.BIAS>();
    }

    [JsonIgnore]
    public List<Outputs.Values.BIAS> Result { get; set; }
    
    /// <summary>
    /// 计算最后的指标值
    /// </summary>
    /// <param name="values"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateLastValues(string stockCode, List<Inputs.Price> prices)
    {
        CalculateAll(prices);
        /*
        for (int i = Math.Max(prices.Count-1, N - 1); i < prices.Count; i++)
        {
            var maSum = 0M;
            for (int j = 0; j < N; j++)
            {
                maSum += prices[i - j].Close.Value;
            }
            var ma = maSum / N;

            var oneDay = new Defines.Calc.Indexes.BIAS
            {
                MarkTime = prices[i].MarkTime,
                RefBIAS = Math.Round((prices[i].Close.Value - ma) / ma * 100M, 4)
            };

            var biasSum = 0M;
            for (int j = 0; j < M; j++)
            {
                biasSum += Result[i - j].RefBIAS.Value;
            }

            oneDay.RefBIASMA = Math.Round(biasSum / M, 4);

            var exists = Result.FindLast(o => o.MarkTime.DateEqual(oneDay.MarkTime));
            if (exists == null) { Result.Add(oneDay); } else { exists = oneDay; }
        }
        */
    }

    /// <summary>
    /// 计算BIAS
    /// BIAS :(CLOSE-MA(CLOSE,N))/MA(CLOSE,N)*100;
    /// BIASMA :MA(BIAS, M);
    /// 
    /// zhaoma/N=4,M=4
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public void CalculateAll(List<Inputs.Price> prices)
    {
        Result = prices.Select(o => new Outputs.Values.BIAS
        {
            TradeDate = o.TradeDate,
            RefBIAS = null,
            RefBIASMA = null
        }).ToList();

        for (var i = Math.Max(0, N - 1); i < prices.Count; i++)
        {
            if (i >= N - 1)
            {
                var ma = DescRangeCloseAverage(prices, i, N);

                if (ma != 0)
                {
                    Result[i].RefBIAS = Math.Round((prices[i].Close!.Value - ma) / ma * 100D, 3);
                }
            }

            if (i >= N + M - 2)
            {
                var biasSum = 0D;
                for (int j = 0; j < M; j++)
                {
                    if (Result[i - j].RefBIAS != null)
                    {
                        biasSum += Result[i - j].RefBIAS!.Value;
                    }
                }

                Result[i].RefBIASMA = Math.Round(biasSum / M, 3);
            }
        }
    }
}