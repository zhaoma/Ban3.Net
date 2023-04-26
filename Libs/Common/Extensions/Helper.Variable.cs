/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（变量类型转换）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Extensions
{
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
            int.TryParse( strValue+"", out var def );
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
        public static float ToFloat( this object strValue, float defValue = 0 )
        {
            float.TryParse( strValue.ToString(), out var def );
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
        public static bool ToBool( this object expression, bool defValue )
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
            catch( Exception ) {}

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
        /// <param name="inVal"></param>
        /// <returns></returns>
        public static long DatetimeToTimestamp( this DateTime inVal )
        {
            return Convert.ToInt64(
                                   new TimeSpan( inVal.ToUniversalTime().Ticks - 621355968000000000 )
                                           .TotalMilliseconds
                                  );
        }

        /// <summary>
        /// 找到周末
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime FindWeekend( this DateTime day )
        {
            DateTime weekend = day;
            while( weekend.DayOfWeek != DayOfWeek.Saturday )
                weekend = weekend.AddDays( 1.0 );
            return weekend;
        }

        /// <summary>
        /// 找到月末
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime FindMonthend( this DateTime day ) => new DateTime( day.Year, day.Month, 1 ).AddMonths( 1 );

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
        public static string ToAmount( this Decimal val ) => Math.Round( val / 10000M, 1 ).ToString() + "万";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToAmount( this double val ) => Math.Round( val / 1000000.0, 0 ).ToString() + "M";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToCapital( this long val ) => val <= 100000000L ? Math.Round( (Decimal)val / 10000M, 0 ).ToString() + "万" : Math.Round( (Decimal)val / 100000000M, 2 ).ToString() + "亿";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToCapitalInt( this double val ) => Math.Round( val / 1000000.0, 0 ).ToInt();
    }
}