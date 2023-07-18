﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（共用）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Formulas;

/// <summary>
/// 共用公式
/// </summary>
public class Communal
{
    public ILog Logger = LogManager.GetLogger(typeof(Communal));

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// EMA(C,N)=2*C/(N+1)+(N-1)/(N+1)*昨天的指数收盘平均值
    /// </summary>
    /// <param name="current"></param>
    /// <param name="yest"></param>
    /// <param name="days"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    public double EMA( double current, double yest, int days, int round = 3 )
    {
        //var now = DateTime.Now;
        var result = (current * 2 + yest * (days - 1)) / (days + 1);
        //Logger.Info("EMA"+values.Count+"."+DateTime.Now.Subtract(now).TotalMilliseconds+". ms spent");
        //now = DateTime.Now;

        return Math.Round( result, round );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="current"></param>
    /// <param name="values"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    public double AVEDEV( double current, List<double> values, int round = 3 )
    {
        var avg = values.Average();

        var avgAbs = values.Average( o => Math.Abs( o - avg ) );

        var result = avgAbs != 0
                             ? (current - avg) / (0.015D * avgAbs)
                             : (current != 0
                                        ? (current - avg) / (0.015D * current)
                                        : current);

        return Math.Round( result, round );
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="current"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public double DescRangeAmountAverage( List<Inputs.Price> prices, int current, int N )
    {
        var d = 0D;
        var m = 0;

        for( int r = 0; r < N; r++ )
        {
            m++;
            d += prices[ Math.Max( 0, current - r ) ].Amount!.Value;
        }

        return Math.Round( d / m, 0 );
    }

    /// <summary>
    /// DescRangeCloseAverage
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="current"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public double DescRangeCloseAverage( List<Inputs.Price> prices, int current, int N )
    {
        var d = 0D;
        var m = 0D;

        for( int r = 0; r < N; r++ )
        {
            m++;
            d += prices[ Math.Max( 0, current - r ) ].Close!.Value;
        }

        return Math.Round( d / m, 3 );
    }

    /// <summary>
    /// LLV
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="current"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public double LLV( List<Inputs.Price> prices, int current, int N )
    {
        var min = prices[current].Low!.Value; //new List<double>();
        for ( int r = 0; r < N; r++ )
        {
            //mins.Add( prices[ Math.Max( 0, current - r ) ].Low!.Value );
            min = Math.Min(min, prices[Math.Max(0, current - r)].Low!.Value);
        }

        return min;//.Min();
    }

    /// <summary>
    /// HHV
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="current"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public double HHV(List<Inputs.Price> prices, int current, int N)
    {
        var max = prices[current].High!.Value;// new List<double>();
        for (int r = 0; r < N; r++)
        {
            //maxes.Add( prices[ Math.Max( 0, current - r ) ].High!.Value );
            max = Math.Max(max, prices[Math.Max(0, current - r)].High!.Value);
        }

        return max;// maxes.Max();
    }
}