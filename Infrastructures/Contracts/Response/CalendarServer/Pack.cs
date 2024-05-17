using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Response.CalendarServer;

public class Pack<T>
{
    /// <summary>
    /// 下页链接(令牌)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "next")]
    public string Next { get; set; }

    /// <summary>
    /// 时间数据包
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "data")]
    public List<T> Data { get; set; }
}
