/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            条件运算符
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */
using System.ComponentModel;

namespace Ban3.Infrastructures.Indicators.Enums;

/// <summary>
/// 条件运算符
/// </summary>
public enum ConditionSymbol
{
    /// <summary>
    /// 大于
    /// </summary>
    [Description("大于")]
    GT = 0,
    /// <summary>
    /// 大于等于
    /// </summary>
    [Description("大于等于")]
    GE = 1,
    /// <summary>
    /// 等于
    /// </summary>
    [Description("等于")]
    EQ = 2,
    /// <summary>
    /// 小于等于
    /// </summary>
    [Description("小于等于")]
    LE = 3,
    /// <summary>
    /// 小于
    /// </summary>
    [Description("小于")]
    LT = 4,
    /// <summary>
    /// 上穿
    /// </summary>
    [Description("上穿")]
    UC = 5,
    /// <summary>
    /// 下穿
    /// </summary>
    [Description("下穿")]
    DC = 6
}