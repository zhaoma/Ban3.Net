using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;

public class AnalyzeReferencesResult
{
    public AnalyzeReferences? Request { get; set; }

    public Dictionary<string, List<string>> AssemblyFilesFromDependencies { get; set; } = new();

    public Dictionary<string, List<string>> AssemblyFilesFromSpringConfigs { get; set; } = new();

    public List<string> Assemblies => AssemblyFilesFromDependencies
        .Select(o=>o.Key)
        .Union(AssemblyFilesFromSpringConfigs.Select(o=>o.Key))
        .ToList();

    public Dictionary<string,string> Proposals { get; set; } = new();
}