using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 动画特效
/// </summary>
public enum EasingEffect
{
    /// 
    [Description("linear"), EnumMember(Value = "linear")]
    Linear,

    /// 
    [Description("quadraticIn"), EnumMember(Value = "quadraticIn")]
    QuadraticIn,

    /// 
    [Description("quadraticOut"), EnumMember(Value = "quadraticOut")]
    QuadraticOut,

    /// 
    [Description("quadraticInOut"), EnumMember(Value = "quadraticInOut")]
    QuadraticInOut,

    /// 
    [Description("cubicIn"), EnumMember(Value = "cubicIn")]
    CubicIn,

    /// 
    [Description("cubicOut"), EnumMember(Value = "cubicOut")]
    CubicOut,

    /// 
    [Description("cubicInOut"), EnumMember(Value = "cubicInOut")]
    CubicInOut,

    /// 
    [Description("quarticIn"), EnumMember(Value = "quarticIn")]
    QuarticIn,

    /// 
    [Description("quarticOut"), EnumMember(Value = "quarticOut")]
    QuarticOut,

    /// 
    [Description("quarticInOut"), EnumMember(Value = "quarticInOut")]
    QuarticInOut,

    /// 
    [Description("quinticIn"), EnumMember(Value = "quinticIn")]
    QuinticIn,

    /// 
    [Description("quinticOut"), EnumMember(Value = "quinticOut")]
    QuinticOut,

    /// 
    [Description("quinticInOut"), EnumMember(Value = "quinticInOut")]
    QuinticInOut,

    /// 
    [Description("sinusoidalIn"), EnumMember(Value = "sinusoidalIn")]
    SinusoidalIn,

    /// 
    [Description("sinusoidalOut"), EnumMember(Value = "sinusoidalOut")]
    SinusoidalOut,

    /// 
    [Description("sinusoidalInOut"), EnumMember(Value = "sinusoidalInOut")]
    SinusoidalInOut,

    /// 
    [Description("exponentialIn"), EnumMember(Value = "exponentialIn")]
    ExponentialIn,

    /// 
    [Description("exponentialOut"), EnumMember(Value = "exponentialOut")]
    ExponentialOut,

    /// 
    [Description("exponentialInOut"), EnumMember(Value = "exponentialInOut")]
    ExponentialInOut,

    /// 
    [Description("circularIn"), EnumMember(Value = "circularIn")]
    CircularIn,

    /// 
    [Description("circularOut"), EnumMember(Value = "circularOut")]
    CircularOut,

    /// 
    [Description("circularInOut"), EnumMember(Value = "circularInOut")]
    CircularInOut,

    /// 
    [Description("elasticIn"), EnumMember(Value = "elasticIn")]
    ElasticIn,

    /// 
    [Description("elasticOut"), EnumMember(Value = "elasticOut")]
    ElasticOut,

    /// 
    [Description("elasticInOut"), EnumMember(Value = "elasticInOut")]
    ElasticInOut,

    /// 
    [Description("backIn"), EnumMember(Value = "backIn")]
    BackIn,

    /// 
    [Description("backOut"), EnumMember(Value = "backOut")]
    BackOut,

    /// 
    [Description("backInOut"), EnumMember(Value = "backInOut")]
    BackInOut,

    /// 
    [Description("bounceIn"), EnumMember(Value = "bounceIn")]
    BounceIn,

    /// 
    [Description("bounceOut"), EnumMember(Value = "bounceOut")]
    BounceOut,

    /// 
    [Description("bounceInOut"), EnumMember(Value = "bounceInOut")]
    BounceInOut
}