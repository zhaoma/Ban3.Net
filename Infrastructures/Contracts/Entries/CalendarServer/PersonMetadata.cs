//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class PersonMetadata
{
    /// <summary>
    /// 数据来源
    /// </summary>    
    public Source? Sources { get; set; }

    /// <summary>
    /// 曾经有过的资源名称：认证的电话号码，网址
    /// </summary>    
    public string? PreviousResourceNames { get; set; }

    /// <summary>
    /// 与此资源相关的人员的资源名称.
    /// </summary>    
    public string? LinkedPeopleResourceNames { get; set; }

    /// <summary>
    /// 资源是否被删除
    /// </summary>    
    public bool Deleted { get; set; }
}
