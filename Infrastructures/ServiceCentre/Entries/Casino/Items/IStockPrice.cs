//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 标的价格数据声明
/// </summary>
public interface IStockPrice : IStockRecord
{
    /// <summary>
    /// 前收盘价
    /// </summary>
    [JsonProperty( "preClose" )]
    decimal PreClose { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    [JsonProperty( "open" )]
    decimal Open { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty( "close" )]
    decimal Close { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    [JsonProperty( "high" )]
    decimal High { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    [JsonProperty( "low" )]
    decimal Low { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    [JsonProperty( "turnover" )]
    decimal Turnover { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    [JsonProperty( "vol" )]
    double Vol { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    [JsonProperty( "amount" )]
    double Amount { get; set; }
}