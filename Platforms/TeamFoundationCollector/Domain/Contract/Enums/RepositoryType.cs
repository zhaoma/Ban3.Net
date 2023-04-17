namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#repositorytype
    /// </summary>
    public enum RepositoryType
    {
        AzureReposGit,

        AzureReposGitHyphenated,

        GitHub,

        GitHubEnterprise,

        Unknown
    }
}

