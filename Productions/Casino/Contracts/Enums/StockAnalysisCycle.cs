/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            周期定义
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 周期定义
/// </summary>
public enum StockAnalysisCycle
{
    /// <summary>
    /// 日线
    /// </summary>
    [Description("日线")] DAILY = 1,

    /// <summary>
    /// 周线
    /// </summary>
    [Description("周线")] WEEKLY = 2,

    /// <summary>
    /// 月线
    /// </summary>
    [Description("月线")] MONTHLY = 3
}