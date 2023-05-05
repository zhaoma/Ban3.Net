using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/send-mail/send-mail?view=azure-devops-rest-7.0#emailrecipients
/// </summary>
public class EmailRecipients
{
    /// <summary>
    /// Plaintext email addresses.
    /// </summary>
    [JsonProperty("emailAddresses")]
    public List<string>? EmailAddresses { get; set; }

    /// <summary>
    /// TfIds
    /// </summary>
    [JsonProperty("tfIds")]
    public List<string>? TfIds { get; set; }

    /// <summary>
    /// Unresolved entity ids
    /// </summary>
    [JsonProperty("unresolvedEntityIds")]
    public List<string>? UnresolvedEntityIds { get; set; }
}