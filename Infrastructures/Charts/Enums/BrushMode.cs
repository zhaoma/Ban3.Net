// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Default brush mode, whose value can be:
/// 'single': for single selection;
/// 'multiple': for multiple selection.
/// </summary>
public enum BrushMode
{
    [Description("single"), EnumMember(Value = "single")]
    Single,

    [Description("multiple"), EnumMember(Value = "multiple")]
    Multiple
}