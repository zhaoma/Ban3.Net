namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The quality of the definition document (draft, etc.)
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#definitionquality
/// </summary>
public enum DefinitionQuality
{
    Definition,

    Draft
}