﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 公共处理类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 
        /// </summary>
        public const string PRODID = "-//tracky/iCal//FUBU v1.0//EN";

        /// <summary>
        /// 
        /// </summary>
        public static readonly XNamespace xDav = XNamespace.Get( "DAV:" );

        /// <summary>
        /// 
        /// </summary>
        public static readonly XNamespace xCalDav = XNamespace.Get( "urn:ietf:params:xml:ns:caldav" );

        /// <summary>
        /// 
        /// </summary>
        public static readonly XNamespace xApple = XNamespace.Get( "http://apple.com/ns/ical/" );

        /// <summary>
        /// 
        /// </summary>
        public static readonly XNamespace xCardDav = XNamespace.Get( "urn:ietf:params:xml:ns:carddav" );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrtr"></param>
        /// <param name="name"></param>
        internal static void BeginBlock( this System.IO.TextWriter wrtr, string name )
        {
            wrtr.WriteLine( "BEGIN:" + name.ToUpper() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrtr"></param>
        /// <param name="name"></param>
        internal static void EndBlock( this System.IO.TextWriter wrtr, string name )
        {
            wrtr.WriteLine( "END:" + name.ToUpper() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrtr"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        internal static void Property( this System.IO.TextWriter wrtr, string name, IEnumerable<string> value )
        {
            wrtr.Property( name, string.Join( ",", value.Select( PropertyEncode ) ), true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Is( this string input, string other )
        {
            return string.Equals( input ?? string.Empty, other ?? string.Empty, StringComparison.OrdinalIgnoreCase );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="calendar"></param>
        /// <param name="TimeZoneID"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime( this string value, Calendar calendar, string TimeZoneID )
        {
            var date = ToDateTime( value );
            if( date == null ) return null;
            if( calendar == null ) return date;
            var info = calendar.TimeZones.SelectMany( x => x ).Where( x => x.ID == TimeZoneID );
            if( info == null ) return date;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T? ToEnum<T>( this string input ) where T : struct, IConvertible
        {
            if( string.IsNullOrEmpty( input ) ) return null;
            T ret;
            if( System.Enum.TryParse<T>( input.Replace( "-", "_" ), true, out ret ) )
                return ret;
            return null;
        }

        private static Regex rxDate = new Regex( @"(\d{4})(\d{2})(\d{2})T?(\d{2}?)(\d{2}?)(\d{2}?)(Z?)",
                                                 RegexOptions.IgnoreCase | RegexOptions.Compiled );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime( this string value )
        {
            if( string.IsNullOrEmpty( value ) )
                return null;

            DateTime ret;
            if( value.Length == 8 )
            {
                DateTime.TryParseExact(
                                       value,
                                       "yyyyMMdd",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.AdjustToUniversal,
                                       out ret );
                return ret;
            }

            var match = rxDate.Match( value );
            if( match.Success )
            {
                var d = new DateTime(
                                     match.Groups[ 1 ].Value.ToInt() ?? 0,
                                     match.Groups[ 2 ].Value.ToInt() ?? 0,
                                     match.Groups[ 3 ].Value.ToInt() ?? 0,
                                     match.Groups[ 4 ].Value.ToInt() ?? 0,
                                     match.Groups[ 5 ].Value.ToInt() ?? 0,
                                     match.Groups[ 6 ].Value.ToInt() ?? 0,
                                     DateTimeKind.Utc );
                return d;
            }
            else
            {
                if( DateTime.TryParse( value, out ret ) )
                    return ret;
            }

            return (DateTime?)null;
        }

        private static Regex rxOffset = new Regex( @"(\+|\-?)(\d{1,2})\:?(\d{2})?", RegexOptions.Compiled );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TimeSpan? ToOffset( this string input )
        {
            if( string.IsNullOrEmpty( input ) ) return null;
            var match = rxOffset.Match( input );
            if( !match.Success ) return null;
            var neg = match.Groups[ 1 ].Value == "-";
            var hours = match.Groups[ 2 ].Value.ToInt() ?? 0;
            var minutes = match.Groups[ 3 ].Value.ToInt() ?? 0;
            var off = TimeSpan.FromHours( hours + ((double)minutes / 60) );
            return neg ? -off : off;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="base"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static Uri ToUri( this string input, Uri? @base = null, UriKind kind = UriKind.Absolute )
        {
            Uri uri;
            if( @base != null )
            {
                if( Uri.TryCreate( @base, input, out uri ) )
                    return uri;
            }
            else if( Uri.TryCreate( input, kind, out uri ) )
                return uri;

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int? ToInt( this string input )
        {
            int ret;
            if( int.TryParse( input, out ret ) )
                return ret;
            else return (int?)null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string PropertyEncode( string value )
        {
            return value
                   .Replace( "\n", "\\n" )
                   .Replace( "\r", "\\r" )
                   .Replace( "\\", "\\\\" )
                   //.Replace(";", "\\;")
                   //.Replace(",", "\\,")
                   .Replace( "\r", "" );
        }

        private static string Decode( string value )
        {
            return value
                   .Replace( "\\n", "\n" )
                   .Replace( "\\r", "\r" )
                   .Replace( "\\\\", "\\" )
                   .Replace( "\\;", ";" )
                   .Replace( "\\,", "," );
        }

        internal static void Property( this System.IO.TextWriter wrtr,
                                       string name,
                                       string value,
                                       bool encoded = false,
                                       NameValueCollection? parameters = null )
        {
            if( value == null ) return;
            value = name.ToUpper() + FormatParameters( parameters ) + ":" + (encoded ? value : PropertyEncode( value ));
            while( value.Length > 75 )
            {
                wrtr.WriteLine( value.Substring( 0, 75 ) );
                value = "\t" + value.Substring( 75 );
            }

            if( value.Length > 0 ) wrtr.WriteLine( value );
        }

        internal static void Property( this System.IO.TextWriter wrtr, string name, DateTime? value )
        {
            if( value == null
                || value < System.Data.SqlTypes.SqlDateTime.MinValue.Value
                || value > System.Data.SqlTypes.SqlDateTime.MaxValue.Value ) return;
            wrtr.Property( name, FormatDate( value.Value ) );
        }

        internal static void Property( this System.IO.TextWriter wrtr, string name, Enum value )
        {
            if( value == null ) return;
            wrtr.Property( name, value.ToString().ToUpper() );
        }

        internal static void Property( this System.IO.TextWriter wrtr, string name, object value )
        {
            if( value == null ) return;
            wrtr.Property( name,
                           Convert.ToString( value ),
                           parameters : value is IHasParameters ? ((IHasParameters)value).GetParameters() : null );
        }

        internal static string FormatParameters( NameValueCollection parameters )
        {
            if( parameters == null || parameters.Count == 0 ) return string.Empty;

            var sb = new StringBuilder();
            foreach( var key in parameters.AllKeys )
            {
                sb.AppendFormat( ";{0}={1}", key, ParamEncode( parameters[ key ] ) );
            }

            return sb.ToString();
        }

        internal static IEnumerable<string> SplitEscaped( this string input, char split = ',', char escape = ' ' )
        {
            if( input == null )
                yield break;
            char c0 = '\0';
            string part = string.Empty;
            foreach( var c in input )
            {
                if( c == split && c0 != escape )
                {
                    yield return part;
                    part = string.Empty;
                }
                else part += c;

                c0 = c;
            }

            if( part != string.Empty ) yield return part;
        }

        internal static bool Property( this System.IO.TextReader rdr,
                                       out string name,
                                       out string value,
                                       NameValueCollection parameters )
        {
            var line = rdr.ReadLine();
            var oline = line;
            value = name = null;
            if( line == null )
                return false;
            int peek;
            while( (peek = rdr.Peek()) == 9 || peek == 32 )
                line += rdr.ReadLine().Substring( 1 );

            if( parameters != null ) parameters.Clear();

            var i = 0;
            var separators = new[] { ':', ';', '=' };
            string part, paramValue;
            char sep;

            while( line.Length > 0 )
            {
                i = line.IndexOfAny( separators );
                if( i == -1 )
                {
                    value = line;
                    return true;
                }

                sep = line[ i ];
                part = line.Substring( 0, i );
                line = line.Substring( i + 1 );

                if( name == null )
                {
                    name = part;
                    if( name == "SUMMARY" )
                    {
                        value = line;
                        return true;
                    }
                }
                else if( sep == ':' )
                {
                    value = line;
                    return true;
                }
                else if( sep == '=' )
                {
                    if( line.Length > 1 && line[ 0 ] == '"' )
                    {
                        paramValue = line.Substring( 1, line.IndexOf( '"', 1 ) - 1 );
                        line = line.Substring( paramValue.Length + 2 );
                        if( line.Length > 0 && line[ 0 ] == ';' ) line = line.Substring( 1 );
                    }
                    else
                    {
                        i = line.IndexOfAny( separators );
                        if( i == -1 ) i = line.Length;
                        paramValue = line.Substring( 0, i );
                        line = line.Substring( (int)Math.Min( line.Length, paramValue.Length + 1 ) );
                    }

                    paramValue = paramValue.Replace( "=3D", "=" ).Replace( "\\;", ";" );
                    parameters[ part ] = paramValue;
                }
            }

            return true;
        }

        internal static string ParamEncode( string value )
        {
            if( value == null ) return null;
            if( value.Contains( '=' ) || value.Contains( ';' ) )
                return '"' + value.Replace( "=", "=3D" ) + '"';
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatDate( this DateTime? dateTime )
        {
            if( dateTime == null ) return null;
            return FormatDate( dateTime.Value );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatDate( this DateTime dateTime )
        {
            //return dateTime.ToString("yyyyMMdd");
            return dateTime.ToString( "yyyyMMddTHHmmss" ) + (dateTime.Kind == DateTimeKind.Utc ? "Z" : "");
        }

        internal static string FormatOffset( this TimeSpan offset )
        {
            var neg = offset < TimeSpan.Zero;
            var minutes = (int)offset.TotalMinutes;
            var hours = (int)Math.Floor( (double)minutes / 60 );
            minutes -= hours * 60;

            return (neg ? "-" : null) + hours.ToString( "00" ) + minutes.ToString( "00" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="name"></param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static XElement Element( this XNamespace ns, string name, params object[] inner )
        {
            return new XElement( ns.GetName( name ), inner );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static XElement Element( this XName name, params object[] inner )
        {
            return new XElement( name, inner );
        }
    }
}