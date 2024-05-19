//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 附件信息(GOOGLE)
/// 目前仅google drive支持
/// File attachments for the event. Currently only Google Drive attachments are supported.
/// In order to modify attachments the supportsAttachments request parameter should be set to true.
/// There can be at most 25 attachments per event,
/// </summary>
public class Attachment
{
    /// <summary>
    /// 文件标识
    /// ID of the attached file. Read-only.
    /// For Google Drive files, this is the ID of the corresponding Files resource entry in the Drive API.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fileId")]
    public string FileId { get; set; }

    /// <summary>
    /// 文件地址
    /// URL link to the attachment.
    /// For adding Google Drive file attachments use the same format as in alternateLink property of the Files resource in the Drive API.
    /// Required when adding an attachment.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fileUrl")]
    public string FileUrl { get; set; }

    /// <summary>
    /// 图标地址
    /// URL link to the attachment's icon. Read-only.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "iconLink")]
    public string IconLink { get; set; }

    /// <summary>
    /// 媒体格式
    /// Internet media type (MIME type) of the attachment.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "mimeType")]
    public string MimeType { get; set; }

    /// <summary>
    /// 标题
    /// Attachment title.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
    public string Title { get; set; }
}
