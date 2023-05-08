using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class MonitorBuildReports
{
    /// <summary>
    ///
    /// 1455 SHA.SERV_CI
    /// 1920 SHA.SERV RB
    /// 3288 SHA.SERV_CI_UnitTests
    /// 1841 SHA.SERV NB
    /// 1775 SHA.SERV_SYS_NB
    /// 2389 SHA.IDT.MAIN_RB
    /// 2388 SHA.IDT.MAIN_NB
    /// 1830 IDT.MAIN_COV
    /// 3287 SHA.ISA3_CI_UnitTests
    /// 3285 SHA.ISA4_CI_UnitTests
    /// </summary>
    private static readonly List<ReportDefine> DefaultJobs
        = new()
        {
            new()
            {
                Id=1,
                Subject = "Som10 Integration Summary_SHA.SERV",
                FocusDefinitions = new()
                {
                    1455,1920,3288,1841,1775,2389,2388,1830,3287,3285
                },
                Subscribed = new List<string>
                {
                    "zhifeng.zhao.ext@siemens-healthineers.com" 
                }
            }
        };

    private const string CacheKey = "jobs.MonitorBuildReports";
    static readonly string ConfigFile = Path.Combine(Environment.CurrentDirectory, $"{CacheKey}.json");

    public static List<ReportDefine> Jobs
        => CacheKey.LoadOrSetDefault(DefaultJobs, ConfigFile);

    public static bool Update(List<ReportDefine> jobs)
    {
        return !string.IsNullOrEmpty(ConfigFile.WriteFile(JsonConvert.SerializeObject(jobs)));
    }
}