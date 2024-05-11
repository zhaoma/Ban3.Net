//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino标的
/// </summary>
public class Stock
{
    /// <summary>
    /// 代码
    /// 600001_SH
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 600001
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 当前建议
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public SuggestIs Suggest { get; set; }
}
