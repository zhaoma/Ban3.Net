using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;


var identities =
    DevOps.Collector.Core.LoadTeams()
        //.Where(o => o.Name == Config.DefaultTeam)
        .ToList()
        .GetIdentitiesFromTeams();

Console.WriteLine($"identity count={identities.Count}");

await identities.ParallelExecuteAsync((identity) =>
{
    DevOps.Collector.SyncOneMemberSummary(identity.Id, true);
}, Config.MaxParallelTasks);


/*

var Sql =
    @"Select [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State], [System.Tags] From WorkItems 
                                Where [System.WorkItemType] = 'Defect' AND [State] NOT IN ('Done' ,'Implemented' , 'Terminated')
                                AND ([System.AreaPath] = 'CTS\SERVICE\SMS_SSME' OR [System.AssignedTo] IN GROUP '[CTS]\SERVICE-SMS_SSME')
                                AND [System.IterationPath] UNDER 'CTS\VB10A' AND [Siemens.Defect.FoundInPhase] = 'Automated Test - Build Pipeline'";

var x = DevOps.Reportor.WorkItemTracking.Query(Sql);

Console.WriteLine(x.ObjToJson());

DevOps.Reportor.ParseMonitorJobs();

var job = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBuildReports.Jobs
    .FindLast(o => o.Id == "1");

Console.WriteLine(DevOps.Reportor.ParseBuildReport(job));

*/