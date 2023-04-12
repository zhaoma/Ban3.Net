using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    /// <summary>
    /// 搜狐网站数据下载
    /// </summary>
    public class Sohu
    {
        /// <summary>
        /// 搜狐板块映射
        /// </summary>
        public static List<Entities.Platforms.Sohu.Mapping> Mappings
        {
            get
            {
                return new List<Entities.Platforms.Sohu.Mapping>
                {
                        new Entities.Platforms.Sohu.Mapping
                        {
                                GroupName = "行业",
                                SohuId = 1631
                        },
                        new Entities.Platforms.Sohu.Mapping
                        {
                                GroupName = "地域",
                                SohuId = 1632
                        },
                        new Entities.Platforms.Sohu.Mapping
                        {
                                GroupName = "概念",
                                SohuId = 1630
                        }
                };
            }
        }

        /// <summary>
        /// 板块列表地址
        /// </summary>
        public static string UrlForNotions(int sohuId) => $"http://hq.stock.sohu.com/pl/pl-{sohuId}.html";

        /// <summary>
        /// 板块个股地址
        /// </summary>
        public static string UrlForNotionStocks(int notionId) => $"http://q.stock.sohu.com/cn/bk_{notionId}.shtml";
        
    }
}