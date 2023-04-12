using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 浮层的渲染模式
    /// </summary>
    public enum RenderMode
    {
        /// <summary>
        /// 额外的 DOM 节点展示 tooltip
        /// </summary>
        [Description("html"), EnumMember(Value = "html")]
        Html,

        /// <summary>
        /// 以富文本的形式渲染
        /// </summary>
        [Description("richText"), EnumMember(Value = "richText")]
        RichText
    }
}
