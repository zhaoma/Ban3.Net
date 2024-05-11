//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino使用的指标输出结果
/// </summary>
public class IndicatorValue
{
    /// <summary>
    /// 指标类型
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; }
}
