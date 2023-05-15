using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Functions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;

public class ReportService
    : IReportService
{
    public IBuild Build { get; set; } = new Build();

    public ICore Core { get; set; } = new Core();

    public IDiscussion Discussion { get; set; } = new Discussion();

    public IPipelines Pipelines { get; set; } = new Pipelines();

    public ITfvc Tfvc { get; set; } = new Tfvc();

    public IWorkItemTracking WorkItemTracking { get; set; } = new WorkItemTracking();

    public QueryAnythingResult QueryAnything(QueryAnything request)
    {
        var result = new Response.QueryAnythingResult(request)
        {
            AssemblyFiles = Infrastructures.PlatformInvoke.Helper.Load(),
            SpringXmls = Infrastructures.SpringConfig.Helper.LoadConfigs()
        };

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            result.AssemblyFiles = result.AssemblyFiles
                .Where(o => o.Name.Contains(request.Keyword))
                .ToList();

            result.SpringXmls = result.SpringXmls
                .Where(o => o.FileName.Contains(request.Keyword))
                .ToList();
        }

        return result;
    }

    public GetRelationsResult GetRelations(GetRelations request)
    {
        var result = new GetRelationsResult
        {
            ObjectsAndReasons = new Dictionary<string, List<string>>()
        };

        if (request.SpecialDlls!=null&&request.SpecialDlls.Any())
        {
            var allDlls = Infrastructures.PlatformInvoke.Helper.Load();
            foreach (var requestSpecialDll in request.SpecialDlls)
            {
                var roads = Infrastructures.PlatformInvoke.Helper.AllLowerLevels(requestSpecialDll, allDlls);
                result.ObjectsAndReasons.AppendDllRoads(roads);
            }
        }

        if (request.SpringXmls!=null&&request.SpringXmls.Any())
        {
            var allXmls = Infrastructures.SpringConfig.Helper.LoadConfigs();
            var allDeclares = Infrastructures.SpringConfig.Helper.LoadDeclares();
            var allAlias = Infrastructures.SpringConfig.Helper.LoadAlias();

            foreach (var springXml in request.SpringXmls)
            {
                var roads = Infrastructures.SpringConfig.Helper.AllLowerLevels(springXml, allXmls);

                result.ObjectsAndReasons.AppendXmlRoads( roads, allXmls, allAlias, allDeclares);
            }
        }

        if (result.ObjectsAndReasons.Any())
        {
            var allWxs = Ban3.Infrastructures.WxsConfig.Helper.Load();
            result.Incos = allWxs.FindAll(o => o.Files.Any(x => result.ObjectsAndReasons.ContainsKey(x.LongName)));
        }

        return result;
    }


}