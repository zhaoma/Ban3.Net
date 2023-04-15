using System;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// A reference to a Pipeline.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#pipelinereference
    /// </summary>
    public class PipelineReference
    {
        /// <summary>
        /// Pipeline folder
        /// </summary>
        [JsonProperty("folder")]
        public string Folder { get; set; }

        /// <summary>
        /// Pipeline ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Pipeline name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Revision number
        /// </summary>
        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}

