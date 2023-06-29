using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Microsoft.AspNetCore.Mvc;
using Settings=Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.Report.Controllers;

public class HomeController : Controller
{
    #region tfvc

    public IActionResult Index(string id)
    {
        if (string.IsNullOrEmpty(id))
            id = Platforms.TeamFoundationCollector.Domain.Contract.Config.DefaultTeam;

        var filter = new TfvcFilter
        {
            LimitTeamNames = new List<string> { id },
            //FromDate = new DateTime( now.Year, now.Month, 1 ).ToString( "yyyy-MM-dd" ),
            //ToDate = now.ToString( "yyyy-MM-dd" )
        };

        return View(filter);
    }

    /// <summary>
    /// 显示team 列表
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult Teams(string id)
    {
        var allTeams = DevOps.Reportor.Core.LoadTeams();

        return string.IsNullOrEmpty(id)
            ? View(allTeams)
            : View(id, allTeams);
    }

    /// <summary>
    /// 显示组员列表
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IActionResult Identities(TfvcFilter filter)
    {
        var identities = DevOps.Reportor.GetIdentities(filter);

        return View(identities);
    }

    /// <summary>
    /// 输出内容列表(changeset/shelveset)
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IActionResult Table(TfvcFilter filter)
    {
        var report = DevOps.Reportor.GetTfvcReport(filter);

        return View(report);
    }

    /// <summary>
    /// export Excel
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IActionResult Excel(TfvcFilter filter)
    {
        var excel = DevOps.Reportor.GetTfvcExcel(filter);

        return new FileStreamResult(excel, "application/vnd.ms-excel");
    }

    public IActionResult ShowCode(ReportRef reportRef, string fileId, string properties)
    {
        var result = new Models.ShowCodes
        {
            Properties = properties.JsonToObj<DiscussionProperties>()
        };

        result.Lines = DevOps.Collector.Tfvc.GetItem(reportRef, fileId, result.Properties);
        return View(result);
    }

    #endregion

    public IActionResult Pages(string id)
    {
        return View(id);
    }

    public IActionResult Definitions()
    {
        var definitionRefs = DevOps.Reportor.Build.LoadDefinitionRefs();
        return View(definitionRefs);
    }

    public IActionResult Pipelines()
    {
        var pipelines = DevOps.Reportor.Pipelines.LoadPipelines();
        return View(pipelines);
    }

    public IActionResult Folders()
    {
        var folders = DevOps.Reportor.Build.LoadFolders();
        return View(folders);
    }

    public IActionResult BuildReport(string id)
    {
        var reportDefine =
            Settings.MonitorBuildReports.Jobs.FindLast(o => o.Id == id)
            ?? Settings.MonitorBuildReports.Jobs.First();

        return View(reportDefine);
    }

    public IActionResult Query(string id = "CT.Exam.Recon")
    {
        var response = DevOps.Reportor.QueryAnything(new QueryAnything
        {
            Keyword = id
        });

        return View(response);
    }

    public IActionResult Relations(GetRelations request)
    {
        var response = DevOps.Reportor.GetRelations(request);
        return View(response);
    }

    public IActionResult Analyze(AnalyzeReferences? request)
    {
        if (request == null
            || string.IsNullOrEmpty(request.AssembliesStartWith)
            || string.IsNullOrEmpty(request.SpringConfigFile))
            request = new AnalyzeReferences
            {
                AssembliesStartWith = @"CT.Serv.Ctl",
                SpringConfigFile = @"CT.Serv.Ctl.SpringConfig.xml"
            };

        var file = typeof(AnalyzeReferencesResult)
            .LocalFile($"{request.AssembliesStartWith}:{request.SpringConfigFile}".MD5String());

        var result =
            System.IO.File.Exists(file)
                ? file.ReadFileAs<AnalyzeReferencesResult>()
                : DevOps.Reportor.GetResult(request);

        return View(result);
    }
}