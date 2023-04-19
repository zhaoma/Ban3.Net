using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets controller, optionally filtered by name
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/controllers/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListControllers
        : PresetRequest, IRequest
    {

        public string Method { get; set; } = "Get";

        [JsonProperty("name")] 
        public string Name { get; set; } = string.Empty;

        public string RequestPath() => $"{Instance}/{Organization}/_apis/build/controllers";

        public string RequestQuery() =>string.IsNullOrEmpty(Name)
            ?$"?api-version={ApiVersion}"
            : $"?name={Name}api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

