﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Updates multiple builds.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/update-builds?view=azure-devops-rest-7.0
    /// </summary>
    public class UpdateBuilds
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Patch";

        public List<UpdateBuildBody>? Body { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}
