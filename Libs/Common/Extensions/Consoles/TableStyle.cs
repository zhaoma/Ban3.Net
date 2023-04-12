/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            表格显示样式
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Extensions.Consoles
{
    /// <summary>
    /// 表格显示样式
    /// </summary>
    public enum TableStyle
    {
        /// <summary>
        /// 默认格式的表格
        /// </summary>
        Default = 0,

        /// <summary>
        /// Markdwon格式的表格
        /// </summary>
        MarkDown = 1,

        /// <summary>
        /// 交替格式的表格
        /// </summary>
        Alternative = 2,

        /// <summary>
        /// 最简格式的表格
        /// </summary>
        Minimal = 3
    }

}