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
/// 成交量参数
/// </summary>
public class AMOUNT : IIndicatorParameter
{
    public AMOUNT() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public AMOUNT(int shortPeriod, int longPeriod)
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
            {"LONG",10 }
        };


}
