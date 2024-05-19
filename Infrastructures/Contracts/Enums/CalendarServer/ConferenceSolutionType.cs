using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 此日历支持的会议解决方案类型。
/// </summary>
public enum ConferenceSolutionType
{
    [JsonProperty("eventHangout")]
    EventHangout,

    [JsonProperty("eventNamedHangout")]
    EventNamedHangout,

    [JsonProperty("hangoutsMeet")]
    HangoutsMeet
}
