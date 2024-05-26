//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历事件
/// </summary>
public class Event : IEventOnMicrosoft, IEventOnGoogle
{
    /// <summary>
    /// 所属日历标识
    /// </summary>
    public string CalendarId { get; set; } = string.Empty;

    #region common properties
    public string Id { get; set; }

    public string iCalUId { get; set; }

    public bool AnyoneCanAddSelf { get; set; }

    public IEnumerable<Attachment>? Attachments { get; set; }

    public bool AttendeesOmitted { get; set; }

    public IEnumerable<Attendee>? Attendees { get; set; }

    public IItemBody Body { get; set; }

    public string BodyPreview { get; set; }

    public string Description { get; set; }

    public string ChangeKey { get; set; }

    public IEnumerable<string> Categories { get; set; }

    public string ColorId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public IOrganizer Creator { get; set; }

    public bool EndTimeUnspecified { get; set; }

    public string OriginalStartTimeZone { get; set; }

    public string OriginalEndTimeZone { get; set; }

    public bool HasAttachments { get; set; }

    public bool HideAttendees { get; set; }

    public string HtmlLink { get; set; }

    public Importance Importance { get; set; }

    public bool IsAllDay { get; set; }

    public bool IsCancelled { get; set; }

    public bool IsDraft { get; set; }

    public bool IsOrganizer { get; set; }

    public bool IsReminderOn { get; set; }

    public Gadget? Gadget { get; set; }

    public string HangoutLink { get; set; }

    public bool GuestsCanInviteOthers { get; set; }

    public bool GuestsCanModify { get; set; }

    public bool GuestsCanSeeOtherGuests { get; set; }

    public string Kind { get; set; }

    public DateTime LastModifiedDateTime { get; set; }

    public ILocation? Location { get; set; }

    public IEnumerable<ILocation>? Locations { get; set; }

    public bool Locked { get; set; }

    public string OnlineMeetingUrl { get; set; }

    public bool IsOnlineMeeting { get; set; }

    public string OnlineMeetingProvider { get; set; }

    public bool AllowNewTimeProposals { get; set; }

    public IOrganizer Organizer { get; set; }

    public bool PrivateCopy { get; set; }

    public IRecurrence? Recurrence { get; set; }

    public int ReminderMinutesBeforeStart { get; set; }

    public Reminders? Reminders { get; set; }

    public bool ResponseRequested { get; set; }

    public IResponseStatus? ResponseStatus { get; set; }

    public Sensitivity Sensitivity { get; set; }

    public string SeriesMasterId { get; set; }

    public int Sequence { get; set; }

    public ShowAs ShowAs { get; set; }

    public ITime OriginalStartTime { get; set; }

    public ITime Start { get; set; }

    public ITime End { get; set; }

    public EventStatus Status { get; set; }

    public string Subject { get; set; }

    public string Summary { get; set; }

    public EventTransparency? Transparency { get; set; }

    public EventType Type { get; set; }

    public EventType EventType { get; set; }

    public EventVisibility? Visibility { get; set; }

    public string Weblink { get; set; }

    public string TransactionId { get; set; }

    public string Source { get; set; }

    public string Etag { get; set; }

    #endregion
}
