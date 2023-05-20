using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 板块
/// </summary>
public enum StockGroup
{
    /// <summary>
    /// 深证A股
    /// </summary>
    [Description("深证A股")]
    SZA = 1,

    /// <summary>
    /// 中小板
    /// </summary>
    [Description("中小板")]
    SZZ = 2,

    /// <summary>
    /// 创业板
    /// </summary>
    [Description("创业板")]
    SZC = 3,

    /// <summary>
    /// 上证A股
    /// </summary>
    [Description("上证A股")]
    SHA = 6,

    /// <summary>
    /// 科创板
    /// </summary>
    [Description("科创板")]
    SHK = 7
}