// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Globalization;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 变量相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// Toes the int.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static int ToInt( this object? strValue, int defValue = 0 )
    {
        int.TryParse( strValue + "", out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the tiny int.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static byte ToByte( this object strValue, byte defValue = 0 )
    {
        byte.TryParse( strValue.ToString(), out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the small int.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static short ToShort( this object strValue, short defValue = 0 )
    {
        short.TryParse( strValue.ToString(), out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the decimal.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static decimal ToDecimal( this object strValue, decimal defValue = 0 )
    {
        decimal.TryParse( strValue.ToString(), out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the float.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static float ToFloat( this object? strValue, float defValue = 0 )
    {
        float.TryParse( strValue + "", out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the double.
    /// </summary>
    /// <param name="strValue"></param>
    /// <param name="defValue"></param>
    /// <returns></returns>
    public static double ToDouble( this object strValue, double defValue = 0 )
    {
        double.TryParse( strValue.ToString(), out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the big int.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static Int64 ToInt64( this object strValue, Int64 defValue = 0 )
    {
        Int64.TryParse( strValue.ToString(), out var def );
        return def == 0 ? defValue : def;
    }

    /// <summary>
    /// Toes the bool.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="defValue">if set to <c>true</c> [def value].</param>
    /// <returns></returns>
    public static bool ToBool( this object? expression, bool defValue )
    {
        if( expression == null )
        {
            return defValue;
        }

        if( String.Compare( expression.ToString(), "true", StringComparison.OrdinalIgnoreCase ) == 0 )
        {
            return true;
        }

        if( String.Compare( expression.ToString(), "false", StringComparison.OrdinalIgnoreCase ) == 0 )
        {
            return false;
        }

        if( String.Compare( expression.ToString(), "1", StringComparison.OrdinalIgnoreCase ) == 0 )
        {
            return true;
        }

        if( String.Compare( expression.ToString(), "0", StringComparison.OrdinalIgnoreCase ) == 0 )
        {
            return false;
        }

        return defValue;
    }

    /// <summary>
    /// Toes the date time.
    /// </summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="defValue">The def value.</param>
    /// <returns></returns>
    public static DateTime ToDateTime( this object strValue, DateTime defValue )
    {
        try
        {
            DateTime.TryParse( strValue.ToString(), out var def );
            return def == Convert.ToDateTime( null ) ? defValue : def;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return Convert.ToDateTime( null );
    }

    /// 
    public static DateTime ToDateTime( this object strValue, DateTime defValue, string format )
    {
        try
        {
            DateTime.TryParseExact( strValue.ToString(), format, CultureInfo.CurrentCulture, DateTimeStyles.None,
                                    out var def );
            return def == Convert.ToDateTime( null ) ? defValue : def;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return Convert.ToDateTime( null );
    }

    /// <summary>
    /// 转日期
    /// </summary>
    /// <param name="strValue"></param>
    /// <returns></returns>
    public static DateTime ToDateTime( this object strValue )
    {
        var defaultValue = DateTime.MinValue;
        return strValue.ToDateTime( defaultValue );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strValue"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeEx( this object strValue, string format = "yyyyMMdd" )
    {
        var defaultValue = DateTime.MinValue;
        return strValue.ToDateTime( defaultValue, format );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inVal"></param>
    /// <returns></returns>
    public static long DatetimeToTimestamp( this DateTime inVal )
    {
        return Convert.ToInt64(
            new TimeSpan( inVal.ToUniversalTime().Ticks - 621355968000000000 )
               .TotalMilliseconds
        );
    }

    /// 
    public static bool TimeGe( this DateTime inVal, DateTime compareTime )
        =>
            inVal.Subtract( new DateTime(
                                inVal.Year,
                                inVal.Month,
                                inVal.Day,
                                compareTime.Hour,
                                compareTime.Minute,
                                compareTime.Second
                            ) )
                 .TotalSeconds >= 0;

    /// <summary>
    /// 找到周末
    /// </summary>
    /// <param name="day"></param>
    /// <returns></returns>
    public static DateTime FindWeekEnd( this DateTime day )
    {
        DateTime weekend = day;
        while( weekend.DayOfWeek != DayOfWeek.Saturday )
        {
            weekend = weekend.AddDays( 1 );
        }
        return weekend;
    }

    /// <summary>
    /// 找到月末
    /// </summary>
    /// <param name="day"></param>
    /// <returns></returns>
    public static DateTime FindMonthEnd( this DateTime day ) => new DateTime( day.Year, day.Month, 1 ).AddMonths( 1 );

    /// <summary>
    /// 金额（币种）
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToMoney( this Decimal val ) => val.ToString( "C" );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToAmount( this Decimal val ) => Math.Round( val / 10000M, 1 ) + "万";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToAmount( this double val ) => Math.Round( val / 1000000.0, 0 ) + "M";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToCapital( this long val )
        => val <= 100000000L
            ? Math.Round( val / 10000M, 0 ) + "万"
            : Math.Round( val / 100000000M, 2 ) + "亿";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int ToCapitalInt( this double val ) => Math.Round( val / 1000000.0, 0 ).ToInt();

    /// 
    public static string ToYmd( this DateTime val ) => val.ToString( "yyyyMMdd" );

    /// 
    public static DateTime FromYmd( this string val ) => val.ToDateTimeEx();

    /// <summary>
    /// 相同日期
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="inVal"></param>
    /// <returns></returns>
    public static bool DateEqual( this DateTime dt, DateTime inVal ) => inVal.ToYmd().Equals( dt.ToYmd() );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="close"></param>
    /// <param name="preClose"></param>
    /// <param name="changeRatio"></param>
    /// <returns></returns>
    public static bool IsLimit( this double close, double preClose, decimal changeRatio )
    {
        var a = Math.Round( preClose * (double)( changeRatio / 100M + 1 ), 2 );
        var b = Math.Round( close, 2 );

        return a <= b;
    }
}