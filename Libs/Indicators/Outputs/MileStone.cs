/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的里程碑）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的里程碑
    /// </summary>
    public class MileStone
            : StockLog
    {
        /// <summary>
        /// 
        /// </summary>
        public List<NoticeDate>? NoticeDates { get; set; }
    }
}