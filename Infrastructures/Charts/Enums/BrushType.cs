using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 选框组件的控制按钮
/// </summary>
public enum BrushType
{
    /// <summary>
    /// 开启矩形选框选择功能
    /// </summary>
    [Description("rect"), EnumMember(Value = "rect")]
    Rect,

    /// <summary>
    /// 开启任意形状选框选择功能
    /// </summary>
    [Description("polygon"), EnumMember(Value = "polygon")]
    Polygon,

    /// <summary>
    /// 开启横向选择功能
    /// </summary>
    [Description("lineX"), EnumMember(Value = "lineX")]
    LineX,

    /// <summary>
    /// 开启纵向选择功能
    /// </summary>
    [Description("lineY"), EnumMember(Value = "lineY")]
    LineY,

    /// <summary>
    /// 切换『单选』和『多选』模式。后者可支持同时画多个选框。前者支持单击清除所有选框。
    /// </summary>
    [Description("keep"), EnumMember(Value = "keep")]
    Keep,

    /// <summary>
    /// 清空所有选框
    /// </summary>
    [Description("clear"), EnumMember(Value = "clear")]
    Clear
}