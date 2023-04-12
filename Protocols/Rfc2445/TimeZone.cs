using System;
using System.Collections.Generic;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 时区定义
    /// </summary>
    public class TimeZone : List<TimeZone.TimeZoneDetail>, ISerializeToICAL
    {
        /// <summary>
        /// 时区详情类
        /// </summary>
        public class TimeZoneDetail : ISerializeToICAL
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            public TimeZoneDetail()
            {
                Recurrences = new List<Recurrence>();
            }

            /// <summary>
            /// 
            /// </summary>
            public virtual string Type { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public virtual string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public virtual string ID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public virtual DateTime? Start { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public virtual TimeSpan? OffsetFrom { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public virtual TimeSpan? OffsetTo { get; set; }

            /// <summary>
            /// 循环定义
            /// </summary>
            public virtual ICollection<Recurrence> Recurrences { get; set; }

            /// <summary>
            /// 日历
            /// </summary>
            public Calendar Calendar { get; set; }

            /// <summary>
            /// 解析
            /// </summary>
            /// <param name="rdr"></param>
            /// <param name="serializer"></param>
            public void Deserialize( System.IO.TextReader rdr, Serializer serializer )
            {
                string name, value;
                var parameters = new System.Collections.Specialized.NameValueCollection();
                while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
                {
                    switch( name.ToUpper() )
                    {
                        case "TZID":
                            ID = value;
                            break;
                        case "TZNAME":
                            Name = value;
                            break;
                        case "DTSTART":
                            Start = value.ToDateTime();
                            break;
                        case "RRULE":
                            var rule = serializer.GetService<Recurrence>();
                            rule.Deserialize( value, parameters );
                            Recurrences.Add( rule );
                            break;
                        case "TZOFFSETFROM":
                            OffsetFrom = value.ToOffset();
                            break;
                        case "TZOFFSETTO":
                            OffsetTo = value.ToOffset();
                            break;
                        case "END":
                            return;
                    }
                }
            }

            /// <summary>
            /// 序列化
            /// </summary>
            /// <param name="wrtr"></param>
            public void Serialize( System.IO.TextWriter wrtr )
            {
                wrtr.BeginBlock( Type.ToUpper() );
                wrtr.Property( "TZID", ID );
                wrtr.Property( "TZNAME", Name );
                wrtr.Property( "DTSTART", Start );
                if( Recurrences != null )
                    foreach( var rule in Recurrences )
                        wrtr.Property( "RRULE", rule );
                if( OffsetFrom != null )
                    wrtr.Property( "TZOFFSETFROM", OffsetFrom.Value.FormatOffset() );
                if( OffsetFrom != null )
                    wrtr.Property( "TZOFFSETTO", OffsetTo.Value.FormatOffset() );
                wrtr.EndBlock( Type.ToUpper() );
            }
        }

        /// <summary>
        /// 日历
        /// </summary>
        public virtual Calendar Calendar { get; set; }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="serializer"></param>
        public void Deserialize( System.IO.TextReader rdr, Serializer serializer )
        {
            string name, value;
            var parameters = new System.Collections.Specialized.NameValueCollection();
            while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
            {
                switch( name )
                {
                    case "BEGIN":
                        var detail = serializer.GetService<TimeZoneDetail>();
                        detail.Type = value;
                        detail.Calendar = Calendar;
                        detail.Deserialize( rdr, serializer );
                        Add( detail );
                        break;
                    case "END":
                        if( value == "VTIMEZONE" )
                            return;
                        break;
                }
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="wrtr"></param>
        public void Serialize( System.IO.TextWriter wrtr )
        {
            if( Count == 0 ) return;
            wrtr.BeginBlock( "VTIMEZONE" );
            foreach( var detail in this )
            {
                detail.Calendar = Calendar;
                detail.Serialize( wrtr );
            }

            wrtr.EndBlock( "VTIMEZONE" );
        }
    }
}