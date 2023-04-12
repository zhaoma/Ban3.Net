
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Sohu
{
    /// <summary>
    /// 
    /// </summary>
    public class Mapping
    {
        /// <summary>
        /// 搜狐ID
        /// </summary>
        public int SohuId { get; set; }

        /// <summary>
        /// 板块分组
        /// </summary>
        public string GroupName { get; set; }=string.Empty;

        /// <summary>
        /// 郁垒主键
        /// </summary>
        public List<Notion> Notions { get; set; }
    }
}
