//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CasinoServer;

/// <summary>
/// 备注特征
/// </summary>
public enum FeatureIs
{
    /// <summary>
    /// 常规
    /// </summary>
    Normal,

    /// <summary>
    /// 上升
    /// </summary>
    Plus,

    /// <summary>
    /// 下降
    /// </summary>
    Minus,

    /// <summary>
    /// 涨停
    /// </summary>
    LimitUp,

    /// <summary>
    /// 跌停
    /// </summary>
    LimitDown,

    /// <summary>
    /// 周期买点
    /// </summary>
    DotBuy,

    /// <summary>
    /// 周期卖点
    /// </summary>
    DotSell,

    /// <summary>
    /// 触涨停
    /// </summary>
    ReachUp,

    /// <summary>
    /// 触跌停
    /// </summary>
    ReachDown,

    /// <summary>
    /// MACD上穿0
    /// </summary>
    Launch,

    /// <summary>
    /// MACD下穿0
    /// </summary>
    Hold
}
