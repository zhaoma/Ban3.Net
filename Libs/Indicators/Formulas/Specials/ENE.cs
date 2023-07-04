/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（ENE）
 * reference:
 
    /// UPPER:(1+M1/100)*MA(CLOSE,N);
    /// LOWER:(1-M2/100)* MA(CLOSE, N);
    /// ENE:(UPPER+LOWER)/2;
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
    /// ENE指标
    /// 
    /// </summary>
    public class ENE
            : Communal, IIndicatorFormula
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("m1", NullValueHandling = NullValueHandling.Ignore)]
        public int M1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("m2", NullValueHandling = NullValueHandling.Ignore)]
        public int M2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdUPPER { get; set; } = 23;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdLOWER { get; set; } = 24;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int ParamIdENE { get; set; } = 25;

        /// <summary>
        /// 
        /// </summary>
        public ENE()
        {
            Title = "ENE(10,11,9)";

            N = 10;
            M1 = 11;
            M2 = 9;
            Result = new List<Outputs.Values.ENE>();
        }

        public ENE( int n = 10, int m1 = 11, int m2 = 9 )
        {
            Title = $"ENE({n},{m1},{m2})";

            N = n;
            M1 = m1;
            M2 = m2;
            Result = new List<Outputs.Values.ENE>();
        }

        [JsonIgnore]
        public List<Outputs.Values.ENE> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            Result = new List<Outputs.Values.ENE>();

            foreach( var pv in paramValues )
            {
                var r = Result.FindLast( o => o.MarkTime == pv.MarkTime );
                if( r == null )
                {
                    r = new Outputs.Values.ENE { MarkTime = pv.MarkTime };
                    Result.Add( r );
                }

                if( pv.ParamId == ParamIdENE )
                {
                    r.RefENE =pv.Ref;
                }

                if( pv.ParamId == ParamIdUPPER )
                {
                    r.RefUPPER = pv.Ref;
                }

                if( pv.ParamId == ParamIdLOWER )
                {
                    r.RefLOWER = pv.Ref;
                }
            }
        }

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
            for (int i = Math.Max(prices.Count-1, N - 1); i < prices.Count; i++)
            {
                var d = 0M;
                for (int r = i; r > i - N; r--)
                {
                    d += prices[r].CurrentClose.Value;
                }

                var ma = d / N;

                var oneDay = new Defines.Calc.Indexes.ENE
                {
                    MarkTime = prices[i].MarkTime,
                    RefUPPER = Math.Round((1 + M1 / 100M) * ma, 2),
                    RefLOWER = Math.Round((1 - M2 / 100M) * ma, 2)
                };

                oneDay.RefENE = Math.Round((oneDay.RefUPPER + oneDay.RefLOWER) / 2, 2);


                var exists = Result.FindLast(o => o.MarkTime.DateEqual(oneDay.MarkTime));
                if (exists == null) { Result.Add(oneDay); } else { exists = oneDay; }
            }
            */
        }

        /// <summary>
        /// ENE指标
        /// 
        /// UPPER:(1+M1/100)*MA(CLOSE,N);
        /// LOWER:(1-M2/100)* MA(CLOSE, N);
        /// ENE:(UPPER+LOWER)/2;
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void CalculateAll( List<Inputs.Price> prices )
        {
            Result = prices.Select( o => new Outputs.Values.ENE
            {
                    MarkTime = o.MarkTime,
                    RefUPPER = null,
                    RefLOWER = null,
                    RefENE = null
            } ).ToList();

            for( var i = Math.Max( 0, N - 1 ); i < prices.Count; i++ )
            {
                if( i >= N - 1 )
                {
                    var ma = DescRangeCloseAverage( prices, i, N );

                    Result[ i ].RefUPPER = Math.Round( (1 + M1 / 100D) * ma, 2 );
                    Result[ i ].RefLOWER = Math.Round( (1 - M2 / 100D) * ma, 2 );
                    Result[ i ].RefENE = Math.Round( (Result[ i ].RefUPPER!.Value + Result[ i ].RefLOWER!.Value) / 2, 2 );
                }
            }
        }
    }
}