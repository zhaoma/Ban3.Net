using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 绘制类型
/// </summary>
public enum Shape
{
    /// <summary>
    /// 
    /// </summary>
    [Description("polygon"), EnumMember(Value = "polygon")]
    Polygon,

    /// <summary>
    /// 
    /// </summary>
    [Description("circle"), EnumMember(Value = "circle")]
    Circle
}