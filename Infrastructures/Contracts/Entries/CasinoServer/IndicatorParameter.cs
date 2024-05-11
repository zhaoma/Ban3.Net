//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino使用的指标输入参数
/// </summary>
public class IndicatorParameter
{
    /// <summary>
    /// 指标类型
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; }

    /// <summary>
    /// 入参
    /// MA:D5,D30
    /// MACD:(13.26.9)
    /// MXCD:(2,4)
    /// </summary>
    public Dictionary<string, int> Parameters { get; set; }
}
