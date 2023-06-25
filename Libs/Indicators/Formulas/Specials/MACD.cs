/* —————————————————————————————————————————————————————————————————————————————
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
using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Interfaces;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials
{
    /// <summary>
    /// 平滑异同平均
    /// </summary>
    [Serializable, DataContract]
    public class MACD : Communal, IIndicatorFormula
    {
        /// <summary>
        /// SHORT(短期)
        /// </summary>
        [DataMember]
        public int SHORT { get; set; }

        /// <summary>
        /// LONG(长期)
        /// </summary>
        [DataMember]
        public int LONG { get; set; }

        /// <summary>
        /// M 天数
        /// </summary>
        [DataMember]
        public int MID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdDIF { get; set; } = 9;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdDEA { get; set; } = 10;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdMACD { get; set; } = 11;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdEMAShort { get; set; } = 21;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParamIdEMALong { get; set; } = 22;

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


        public List<Outputs.Values.MACD> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public void ConvertFrom( List<RecordWithValue> paramValues )
        {
            Result = new List<Outputs.Values.MACD>();

            foreach( var pv in paramValues )
            {
                var r = Result.FindLast( o => o.MarkTime == pv.MarkTime );

                if( r == null )
                {
                    r = new Outputs.Values.MACD
                    {
                            MarkTime = pv.MarkTime
                    };
                    Result.Add( r );
                }

                if( pv.ParamId == ParamIdDIF )
                    r.RefDIF = pv.Ref;

                if( pv.ParamId == ParamIdDEA )
                    r.RefDEA = pv.Ref;

                if( pv.ParamId == ParamIdMACD )
                    r.RefMACD = pv.Ref;

                if( pv.ParamId == ParamIdEMAShort )
                    r.RefEMAShort = pv.Ref;

                if( pv.ParamId == ParamIdEMALong )
                    r.RefEMALong = pv.Ref;
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
            for (var i = prices.Count-1; i < prices.Count; i++)
            {
                    try
                    {
                        #region Calc
                        var oneDay = new Indexes.MACD
                        {
                            MarkTime = prices[i].MarkTime,
                            RefEMAShort =
                                    EMA(prices[i].CurrentClose.Value,
                                        Result[i - 1].RefEMAShort, i, SHORT),
                            RefEMALong =
                                    EMA(prices[i].CurrentClose.Value,
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

            var emaShortYest = 0M;
            var emaLongYest = 0M;
            var deaYest = 0M;

            for( var i = 0; i < prices.Count; i++ )
            {
                if( i == 0 )
                {
                    Result[ i ] = new Outputs.Values.MACD
                    {
                            MarkTime = prices[ i ].MarkTime,
                            RefEMAShort = prices[ i ].CurrentClose!.Value,
                            RefEMALong = prices[ i ].CurrentClose!.Value
                    };
                }
                else
                {
                    Result[ i ] = new Outputs.Values.MACD
                    {
                            MarkTime = prices[ i ].MarkTime,
                            RefEMAShort = EMA( prices[ i ].CurrentClose!.Value, emaShortYest, SHORT ),
                            RefEMALong = EMA( prices[ i ].CurrentClose!.Value, emaLongYest, LONG )
                    };

                    Result[ i ].RefDIF = Math.Round( Result[ i ].RefEMAShort - Result[ i ].RefEMALong, 3 );
                    Result[ i ].RefDEA = Math.Round( deaYest * (MID - 1) / (MID + 1) + Result[ i ].RefDIF * 2 / (MID + 1), 3 );
                    Result[ i ].RefMACD = Math.Round( 2 * (Result[ i ].RefDIF - Result[ i ].RefDEA), 3 );
                }

                emaShortYest = Result[ i ].RefEMAShort;
                emaLongYest = Result[ i ].RefEMALong;
                deaYest = Result[ i ].RefDEA;
            }
        }
    }
}