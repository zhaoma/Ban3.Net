using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/preview/preview?view=azure-devops-rest-7.0#previewrun
    /// </summary>
    public class PreviewRun
	{
        [JsonProperty("finalYaml")]
        public string FinalYaml { get; set; } = string.Empty;


    }
}

