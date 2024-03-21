// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// font style.
/// </summary>
public enum FontStyle
{
    /// <summary>
    /// normal
    /// </summary>
    [Description("normal"), EnumMember(Value = "normal")]
    Normal,

    /// <summary>
    /// italic
    /// </summary>
    [Description("italic"), EnumMember(Value = "italic")]
    Italic,

    /// <summary>
    /// oblique
    /// </summary>
    [Description("oblique"), EnumMember(Value = "oblique")]
    Oblique
}