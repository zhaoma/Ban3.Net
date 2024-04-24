//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 移动平均线参数
/// </summary>
public class MA : IIndicatorParameter
{
    public MA() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public MA(int shortPeriod, int longPeriod)
    {
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",shortPeriod },
            {"LONG",longPeriod }
        };
    }

    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.MA;

    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"SHORT",5 },
            {"LONG",20 }
        };


}
