using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// The position of page buttons and page info.
/// </summary>
public enum Position
{
    /// <summary>
    /// 'start': on the left or top.
    /// </summary>
    [Description("start"), EnumMember(Value = "start")]
    Start,

    /// <summary>
    /// 'end': on the right or bottom.
    /// </summary>
    [Description("end"), EnumMember(Value = "end")]
    End,

    /// <summary>
    /// 'start': on the left or top.
    /// </summary>
    [Description("middle"), EnumMember(Value = "middle")]
    Middle,

    /// <summary>
    /// 'end': on the right or bottom.
    /// </summary>
    [Description("center"), EnumMember(Value = "center")]
    Center,

    /// 
    [Description("top"), EnumMember(Value = "top")]
    Top,

    /// 
    [Description("bottom"), EnumMember(Value = "bottom")]
    Bottom,

    /// 
    [Description("left"), EnumMember(Value = "left")]
    Left,

    /// 
    [Description("right"), EnumMember(Value = "right")]
    Right
}