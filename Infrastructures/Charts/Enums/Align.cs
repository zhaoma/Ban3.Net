using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Legend marker and text aligning.
/// By default, it automatically calculates from component location and orientation. 
/// When left value of this component is 'right', 
/// and the vertical layout (orient is 'vertical'), 
/// it would be aligned to 'right'.
/// </summary>
public enum Align
{
    /// 
    [Description("auto"), EnumMember(Value = "auto")]
    Auto,

    /// 
    [Description("left"), EnumMember(Value = "left")]
    Left,

    /// 
    [Description("right"), EnumMember(Value = "right")]
    Right,

    /// 
    [Description("top"), EnumMember(Value = "top")]
    Top,

    /// 
    [Description("bottom"), EnumMember(Value = "bottom")]
    Bottom
}