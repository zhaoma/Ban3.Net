//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
#nullable enable
namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// Casino分析结果
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// 标的信息
    /// </summary>
    [JsonProperty("stock", NullValueHandling = NullValueHandling.Ignore)]
    public IStock Stock { get; set; }

    /// <summary>
    /// 备注笔记
    /// </summary>
    [JsonProperty("remarks", NullValueHandling = NullValueHandling.Ignore)]
    public List<IRemark>? Remarks { get; set; }

    /// <summary>
    /// 操作建议
    /// </summary>
    [JsonProperty("suggest", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SuggestIs Suggest { get; set; }

    /// <summary>
    /// 备注笔记
    /// </summary>
    [JsonProperty("notices", NullValueHandling = NullValueHandling.Ignore)]
    public List<INotice>? Notices { get; set; }
}
