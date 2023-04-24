using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract;

/// <summary>
/// load host config
/// </summary>
public class Config
{
    public static Target Target { get; set; }

    public static TargetHost Host { get; set; }

    static Config()
    {
        var cfg = Infrastructures.Common.Config.AppConfiguration;

        Target = new Target
        {
            HostBaseUrl = cfg["Target:HostBaseUrl"] + "",
            Instance = cfg["Target:Instance"] + "",
            Organization = cfg["Target:Organization"] + "",
            Project = cfg["Target:Project"] + "",
            AuthenticationType = cfg["Target:AuthenticationType"] + "",
            UserName = cfg["Target:UserName"] + "",
            Password = cfg["Target:Password"] + "",
            ApiVersion = cfg["Target:ApiVersion"] + ""
        };

        Host = new TargetHost
        {
            AuthenticationType = Target.AuthenticationType,
            BaseUrl = Target.HostBaseUrl,
            UserName = Target.UserName,
            Password = Target.Password,
        };
    }
}