//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 财务事件类型
/// </summary>
public enum EventIs
{
    /// <summary>
    /// 分红
    /// </summary>
    [JsonProperty("sharing")]
    Sharing,

    /// <summary>
    /// 配股
    /// </summary>
    [JsonProperty("stockBonus")]
    StockBonus
}