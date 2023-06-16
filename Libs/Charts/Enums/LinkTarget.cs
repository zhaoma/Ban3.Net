using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

public enum LinkTarget
{
    /// <summary>
    /// 'self' opening it in current tab
    /// </summary>
    [Description("self"), EnumMember(Value = "self")]
    Self,

    /// <summary>
    /// 'blank' opening it in a new tab
    /// </summary>
    [Description("blank"), EnumMember(Value = "go..blank")]
    Blank
}