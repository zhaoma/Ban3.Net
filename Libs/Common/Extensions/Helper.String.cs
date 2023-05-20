/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（字符串）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Ban3.Infrastructures.Common.Extensions
{
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
        public static string ToCamel(this string s)
        {
            return string.IsNullOrEmpty(s) ? s : s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascal(this string s)
        {
            return string.IsNullOrEmpty(s) ? s : s[0].ToString().ToUpper() + s.Substring(1);
        }

        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>
        /// 全角字符串
        /// </returns>
        public static string ToSBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }

                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }

            return new string(c);
        }

        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>
        /// 半角字符串
        /// </returns>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }

                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }

            return new string(c);
        }

        /// <summary>
        /// Determines whether the specified s is match.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>
        ///   <c>true</c> if the specified s is match; otherwise, <c>false</c>.
        /// </returns>
        /*
	    public static bool IsMatch( this string s, string pattern )
        {
            if( s == null ) return false;
            return Regex.IsMatch( s, pattern );
        }
        */

        /// <summary>
        /// Matches the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static string Match(this string s, string pattern)
        {
            if (s == null) return "";
            return Regex.Match(s, pattern).Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        #region SQL/HTML/TEXT

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 判断有无中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inVal"></param>
        /// <returns></returns>
        public static string ConvertJapan(string inVal)
        {
            var jis = Encoding.GetEncoding("Shift_JIS");
            var gb2312 = Encoding.GetEncoding("GB2312");

            var buff = gb2312.GetBytes(inVal);
            buff = Encoding.Convert(jis, gb2312, buff);
            return gb2312.GetString(buff);
        }

        /// <summary>
        /// 防止注入
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string SQLParse(this string text)
        {
            var sqlExp =
                new Regex(
                    @"\s*\'\s+|\s(and|exec|insert|select|delete|update|count|drop|table|\*|\%|chr|mid|master|truncate|char|declare)\s");

            return sqlExp.Replace(text + "", "");
        }

        /// <summary>
        /// Strips the deny word.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="denyWords">The deny words.</param>
        /// <returns></returns>
        public static string StripDenyWord(this string content, string denyWords)
        {
            var sqlExp = new Regex(string.Format(".*({0}).*", denyWords));
            return sqlExp.Replace(content, "");
        }

        /// <summary>
        /// Strips the bad word.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="badWords">The bad words.</param>
        /// <param name="fixWord">The fix word.</param>
        /// <returns></returns>
        public static string StripBadWord(this string content, string badWords, string fixWord)
        {
            var sqlExp = new Regex(string.Format("({0})", badWords));
            return sqlExp.Replace(content, fixWord);
        }

        /// <summary>
        /// 清理HTML
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string StripHTML(this string html)
        {
            string strOutput = html;

            var scriptRegExp = new Regex("<scr" + "ipt[^>.]*>[\\s\\S]*?</sc" + "ript>",
                RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline &
                RegexOptions.ExplicitCapture);
            strOutput = scriptRegExp.Replace(strOutput, "");

            var styleRegex = new Regex("<style[^>.]*>[\\s\\S]*?</style>",
                RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline &
                RegexOptions.ExplicitCapture);
            strOutput = styleRegex.Replace(strOutput, "");

            var objRegExp = new Regex("<(.|\\n)+?>",
                RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline);
            strOutput = objRegExp.Replace(strOutput, "");

            objRegExp = new Regex("<[^>]+>", RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline);

            strOutput = objRegExp.Replace(strOutput, "");

            strOutput = strOutput.Replace("&lt;", "<");
            strOutput = strOutput.Replace("&gt;", ">");
            strOutput = strOutput.Replace("&nbsp;", " ");

            return strOutput;
        }

        /// <summary>
        /// Strips the HTML but image.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string StripHTMLButImage(this string html)
        {
            string strOutput = html;

            Regex objRegExp = new Regex("<[^img][^>]*>",
                RegexOptions.IgnoreCase & RegexOptions.Compiled & RegexOptions.Multiline);
            strOutput = objRegExp.Replace(strOutput, "");

            strOutput = strOutput.Replace("&lt;", "<");
            strOutput = strOutput.Replace("&gt;", ">");
            //&nbsp; 
            strOutput = strOutput.Replace("&nbsp;", " ");

            return strOutput;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToString(this object o)
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
        public static bool IsMatch(this string input, string pattern)
        {
            if (string.IsNullOrEmpty(input)) return false;
            return Regex.IsMatch(input, pattern,
                RegexOptions.IgnoreCase |
                RegexOptions.IgnorePatternWhitespace |
                RegexOptions.Multiline
            ) || (input + "").ToUpper().Contains((pattern + "").ToUpper());
        }

        public static string FirstMatchValue(this string input, string pattern)
        {
            var match = Regex.Match(
                input,
                pattern,
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline
            );

            return match.Groups[1].Value;
        }

        public static string FirstHtmlImage(this string input, string imgSymbol)
        {
            var pattern = string.Format(@"<img.+{0}.+?src=[\""'](?<value>.+?)[\""'].*?>", imgSymbol);
            return input.FirstMatchValue(pattern);
        }

        public static List<string> FindHtmlTd(this string input, string tdSymbol)
        {
            var result = new List<string>();

            var pattern = string.Format(@"<td.+{0}.+>(?<value>.+?)</td>", tdSymbol);
            var matchs = Regex.Matches(input, pattern);

            foreach (Match mc in matchs)
            {
                result.Add(mc.Groups[1].Value);
            }

            return result;
        }

        public static string Substr(this string input, string prefix, string suffix)
        {
            if (!input.Contains(prefix)) return string.Empty;

            var start = input.IndexOf(prefix) + prefix.Length;
            var result = input.Substring(start);

            if (!result.Contains(suffix)) return result;
            return result.Substring(0, result.Length - suffix.Length);
        }

        public static string RemoveJsonp(this string input, string jsonp)
            => input.Substr($"{jsonp}(", ");");


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inVal"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static List<string> SplitFix(this string inVal, string prefix, string suffix)
        {
            var result = new List<string>();
            try
            {
                var tmp = inVal;
                while (tmp.Contains(prefix))
                {
                    tmp = tmp.Substring(tmp.IndexOf(prefix) + prefix.Length);

                    var item = tmp.Substring(0, tmp.IndexOf(suffix));
                    result.Add(item);

                    //tmp = tmp.Substring(tmp.IndexOf(end) + end.Length);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// 抽取表格Tbody里的tr与td
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static List<List<string>> SplitTbody(this string val, string tdStart = "<td>", string tdEnd = "</td>")
        {
            var result = new List<List<string>>();

            if (val.Contains("</tbody>"))
            {
                val = val.Substring(0, val.IndexOf("</tbody>")).Substring(val.IndexOf("<tbody>") + 7);
            }

            var trs = val.SplitFix("<tr>", "</tr>");
            if (trs != null && trs.Any())
            {
                foreach (var tr in trs)
                {
                    var tds = tr.SplitFix(tdStart, tdEnd);
                    if (tds != null && tds.Any())
                    {
                        result.Add(tds.Select(o => o.StripHTML()).ToList());
                    }
                }
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
        public static StringBuilder AppendQuery(
            this StringBuilder sb,
            string key,
            string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (sb.ToString() != "?")
                    sb.Append("&");
                sb.Append($"{key}={value}");
            }

            return sb;
        }


        public static StringBuilder AppendQuery(this StringBuilder sb, string key, Enum? value)
        {
            if (value != null)
            {
                if (sb.ToString() != "?")
                    sb.Append("&");

                sb.Append($"{key}={value}");
            }

            return sb;
        }

        public static StringBuilder AppendQuery(this StringBuilder sb, string key, int? value)
        {
            if (value != null)
            {
                if (sb.ToString() != "?")
                    sb.Append("&");

                sb.Append($"{key}={value}");
            }

            return sb;
        }

        public static StringBuilder AppendQuery(this StringBuilder sb, string key, bool? value)
        {
            if (value != null)
            {
                if (sb.ToString() != "?")
                    sb.Append("&");

                sb.Append($"{key}={value}");
            }

            return sb;
        }

        public static bool DateGE(this string dateString, string dateVal)
        {
            if (string.IsNullOrEmpty(dateVal)) return true;

            return dateString.ToDateTime()
                       .Subtract(dateVal.ToDateTime())
                       .Seconds
                   >= 0;
        }

        public static bool DateLE(this string dateString, string dateVal)
        {
            if (string.IsNullOrEmpty(dateVal)) return true;

            return dateVal.ToDateTime()
                       .Subtract(dateString.ToDateTime())
                       .Seconds
                   >= 0;
        }

        public static bool StringExists(this string content, string key)
        {
            if (string.IsNullOrEmpty(key)) return true;

            var keys = key.Split(' ');
            return keys.Any(o => content.Contains(o.Trim()));
        }
    }
}