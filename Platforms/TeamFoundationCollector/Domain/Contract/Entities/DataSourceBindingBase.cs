using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents binding of data source for the service endpoint request.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#datasourcebindingbase
/// </summary>
public class DataSourceBindingBase
{
    /// <summary>
    /// Pagination format supported by this data source(ContinuationToken/SkipTop).
    /// </summary>
    [JsonProperty("callbackContextTemplate")] 
    public string CallbackContextTemplate { get; set; } = string.Empty;

    /// <summary>
    /// Subsequent calls needed?
    /// </summary>
    [JsonProperty("callbackRequiredTemplate")]
    public string CallbackRequiredTemplate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the data source.
    /// </summary>
    [JsonProperty("dataSourceName")]
    public string DataSourceName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the endpoint Id.
    /// </summary>
    [JsonProperty("endpointId")]
    public string EndpointId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the url of the service endpoint.
    /// </summary>
    [JsonProperty("endpointUrl")]
    public string EndpointUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the authorization headers.
    /// </summary>
    [JsonProperty("headers")]
    public List<AuthorizationHeader>? Headers { get; set; }
    
    /// <summary>
    /// Defines the initial value of the query params
    /// </summary>
    [JsonProperty("initialContextTemplate")]
    public string InitialContextTemplate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the parameters for the data source.
    /// </summary>
    [JsonProperty("parameters")]
    public object? Parameters { get; set; }

    /// <summary>
    /// Gets or sets http request body
    /// </summary>
    [JsonProperty("requestContent")]
    public string RequestContent { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets http request verb
    /// </summary>
    [JsonProperty("requestVerb")]
    public string RequestVerb { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the result selector.
    /// </summary>
    [JsonProperty("resultSelector")]
    public string ResultSelector { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the result template.
    /// </summary>
    [JsonProperty("resultTemplate")]
    public string ResultTemplate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the target of the data source.
    /// </summary>
    [JsonProperty("target")]
    public string Target { get; set; } = string.Empty;
}