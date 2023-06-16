using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

public enum ThrottleType
{
    /// <summary>
    /// for triggering events only when the action has been stopped (no action after some duration).
    /// </summary>
    [Description("debounce"), EnumMember(Value = "debounce")]
    Debounce,

    /// <summary>
    /// for triggering event with a certain frequency.
    /// The frequency can be assigned with brush.
    /// </summary>
    [Description("fixRate"), EnumMember(Value = "fixRate")]
    FixRate
}