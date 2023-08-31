using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 标签重叠的时候是否挪动标签位置以防止重叠
/// </summary>
public enum MoveOverlap
{
    /// <summary>
    /// 'shiftX' 水平方向依次位移，在水平方向对齐时使用
    /// </summary>
    [Description("shiftX"), EnumMember(Value = "shiftX")]
    ShiftX,

    /// <summary>
    /// 'shiftY' 垂直方向依次位移，在垂直方向对齐时使用
    /// </summary>
    [Description("shiftY"), EnumMember(Value = "shiftY")]
    ShiftY
}