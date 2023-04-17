using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#repositoryresource
    /// </summary>
	public class RepositoryResource
    {
        [JsonProperty("refName")]
        public string RefName { get; set; } = string.Empty;

        [JsonProperty("repository")]
        public Repository? Repository { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }
}

