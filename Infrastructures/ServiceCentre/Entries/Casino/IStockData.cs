// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IStockData<T> : IStock
{
    /// <summary>
    /// 数据集合
    /// </summary>
    [JsonProperty( "values" )]
    IEnumerable<T> Values { get; set; }
}