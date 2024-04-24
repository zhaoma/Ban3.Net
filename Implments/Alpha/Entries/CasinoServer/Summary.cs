//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Enums;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino市场汇总信息
/// </summary>
public class Summary:ISummary
{
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(YmdConverter))]
    public DateTime MarkTime { get; set; }

    [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
    public List<IResult> Results { get; set; }
}
