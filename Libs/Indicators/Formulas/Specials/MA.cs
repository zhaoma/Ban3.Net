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
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Interfaces;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials
{
    /// <summary>
    /// 均线
    /// </summary>
    [Serializable, DataContract]
    public class MA : Communal, IIndicatorFormula
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Entries.Line> Details { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MA()
        {
            this.Title = "MA(5,10,20,30)";
            Details = new List<Entries.Line>
            {
                    //new MALine {ParamId=1,Days=3 },
                    new Entries.Line { ParamId = 2, Days = 5 },
                    new Entries.Line { ParamId = 3, Days = 10 },
                    new Entries.Line { ParamId = 4, Days = 20 },
                    new Entries.Line { ParamId = 5, Days = 30 },
                    //new MALine {ParamId=6,Days=60 },
                    //new MALine {ParamId=7,Days=120 },
                    //new MALine {ParamId=8,Days=250 }
            };
        }

        public MA( int d1 = 5, int d2 = 10, int d3 = 20, int d4 = 30 )
        {
            this.Title = $"MA({d1},{d2},{d3},{d4})";
            Details = new List<Entries.Line>
            {
                    //new MALine {ParamId=1,Days=3 },
                    new Entries.Line { ParamId = 2, Days = d1 },
                    new Entries.Line { ParamId = 3, Days = d2 },
                    new Entries.Line { ParamId = 4, Days = d3 },
                    new Entries.Line { ParamId = 5, Days = d4 },
                    //new MALine {ParamId=6,Days=60 },
                    //new MALine {ParamId=7,Days=120 },
                    //new MALine {ParamId=8,Days=250 }
            };
        }

        public List<Outputs.Values.MA> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            Result = new List<Outputs.Values.MA>();

            foreach( var pv in paramValues )
            {
                if( Details.Any( o => o.ParamId == pv.ParamId ) )
                {
                    var r = Result.FindLast( o => o.MarkTime == pv.MarkTime );

                    if( r == null )
                    {
                        r = new Outputs.Values.MA
                        {
                                MarkTime = pv.MarkTime,
                                RefPrices = new List<Entries.LineWithValue>()
                        };
                        Result.Add( r );
                    }

                    var line = r.RefPrices.FindLast( o => o.ParamId == pv.ParamId );
                    if( line == null )
                    {
                        r.RefPrices.Add( new Entries.LineWithValue
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
        /// <param name="values"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public void CalculateLastValues( string stockCode, List<Inputs.Price> prices )
        {
            CalculateAll( prices );
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
                                d += prices[r].CurrentClose.Value;
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
        public void CalculateAll( List<Inputs.Price> prices )
        {
            Result = prices.Select( o => new Outputs.Values.MA
            {
                    MarkTime = o.MarkTime,
                    RefPrices = new List<Entries.LineWithValue>()
            } ).ToList();

            for( var i = 0; i < prices.Count; i++ )
            {
                foreach( var detail in Details )
                {
                    if( i >= detail.Days - 1 )
                    {
                        var ma = DescRangeCloseAverage( prices, i, detail.Days );

                        if( Result[ i ].RefPrices.All( o => o.ParamId != detail.ParamId ) )
                        {
                            Result[ i ].RefPrices.Add(
                                                      new Entries.LineWithValue
                                                      {
                                                              ParamId = detail.ParamId,
                                                              Ref = Math.Round( ma, 2 ),
                                                              Days = detail.Days
                                                      } );
                        }
                    }
                }
            }
        }
    }
}