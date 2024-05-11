//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino笔记
/// </summary>
public class Notice
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 笔记时间
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 特征
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public FeatureIs Feature { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    public string Note { get; set; } = string.Empty;
}
