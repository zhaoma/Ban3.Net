
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get Item Metadata and/or Content for a single item.
/// The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response.
/// Doesn't apply to zipped content which is always returned as a download.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-rest-7.0
/// </summary>
public class GetItem
    : PresetRequest, IRequest
{
    /// <summary>
    /// Version control path of an individual item to return.
    /// </summary>
    [JsonProperty("path")]
    public string? Path { get; set; }

    /// <summary>
    /// If true, create a downloadable attachment.
    /// </summary>
    [JsonProperty("download")]
    public bool? Download { get; set; }

    /// <summary>
    /// file name of item returned.
    /// </summary>
    [JsonProperty("fileName")]
    public string? FileName { get; set; }

    /// <summary>
    /// Set to true to include item content when requesting json.
    /// Default is false.
    /// </summary>
    [JsonProperty("includeContent")]
    public bool IncludeContent { get; set; }

    [JsonProperty("RecursionLevel")]
    public VersionControlRecursionType? RecursionLevel { get; set; }

    [JsonProperty("scopePath")]
    public string? ScopePath { get; set; } 

    public SubCondition.VersionDescriptor? VersionDescriptor { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/items";
}
