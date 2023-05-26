namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;

public class AnalyzeReferences
{
    public string SpringConfigFile { get; set; }

    public string AssembliesStartWith { get; set; }
}