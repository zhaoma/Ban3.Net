//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class ContactFolder
{
    /// <summary>
    /// 名称
    /// </summary>
    
    public string DisplayName { get; set; }

    /// <summary>
    /// 上级目录
    /// </summary>
    
    public string ParentFolderId { get; set; }
}
