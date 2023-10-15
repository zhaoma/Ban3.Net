using Ban3.Infrastructures.ServiceCentre.Enums.Casino;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 股东信息声明
/// </summary>
public interface IStockHolder
{
    /// <summary>
    /// 股东标识
    /// </summary>
    [JsonProperty("id")]
    string Id { get; set; }

    /// <summary>
    /// 股东类型
    /// </summary>
    [JsonProperty("holderIs")]
    [JsonConverter(typeof(StringEnumConverter))]
    HolderIs HolderIs { get; set; }

    /// <summary>
    /// 持股数量
    /// </summary>
    [JsonProperty("holdNumber")]
    long HoldNumber { get; set; }

    /// <summary>
    /// 持有比例
    /// </summary>
    [JsonProperty("holdRatio")]
    decimal HoldRatio { get; set; }

    /// <summary>
    /// 持仓变化
    /// </summary>
    [JsonProperty("holdChange")]
    [JsonConverter(typeof(StringEnumConverter))]
    HoldChange HoldChange { get; set; }
}