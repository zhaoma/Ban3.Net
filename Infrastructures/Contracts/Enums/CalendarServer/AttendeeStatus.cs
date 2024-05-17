using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// The attendee's response status.
/// </summary>
public enum AttendeeStatus
{
    /// <summary>
    /// The attendee has not responded to the invitation.
    /// </summary>
    [JsonProperty("needsAction")]
    NeedsAction,

    /// <summary>
    /// The attendee has declined the invitation.
    /// </summary>
    [JsonProperty("declined")]
    Declined,

    /// <summary>
    /// The attendee has tentatively accepted the invitation.
    /// </summary>
    [JsonProperty("tentative")]
    Tentative,

    /// <summary>
    /// The attendee has accepted the invitation.
    /// </summary>
    [JsonProperty("accepted")]
    Accepted
}
