/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（KD/SKDJ）
 * reference:
    /// LOWV:=LLV(LOW, N);
    /// HIGHV:=HHV(HIGH, N);
    /// RSV:=EMA((CLOSE-LOWV)/(HIGHV-LOWV)*100,M);
    /// K:EMA(RSV, M);
    /// D:MA(K, M);
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials
{
    /// <summary>
    /// 随机指标
    /// </summary>
    public class KD : Communal, IIndicatorFormula
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
        [JsonIgnore]
        public int ParamIdK { get; set; } = 18;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdD { get; set; } = 19;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdPSV { get; set; } = 29;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdDailyPSV { get; set; } = 32;

        /// <summary>
        /// 
        /// </summary>
        public KD()
        {
            Title = "KD(9,3)";

            N = 9;
            M = 3;

            Result = new List<Outputs.Values.KD>();
        }

        public KD(int n = 9, int m = 3)
        {
            Title = $"KD({n},{m})";

            N = n;
            M = m;

            Result = new List<Outputs.Values.KD>();
        }

        [JsonIgnore]
        public List<Outputs.Values.KD> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            var result = new List<Outputs.Values.KD>();

            foreach( var pv in paramValues )
            {
                var r = result.FindLast( o => o.MarkTime == pv.MarkTime );
                if( r == null )
                {
                    r = new Outputs.Values.KD { MarkTime = pv.MarkTime };
                    result.Add( r );
                }

                if( pv.ParamId == ParamIdK )
                {
                    r.RefK = (decimal)pv.Ref;
                }

                if( pv.ParamId == ParamIdD )
                {
                    r.RefD = (decimal)pv.Ref;
                }

                if( pv.ParamId == ParamIdPSV )
                {
                    r.RefPSV = (decimal)pv.Ref;
                }

                if( pv.ParamId == ParamIdDailyPSV )
                {
                    r.RefDailyPSV = (decimal)pv.Ref;
                }
            }
        }

        /// <summary>
        /// 计算最后的指标值
        /// </summary>
        /// <param name="values"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public void CalculateLastValues( string stockCode, List<Inputs.Price> prices )
        {
            CalculateAll( prices );
            /*
            var lows = prices.Select(o => o.CurrentLow.Value).ToList();
            var highs = prices.Select(o => o.CurrentHigh.Value).ToList();

            for (int i = Math.Max(prices.Count-1, N - 1); i < prices.Count; i++)
            {
                try
                {
                    #region Calc

                    var oneDay = new Defines.Calc.Indexes.KD
                    {
                        MarkTime = prices[i].MarkTime,
                        RefPSV = 0M,
                        RefK = 0M,
                        RefD = 0M,
                        RefDailyPSV = 0M
                    };

                    oneDay.RefLLV = LLV(lows, i, Math.Min(i + 1, N));
                    oneDay.RefHHV = HHV(highs, i, Math.Min(i + 1, N));
                    if (oneDay.RefHHV - oneDay.RefLLV != 0)
                    {
                        oneDay.RefDailyPSV = (prices[i].CurrentClose - oneDay.RefLLV) * 100M / (oneDay.RefHHV - oneDay.RefLLV);
                    }

                    if (i >= N - 1)
                    {
                        if (i >= N + M - 1)
                        {
                            oneDay.RefPSV = EMA(oneDay.RefDailyPSV.Value,
                                Result[i - 1].RefPSV.Value,
                                i, M, 4);

                            oneDay.RefK = EMA(oneDay.RefPSV.Value,
                                Result[i - 1].RefK.Value,
                                i, M);

                            var ks = Result.Take(i + 1)
                                .Select(o => o.RefK.Value).ToList();
                            oneDay.RefD = MA(ks, i, M);
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
        /// 计算KD
        /// LOWV:=LLV(LOW, N);
        /// HIGHV:=HHV(HIGH, N);
        /// RSV:=EMA((CLOSE-LOWV)/(HIGHV-LOWV)*100,M);
        /// K:EMA(RSV, M);
        /// D:MA(K, M);
        /// 
        /// 默认参数 N=9 M=3
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public void CalculateAll( List<Inputs.Price> prices )
        {
            Result = prices.Select( o => new Outputs.Values.KD
            {
                    MarkTime = o.MarkTime,
                    RefPSV = null,
                    RefK = null,
                    RefD = null,
                    RefDailyPSV = null,
                    RefLLV = o.CurrentLow,
                    RefHHV = o.CurrentHigh
            } ).ToList();

            for( var i = 0; i < prices.Count; i++ )
            {
                Result[ i ].RefLLV = LLV( prices, i, N );
                Result[ i ].RefHHV = HHV( prices, i, N );

                if( Result[ i ].RefHHV - Result[ i ].RefLLV != 0 )
                {
                    Result[ i ].RefDailyPSV = Math.Round( (prices[ i ].CurrentClose!.Value - Result[ i ].RefLLV!.Value) * 100M / (Result[ i ].RefHHV!.Value - Result[ i ].RefLLV!.Value), 3 );
                }

                if( i > 0 )
                {
                    Result[ i ].RefPSV = EMA(
                                             Result[ i ].RefDailyPSV!.Value,
                                             Result[ i - 1 ].RefPSV!.Value,
                                             M );

                    Result[ i ].RefK = EMA(
                                           Result[ i ].RefPSV!.Value,
                                           Result[ i - 1 ].RefK!.Value,
                                           M );
                }
                else
                {
                    Result[ i ].RefPSV = Result[ i ].RefDailyPSV;
                    Result[ i ].RefK = Result[ i ].RefDailyPSV;
                }

                if( i >= M - 1 )
                {
                    var d = 0M;
                    for( int r = 0; r < M; r++ )
                    {
                        d += Result[ i - r ].RefK!.Value;
                    }

                    Result[ i ].RefD = Math.Round( d / M, 3 );
                }
            }
        }
    }
}