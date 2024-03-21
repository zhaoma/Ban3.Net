// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 朝向
/// </summary>
public enum Orient
{
    /// 
    [Description("horizontal"), EnumMember(Value = "horizontal")]
    Horizontal,

    /// 
    [Description("vertical"), EnumMember(Value = "vertical")]
    Vertical
}