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
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Interfaces;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials
{
    /// <summary>
    /// 乖离率
    /// </summary>
    [Serializable, DataContract]
    public class BIAS : Communal, IIndicatorFormula
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int M { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdBIAS { get; set; } = 16;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdBIASMA { get; set; } = 17;

        /// <summary>
        /// 
        /// </summary>
        public BIAS()
        {
            Title = "BIAS(6,6)";

            N = 6;
            M = 6;
        }

        public BIAS( int n = 6, int m = 6 )
        {
            Title = $"BIAS({n},{m})";
            N = n;
            M = m;
        }

        public List<Outputs.Values.BIAS> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            Result = new List<Outputs.Values.BIAS>();

            foreach( var pv in paramValues )
            {
                var r = Result.FindLast( o => o.MarkTime == pv.MarkTime );
                if( r == null )
                {
                    r = new Outputs.Values.BIAS { MarkTime = pv.MarkTime };
                    Result.Add( r );
                }

                if( pv.ParamId == ParamIdBIAS )
                {
                    r.RefBIAS = pv.Ref;
                }

                if( pv.ParamId == ParamIdBIASMA )
                {
                    r.RefBIASMA = pv.Ref;
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
            for (int i = Math.Max(prices.Count-1, N - 1); i < prices.Count; i++)
            {
                var maSum = 0M;
                for (int j = 0; j < N; j++)
                {
                    maSum += prices[i - j].CurrentClose.Value;
                }
                var ma = maSum / N;

                var oneDay = new Defines.Calc.Indexes.BIAS
                {
                    MarkTime = prices[i].MarkTime,
                    RefBIAS = Math.Round((prices[i].CurrentClose.Value - ma) / ma * 100M, 4)
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
        public void CalculateAll( List<Inputs.Price> prices )
        {
            Result = prices.Select( o => new Outputs.Values.BIAS
            {
                    MarkTime = o.MarkTime,
                    RefBIAS = null,
                    RefBIASMA = null
            } ).ToList();

            for( var i = Math.Max( 0, N - 1 ); i < prices.Count; i++ )
            {
                if( i >= N - 1 )
                {
                    var ma = DescRangeCloseAverage( prices, i, N );

                    if( ma != 0 )
                    {
                        Result[ i ].RefBIAS = Math.Round( (prices[ i ].CurrentClose.Value - ma) / ma * 100M, 3 );
                    }
                }

                if( i >= N + M - 2 )
                {
                    var biasSum = 0M;
                    for( int j = 0; j < M; j++ )
                    {
                        if( Result[ i - j ].RefBIAS != null )
                        {
                            biasSum += Result[ i - j ].RefBIAS.Value;
                        }
                    }

                    Result[ i ].RefBIASMA = Math.Round( biasSum / M, 3 );
                }
            }
        }
    }
}