//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    布局方式
//  reference:https://echarts.apache.org/zh/option.html#parallel.layout
//  ————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 
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