namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The expand parameters for work item attributes. Possible options are { None, Relations, Fields, Links, All }
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitemerrorpolicy
/// </summary>
public enum WorkItemExpand
{
    All,
    Fields,
    Links,
    None,
    Relations
}