// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// 
public enum Symbol
{
    /// 
    [Description("circle"), EnumMember(Value = "circle")]
    Circle,

    /// 
    [Description("rect"), EnumMember(Value = "rect")]
    Rect,

    /// 
    [Description("roundRect"), EnumMember(Value = "roundRect")]
    RoundRect,

    /// 
    [Description("triangle"), EnumMember(Value = "triangle")]
    Triangle,

    /// 
    [Description("diamond"), EnumMember(Value = "diamond")]
    Diamond,

    /// 
    [Description("pin"), EnumMember(Value = "pin")]
    Pin,

    /// 
    [Description("arrow"), EnumMember(Value = "arrow")]
    Arrow,

    /// 
    [Description("none"), EnumMember(Value = "none")]
    None
}