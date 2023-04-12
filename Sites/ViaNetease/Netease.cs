using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease;

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    public class Netease
    {
        /// <summary>
        /// 
        /// </summary>
        static List<StockGroup> Data =>
                new List<StockGroup>
                {
                        new StockGroup { Identity = 0, Name = "深圳A股", NeteasePrefix = "1", CodePrefix = "sz" },
                        //new StockGroup {Identity = 1, Name = "深市基金", NeteasePrefix = "1",CodePrefix = "sz"},
                        //new StockGroup {Identity = 2, Name = "深市B股", NeteasePrefix = "1",CodePrefix = "sz"},
                        new StockGroup { Identity = 3, Name = "创业板", NeteasePrefix = "1", CodePrefix = "sz" },
                        new StockGroup { Identity = 4, Name = "中小板", NeteasePrefix = "1", CodePrefix = "sz" },
                        //new StockGroup {Identity = 5, Name = "沪市基金", NeteasePrefix = "0",CodePrefix = "sh"},
                        new StockGroup { Identity = 6, Name = "沪市A股", NeteasePrefix = "0", CodePrefix = "sh" },
                        //new StockGroup {Identity = 9, Name = "沪市B股", NeteasePrefix = "0",CodePrefix = "sh"},
                };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetName( int identity )
        {
            var row = Data.FindLast( o => o.Identity == identity );
            return row != null ? row.Name : "";
        }

        /// <summary>
        /// 网易股票代码前加0/1
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetCode( string code )
        {
            var p = code.Substring( 0, 1 );
            var group = Data.FindLast( o => o.Identity + "" == p );

            return group.NeteasePrefix + code;
        }

        /// <summary>
        /// 历史记录文件(日)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string UrlForDailyPricesFull( string code )
        {
            var urlForOneStock =
                    "http://quotes.money.163.com/service/chddata.html?code={0}&end={1}&fields=TCLOSE;HIGH;LOW;TOPEN;LCLOSE;CHG;PCHG;TURNOVER;VOTURNOVER;VATURNOVER;TCAP;MCAP";

            return string.Format( urlForOneStock, GetCode( code ), DateTime.Now.ToString( "yyyyMMdd" ) );
        }

        /// <summary>
        /// 读取即时行情
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static string UrlForReadRealtime( IEnumerable<string> codes )
        {
            var ss = codes.Aggregate( "", ( current, code ) => current + GetCode( code ) + "," );
            return $"http://api.money.126.net/data/feed/{ss}money.api";
        }

        /// <summary>
        /// 财务报表地址
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string UrlForFinances( string code )
        {
            return $"http://quotes.money.163.com/service/zycwzb_{code}.html";
        }
    }
}