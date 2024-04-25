﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 买卖线参数
/// </summary>
public class MX : IIndicatorParameter
{
    public MX() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public MX(int n, int m)
    {
        Parameters = new Dictionary<string, int>
        {
            {"N",n },
            {"M",m }
        };
    }

    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndexIs Index { get; set; } = IndexIs.MX;

    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"N",2 },
            {"M",4 }
        };


}