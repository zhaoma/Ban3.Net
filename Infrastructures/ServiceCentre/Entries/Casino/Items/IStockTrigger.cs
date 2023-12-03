//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

public interface IStockTrigger : IStock, IStockRecord
{
    /// <summary>
    /// 时间点类型
    /// </summary>
    [JsonProperty("triggerIs")]
    [JsonConverter(typeof(StringEnumConverter))]
    TriggerIs TriggerIs { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonProperty("subject")]
    string Subject { get; set; }
}

