/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标类型
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Indicators.Enums
{
    /// <summary>
    /// 指标类型
    /// </summary>
    public enum IndicatorKind
    {
        /// <summary>
        /// 均线
        /// </summary>
        [Description("均线")]
        Junxian =1,
        /// <summary>
        /// 趋势
        /// </summary>
        [Description("趋势")]
        Qushi =2,
        /// <summary>
        /// 情绪
        /// </summary>
        [Description("情绪")]
        Qingxu =3,
        /// <summary>
        /// 波动
        /// </summary>
        [Description("波动")]
        Bodong =4
    }
}
