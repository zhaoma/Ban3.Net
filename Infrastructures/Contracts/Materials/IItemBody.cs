//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// 表示项目正文的属性，例如邮件、事件或组帖子。(MS)
/// https://developer.microsoft.com/zh-cn/graph/docs/api-reference/v1.0/resources/itembody
/// </summary>
public interface IItemBody : IZero
{
    /// <summary>
    /// 内容的类型。可能的值为 Text 和 HTML。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    BodyType ContentType { get; set; }

    /// <summary>
    /// 项目的内容。
    /// </summary>
    string Content { get; set; }
}
