// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 视觉映射组件类型
/// </summary>
public enum VisualMapType
{
    /// <summary>
    /// 连续型（visualMapContinuous）
    /// </summary>
    [Description("continuous"), EnumMember(Value = "continuous")]
    Continuous,

    /// <summary>
    /// 分段型（visualMapPiecewise）
    /// </summary>
    [Description("piecewise"), EnumMember(Value = "piecewise")]
    Piecewise
}