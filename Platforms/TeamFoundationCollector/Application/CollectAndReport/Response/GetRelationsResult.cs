using Ban3.Infrastructures.WxsConfig.Entries;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;

public class GetRelationsResult
{
    public Dictionary<string,List<string>> ObjectsAndReasons { get; set; }

    public List<WxsXml> Incos { get; set; }
}