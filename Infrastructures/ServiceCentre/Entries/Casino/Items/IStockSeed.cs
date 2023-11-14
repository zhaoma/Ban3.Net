// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 复权因子
/// </summary>
public interface IStockSeed : IStockRecord
{
    /// <summary>
    /// 复权系数
    /// </summary>
    [JsonProperty( "factor" )]
    decimal Factor { get; set; }
}