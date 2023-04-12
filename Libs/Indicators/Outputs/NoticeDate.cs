/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的提示日期）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的提示日期
    /// </summary>
    public class NoticeDate
    {
        /// ctor
        public NoticeDate() {}

        /// <summary>
        /// 日
        /// </summary>
        public DateTime Day { get; set; }

        /// <summary>
        /// 周
        /// </summary>
        public DateTime Week { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public DateTime Month { get; set; }
    }
}