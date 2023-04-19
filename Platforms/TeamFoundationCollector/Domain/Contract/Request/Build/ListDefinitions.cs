using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets a list of definitions.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListDefinitions
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";
        
        [JsonProperty("top")]
        public int? Top { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";

        public string RequestQuery()
        {
            /*TODO :  need check*/

            var sb = new StringBuilder();

            sb.Append("?");

            if (Top != null)
                sb.Append($"$top={Top}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

