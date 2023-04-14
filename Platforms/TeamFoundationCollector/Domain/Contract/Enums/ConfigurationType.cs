namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Type of configuration.(pipeline)
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/get?view=azure-devops-rest-7.0#configurationtype
/// </summary>
public enum ConfigurationType
{
    DesignerHyphenJson,

    DesignerJson,

    JustInTime,

    Unknown,

    Yaml
}