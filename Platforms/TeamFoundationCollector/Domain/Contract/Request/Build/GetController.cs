using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets a controller
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/controllers/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetController
        : PresetRequest, IRequest
    {
        public int ControllerId { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/controllers/{ControllerId}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        
    }
}

