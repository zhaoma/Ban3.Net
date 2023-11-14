// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 操作建议
/// </summary>
public interface IStockSuggest
{
    /// <summary>
    /// 购买日期
    /// </summary>
    [JsonProperty( "buyDate" )]
    string BuyDate { get; set; }

    /// <summary>
    /// 购买价格
    /// </summary>
    [JsonProperty( "buyPrice" )]
    decimal BuyPrice { get; set; }

    /// <summary>
    /// 售出日期
    /// </summary>
    [JsonProperty( "sellDate" )]
    string SellDate { get; set; }

    /// <summary>
    /// 售出价格
    /// </summary>
    [JsonProperty( "sellPrice" )]
    decimal SellPrice { get; set; }

    /// <summary>
    /// 改变比率
    /// </summary>
    [JsonProperty( "changeRatio" )]
    decimal ChangeRatio { get; set; }

    /// <summary>
    /// 建议正确
    /// </summary>
    [JsonProperty( "isCorrect" )]
    bool IsCorrect { get; set; }
}