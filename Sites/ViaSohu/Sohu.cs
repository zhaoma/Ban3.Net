using System.Collections.Generic;
using Ban3.Sites.ViaSohu.Entries;

namespace Ban3.Sites.ViaSohu
{
    /// <summary>
    /// 搜狐网站数据下载
    /// </summary>
    public class Sohu
    {
        /// <summary>
        /// 搜狐板块映射
        /// </summary>
        public static List<Mapping> Mappings
        {
            get
            {
                return new List<Mapping>
                {
                        new Mapping
                        {
                                GroupName = "行业",
                                SohuId = 1631
                        },
                        new Mapping
                        {
                                GroupName = "地域",
                                SohuId = 1632
                        },
                        new Mapping
                        {
                                GroupName = "概念",
                                SohuId = 1630
                        }
                };
            }
        }
    }
}