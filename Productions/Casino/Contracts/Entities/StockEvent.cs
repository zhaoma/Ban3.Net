using System;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Sites.ViaSina.Entries;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class StockEvent
{
    public StockEvent(){}

    public StockEvent(ShareBonus o)
    {
        MarkTime=o.MarkTime;
        EventType =o.EventType;
        EventSubject=o.EventSubject;
        Sbonus = o.Sbonus;
        Zbonus=o.Zbonus;
        Xmoney=o.Xmoney;
        Pbonus=o.Pbonus;
        Pprice=o.Pprice;
        Pcapital=o.Pcapital;
        Lifted=o.Lifted;
    }

    /// <summary>
    /// 除权日
    /// </summary>
    [JsonProperty("MarkTime")]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonProperty("EventType")]
    public int EventType { get; set; }

    /// <summary>
    /// 事件主题
    /// </summary>
    [JsonProperty("EventSubject")]
    public string EventSubject { get; set; }

    /// <summary>
    /// 送股(每十股)
    /// </summary>
    [JsonProperty("Sbonus")]
    public decimal Sbonus { get; set; }

    /// <summary>
    /// 转增(每十股)
    /// </summary>
    [JsonProperty("Zbonus")]
    public decimal Zbonus { get; set; }

    /// <summary>
    /// 派息(每十股)
    /// </summary>
    [JsonProperty("Xmoney")]
    public decimal Xmoney { get; set; }

    /// <summary>
    /// 配股(每十股)
    /// </summary>
    [JsonProperty("Pbonus")]
    public decimal Pbonus { get; set; }

    /// <summary>
    /// 配股价格
    /// </summary>
    [JsonProperty("Pprice")]
    public decimal Pprice { get; set; }

    /// <summary>
    /// 基准股本
    /// </summary>
    [JsonProperty("Pcapital")]
    public decimal Pcapital { get; set; }

    /// <summary>
    /// 解禁数量
    /// </summary>
    [JsonProperty("Lifted")]
    public decimal Lifted { get; set; }
}