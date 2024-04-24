//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Enums;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;
using System;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 复权因子
/// </summary>
public class Reinstate:IReinstate
{
    /// <summary>
    /// 除权日期
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(YmdConverter))]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 除权因子
    /// </summary>
    [JsonProperty("factor", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Factor { get; set; }
}
