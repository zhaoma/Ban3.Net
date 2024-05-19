//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 渠道，live/google/icalDAV/etc.
/// </summary>
public class Channel
{
    /// <summary>
    /// 主键
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
    public int Id { get; set; }

    /// <summary>
    /// 服务器地址
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channelUrl")]
    public string ChannelUrl { get; set; }

    /// <summary>
    /// 应用ID
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "appId")]
    public string AppId { get; set; }

    /// <summary>
    /// 应用Secret
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "appSecret")]
    public string AppSecret { get; set; }

    /// <summary>
    /// 应用Key
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "appKey")]
    public string AppKey { get; set; }

    /// <summary>
    /// 回叫地址
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "codeCallback")]
    public string CodeCallback { get; set; }

    /// <summary>
    /// 渠道参数
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parameters")]
    public string Parameters { get; set; }

    /// <summary>
    /// CalDav服务器
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "caldavServer")]
    public string CalDavServer { get; set; }
}
