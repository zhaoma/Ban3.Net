using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Updates a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/update-build?view=azure-devops-rest-7.0
    /// </summary>
    public class UpdateBuild
        : PresetRequest, IRequest
    {
        public UpdateBuild() { Method = "Patch"; }

        public int BuildId { get; set; }
        
        [JsonProperty("retry")]
        public bool? Retry { get; set; }
        
        public UpdateBuildBody? Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");
            
            if (Retry != null)
                sb.Append($"retry={Retry}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public override string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

