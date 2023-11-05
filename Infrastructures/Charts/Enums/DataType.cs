// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Special label types, are used to label maximum value, minimum value and so on.
/// </summary>
public enum DataType
{
    [Description("min"), EnumMember(Value = "min")]
    Min,

    [Description("max"), EnumMember(Value = "max")]
    Max,
    
    [Description("average"), EnumMember(Value = "average")]
    Average,
}