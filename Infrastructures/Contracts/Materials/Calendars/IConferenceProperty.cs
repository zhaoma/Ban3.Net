//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

public interface IConferenceProperty : IZero
{
    /// <summary>
    /// 此日历支持的会议解决方案类型。
    /// </summary>
    IEnumerable<ConferenceSolutionType>? AllowedConferenceSolutionTypes { get; set; }
}
