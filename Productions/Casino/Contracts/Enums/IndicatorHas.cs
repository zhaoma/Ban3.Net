using System;
namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 信号周期枚举
/// </summary>
[Flags]
public enum IndicatorHas
{
    /// <summary>
    /// 
    /// </summary>
    Daily,

    /// <summary>
    /// 周线出现信号
    /// </summary>
    Weekly,

    /// <summary>
    /// 月线出现信号
    /// </summary>
    Monthly
}

