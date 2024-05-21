//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// The response type. 
/// Possible values are: none, organizer, tentativelyAccepted, accepted, declined, notResponded.
/// 
/// </summary>
public enum ResponseType
{
    /// <summary>
    /// none – from organizer's perspective. 
    /// This value is used when the status of an attendee/participant is reported to the organizer of a meeting.
    /// </summary>
    None,

    /// <summary>
    /// notResponded – from attendee's perspective. 
    /// Indicates the attendee has not responded to the meeting request.
    /// Clients can treat notResponded == none.
    /// </summary>
    NotResponded,

    Organizer,

    TentativelyAccepted,

    /// <summary>
    /// The attendee has not responded to the invitation.
    /// </summary>
    NeedsAction,

    /// <summary>
    /// The attendee has declined the invitation.
    /// </summary>
    Declined,

    /// <summary>
    /// The attendee has tentatively accepted the invitation.
    /// </summary>
    Tentative,

    /// <summary>
    /// The attendee has accepted the invitation.
    /// </summary>
    Accepted
}
