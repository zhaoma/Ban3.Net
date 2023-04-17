using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#taskinputvalidation
/// </summary>
public class TaskInputValidation
{
    /// <summary>
    /// Conditional expression
    /// </summary>
    [JsonProperty("expression")]
    public string Expression { get; set; } = string.Empty;

    /// <summary>
    /// Message explaining how user can correct if validation fails
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;
}