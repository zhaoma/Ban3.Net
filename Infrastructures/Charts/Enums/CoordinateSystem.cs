// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 使用的坐标系
/// </summary>
public enum CoordinateSystem
{
    /// <summary>
    /// 使用二维的直角坐标系（也称笛卡尔坐标系），
    /// 通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
    /// </summary>
    [Description("cartesian2d"), EnumMember(Value = "cartesian2d")]
    Cartesian2d,

    /// <summary>
    /// 使用极坐标系，通过 polarIndex 指定相应的极坐标组件
    /// </summary>
    [Description("polar"), EnumMember(Value = "polar")]
    Polar,

    /// <summary>
    /// 使用地理坐标系，通过 geoIndex 指定相应的地理坐标系组件。
    /// </summary>
    [Description("geo"), EnumMember(Value = "geo")]
    Geo,

    /// <summary>
    /// 使用日历坐标系，通过 calendarIndex 指定相应的日历坐标系组件。
    /// </summary>
    [Description("calendar"), EnumMember(Value = "calendar")]
    Calendar
}