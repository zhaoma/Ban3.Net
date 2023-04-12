using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    public enum BorderType
    {
        [Description("solid"), EnumMember(Value = "solid")]
        Solid,

        [Description("dashed"), EnumMember(Value = "dashed")]
        Dashed,

        [Description("dotted"), EnumMember(Value = "dotted")]
        Dotted
    }
}
