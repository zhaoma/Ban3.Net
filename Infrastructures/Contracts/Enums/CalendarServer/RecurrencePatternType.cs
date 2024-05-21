//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 
/// </summary>
public enum RecurrencePatternType
{
    /// <summary>
    /// 
    /// </summary>
    Daily,
    /// <summary>
    /// 
    /// </summary>
    Weekly,
    /// <summary>
    /// 
    /// </summary>
    AbsoluteMonthly,
    /// <summary>
    /// 
    /// </summary>
    RelativeMonthly,
    /// <summary>
    /// 
    /// </summary>
    AbsoluteYearly,
    /// <summary>
    /// 
    /// </summary>
    RelativeYearly
}
