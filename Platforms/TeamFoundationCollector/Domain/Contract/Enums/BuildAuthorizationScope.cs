namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildauthorizationscope
/// </summary>
public enum BuildAuthorizationScope
{
    /// <summary>
    /// The identity used should have build service account permissions scoped to the project in which the build definition resides.
    /// This is useful for isolation of build jobs to a particular team project to avoid any unintentional escalation of privilege attacks during a build.
    /// </summary>
    Project,

    /// <summary>
    /// The identity used should have build service account permissions scoped to the project collection.
    /// This is useful when resources for a single build are spread across multiple projects.
    /// </summary>
    ProjectCollection
}