//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino使用的指标输出结果
/// </summary>
public interface IIndicatorValue
{
    /// <summary>
    /// 指标类型
    /// </summary>
    IndexIs Index { get; set; }
}
