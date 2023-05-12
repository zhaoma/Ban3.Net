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

var teams=DevOps.Collector.Core.LoadTeams();
teams.Where(o=>o.Name.Contains("SSME"))
    .ToList()
    .ForEach(o=>DevOps.Collector.SyncOneTeamSummary(o.Id));
/*

new Action(() =>
{
DevOps.Collector.Tfvc.PrepareChangesets(string.Empty, 5);
}).ExecuteAndTiming("PrepareChangesets");

new Action(() =>
{
DevOps.Collector.Tfvc.PrepareShelvesets(string.Empty);
}).ExecuteAndTiming("PrepareShelvesets");



DevOps.Reportor.ParseMonitorJobs();

var job = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBuildReports.Jobs
    .FindLast(o => o.Id == "1");

Console.WriteLine(DevOps.Reportor.ParseBuildReport(job));
*/
