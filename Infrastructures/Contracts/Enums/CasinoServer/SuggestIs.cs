//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CasinoServer;

/// <summary>
/// 操作建议
/// </summary>
public enum SuggestIs
{
    /// <summary>
    /// 忽略(不参与的品种)
    /// </summary>
    Ignore,

    /// <summary>
    /// 买入
    /// </summary>
    Buy,

    /// <summary>
    /// 持有
    /// </summary>
    Keep,

    /// <summary>
    /// 卖出
    /// </summary>
    Sell,

    /// <summary>
    /// 跳过(卖出后不买入)
    /// </summary>
    Skip
}
