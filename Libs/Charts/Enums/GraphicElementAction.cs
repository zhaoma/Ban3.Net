using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    ///
    public enum GraphicElementAction
    {
        /// 
        [Description("merge"), EnumMember(Value = "merge")]
        Merge,

        /// 
        [Description("replace"), EnumMember(Value = "replace")]
        Replace,

        /// 
        [Description("remove"), EnumMember(Value = "remove")]
        Remove
    }
}
