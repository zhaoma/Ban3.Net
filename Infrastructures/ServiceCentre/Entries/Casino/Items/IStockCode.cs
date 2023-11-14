// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 有编号的记录
/// </summary>
public interface IStockCode
{
    /// <summary>
    /// 编号 600001.SH
    /// </summary>
    [JsonProperty( "code" )]
    string Code { get; set; }
}