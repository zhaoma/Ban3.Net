namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0#runresourcesparameters
/// </summary>
public class RunResourcesParameters
{
    public Dictionary<string, BuildResourceParameters> Builds { get; set; }


    public Dictionary<string, ContainerResourceParameters> Containers { get; set; }


    public Dictionary<string, PackageResourceParameters> Packages { get; set; }


    public Dictionary<string, PipelineResourceParameters> Pipelines { get; set; }


    public Dictionary<string, RepositoryResourceParameters> Repositories { get; set; }


}