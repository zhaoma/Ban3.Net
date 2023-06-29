using System.Collections.Generic;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;
using CommonConfig= Ban3.Infrastructures.Common.Config;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract;

/// <summary>
/// load host config
/// </summary>
public class Config
{
    public static Target Target { get; set; }

    public static TargetHost Host { get; set; }

    public static string DefaultTeam { get; set; }

    public static string SliderKeywords{ get; set; }

    public static string SliderTeams { get; set; }

    static Config()
    {
        var cfg = CommonConfig.AppConfiguration;

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

        DefaultTeam = CommonConfig.GetValue<string>("Focus:DefaultTeam")?? "SERVICE-SMS_SSME";
        SliderKeywords = CommonConfig.GetValue<string>("Slider:Keywords")?? "SSME";
        SliderTeams = CommonConfig.GetValue<string>("Slider:Teams")+ "";
    }

    public const int MaxParallelTasks = 20;

    public static List<string> IgnoredKeys = new() { "Forward Integration", "Reverse Integration" };
    
    public static string CacheKey<T>(string key="all")
        => $"{typeof(T).Name}.{key}";

}