/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            事件类型
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Indicators.Enums
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum StockEventType
    {
        /// <summary>
        /// 分红
        /// </summary>
        [Description("分红")]
        Fenghong = 1,

        /// <summary>
        /// 配股
        /// </summary>
        [Description("配股")]
        Peigu = 2,

        /// <summary>
        /// 解禁
        /// </summary>
        [Description("解禁")]
        Jiejin = 4
    }
}
