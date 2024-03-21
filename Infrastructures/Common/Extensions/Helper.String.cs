//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 字符串扩展方法
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToCamel( this string s )
    {
        return string.IsNullOrEmpty( s ) ? s : s[ 0 ].ToString().ToLower() + s.Substring( 1 );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToPascal( this string s )
    {
        return string.IsNullOrEmpty( s ) ? s : s[ 0 ].ToString().ToUpper() + s.Substring( 1 );
    }

    /// <summary>
    /// 转全角(SBC case)
    /// </summary>
    /// <param name="input">任意字符串</param>
    /// <returns>
    /// 全角字符串
    /// </returns>
    public static string ToSBC( this string input )
    {
        char[] c = input.ToCharArray();
        for( int i = 0; i < c.Length; i++ )
        {
            if( c[ i ] == 32 )
            {
                c[ i ] = (char)12288;
                continue;
            }

            if( c[ i ] < 127 )
                c[ i ] = (char)( c[ i ] + 65248 );
        }

        return new string( c );
    }

    /// <summary>
    /// 转半角(DBC case)
    /// </summary>
    /// <param name="input">任意字符串</param>
    /// <returns>
    /// 半角字符串
    /// </returns>
    public static string ToDBC( this string input )
    {
        char[] c = input.ToCharArray();
        for( int i = 0; i < c.Length; i++ )
        {
            if( c[ i ] == 12288 )
            {
                c[ i ] = (char)32;
                continue;
            }

            if( c[ i ] > 65280 && c[ i ] < 65375 )
                c[ i ] = (char)( c[ i ] - 65248 );
        }

        return new string( c );
    }

    /// <summary>
    /// Matches the specified s.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="pattern">The pattern.</param>
    /// <returns></returns>
    public static string Match( this string s, string pattern )
        => string.IsNullOrEmpty( s ) ? "" : Regex.Match( s, pattern ).Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string ToBase64String( byte[] bytes )
    {
        return Convert.ToBase64String( bytes );
    }

    #region SQL/HTML/TEXT

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsEmail( string source )
    {
        return Regex.IsMatch( source, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase );
    }

    /// <summary>
    /// 判断有无中文
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool HasChinese( string str )
    {
        return Regex.IsMatch( str, @"[\u4e00-\u9fa5]" );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inVal"></param>
    /// <returns></returns>
    public static string ConvertJapan( string inVal )
    {
        var jis = Encoding.GetEncoding( "Shift_JIS" );
        var gb2312 = Encoding.GetEncoding( "GB2312" );

        var buff = gb2312.GetBytes( inVal );
        buff = Encoding.Convert( jis, gb2312, buff );
        return gb2312.GetString( buff );
    }

    /// <summary>
    /// 防止注入
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static string SQLParse( this string text )
    {
        var sqlExp =
            new Regex(
                @"\s*\'\s+|\s(and|exec|insert|select|delete|update|count|drop|table|\*|\%|chr|mid|master|truncate|char|declare)\s" );

        return sqlExp.Replace( text + "", "" );
    }

    /// <summary>
    /// Strips the deny word.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="denyWords">The deny words.</param>
    /// <returns></returns>
    public static string StripDenyWord( this string content, string denyWords )
    {
        var sqlExp = new Regex( $".*({denyWords}).*" );
        return sqlExp.Replace( content, "" );
    }

    /// <summary>
    /// Strips the bad word.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="badWords">The bad words.</param>
    /// <param name="fixWord">The fix word.</param>
    /// <returns></returns>
    public static string StripBadWord( this string content, string badWords, string fixWord )
    {
        var sqlExp = new Regex( $"({badWords})" );
        return sqlExp.Replace( content, fixWord );
    }

    /// <summary>
    /// 清理HTML
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns></returns>
    public static string StripHTML( this string html )
    {
        string strOutput = html;

        var scriptRegExp = new Regex( "<scr" + "ipt[^>.]*>[\\s\\S]*?</sc" + "ript>",
                                      RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline &
                                      RegexOptions.ExplicitCapture );
        strOutput = scriptRegExp.Replace( strOutput, "" );

        var styleRegex = new Regex( "<style[^>.]*>[\\s\\S]*?</style>",
                                    RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline &
                                    RegexOptions.ExplicitCapture );
        strOutput = styleRegex.Replace( strOutput, "" );

        var objRegExp = new Regex( "<(.|\\n)+?>",
                                   RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline );
        strOutput = objRegExp.Replace( strOutput, "" );

        objRegExp = new Regex( "<[^>]+>", RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline );

        strOutput = objRegExp.Replace( strOutput, "" );

        strOutput = strOutput.Replace( "&lt;", "<" );
        strOutput = strOutput.Replace( "&gt;", ">" );
        strOutput = strOutput.Replace( "&nbsp;", " " );

        return strOutput;
    }

    /// <summary>
    /// Strips the HTML but image.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns></returns>
    public static string StripHTMLExceptImages( this string html )
    {
        string strOutput = html;

        Regex objRegExp = new Regex( "<[^img][^>]*>",
                                     RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline );
        strOutput = objRegExp.Replace( strOutput, "" );

        strOutput = strOutput.Replace( "&lt;", "<" );
        strOutput = strOutput.Replace( "&gt;", ">" );
        //&nbsp; 
        strOutput = strOutput.Replace( "&nbsp;", " " );

        return strOutput;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static string ObjToString( this object o )
    {
        return o + "";
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static bool IsMatch( this string input, string pattern )
    {
        if( string.IsNullOrEmpty( input ) ) return false;
        return Regex.IsMatch( input, pattern,
                              options: RegexOptions.IgnoreCase |
                                       RegexOptions.IgnorePatternWhitespace |
                                       RegexOptions.Multiline
        ) || ( input + "" ).ToUpper().Contains( ( pattern + "" ).ToUpper() );
    }

    /// <summary>
    /// 第一个匹配项
    /// </summary>
    /// <param name="input"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static string FirstMatchValue( this string input, string pattern )
    {
        var match = Regex.Match(
            input,
            pattern,
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline
        );

        return match.Groups[ 1 ].Value;
    }

    /// <summary>
    /// 第一张图片
    /// </summary>
    /// <param name="input"></param>
    /// <param name="imgSymbol"></param>
    /// <returns></returns>
    public static string FirstHtmlImage( this string input, string imgSymbol )
    {
        var pattern = $@"<img.+{imgSymbol}.+?src=[\""'](?<value>.+?)[\""'].*?>";
        return input.FirstMatchValue( pattern );
    }

    /// <summary>
    /// 查找表格单元格
    /// </summary>
    /// <param name="input"></param>
    /// <param name="tdSymbol"></param>
    /// <returns></returns>
    public static List<string> FindHtmlTd( this string input, string tdSymbol )
    {
        var pattern = $@"<td.+{tdSymbol}.+>(?<value>.+?)</td>";
        var matches = Regex.Matches( input, pattern );

        return ( from Match mc in matches select mc.Groups[ 1 ].Value ).ToList();
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="input"></param>
    /// <param name="prefix"></param>
    /// <param name="suffix"></param>
    /// <returns></returns>
    public static string Substr( this string input, string prefix, string suffix )
    {
        if( !input.Contains( prefix ) ) return string.Empty;

        var start = input.IndexOf( prefix, StringComparison.Ordinal ) + prefix.Length;
        var result = input.Substring( start );

        return !result.Contains( suffix )
            ? result
            : result.Substring( 0, result.Length - suffix.Length );
    }

    /// <summary>
    /// 移出jsonp标签
    /// </summary>
    /// <param name="input"></param>
    /// <param name="jsonp"></param>
    /// <returns></returns>
    public static string RemoveJsonpTags( this string input, string jsonp )
        => input.Substr( $"{jsonp}(", ");" );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inVal"></param>
    /// <param name="prefix"></param>
    /// <param name="suffix"></param>
    /// <returns></returns>
    public static List<string> SplitFix( this string inVal, string prefix, string suffix )
    {
        var result = new List<string>();
        try
        {
            var tmp = inVal;
            while( tmp.Contains( prefix ) )
            {
                tmp = tmp.Substring( tmp.IndexOf( prefix, StringComparison.Ordinal ) + prefix.Length );

                var item = tmp.Substring( 0, tmp.IndexOf( suffix, StringComparison.Ordinal ) );

                result.Add( item );
            }
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return result;
    }

    /// <summary>
    /// 抽取表格Tbody里的tr与td
    /// </summary>
    /// <param name="val"></param>
    /// <param name="tdStart"></param>
    /// <param name="tdEnd"></param>
    /// <returns></returns>
    public static List<List<string>> SplitTbody( this string val, string tdStart = "<td>", string tdEnd = "</td>" )
    {
        var result = new List<List<string>>();

        if( val.Contains( "</tbody>" ) )
        {
            val = val
                 .Substring( 0, val.IndexOf( "</tbody>", StringComparison.Ordinal ) )
                 .Substring( val.IndexOf( "<tbody>", StringComparison.Ordinal ) + 7 );
        }

        var trs = val.SplitFix( "<tr>", "</tr>" );
        if( trs.Any() )
        {
            result.AddRange(
                from tr in trs
                select tr.SplitFix( tdStart, tdEnd )
                into tds
                where tds.Any()
                select tds.Select( o => o.StripHTML() )
                          .ToList() );
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static StringBuilder AppendQuery<T>(
        this StringBuilder sb,
        string key,
        T? value )
    {
        if( value is null )
        {
            return sb;
        }
        if( sb.ToString() != "?" )
        {
            sb.Append( "&" );
        }
        sb.Append( $"{key}={value}" );

        return sb;
    }

    /// 
    public static bool DateGe( this string dateString, string dateVal )
    {
        if( string.IsNullOrEmpty( dateVal ) ) return true;

        return dateString.ToDateTime()
                         .Subtract( dateVal.ToDateTime() )
                         .Seconds
            >= 0;
    }

    /// 
    public static bool DateLe( this string dateString, string dateVal )
    {
        if( string.IsNullOrEmpty( dateVal ) ) return true;

        return dateVal.ToDateTime()
                      .Subtract( dateString.ToDateTime() )
                      .Seconds
            >= 0;
    }

    /// 
    public static bool StringExists( this string content, string key )
    {
        if( string.IsNullOrEmpty( key ) ) return true;

        var keys = key.Split( ' ' );
        return keys.Any( o => content.Contains( o.Trim() ) );
    }

    /// 
    public static bool StartsWithIn( this string content, IEnumerable<string> prefixes )
        => prefixes.Any( o => content.ToUpper().StartsWith( o.ToUpper() ) );

    /// 
    public static bool StringEquals( this string a, string b )
    {
        if( string.IsNullOrEmpty( a ) || string.IsNullOrEmpty( b ) ) return true;

        return a.Trim().ToUpper() == b.Trim().ToUpper();
    }
}