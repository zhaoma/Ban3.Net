// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 从调色盘 option.color 中取色的策略
/// </summary>
public enum ColorBy
{
    /// <summary>
    /// 'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
    /// </summary>
    [Description("series"), EnumMember(Value = "series")]
    Series,

    /// <summary>
    /// 'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
    /// </summary>
    [Description("data"), EnumMember(Value = "data")]
    Data
}