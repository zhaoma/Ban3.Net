// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 布局方式
/// https://echarts.apache.org/zh/option.html#parallel.layout
/// </summary>
public enum Layout
{
    /// <summary>
    /// 水平排布各个坐标轴
    /// </summary>
    [Description("horizontal"), EnumMember(Value = "horizontal")]
    Horizontal,

    /// <summary>
    /// 竖直排布各个坐标轴
    /// </summary>
    [Description("vertical"), EnumMember(Value = "vertical")]
    Vertical
}