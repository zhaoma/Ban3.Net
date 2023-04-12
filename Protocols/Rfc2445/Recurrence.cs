using System;
using System.Linq;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 循环周期定义
    /// </summary>
    public class Recurrence : IHasParameters
    {
        /// <summary>
        /// 循环类型
        /// </summary>
        public Frequencies? Frequency { get; set; }

        /// <summary>
        /// 执行次数
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 间隔
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? Until { get; set; }

        /// <summary>
        /// 年度循环月份
        /// </summary>
        public int? ByMonth { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string[] ByDay { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public int? ByMonthDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Collections.Specialized.NameValueCollection GetParameters()
        {
            return null;
        }

        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var parameters = new System.Collections.Specialized.NameValueCollection();
            if( Count != null ) parameters[ "COUNT" ] = Count.ToString();
            if( Interval != null ) parameters[ "INTERVAL" ] = Interval.ToString();
            if( Frequency != null ) parameters[ "FREQ" ] = Frequency.Value.ToString().ToUpper();
            if( Until != null ) parameters[ "UNTIL" ] = Common.FormatDate( Until.Value );
            if( ByMonth != null ) parameters[ "BYMONTH" ] = ByMonth.ToString();
            if( ByMonthDay != null ) parameters[ "BYMONTHDAY" ] = ByMonthDay.ToString();
            if( ByDay != null && ByDay.Length > 0 ) parameters[ "BYDAY" ] = string.Join( ",", ByDay );

            var rrule = Common.FormatParameters( parameters ).TrimStart( ';' );

            return rrule;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameters"></param>
        public void Deserialize( string value, System.Collections.Specialized.NameValueCollection parameters )
        {
            Count = parameters[ "COUNT" ].ToInt();
            Interval = parameters[ "INTERVAL" ].ToInt();
            Frequency = parameters[ "FREQ" ].ToEnum<Frequencies>();
            Until = parameters[ "UNTIL" ].ToDateTime();
            ByMonth = parameters[ "BYMONTH" ].ToInt();
            ByMonthDay = parameters[ "BYMONTHDAY" ].ToInt();
            ByDay = parameters[ "BYDAY" ].SplitEscaped().ToArray();
        }
    }
}