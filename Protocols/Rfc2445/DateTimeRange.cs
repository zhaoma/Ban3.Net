using System;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 时间区间
    /// </summary>
    public struct DateTimeRange
    {
        /// <summary>
        /// 开始
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// 截止
        /// </summary>
        public DateTime? To { get; set; }
    }
}