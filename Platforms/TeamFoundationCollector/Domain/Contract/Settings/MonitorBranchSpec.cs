using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class MonitorBranchSpec
{
    private static readonly List<JobForMonitorBranchSpec> DefaultJobs
        = new()
        {
            new()
            {
                TargetPath = @"$/CTS/IDT/MAIN/BranchSpec.xml",
                GuidelinePath = @"$/CTS/Development/ICS/ICS.INT/BranchSpec.xml",
                Subscribed = new List<string>
                {
                    "zhifeng.zhao.ext@siemens-healthineers.com"
                    /*"yaoyao.guo@siemens-healthineers.com",
                    "yongfeng.feng@siemens-healthineers.com",
                    "yunjie.zeng@siemens-healthineers.com",
                    "liang_yan.fan@siemens-healthineers.com"*/
                }
            }
        };

    private const string CacheKey = "jobs.MonitorBranchSpec";
    static readonly string ConfigFile = Path.Combine(Environment.CurrentDirectory, $"{CacheKey}.json");

    public static List<JobForMonitorBranchSpec> Jobs
        => CacheKey.LoadOrSetDefault(DefaultJobs, ConfigFile);

    public static bool Update(List<JobForMonitorBranchSpec> jobs)
    {
        return !string.IsNullOrEmpty(ConfigFile.WriteFile(JsonConvert.SerializeObject(jobs)));
    }
}