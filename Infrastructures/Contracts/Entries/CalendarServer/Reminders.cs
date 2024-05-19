using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Reminders
{
    /// <summary>
    /// 默认提醒是否适用于该事件
    /// Whether the default reminders of the calendar apply to the event.
    /// </summary>
    [JsonProperty("useDefault",NullValueHandling = NullValueHandling.Ignore)]
    public bool UseDefault { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("overrides", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<Reminder> Overrides { get; set; }
}
