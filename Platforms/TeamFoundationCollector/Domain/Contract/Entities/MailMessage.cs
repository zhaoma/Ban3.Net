using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/send-mail/send-mail?view=azure-devops-rest-7.0#mailmessage
/// </summary>
public class MailMessage
{
    /// <summary>
    /// The mail body in HTML format.
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; } = string.Empty;

    /// <summary>
    /// CC recipients.
    /// </summary>
    [JsonProperty("cc")]
    public EmailRecipients? CC { get; set; }

    /// <summary>
    /// The in-reply-to header value
    /// </summary>
    [JsonProperty("inReplyTo")]
    public string InReplyTo { get; set; } = string.Empty;

    /// <summary>
    /// The Message Id value
    /// </summary>
    [JsonProperty("messageId")]
    private string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// Reply To recipients.
    /// </summary>
    [JsonProperty("replyTo")]
    public EmailRecipients? ReplyTo { get; set; }

    /// <summary>
    /// The mail subject.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// To recipients
    /// </summary>
    [JsonProperty("to")]
    public EmailRecipients? To { get; set; }
}