using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetItems
    : PresetRequest, IRequest
{
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }

    [JsonProperty("recursionLevel")]
    public VersionControlRecursionType RecursionLevel { get; set; }

    [JsonProperty("scopePath")]
    public string ScopePath { get; set; } = string.Empty;

    [JsonProperty("versionDescriptor")]
    public SubCondition.VersionDescriptor? VersionDescriptor { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/items";
    
    
}