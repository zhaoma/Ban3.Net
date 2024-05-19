using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

public interface IConferenceProperty
{
    /// <summary>
    /// 此日历支持的会议解决方案类型。
    /// </summary>
    [JsonProperty("allowedConferenceSolutionTypes", NullValueHandling = NullValueHandling.Ignore)]
    IEnumerable<ConferenceSolutionType>? AllowedConferenceSolutionTypes { get; set; }
}
