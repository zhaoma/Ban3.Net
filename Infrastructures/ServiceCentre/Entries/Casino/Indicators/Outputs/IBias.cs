﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 乖离率
/// </summary>
public interface IBias : IEvaluation<IBias>
{
    /// <summary>
    /// 乖离
    /// </summary>
    [JsonProperty( "bias" )]
    decimal BIAS { get; set; }

    /// <summary>
    /// 平均乖离
    /// </summary>
    [JsonProperty( "biasma" )]
    decimal BIASMA { get; set; }
}