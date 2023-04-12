using System;
using System.Collections.Specialized;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 提醒触发器
    /// https://tools.ietf.org/html/rfc2445#section-4.8.6
    /// TRIGGER:-P15M(A trigger set 15 minutes prior to the start of the event or to-do.)
    /// TRIGGER;RELATED=END:P5M(A trigger set 5 minutes after the end of the event or to-do.)
    /// TRIGGER;VALUE=DATE-TIME:19980101T050000Z(A trigger set to an absolute date/time.)
    /// </summary>
    public class Trigger : IHasParameters
    {
        /// <summary>
        /// 触发依据时间(开始/结束)
        /// </summary>
        public enum Relateds
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            Start,

            /// <summary>
            /// 结束时间
            /// </summary>
            End
        }

        /// <summary>
        /// 默认Start
        /// </summary>
        public Relateds Related { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// 指定提醒时间
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetParameters()
        {
            var values = new NameValueCollection();
            if( DateTime != null ) values[ "VALUE" ] = "DATE-TIME";
            if( DateTime == null && Related != Relateds.Start )
                values[ "RELATED" ] = Related.ToString().ToUpper();
            return values;
        }

        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if( DateTime != null ) return Common.FormatDate( DateTime.Value );
            if( Duration != null )
            {
                var total = Math.Abs( Duration.Value.TotalSeconds );
                var weeks = Math.Floor( total / 3600 / 24 / 7 );
                total -= weeks * 3600 * 24 * 7;
                var days = Math.Floor( total / 3600 / 24 );
                total -= days * 3600 * 24;
                var hours = Math.Floor( total / 3600 );
                total -= hours * 3600;
                var minutes = Math.Floor( total / 60 );
                var seconds = (total -= minutes * 60);

                return (Duration.Value < TimeSpan.Zero ? "-" : null)
                       + "P"
                       + (weeks > 0 ? (weeks + "W") : null)
                       + (days > 0 ? (days + "D") : null)
                       + (weeks > 0 || days > 0 ? "T" : null)
                       + (hours > 0 ? (hours + "H") : null)
                       + (minutes > 0 ? (minutes + "M") : null)
                       + (seconds > 0 ? (seconds + "S") : null);
            }

            return null;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameters"></param>
        public void Deserialize( string value, NameValueCollection parameters )
        {
            if( string.Equals( parameters[ "VALUE" ], "DATE-TIME", StringComparison.OrdinalIgnoreCase ) )
            {
                DateTime = value.ToDateTime();
            }
            else
            {
                Relateds related;
                if( Enum.TryParse<Relateds>( parameters[ "RELATED" ], true, out related ) )
                    Related = related;

                var duration = TimeSpan.Zero;
                var neg = false;
                var num = "";
                foreach( var c in value.ToUpper() )
                {
                    if( char.IsDigit( c ) )
                    {
                        num += c;
                    }
                    else
                    {
                        switch( c )
                        {
                            case '-':
                                neg = true;
                                continue;
                            case 'W':
                                duration = duration.Add( TimeSpan.FromDays( (num.ToInt() ?? 0) * 7 ) );
                                break;
                            case 'D':
                                duration = duration.Add( TimeSpan.FromDays( num.ToInt() ?? 0 ) );
                                break;
                            case 'H':
                                duration = duration.Add( TimeSpan.FromHours( num.ToInt() ?? 0 ) );
                                break;
                            case 'M':
                                duration = duration.Add( TimeSpan.FromMinutes( num.ToInt() ?? 0 ) );
                                break;
                            case 'S':
                                duration = duration.Add( TimeSpan.FromSeconds( num.ToInt() ?? 0 ) );
                                break;
                        }

                        num = string.Empty;
                    }
                }

                Duration = neg ? -duration : duration;
            }
        }
    }
}