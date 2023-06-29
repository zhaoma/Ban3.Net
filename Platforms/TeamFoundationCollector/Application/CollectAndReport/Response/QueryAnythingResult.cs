using Ban3.Infrastructures.PlatformInvoke.Entries;
using Ban3.Infrastructures.SpringConfig.Entries;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;

public class QueryAnythingResult
{
    public Request.QueryAnything Request { get; set; }

    public QueryAnythingResult(Request.QueryAnything request)
    {
        Request=request;
    }

    public List<AssemblyFile> AssemblyFiles { get; set; } = new();

    public List<SpringXml> SpringXmls { get; set; } = new();
}