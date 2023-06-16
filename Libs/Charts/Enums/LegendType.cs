using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Type of legend.
/// </summary>
public enum LegendType
{
    /// <summary>
    /// Simple legend. (default)
    /// </summary>
    [Description("plain"), EnumMember(Value = "plain")]
    Plain,

    /// <summary>
    /// Scrollable legend. It helps when too many legend items needed to be shown.
    /// </summary>
    [Description("scroll"), EnumMember(Value = "scroll")]
    Scroll
}