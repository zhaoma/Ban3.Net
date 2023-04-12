namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-server-rest-6.0&tabs=HTTP#filecontentmetadata
/// </summary>
public class FileContentMetadata
{
    public string ContentType { get; set; }

    public int Encoding { get; set; }

    public string Extension { get; set; }

    public string FileName { get; set; }

    public bool IsBinary { get; set; }

    public bool IsImage { get; set; }

    public string VsLink { get; set; }
}