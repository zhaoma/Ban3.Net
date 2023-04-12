using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 
        /// </summary>
        public CompFilter[] Filters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Filter() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public Filter( XElement filter )
        {
            var filters = new List<CompFilter>();
            foreach( var elm in filter.Elements() )
            {
                var obj = Create( elm );
                if( obj == null ) continue;
                if( obj is CompFilter )
                    filters.Add( (CompFilter)obj );
            }

            Filters = filters.ToArray();
        }

        private static object Create( XElement elm )
        {
            switch( elm.Name.LocalName.ToLower() )
            {
                case "filter":
                    return new Filter( elm );
                case "comp-filter":
                    return new CompFilter( elm );
                case "time-range":
                    return new TimeRangeFilter( elm );
                case "prop-filter":
                    return new PropFilter( elm );
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator XElement( Filter a )
        {
            return Common.xCalDav.Element( "filter",
                                           a.Filters == null || a.Filters.Length == 0 ? null : a.Filters.Select( f => (XElement)f )
                                         );
        }

        /// <summary>
        /// 
        /// </summary>
        public class CompFilter
        {
            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public CompFilter[] Filters { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public PropFilter[] Properties { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public TimeRangeFilter TimeRange { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool? IsDefined { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public CompFilter() {}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="filter"></param>
            public CompFilter( XElement filter )
            {
                Name = (string)filter.Attribute( "name" );
                var props = new List<PropFilter>();
                var filters = new List<CompFilter>();
                foreach( var elm in filter.Elements() )
                {
                    switch( elm.Name.LocalName )
                    {
                        case "is-defined":
                            IsDefined = true;
                            continue;
                    }

                    var obj = Create( elm );
                    if( obj == null ) continue;
                    if( obj is PropFilter )
                        props.Add( (PropFilter)obj );
                    if( obj is TimeRangeFilter )
                        TimeRange = (TimeRangeFilter)obj;
                    if( obj is CompFilter )
                        filters.Add( (CompFilter)obj );
                }

                Properties = props.ToArray();
                Filters = filters.ToArray();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            public static explicit operator XElement( CompFilter a )
            {
                return Common.xCalDav.Element( "comp-filter",
                                               new XAttribute( "name", a.Name ),
                                               a.IsDefined != true ? null : Common.xCalDav.Element( "is-defined" ),
                                               a.TimeRange == null ? null : (XElement)a.TimeRange,
                                               a.Properties == null || a.Properties.Length == 0 ? null : a.Properties.Select( f => (XElement)f ),
                                               a.Filters == null || a.Filters.Length == 0 ? null : a.Filters.Select( f => (XElement)f )
                                             );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class PropFilter : ValueFilter
        {
            /// <summary>
            /// 
            /// </summary>
            public PropFilter() {}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="filter"></param>
            public PropFilter( XElement filter )
                    : base( filter ) {}
        }

        /// <summary>
        /// 
        /// </summary>
        public class ParamFilter : ValueFilter
        {
            /// <summary>
            /// 
            /// </summary>
            public ParamFilter() {}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="filter"></param>
            public ParamFilter( XElement filter )
                    : base( filter ) {}
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class ValueFilter
        {
            /// <summary>
            /// 
            /// </summary>
            public ValueFilter() {}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="filter"></param>
            public ValueFilter( XElement filter )
            {
                Name = (string)filter.Attribute( "name" );
                var paramfilters = new List<ParamFilter>();
                foreach( var elm in filter.Elements() )
                {
                    switch( elm.Name.LocalName )
                    {
                        case "text-match":
                            Text = elm.Value;
                            IgnoreCase = (string)elm.Attribute( "caseless" ) == "yes";
                            break;
                        case "param-filter":
                            paramfilters.Add( new ParamFilter( elm ) );
                            break;
                    }

                    Parameters = paramfilters.ToArray();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool? IgnoreCase { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public ParamFilter[] Parameters { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            public static explicit operator XElement( ValueFilter a )
            {
                return Common.xCalDav.Element( (a is PropFilter ? "prop" : "param") + "-filter",
                                               string.IsNullOrEmpty( a.Name ) ? null : new XAttribute( "name", a.Name ),
                                               string.IsNullOrEmpty( a.Text )
                                                       ? null
                                                       : new XElement( Common.xCalDav.GetName( "text-match" ),
                                                                       new XAttribute( "caseless", a.IgnoreCase == true ? "yes" : "no" ), a.Text ),
                                               a.Parameters == null || a.Parameters.Length == 0 ? null : a.Parameters.Select( f => (XElement)f )
                                             );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class TimeRangeFilter
        {
            /// <summary>
            /// 
            /// </summary>
            public TimeRangeFilter() {}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="elm"></param>
            public TimeRangeFilter( XElement elm )
            {
                var attr = elm.Attribute( "start" );
                if( attr != null ) Start = ((string)attr).ToDateTime();

                attr = elm.Attribute( "end" );
                if( attr != null ) End = ((string)attr).ToDateTime();
            }

            /// <summary>
            /// 
            /// </summary>
            public DateTime? Start { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public DateTime? End { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="a"></param>
            public static explicit operator XElement( TimeRangeFilter a )
            {
                return Common.xCalDav.Element( "time-range",
                                               a.Start == null ? null : new XAttribute( "start", a.Start.Value.ToString( "yyyyMMddTHHmmssZ" ) ),
                                               a.End == null ? null : new XAttribute( "end", a.End.Value.ToString( "yyyyMMddTHHmmssZ" ) )
                                             );
            }
        }
    }
}