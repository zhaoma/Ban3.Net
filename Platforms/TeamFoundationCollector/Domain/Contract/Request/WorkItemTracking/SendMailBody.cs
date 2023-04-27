using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/send-mail/send-mail
/// </summary>
public class SendMailBody
{
    [JsonProperty("fields")]
    public List<string>? Fields { get; set; }

    [JsonProperty("ids")]
    public List<int>? Ids { get; set; }

    [JsonProperty("body")]
    public MailMessage? Body { get; set; }

    [JsonProperty("persistenceId")] public string PersistenceId { get; set; } = string.Empty;

    [JsonProperty("projectId")]
    public string ProjectId { get; set; } = string.Empty;

    [JsonProperty("sortFields")]
    public List<string>? SortFields { get; set; }

    [JsonProperty("tempQueryId")]
    public string TempQueryId { get; set; } = string.Empty;

    [JsonProperty("wiql")]
    public string Wiql { get; set; } = string.Empty;
}