using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 标的声明
/// </summary>
public interface IStock : IStockCode
{
    /// <summary>
    /// 代码 600001
    /// </summary>
    [JsonProperty("symbol")]
    string Symbol { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonProperty("name")]
    string Name { get; set; }

    /// <summary>
    /// 上市时间
    /// </summary>
    [JsonProperty("listDate")]
    string ListDate { get; set; }
}

