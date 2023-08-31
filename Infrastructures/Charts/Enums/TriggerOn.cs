using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// Conditions to trigger tooltip. 
/// </summary>
public enum TriggerOn
{
    /// <summary>
    /// Trigger when mouse moves.
    /// </summary>
    [Description("mousemove"), EnumMember(Value = "mousemove")]
    Mouseover,

    /// <summary>
    /// Trigger when mouse clicks.
    /// </summary>
    [Description("click"), EnumMember(Value = "click")]
    Click,

    /// <summary>
    /// 同时鼠标移动和点击时触发。
    /// </summary>
    [Description("mousemove|click"), EnumMember(Value = "mousemove|click")]
    MouseoverOrClick,

    /// <summary>
    /// 不在 'mousemove' 或 'click' 时触发，
    /// 用户可以通过 action.tooltip.showTip 和 action.tooltip.hideTip 来手动触发和隐藏。
    /// 也可以通过 axisPointer.handle 来触发或隐藏。
    /// </summary>
    [Description("none"), EnumMember(Value = "none")]
    None
}