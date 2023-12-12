﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 多空指标,Bull And Bear Index
/// </summary>
public interface IBbi : IEvaluation<IBbi>
{
    /// <summary>
    /// 均线型指标，一般选用3日、6日、12日、24日等4条平均线
    /// BBI:(MA(CLOSE, M1)+MA(CLOSE, M2)+MA(CLOSE, M3)+MA(CLOSE, M4))/4;
    /// </summary>
    [JsonProperty( "bbi" )]
    decimal BBI { get; set; }
}