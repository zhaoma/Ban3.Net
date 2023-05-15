using System.Diagnostics.Contracts;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using System.Xml;
using Ban3.Infrastructures.NetMail;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using System;
using System.Text;
using Ban3.Infrastructures.Consoles.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Ban3.Infrastructures.SpringConfig;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Org.BouncyCastle.Asn1.Ocsp;
using Ban3.Infrastructures.SpringConfig.Entries;

Ban3.Infrastructures.WxsConfig.Helper.Prepare();

var config = Ban3.Infrastructures.WxsConfig.Helper.Load();
config.ObjToJson().WriteColorLine(ConsoleColor.DarkYellow);

/*
var dll = "CT.Exam.Recon.Impl.dll";
var xml =
    //"D:\\CTS\\Development\\ICS\\SHA.SERV\\site\\config\\CT\\ServCommon\\CT.ServCommon.AppTemplate.SpringConfig.xml";
    "D:\\CTS\\Development\\ICS\\SHA.SERV\\site\\config\\SpringBootstrapper\\NP\\Standalone\\AppContainer\\Exam\\Extensions\\PacsReady\\21_CT.Exam.Recon.PacsReady.Standalone.sdk.Bootstrapper.SpringConfig.xml";


var getRelation = new GetRelations
{
    //SpecialDlls = new() { dll },
    SpringXmls = new() { xml }
};

var x = DevOps.Reportor.GetRelations(getRelation);
Console.WriteLine(x.ObjectsAndReasons.Count);

Ban3.Infrastructures.SpringConfig.Helper.Prepare();
Ban3.Infrastructures.PlatformInvoke.Helper.Prepare();

var all = Ban3.Infrastructures.PlatformInvoke.Helper.Load();
Console.WriteLine($"{all.Count} -> {all.Count(o=>o.ReferencesOrDependencies==null||!o.ReferencesOrDependencies.Any())}");

var teams=DevOps.Collector.Core.LoadTeams();
teams.Where(o=>o.Name==Config.DefaultTeam)
    .ToList()
    .ForEach(o=>DevOps.Collector.SyncOneTeamSummary(o.Id));

DevOps.Collector.SyncTfvc();


new Action(() =>
{
DevOps.Collector.Tfvc.PrepareShelvesets(string.Empty);
}).ExecuteAndTiming("PrepareShelvesets");



DevOps.Reportor.ParseMonitorJobs();

var job = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBuildReports.Jobs
    .FindLast(o => o.Id == "1");

Console.WriteLine(DevOps.Reportor.ParseBuildReport(job));
*/
