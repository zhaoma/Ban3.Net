using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 有日期的记录
/// </summary>
public interface IStockRecord
{
    /// <summary>
    /// 日期用yyyyMMdd格式的string
    /// </summary>
    [JsonProperty("recordDate")]
    string RecordDate { get; set; }
}

