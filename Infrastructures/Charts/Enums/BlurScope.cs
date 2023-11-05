// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 在开启focus的时候，可以通过blurScope配置淡出的范围。
/// </summary>
public enum BlurScope
{
    /// <summary>
    /// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
    /// </summary>
    [Description("coordinateSystem"), EnumMember(Value = "coordinateSystem")]
    CoordinateSystem,

    /// <summary>
    /// 'series' 淡出范围为系列。
    /// </summary>
    [Description("series"), EnumMember(Value = "series")]
    Series,

    /// <summary>
    /// 'global' 淡出范围为全局。
    /// </summary>
    [Description("global"), EnumMember(Value = "global")]
    Global
}