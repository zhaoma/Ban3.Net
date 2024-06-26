﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（DMI）
 * reference:
   PDI(上升方向线)    MDI(下降方向线)  ADX(趋向平均值)
   MTR:= SUM(MAX(MAX(HIGH-LOW,ABS(HIGH-REF(CLOSE,1))),ABS(LOW-REF(CLOSE,1))),N);
   HD := HIGH-REF(HIGH,1);
   LD := REF(LOW,1)-LOW;
   DMP:= SUM(IF(HD>0 AND HD>LD, HD,0),N);
   DMM:= SUM(IF(LD>0 AND LD>HD, LD,0),N);
   PDI: DMP*100/MTR;
   MDI: DMM*100/MTR;
   ADX: MA(ABS(MDI-PDI)/(MDI+PDI)*100,M);
   ADXR:(ADX+REF(ADX, M))/2;

   默认：N=14 M=6
   REF:向前引用函数 REF(CLOSE,1) 昨日收盘价
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Formulas.Specials;

/// <summary>
/// 趋向指标
/// </summary>
public class DMI : Communal, IIndicatorFormula
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
    public DMI()
    {
        Title = "DMI(14,6)";

        N = 14;
        M = 6;

        Result = new List<Outputs.Values.DMI>();
    }

    public DMI( int n = 14, int m = 6 )
    {
        Title = $"DMI({n},{m})";

        N = n;
        M = m;
        Result = new List<Outputs.Values.DMI>();
    }

    [JsonIgnore]
    public List<Outputs.Values.DMI> Result { get; set; }

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
        var middles = prices.Select(o =>
             new decimal[] {
                        o.High.Value,
                        o.Low.Value,
                        o.Close.Value,
                        0,0
             }).ToList();

        for (int i = Math.Max(prices.Count-1, N - 1); i < prices.Count; i++)
        {
            var oneDay = new Defines.Calc.Indexes.DMI
            {
                MarkTime = prices[i].MarkTime,
                RefADX = 0M,
                RefADXR = 0M,
                RefPDI = 0M,
                RefMDI = 0M
            };
            if (i>0)
            {
                //HD:=HIGH-REF(HIGH,1)
                Result[i].RefHD = middles[i][0] - middles[i - 1][0];
                //LD:=REF(LOW,1)-LOW
                Result[i].RefLD = middles[i - 1][1] - middles[i][1];
                Result[i].RefMTR = Math.Max(middles[i][0] - middles[i][1], Math.Abs(middles[i][0] - middles[i - 1][2]));
                Result[i].RefMTR = Math.Max(Result[i].RefMTR, Math.Abs(middles[i][1] - middles[i - 1][2]));

                middles[i][3] = Result[i].RefHD.Value > 0 && Result[i].RefHD.Value > Result[i].RefLD.Value ? Result[i].RefHD.Value : 0M;
                middles[i][4] = Result[i].RefLD.Value > 0 && Result[i].RefLD.Value > Result[i].RefHD.Value ? Result[i].RefLD.Value : 0M;

                var dmp = 0M; var dmm = 0M; var mtr = 0M;
                for (int index = 0; index < N; index++)
                {
                    if (index <= i)
                    {
                        var current = i - index;

                        mtr += Result[current].RefMTR;
                        dmp += middles[current][3];
                        dmm += middles[current][4];
                    }
                }

                Result[i].RefDMP = dmp;
                Result[i].RefDMM = dmm;

                if (mtr != 0)
                {
                    Result[i].RefPDI = dmp * 100 / mtr;
                    Result[i].RefMDI = dmm * 100 / mtr;
                }

                var adx = 0M;
                for (int r = i; r > i - M-1; r--)
                {
                    adx += Result[r].RefPDI + Result[r].RefMDI == 0M
                             ? 0M
                             : Math.Abs(Result[r].RefMDI.ToDecimal() - Result[r].RefPDI.ToDecimal()) /
                               (Result[r].RefPDI.ToDecimal() + Result[r].RefMDI.ToDecimal()) * 100M;

                }

                Result[i].RefADX = adx / M;

                if (i >= 2 * M - 1)
                {
                    oneDay.RefADXR = (Result[i].RefADX.ToDecimal() + Result[i - M].RefADX.ToDecimal()) / 2;
                }

                oneDay.RefADX = Math.Round(oneDay.RefADX.Value, 4);
                oneDay.RefADXR = Math.Round(oneDay.RefADXR.Value, 4);
                oneDay.RefHD = Math.Round(oneDay.RefHD.Value, 4);
                oneDay.RefLD = Math.Round(oneDay.RefLD.Value, 4);
                oneDay.RefMDI = Math.Round(oneDay.RefMDI.Value, 4);
                oneDay.RefPDI = Math.Round(oneDay.RefPDI.Value, 4);

                var exists = Result.FindLast(o => o.MarkTime.DateEqual(oneDay.MarkTime));
                if (exists == null) { Result.Add(oneDay); } else { exists = oneDay; }

            }
        }
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prices"></param>
    public void CalculateAll( List<Inputs.Price> prices )
    {
        Result = prices.Select( o => new Outputs.Values.DMI
        {
            TradeDate = o.TradeDate,
                RefADX = 0D,
                RefADXR = 0D,
                RefPDI = 0D,
                RefMDI = 0D
        } ).ToList();

        /* high low close HD(high差) LD(low差) MTR dmps dmms */
        var middles = prices.Select( o =>
                                             new []
                                             {
                                                     o.High!.Value,
                                                     o.Low!.Value,
                                                     o.Close!.Value,
                                                     0,
                                                     0,
                                                     Math.Abs( o.High.Value - o.Low.Value )
                                             } ).ToList();

        for( var i = 0; i < prices.Count; i++ )
        {
            if( i > 0 )
            {
                Result[ i ].RefHD = middles[ i ][ 0 ] - middles[ i - 1 ][ 0 ];
                Result[ i ].RefLD = middles[ i - 1 ][ 1 ] - middles[ i ][ 1 ];

                middles[ i ][ 3 ] = Result[ i ].RefHD!.Value > 0 && Result[ i ].RefHD!.Value > Result[ i ].RefLD!.Value ? Result[ i ].RefHD!.Value : 0D;
                middles[ i ][ 4 ] = Result[ i ].RefLD!.Value > 0 && Result[ i ].RefLD!.Value > Result[ i ].RefHD!.Value ? Result[ i ].RefLD!.Value : 0D;

                middles[ i ][ 5 ] = Math.Max( middles[ i ][ 5 ], Math.Abs( middles[ i ][ 0 ] - middles[ i - 1 ][ 2 ] ) );
                middles[ i ][ 5 ] = Math.Max( middles[ i ][ 5 ], Math.Abs( middles[ i ][ 1 ] - middles[ i - 1 ][ 2 ] ) );

                var dmp = 0D;
                var dmm = 0D;
                var mtr = 0D;
                for( int index = 0; index < N; index++ )
                {
                    if( index <= i )
                    {
                        var current = Math.Max( 0, i - index );

                        mtr += middles[ current ][ 5 ];
                        dmp += middles[ current ][ 3 ];
                        dmm += middles[ current ][ 4 ];
                    }
                }

                Result[ i ].RefMTR = mtr;
                Result[ i ].RefDMP = dmp;
                Result[ i ].RefDMM = dmm;

                if( mtr != 0 )
                {
                    Result[ i ].RefPDI = dmp * 100 / mtr;
                    Result[ i ].RefMDI = dmm * 100 / mtr;
                }
            }
            else
            {
                Result[ i ].RefHD = 0D; // prices[i].Close;
                Result[ i ].RefLD = 0D; // -prices[i].CurrentOpenEx;
                Result[ i ].RefMTR = middles[ i ][ 5 ];
            }

            if( i >= M - 1 )
            {
                var adx = 0D;
                for( int r = i; r > i - M; r-- )
                {
                    adx += Result[ r ].RefPDI!.Value + Result[ r ].RefMDI!.Value == 0D
                                   ? 0D
                                   : Math.Abs( Result[ r ].RefMDI!.Value - Result[ r ].RefPDI!.Value ) /
                                     (Result[ r ].RefPDI!.Value + Result[ r ].RefMDI!.Value) * 100D;
                }

                Result[ i ].RefADX = adx / M;
            }

            if( i >= 2 * M - 1 )
            {
                Result[ i ].RefADXR = (Result[ i ].RefADX! + Result[ i - M ].RefADX!) / 2;
            }

            Result[ i ].RefADX = Math.Round( Result[ i ].RefADX!.Value, 3 );
            Result[ i ].RefADXR = Math.Round( Result[ i ].RefADXR!.Value, 3 );
            Result[ i ].RefHD = Math.Round( Result[ i ].RefHD!.Value, 3 );
            Result[ i ].RefLD = Math.Round( Result[ i ].RefLD!.Value, 3 );
            Result[ i ].RefMDI = Math.Round( Result[ i ].RefMDI!.Value, 3 );
            Result[ i ].RefPDI = Math.Round( Result[ i ].RefPDI!.Value, 3 );
        }
    }
}