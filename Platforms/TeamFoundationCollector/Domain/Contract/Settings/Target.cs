namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class Target
{
    public string HostBaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// DevOps 地址
    /// </summary>
    public string Instance { get; set; } = string.Empty;

    public string Organization { get; set; } = string.Empty;

    public string Project { get; set; } = string.Empty;

    public string AuthenticationType { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
    
    public string ApiVersion { get; set; } = string.Empty;
}