//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历分组
/// </summary>
public class CalendarGroup : IZero
{
    /// <summary>
    /// ClassId(MS)
    /// The class identifier. Read-only.
    /// </summary>
    public string ClassId { get; set; }

    /// <summary>
    /// 分组名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ChangeKey
    /// Identifies the version of the calendar group. 
    /// Every time the calendar group is changed, ChangeKey changes as well. 
    /// This allows Exchange to apply changes to the correct version of the object. Read-only.
    /// </summary>
    public string ChangeKey { get; set; }

    /// <summary>
    /// ChangeKey
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public object Data { get; set; }
}
