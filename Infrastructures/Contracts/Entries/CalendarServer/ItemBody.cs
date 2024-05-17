using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 表示项目正文的属性，例如邮件、事件或组帖子。(MS)
/// https://developer.microsoft.com/zh-cn/graph/docs/api-reference/v1.0/resources/itembody
/// </summary>
[Serializable, DataContract]
public class ItemBody
{
    /// <summary>
    /// 内容的类型。可能的值为 Text 和 HTML。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "contentType")]
    public string ContentType { get; set; } = "HTML";

    /// <summary>
    /// 项目的内容。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "content")]
    public string Content { get; set; }
}
