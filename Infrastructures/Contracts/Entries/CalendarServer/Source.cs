using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 联系人信息来源
/// </summary>
public class Source
{
    /// <summary>
    /// 源类型Id
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    /// <summary>
    /// https缓存标识
    /// </summary>
    [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
    public string Etag { get; set; }

    /// <summary>
    /// 更新的时间戳
    /// </summary>
    [JsonProperty("updateTime", NullValueHandling = NullValueHandling.Ignore)]
    public string UpdateTime { get; set; }

    /// <summary>
    /// 元数据配置文件来源
    /// </summary>
    [JsonProperty("profileMetadata", NullValueHandling = NullValueHandling.Ignore)]
    public string ProfileMetadata { get; set; }
}
