// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 坐标轴类型
/// </summary>
public enum AxisType
{
    /// <summary>
    /// 类目轴，适用于离散的类目数据。
    /// 为该类型时类目数据可自动从 series.data 或 dataset.source 中取，或者可通过 angleAxis.data 设置类目数据。
    /// </summary>
    [Description("category"), EnumMember(Value = "category")]
    Category,

    /// <summary>
    /// 数值轴，适用于连续数据。
    /// </summary>
    [Description("value"), EnumMember(Value = "value")]
    Value,

    /// <summary>
    ///  时间轴，适用于连续的时序数据，
    ///  与数值轴相比时间轴带有时间的格式化，
    ///  在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
    /// </summary>
    [Description("time"), EnumMember(Value = "time")]
    Time,

    /// <summary>
    /// 对数轴。适用于对数数据。
    /// </summary>
    [Description("log"), EnumMember(Value = "log")]
    Log
}
