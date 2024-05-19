using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// Visibility of the event.
/// </summary>
public enum EventVisibility
{
    /// <summary>
    /// Uses the default visibility for events on the calendar.This is the default value.
    /// </summary>
    [JsonProperty("default")]
    Default,

    /// <summary>
    /// The event is public and event details are visible to all readers of the calendar.
    /// </summary>
    [JsonProperty("public")]
    Public,

    /// <summary>
    /// The event is private and only event attendees may view event details.
    /// </summary>
    [JsonProperty("private")]
    Private,

    /// <summary>
    /// The event is private. This value is provided for compatibility reasons.
    /// </summary>
    [JsonProperty("confidential")]
    Confidential
}
