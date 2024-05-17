//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历分组
/// </summary>
public class Group
{

    /// <summary>
    /// ClassId(MS)
    /// The class identifier. Read-only.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "classId")]
    public string ClassId { get; set; }

    /// <summary>
    /// 分组名称
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// ChangeKey
    /// Identifies the version of the calendar group. 
    /// Every time the calendar group is changed, ChangeKey changes as well. 
    /// This allows Exchange to apply changes to the correct version of the object. Read-only.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    public string ChangeKey { get; set; }

    /// <summary>
    /// ChangeKey
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "color")]
    public string Color { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "data")]
    public object Data { get; set; }
}
