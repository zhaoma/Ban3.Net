// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Vertical alignment of text, automatic by default.
/// </summary>
public enum VerticalAlign
{
    /// 
    [Description("top"), EnumMember(Value = "top")]
    Top,

    /// 
    [Description("middle"), EnumMember(Value = "middle")]
    Middle,

    /// 
    [Description("bottom"), EnumMember(Value = "bottom")]
    Bottom
}