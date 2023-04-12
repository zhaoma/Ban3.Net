using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 指示器类型
    /// </summary>
    public enum AxisPointerType
    {
        /// <summary>
        /// 直线指示器
        /// </summary>
        [Description("line"), EnumMember(Value = "line")]
        Line,

        /// <summary>
        /// 阴影指示器
        /// </summary>
        [Description("shadow"), EnumMember(Value = "shadow")]
        Shadow,

        /// <summary>
        /// 无指示器
        /// </summary>
        [Description("none"), EnumMember(Value = "none")]
        None
    }
}
