//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 关系信息
/// </summary>
public class Relation
{
    /// <summary>
    /// 关联的姓名
    /// </summary>
    [DataMember(Name = "person")]
    public string Person { get; set; }

    /// <summary>
    ///关系，比如父母，兄弟等
    /// </summary>
    
    public string Type { get; set; }

    /// <summary>
    /// 查看器中翻译
    /// </summary>
    
    public string FormattedType { get; set; }
}
