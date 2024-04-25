﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Enums;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Newtonsoft.Json;
using System;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 分红解禁事件
/// </summary>
public  class Bonus:IBonus
{
    /// <summary>
    /// 除权日
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(YmdConverter))]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonProperty("eventType", NullValueHandling = NullValueHandling.Ignore)]
    public int EventType { get; set; }

    /// <summary>
    /// 事件主题
    /// </summary>
    [JsonProperty("eventSubject", NullValueHandling = NullValueHandling.Ignore)]
    public string EventSubject { get; set; }

    /// <summary>
    /// 送股(每十股)
    /// </summary>
    [JsonProperty("sbonus", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Sbonus { get; set; }

    /// <summary>
    /// 转增(每十股)
    /// </summary>
    [JsonProperty("zbonus", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Zbonus { get; set; }

    /// <summary>
    /// 派息(每十股)
    /// </summary>
    [JsonProperty("xmoney", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Xmoney { get; set; }

    /// <summary>
    /// 配股(每十股)
    /// </summary>
    [JsonProperty("pbonus", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Pbonus { get; set; }

    /// <summary>
    /// 配股价格
    /// </summary>
    [JsonProperty("pprice", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Pprice { get; set; }

    /// <summary>
    /// 基准股本
    /// </summary>
    [JsonProperty("pcapital", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Pcapital { get; set; }

    /// <summary>
    /// 解禁数量
    /// </summary>
    [JsonProperty("lifted", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Lifted { get; set; }
}