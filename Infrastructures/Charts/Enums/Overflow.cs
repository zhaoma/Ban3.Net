using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 文字超出宽度是否截断或者换行
/// 配置width时有效
/// </summary>
public enum Overflow
{
    [Description("none"), EnumMember(Value = "none")]
    None,

    /// <summary>
    /// 截断，并在末尾显示ellipsis配置的文本，默认为...
    /// </summary>
    [Description("truncate"), EnumMember(Value = "truncate")]
    Truncate,

    /// <summary>
    /// 换行
    /// </summary>
    [Description("break"), EnumMember(Value = "break")]
    Break,

    /// <summary>
    /// 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
    /// </summary>
    [Description("breakAll"), EnumMember(Value = "breakAll")]
    BreakAll
}