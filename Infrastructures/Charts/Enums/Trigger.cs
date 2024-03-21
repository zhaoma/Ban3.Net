// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 触发类型
/// </summary>
public enum Trigger
{
    /// <summary>
    /// 数据项图形触发，主要在散点图，饼图等无类目轴的图表中使用。
    /// </summary>
    [Description("item"), EnumMember(Value = "item")]
    Item,

    /// <summary>
    /// 坐标轴触发，主要在柱状图，折线图等会使用类目轴的图表中使用。
    /// </summary>
    [Description("axis"), EnumMember(Value = "axis")]
    Axis,

    /// <summary>
    /// 什么都不触发。
    /// </summary>
    [Description("none"), EnumMember(Value = "none")]
    None
}