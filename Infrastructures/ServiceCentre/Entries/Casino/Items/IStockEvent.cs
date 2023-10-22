using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 标的事件数据声明
/// </summary>
public interface IStockEvent : IStockRecord
{
    /// <summary>
    /// 送股(每十股)
    /// </summary>
    [JsonProperty("sBonus")]
    decimal Sbonus { get; set; }

    /// <summary>
    /// 转增(每十股)
    /// </summary>
    [JsonProperty("zBonus")]
    decimal Zbonus { get; set; }

    /// <summary>
    /// 派息(每十股)
    /// </summary>
    [JsonProperty("xMoney")]
    decimal Xmoney { get; set; }

    /// <summary>
    /// 配股(每十股)
    /// </summary>
    [JsonProperty("pBonus")]
    decimal Pbonus { get; set; }

    /// <summary>
    /// 配股价格
    /// </summary>
    [JsonProperty("pPrice")]
    decimal Pprice { get; set; }

    /// <summary>
    /// 基准股本
    /// </summary>
    [JsonProperty("pCapital")]
    decimal Pcapital { get; set; }

    /// <summary>
    /// 解禁数量
    /// </summary>
    [JsonProperty("lifted")]
    decimal Lifted { get; set; }
}