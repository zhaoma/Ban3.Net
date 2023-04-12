using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 
    /// </summary>
    public class CalendarQuery
    {
        /// <summary>
        /// 
        /// </summary>
        public class CalendarData : Property
        {
            internal override XElement Serialize()
            {
                return Common.xCalDav.Element( "calendar-data" );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class Property
        {
            internal abstract XElement Serialize();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="query"></param>
            public static implicit operator XElement( Property query )
            {
                return query.Serialize();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Property> Properties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static CalendarQuery SearchEvents( DateTime? from = null, DateTime? to = null )
        {
            return new CalendarQuery
            {
                    Properties = new System.Collections.Generic.List<CalendarQuery.Property>
                    {
                            new CalendarQuery.CalendarData()
                    },
                    Filter = new Filter
                    {
                            Filters = new[]
                            {
                                    new Filter.CompFilter
                                    {
                                            Name = "VCALENDAR",
                                            Filters = new[]
                                            {
                                                    to == null && from == null
                                                            ? null
                                                            : new Filter.CompFilter
                                                            {
                                                                    Name = "VEVENT",
                                                                    TimeRange = new Filter.TimeRangeFilter
                                                                    {
                                                                            Start = from.Value,
                                                                            End = to.Value,
                                                                    }
                                                            }
                                            }
                                    }
                            }
                    }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        public static implicit operator XElement( CalendarQuery query )
        {
            return Common.xCalDav.Element( "calendar-query",
                                           Common.xDav.Element( "prop", query.Properties.Select( x => (XElement)x ) ),
                                           (XElement)query.Filter
                                         );
        }
    }
}