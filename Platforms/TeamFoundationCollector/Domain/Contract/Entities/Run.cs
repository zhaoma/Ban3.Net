using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#run
    /// </summary>
    public class Run
        : PreviewRun
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonProperty("_links")]
        public ReferenceLinks? Links { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; } = string.Empty;

        [JsonProperty("finishedDate")]
        public string FinishedDate { get; set; } = string.Empty;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A reference to a Pipeline.
        /// </summary>
        [JsonProperty("pipeline")]
        public PipelineReference? Pipeline { get; set; }

        [JsonProperty("resources")]
        public RunResources? Resources { get; set; }


        [JsonProperty("result")]
        public RunResult Result { get; set; }


        [JsonProperty("state")]
        public RunState State { get; set; }


        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("variables")]
        public Dictionary<string, Variable>? Variables { get; set; }

    }
}

