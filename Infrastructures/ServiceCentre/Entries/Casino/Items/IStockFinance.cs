// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 标的财务数据声明
/// </summary>
public interface IStockFinance : IStockRecord
{
    /// <summary>
    /// 每股净资产
    /// </summary>
    [JsonProperty( "equity" )]
    decimal Equity { get; set; }

    /// <summary>
    /// 每股收益
    /// </summary>
    [JsonProperty( "earnings" )]
    decimal Earnings { get; set; }

    /// <summary>
    /// 总资产
    /// </summary>
    [JsonProperty( "assets" )]
    public decimal Assets { get; set; }

    /// <summary>
    /// 总负债
    /// </summary>
    [JsonProperty( "debts" )]
    public decimal Debts { get; set; }

    /// <summary>
    /// 总利润
    /// </summary>
    [JsonProperty( "profits" )]
    public decimal Profits { get; set; }

    /// <summary>
    /// 收益率
    /// </summary>
    [JsonProperty( "rateOfReturn" )]
    decimal RateOfReturn { get; set; }

    /// <summary>
    /// 原始股本
    /// </summary>
    [JsonProperty( "capitalOriginal" )]
    long CapitalOriginal { get; set; }

    /// <summary>
    /// 流通股本
    /// </summary>
    [JsonProperty( "negotiableCapital", NullValueHandling = NullValueHandling.Ignore )]
    long NegotiableCapital { get; set; }

    /// <summary>
    /// 总股本
    /// </summary>
    [JsonProperty( "capital" )]
    long Capital { get; set; }

    /// <summary>
    /// 流通股本
    /// </summary>
    [JsonProperty( "tradable" )]
    long Tradable { get; set; }
}