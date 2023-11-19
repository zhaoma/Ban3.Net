// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 随机震荡指数
/// </summary>
public interface IKd : IStockRecord, IEvaluation<IKd> 
{
    /// <summary>
    /// K线
    /// </summary>
    [JsonProperty("k")]
    decimal K { get; set; }

    /// <summary>
    /// D线
    /// </summary>
    [JsonProperty("d")]
    decimal D { get; set; }
}
