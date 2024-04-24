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
/// 指数平滑异同移动平均线参数
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// MACD:(DIF-DEA)*2,COLORSTICK;
/// </summary>
public class MACD : IIndicatorParameter
{
    public MACD() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public MACD(int shortPeriod, int longPeriod,int midPeriod)
    {
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",shortPeriod },
            {"LONG",longPeriod },
            {"midPeriod",9 }
        };
    }

    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.MACD;

    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"SHORT",12 },
            {"LONG",26 },
            {"MID",9 }
        };
}
