using System.ComponentModel;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Source type, such as Public or Internal.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/artifactspackagetypes/maven/get-package-version?view=azure-devops-server-rest-6.0#packagingsourcetype
/// </summary>
public enum PackagingSourceType
{
    /// <summary>
    /// Azure DevOps upstream source.
    /// </summary>
    [Description("internal")]
    Internal,

    /// <summary>
    /// Publicly available source.
    /// </summary>
    [Description("public")]
    Public
}