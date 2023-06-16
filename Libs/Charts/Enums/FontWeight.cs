using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// font thick weight.
/// 100 | 200 | 300 | 400... not supported now.
/// </summary>
public enum FontWeight
{
    /// <summary>
    /// normal
    /// </summary>
    [Description("normal"), EnumMember(Value = "normal")]
    Normal,

    /// <summary>
    /// bold
    /// </summary>
    [Description("bold"), EnumMember(Value = "bold")]
    Bold,

    /// <summary>
    /// bolder
    /// </summary>
    [Description("bolder"), EnumMember(Value = "bolder")]
    Bolder,

    /// <summary>
    /// lighter
    /// </summary>
    [Description("lighter"), EnumMember(Value = "lighter")]
    Lighter
}
