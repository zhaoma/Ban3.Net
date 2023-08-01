
using Newtonsoft.Json;

namespace Ban3.Infrastructures.NetMail.Entries;

/// <summary>
/// 目标服务器
/// </summary>
public class TargetServer
{
    /// <summary>
    /// 服务器地址
    /// </summary>
    [JsonProperty("serverEndpoint",NullValueHandling=NullValueHandling.Ignore)]
    public string ServerEndpoint { get; set; } = string.Empty;

    /// <summary>
    /// 服务器端口
    /// </summary>
    [JsonProperty("serverPort", NullValueHandling = NullValueHandling.Ignore)]
    public int ServerPort { get; set; } = 25;

    /// <summary>
    /// SSL
    /// </summary>
    [JsonProperty("enableSsl", NullValueHandling = NullValueHandling.Ignore)]
    public bool EnableSsl { get; set; } = true;

    /// <summary>
    /// 账号
    /// </summary>
    [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// office365 企业服务？
    /// </summary>
    [JsonProperty("tagName", NullValueHandling = NullValueHandling.Ignore)]
    public string TagName { get; set; } = string.Empty;
}
