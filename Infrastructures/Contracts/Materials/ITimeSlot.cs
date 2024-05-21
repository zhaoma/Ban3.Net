//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// Represents a time slot for a meeting.
/// https://learn.microsoft.com/en-us/graph/api/resources/timeslot?view=graph-rest-1.0
/// </summary>
public interface ITimeSlot : IZero
{
    /// <summary>
    /// 开始时间
    /// </summary>
    ITime Start { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    ITime End { get; set; }
}
