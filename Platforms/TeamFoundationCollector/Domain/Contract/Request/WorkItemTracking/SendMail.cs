using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

/// <summary>
/// RESTful method to send mail for selected/queried work items.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/send-mail/send-mail
/// </summary>
public class SendMail
    : PresetRequest, IRequest
{
    public SendMail() { Method = "Post"; }

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    [JsonProperty("body")]
    public SendMailBody? Body { get; set; }

    [JsonProperty("propertyFilters")]
    public string PropertyFilters { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/_apis/wit/sendmail";

    public string RequestQuery() =>string.Empty;

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}