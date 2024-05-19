//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// Status of the event. Optional.
/// </summary>
public enum EventStatus
{
    /// <summary>
    /// The event is confirmed. This is the default status.
    /// </summary>
    [JsonProperty("confirmed")]
    confirmed,

    /// <summary>
    /// The event is tentatively confirmed.
    /// </summary>
    [JsonProperty("tentative")]
    Tentative,

    /// <summary>
    /// The event is cancelled (deleted). 
    /// The list method returns cancelled events only 
    /// on incremental sync (when syncToken or updatedMin are specified) 
    /// or if the showDeleted flag is set to true. 
    /// The get method always returns them.
    /// </summary>
    [JsonProperty("cancelled")]
    Cancelled,
}
