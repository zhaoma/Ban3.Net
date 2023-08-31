using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 堆积数值的策略，前提是stack属性已被设置
/// </summary>
public enum StackStrategy
{
    /// <summary>
    /// 只在要堆叠的值与当前累积的堆叠值具有相同的正负符号时才堆叠
    /// </summary>
    [Description("samesign"), EnumMember(Value = "samesign")]
    SameSign,

    /// <summary>
    /// 堆叠所有的值，不管当前或累积的堆叠值的正负符号是什么
    /// </summary>
    [Description("all"), EnumMember(Value = "all")]
    All,

    /// <summary>
    /// 只堆积正值
    /// </summary>
    [Description("positive"), EnumMember(Value = "positive")]
    Positive,

    /// <summary>
    /// 只堆叠负值
    /// </summary>
    [Description("negative"), EnumMember(Value = "negative")]
    Negative
}