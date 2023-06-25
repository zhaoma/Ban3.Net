/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（AMOUNT）
 * reference:
    /// BIAS :(CLOSE-MA(CLOSE,N))/MA(CLOSE,N)*100;
    /// BIASMA :MA(BIAS, M);
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Interfaces;
using Ban3.Infrastructures.Indicators.Outputs;


namespace Ban3.Infrastructures.Indicators.Formulas.Specials
{
    /// <summary>
    /// 成交额均线
    /// </summary>
    [Serializable, DataContract]
    public class AMOUNT : Communal, IIndicatorFormula
    {
        /// <summary>
        /// 数据线条
        /// </summary>
        [DataMember]
        public List<Line>? Details { get; set; }

        /// <summary>
        /// 默认参数选择 5日与10日 均量
        /// </summary>
        public AMOUNT()
        {
            Title = "AMOUNT(5,10)";
            Details = new List<Line>
            {
                    new Line { ParamId = 30, Days = 5 },
                    new Line { ParamId = 31, Days = 10 }
            };
            Result = new List<Outputs.Values.AMOUNT>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">短期（默认5）</param>
        /// <param name="l">长期（默认10）</param>
        public AMOUNT( int s = 5, int l = 10 )
        {
            Title = $"AMOUNT({s},{l})";
            Details = new List<Line>
            {
                    new Line { ParamId = 30, Days = s },
                    new Line { ParamId = 31, Days = l }
            };
            Result = new List<Outputs.Values.AMOUNT>();
        }

        public List<Outputs.Values.AMOUNT> Result { get; set; }

        /// <summary>
        /// 把计算好的指标值列表，按日填充成每日指标组
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            Result = new List<Outputs.Values.AMOUNT>();

            foreach( var pv in paramValues )
            {
                if( Details.Any( o => o.ParamId == pv.ParamId ) )
                {
                    var r = Result.FindLast( o => o.MarkTime.DateEqual( pv.MarkTime ) );
                    if( r == null )
                    {
                        r = new Outputs.Values.AMOUNT
                        {
                                MarkTime = pv.MarkTime,
                                RefAmounts = new List<LineWithValue>()
                        };
                        Result.Add( r );
                    }

                    var line = r.RefAmounts.FindLast( o => o.ParamId == pv.ParamId );
                    if( line == null )
                    {
                        r.RefAmounts.Add( new LineWithValue
                        {
                                ParamId = pv.ParamId,
                                Ref = pv.Ref
                        } );
                    }
                    else
                    {
                        line.Ref = pv.Ref;
                    }
                }
            }
        }

        /// <summary>
        /// 计算最后的指标值
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="prices"></param>
        public void CalculateLastValues( string stockCode, List<Inputs.Price> prices )
        {
            for( var i = prices.Count - 1; i < prices.Count; i++ )
            {
                var oneDay = new Outputs.Values.AMOUNT
                {
                        MarkTime = prices[ i ].MarkTime,
                        RefAmounts = new List<LineWithValue>()
                };
                foreach( var detail in Details! )
                {
                    if( i >= detail.Days - 1 )
                    {
                        var d = 0M;
                        for( int r = i; r > i - detail.Days; r-- )
                        {
                            d += prices[ r ].Amount!.Value;
                        }

                        if( oneDay.RefAmounts.All( o => o.ParamId != detail.ParamId ) )
                        {
                            oneDay.RefAmounts.Add(
                                                  new LineWithValue
                                                  {
                                                          ParamId = detail.ParamId,
                                                          Ref = Math.Round( d / detail.Days, 0 ),
                                                          Days = detail.Days
                                                  } );
                        }
                    }
                }

                var exists = Result.FindLast( o => o.MarkTime.DateEqual( oneDay.MarkTime ) );
                if( exists == null )
                {
                    Result.Add( oneDay );
                }
                else
                {
                    exists = oneDay;
                }
            }
        }

        /// <summary>
        /// 计算MA
        /// MA:ma(AMO, DAYS);
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public void CalculateAll( List<Inputs.Price> prices )
        {
            Result = prices.Select( o => new Outputs.Values.AMOUNT
            {
                    MarkTime = o.MarkTime,
                    RefAmounts = new List<LineWithValue>()
            } ).ToList();

            for( var i = 0; i < prices.Count; i++ )
            {
                foreach( var detail in Details! )
                {
                    if( i >= detail.Days - 1 )
                    {
                        if( Result[ i ].RefAmounts.All( o => o.ParamId != detail.ParamId ) )
                        {
                            Result[ i ].RefAmounts.Add(
                                                       new LineWithValue
                                                       {
                                                               ParamId = detail.ParamId,
                                                               Ref = DescRangeAmountAverage( prices, i, detail.Days ),
                                                               Days = detail.Days
                                                       } );
                        }
                    }
                }
            }
        }
    }
}