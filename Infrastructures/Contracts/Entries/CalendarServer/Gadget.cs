//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 配件(GOOGLE)
/// https://developers.google.com/calendar/v3/reference/events#resource-representations
/// 
/// A gadget that extends this event.
/// </summary>
[Serializable, DataContract]
public class Gadget
{
    /// <summary>
    /// 显示模式
    /// The gadget's display mode. Optional. Possible values are:
    /// "icon" - The gadget displays next to the event's title in the calendar view.
    /// "chip" - The gadget displays when the event is clicked.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "display")]
    public string Display { get; set; }

    /// <summary>
    /// 小工具高度
    /// The gadget's height in pixels. The height must be an integer greater than 0. Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "height")]
    public int Height { get; set; }

    /// <summary>
    /// 小工具图标url
    /// The gadget's icon URL. The URL scheme must be HTTPS.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "iconLink")]
    public string IconLink { get; set; }

    /// <summary>
    /// 小工具url
    /// The gadget's URL. The URL scheme must be HTTPS.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "link")]
    public string Link { get; set; }

    /// <summary>
    /// 小工具主题
    /// The gadget's title.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
    public string Title { get; set; }

    /// <summary>
    /// 小工具类型
    /// The gadget's type.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// 小工具宽度
    /// The gadget's width in pixels. The width must be an integer greater than 0. Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "width")]
    public int Width { get; set; }
}