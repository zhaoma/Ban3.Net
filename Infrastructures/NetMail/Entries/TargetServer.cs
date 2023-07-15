
using Newtonsoft.Json;

namespace Ban3.Infrastructures.NetMail.Entries;

/// <summary>
/// 目标服务器
/// </summary>
public class TargetServer
{
    [JsonProperty("serverEndpoint",NullValueHandling=NullValueHandling.Ignore)]
    public string ServerEndpoint { get; set; } = string.Empty;

    [JsonProperty("serverPort", NullValueHandling = NullValueHandling.Ignore)]
    public int ServerPort { get; set; } = 25;

    [JsonProperty("enableSsl", NullValueHandling = NullValueHandling.Ignore)]
    public bool EnableSsl { get; set; } = true;

    [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
    public string UserName { get; set; } = string.Empty;

    [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
    public string Password { get; set; } = string.Empty;

    [JsonProperty("tagName", NullValueHandling = NullValueHandling.Ignore)]
    public string TagName { get; set; } = string.Empty;
}
