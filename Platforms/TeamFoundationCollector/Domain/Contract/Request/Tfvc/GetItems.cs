using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetItems
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";

    /// <summary>
    /// Version of the API to use. This should be set to '7.0' to use this version of the api.
    /// </summary>
    public string ApiVersion { get; set; } = "7.0";

    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }

    [JsonProperty("recursionLevel")]
    public VersionControlRecursionType RecursionLevel { get; set; }

    [JsonProperty("scopePath")]
    public string ScopePath { get; set; } = string.Empty;

    public SubCondition.VersionDescriptor? VersionDescriptor { get; set; }


    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/items";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");
        
        sb.Append($"includeLinks={IncludeLinks}&");
        sb.Append($"recursionLevel={RecursionLevel}&");

        if (!string.IsNullOrEmpty(ScopePath))
            sb.Append($"scopePath={ScopePath}&");

        if (VersionDescriptor != null)
        {
            sb.Append($"versionDescriptor.version={VersionDescriptor.Version}&");
            sb.Append($"versionDescriptor.versionOption={VersionDescriptor.VersionOption}&");
            sb.Append($"versionDescriptor.versionType={VersionDescriptor.VersionType}&");
        }

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;
}