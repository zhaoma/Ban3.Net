﻿using Newtonsoft.Json;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Get a list of pipelines.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListPipelines
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("top")] public int? Top { get; set; }

        [JsonProperty("continuationToken")] public string ContinuationToken { get; set; } = string.Empty;

        [JsonProperty("orderby")] public string OrderBy { get; set; } = string.Empty;

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            if (!string.IsNullOrEmpty(OrderBy))
                sb.Append($"$orderby={OrderBy}&");

            if (!string.IsNullOrEmpty(ContinuationToken))
                sb.Append($"continuationToken={ContinuationToken}&");
            if (Top != null)
                sb.Append($"$top={Top}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

