using System.Collections.Generic;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 日历集合定义
    /// </summary>
    public class CalendarCollection : List<Calendar>, ISerializeToICAL
    {
        /// <summary>
        /// 实例化
        /// </summary>
        public CalendarCollection() {}

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="calendars"></param>
        public CalendarCollection( IEnumerable<Calendar> calendars ) : base( calendars ) {}

        /// <summary>
        /// 反序列化
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
                    case "BEGIN":
                        if( value == "VCALENDAR" )
                        {
                            var e = serializer.GetService<Calendar>();
                            e.Deserialize( rdr, serializer );
                            this.Add( e );
                        }

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
            foreach( var cal in this )
                cal.Serialize( wrtr );
        }
    }
}