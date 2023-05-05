using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#processparameters
/// </summary>
public class ProcessParameters
{
    /// <summary>
    /// Represents binding of data source for the service endpoint request.
    /// </summary>
    [JsonProperty("dataSourceBindings")]
    public List<DataSourceBindingBase>? DataSourceBindings { get; set; }

    [JsonProperty("inputs")]
    public List<TaskInputDefinitionBase>? Inputs { get; set; }

    [JsonProperty("sourceDefinitions")]
    public List<TaskSourceDefinitionBase>? SourceDefinitions { get; set; }
}