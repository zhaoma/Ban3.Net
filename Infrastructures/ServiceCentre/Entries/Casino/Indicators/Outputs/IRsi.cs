//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 相对强弱指标
/// 受计算公式的限制，不论价位如何变动，强弱指标的值均在0与100之间。⑵强弱指标保持高于50表示为强势市场，反之低于50表示为弱势市场
/// 强弱指标多在70与30之间波动。当六日指标上升到达80时，表示股市已有超买现象，如果一旦继续上升，超过90以上时，则表示已到严重超买的警戒区，股价已形成头部，极可能在短期内反转回转
/// 当六日强弱指标下降至20时，表示股市有超卖现象，如果一旦继续下降至10以下时则表示已到严重超卖区域，股价极可能有止跌回升的机会
/// </summary>
public interface IRsi : IEvaluation<IRsi>
{
    /// <summary>
    /// LC:=REF(CLOSE,1);
    /// </summary>
    [JsonProperty( "lc" )]
    decimal LC { get; set; }

    /// <summary>
    /// RSI1:SMA(MAX(CLOSE-LC,0),N1,1)/SMA(ABS(CLOSE-LC),N1,1)*100;
    /// </summary>
    [JsonProperty( "rsi1" )]
    decimal RSI1 { get; set; }

    /// <summary>
    /// RSI2:SMA(MAX(CLOSE-LC,0),N2,1)/SMA(ABS(CLOSE-LC),N2,1)*100;
    /// </summary>
    [JsonProperty( "rsi2" )]
    decimal RSI2 { get; set; }

    /// <summary>
    /// RSI3:SMA(MAX(CLOSE-LC,0),N3,1)/SMA(ABS(CLOSE-LC),N3,1)*100;
    /// </summary>
    [JsonProperty( "rsi3" )]
    decimal RSI3 { get; set; }
}