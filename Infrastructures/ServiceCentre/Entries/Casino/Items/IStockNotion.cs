//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

/// <summary>
/// 标的题材数据声明
/// </summary>
public interface IStockNotion
{
    /// <summary>
    /// 标识
    /// </summary>
    [JsonProperty( "id" )]
    int Id { get; set; }

    /// <summary>
    /// 题材主题
    /// </summary>
    [JsonProperty( "name" )]
    string Name { get; set; }

    /// <summary>
    /// 题材分组（地域/行业/热门）
    /// </summary>
    [JsonProperty( "notionIs" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    NotionIs NotionIs { get; set; }

    /// <summary>
    /// 相关标的
    /// </summary>
    [JsonProperty( "stocks" )]
    IEnumerable<IStock> Stocks { get; set; }
}