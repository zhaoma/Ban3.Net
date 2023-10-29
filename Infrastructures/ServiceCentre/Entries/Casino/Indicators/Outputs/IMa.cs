﻿using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 价格均线指标
/// </summary>
public interface IMa : IStockRecord, IEvaluation<IMa>
{
    /// <summary>
    /// 价格均线集合
    /// </summary>
    [JsonProperty("lines")]
    IEnumerable<ILine<decimal>> Lines { get; set; }
}