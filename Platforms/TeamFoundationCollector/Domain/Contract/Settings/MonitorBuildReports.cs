using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
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
                Id="1",
                Subject = "Som10 Integration Summary_SHA.SERV",
                Sections=new ()
                {
                    new ReportSectionForLastRI(1,"Latest RI",@"$/CTS/Development/ICS/ICS.INT",@"Reverse Integration: SHA.SERV",15),
                    new ReportSectionForWorkItems(11,"Pipeline Defect")
                    {
                        Sql=@"Select [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State], [System.Tags] From WorkItems 
                                Where [System.WorkItemType] = 'Defect' 
                                AND [State] <> 'Done' 
                                AND [State] <> 'Implemented' 
                                AND [State] <> 'Terminated'
                                AND [System.AreaPath] = 'CTS\SERVICE\SMS_SSME' 
                                AND [System.IterationPath] UNDER 'CTS\VB10A' 
                                AND [Siemens.Defect.FoundInPhase] = 'Automated Test - Build Pipeline'"
                    },
                    new ReportSectionForDefinition(21,1455,"SHA.SERV_CI"),
                    new ReportSectionForDefinition(22,1920,"SHA.SERV RB"),
                    new ReportSectionForDefinition(23,3288,"SHA.SERV_CI_UnitTests"),
                    new ReportSectionForDefinition(24,1841,"SHA.SERV NB"),
                    new ReportSectionForDefinition(25,1775,"SHA.SERV_SYS_NB"),
                    new ReportSectionForDefinition(26,2389,"SHA.IDT.MAIN_RB"),
                    new ReportSectionForDefinition(27,2388,"SHA.IDT.MAIN_NB"),
                    new ReportSectionForDefinition(28,1830,"IDT.MAIN_COV"),
                    new ReportSectionForDefinition(29,3287,"SHA.ISA3_CI_UnitTests"),
                    new ReportSectionForDefinition(30,3285,"SHA.ISA4_CI_UnitTests"),
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
        =>  CacheKey.LoadOrSetDefault(DefaultJobs, ConfigFile);

    public static bool Update(List<ReportDefine> jobs)
    {
        return false;//!string.IsNullOrEmpty(ConfigFile.WriteFile(JsonConvert.SerializeObject(jobs)));
    }
}