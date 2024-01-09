//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 异同移动平均线指标
/// </summary>
public interface IMacd : IEvaluation<IMacd>
{
    /// <summary>
    /// 快线
    /// </summary>
    [JsonProperty( "dif" )]
    decimal DIF { get; set; }

    /// <summary>
    /// 加权移动均线
    /// </summary>
    [JsonProperty( "dea" )]
    decimal DEA { get; set; }

    /// <summary>
    /// MACD柱
    /// </summary>
    [JsonProperty( "macd" )]
    decimal MACD { get; set; }
}