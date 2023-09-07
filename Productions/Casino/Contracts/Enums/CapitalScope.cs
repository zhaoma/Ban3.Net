using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 股本范围，M=1百万
/// </summary>
public enum CapitalScope
{
    /// <summary>
    /// 五千万及以下
    /// </summary>
    [Description("CAPITAL<=50M")]
    LE50M,

    /// 
    [Description("50M<CAPITAL<=100M")]
    LE100M,

    /// 
    [Description("100M<CAPITAL<=200M")]
    LE200M,

    /// 
    [Description("200M<CAPITAL<=300M")]
    LE300M,

    /// 
    [Description("300M<CAPITAL<=500M")]
    LE500M,

    /// 
    [Description("500M<CAPITAL<=1000M")]
    LE1000M,

    /// 
    [Description("1000M<CAPITAL<=2000M")]
    LE2000M,

    /// 超过20亿
    [Description("CAPITAL>2000M")]
    GT2000M
}