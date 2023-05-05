using System;
using System.Collections.Generic;
using System.IO;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class MonitorBranchSpec
{
    private static readonly List<MonitorJob> DefaultJobs
        = new()
        {
            new()
            {
                Subject = "IDTWeb Dependency Version",
                Sections = new()
                {
                    new MonitorSection()
                    {
                        SectionName = "MAIN",
                        Target = new KeyValuePair<string, string>("IDT(MAIN)", @"$/CTS/IDT/MAIN/BranchSpec.xml"),
                        Guidelines = new ()
                        {
                            { "ICS.INT(MAIN)", @"$/CTS/Development/ICS/ICS.INT/BranchSpec.xml" }
                        }
                    },

                    new MonitorSection()
                    {
                        SectionName = "VA50",
                        Target = new KeyValuePair<string, string>("IDT(VA50)", @"$/CTS/IDT/PCP/VA50/BranchSpec.xml"),
                        Guidelines = new ()
                        {
                            { "ICS.INT(VA50)", @"$/CTS/PCP/VA50/Dev/ICS/ICS.INT/BranchSpec.xml" }
                        }
                    },

                    new MonitorSection()
                    {
                        SectionName = "VA40",
                        Target = new KeyValuePair<string, string>("IDT(VA40)", @"$/CTS/IDT/PCP/VA40/BranchSpec.xml"),
                        Guidelines = new ()
                        {
                            { "ICS.INT(VA40)", @"$/CTS/PCP/VA40/Dev/ICS/ICS.INT/BranchSpec.xml" }
                        }
                    }
                },
                Subscribed = new List<string>
                {
                    "zhifeng.zhao.ext@siemens-healthineers.com" ,
                    "yaoyao.guo@siemens-healthineers.com",
                    "yongfeng.feng@siemens-healthineers.com",
                    "yunjie.zeng@siemens-healthineers.com",
                    "liang_yan.fan@siemens-healthineers.com"
                }
            }
        };

    private const string CacheKey = "jobs.MonitorBranchSpec";
    static readonly string ConfigFile = Path.Combine(Environment.CurrentDirectory, $"{CacheKey}.json");

    public static List<MonitorJob> Jobs
        => CacheKey.LoadOrSetDefault(DefaultJobs, ConfigFile);

    public static bool Update(List<MonitorJob> jobs)
    {
        return !string.IsNullOrEmpty(ConfigFile.WriteFile(JsonConvert.SerializeObject(jobs)));
    }
}