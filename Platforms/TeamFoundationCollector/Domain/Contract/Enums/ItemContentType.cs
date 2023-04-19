namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-changeset-changes?view=azure-devops-server-rest-6.0#itemcontenttype
/// </summary>
public enum ItemContentType
{
    /// 
    Base64Encoded,

    /// 
    RawText
}