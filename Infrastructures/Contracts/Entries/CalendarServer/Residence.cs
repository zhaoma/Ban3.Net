//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址
/// </summary>
public class Residence : MetaValue
{
    /// <summary>
    ///是否是现居住地址
    /// </summary>    
    public bool Current { get; set; }
}
