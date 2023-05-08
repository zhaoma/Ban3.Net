using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets a list of build definition folders.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/folders/list?view=azure-devops-rest-7.0
/// </summary>
public class ListFolders
    : PresetRequest, IRequest
{
    /// <summary>
    /// The path to start with.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// The order in which folders should be returned.
    /// </summary>
    [JsonProperty("queryOrder")]
    public FolderQueryOrder? QueryOrder { get; set; }

    public string RequestPath() =>
        string.IsNullOrEmpty(Path)
            ? $"{Instance}/{Organization}/{Project}/_apis/build/folders"
            : $"{Instance}/{Organization}/{Project}/_apis/build/folders/{Path}";
}