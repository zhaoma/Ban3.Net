// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。
/// 从 v5.0.0 开始支持
/// </summary>
public enum Focus
{
    /// <summary>
    /// 'none' 不淡出其它图形，默认使用该配置。
    /// </summary>
    [Description("none"), EnumMember(Value = "none")]
    None,

    /// <summary>
    /// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
    /// </summary>
    [Description("self"), EnumMember(Value = "self")]
    Self,

    /// <summary>
    /// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
    /// </summary>
    [Description("series"), EnumMember(Value = "series")]
    Series
}