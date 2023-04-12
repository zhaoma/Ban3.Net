using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease
{
    /// <summary>
    /// 
    /// </summary>
    public class StockGroups
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<StockGroup> Data =>
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
    }
}