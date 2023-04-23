﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Restores a deleted definition
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/restore-definition?view=azure-devops-rest-7.0
    /// </summary>
    public class RestoreDefinition
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Patch";

        /// <summary>
        /// The identifier of the definition to restore.
        /// </summary>
        [JsonProperty("definitionId")]
        public int DefinitionId { get; set; }

        /// <summary>
        /// When false, restores a deleted definition.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions/{DefinitionId}?deleted={Deleted}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}
