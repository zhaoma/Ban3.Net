using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;

/// <summary>
/// Settings which influence pipeline runs.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0#runresourcesparameters
/// </summary>
public class RunPipelineBody
{
    /// <summary>
    /// If true, don't actually create a new run. Instead, return the final YAML document after parsing templates.
    /// </summary>
    [JsonProperty("previewRun")]
    public bool PreviewRun { get; set; }

    /// <summary>
    /// The resources the run requires.
    /// </summary>
    [JsonProperty("resources")]
    public RunResourcesParameters? Resources { get; set; }

    [JsonProperty("stagesToSkip")]
    public List<string>? StagesToSkip { get; set; }

    [JsonProperty("templateParameters")]
    public object? TemplateParameters { get; set; }

    [JsonProperty("variables")]
    public Dictionary<string, Variable>? Variables { get; set; }

    /// <summary>
    /// If you use the preview run option, you may optionally supply different YAML.
    /// This allows you to preview the final YAML document without committing a changed file.
    /// </summary>
    [JsonProperty("yamlOverride")]
    public string YamlOverrode { get; set; } = string.Empty;
}