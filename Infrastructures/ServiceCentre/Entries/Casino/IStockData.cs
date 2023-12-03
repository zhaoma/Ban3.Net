﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Newtonsoft.Json;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

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