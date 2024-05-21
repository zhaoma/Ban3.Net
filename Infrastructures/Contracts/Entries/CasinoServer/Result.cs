//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino结果
/// </summary>
public class Result : IZero
{
    /// <summary>
    /// 标的信息
    /// </summary>
    public Stock? Stock { get; set; }

    /// <summary>
    /// 最新价格
    /// </summary>
    public Price? LatestPrice { get; set; }

    /// <summary>
    /// 笔记集合
    /// </summary>
    public List<Remark>? Remarks { get; set; }

    /// <summary>
    /// 当前建议
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public SuggestIs Suggest { get; set; }

    /// <summary>
    /// 笔记文本
    /// </summary>
    public List<Notice>? Notices { get; set; }
}
