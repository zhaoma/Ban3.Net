using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 市值范围
/// </summary>
public enum ValueScope
{
    /// 20亿及以下
    [Description("VALUE<=2B")]
    LE2B,

    /// 
    [Description("2B<CAPITAL<=5B")]
    LE5B,

    /// 
    [Description("5B<CAPITAL<=10B")]
    LE10B,

    /// 
    [Description("10B<CAPITAL<=20B")]
    LE20B,

    /// <summary>
    /// 超过200亿
    /// </summary>
    [Description("VALUE>20B")]
    GT20B
}