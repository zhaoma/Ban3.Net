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

//DevOps.Reportor.ParseMonitorJobs();

//var job = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBuildReports.Jobs
//    .FindLast(o => o.Id == "1");
//job.Subject.WriteColorLine(ConsoleColor.Red);
//Console.WriteLine(DevOps.Reportor.ParseBuildReport(job));

//var latestRi = DevOps.Reportor.Tfvc.GetChangesets(new GetChangesets
//{
//    SearchCriteria = new SearchCriteria
//    {
//        ItemPath = @"$/CTS/Development/ICS/ICS.INT",
//        FromDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"),
//        ToDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")
//    }
//});

//latestRi
//    .Value.FirstOrDefault(o=>o.Comment.Contains(@"Reverse Integration: SHA.SERV"))
//    .ObjToJson().WriteSuccessLine();

var teams = DevOps.Reportor.Core.LoadTeams();

var team = teams.FindLast(o => o.Name == Config.DefaultTeam);

DevOps.Collector.SyncOneTeamSummary(team.Id);