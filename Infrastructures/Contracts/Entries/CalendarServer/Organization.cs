//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 组织
/// </summary>
public class Organization
{
    /// <summary>
    /// 组织类型
    /// </summary>
    
    public string Type { get; set; }

    /// <summary>
    ///查看器的翻译
    /// </summary>
    
    public string FormattedType { get; set; }

    /// <summary>
    /// 加入组织日期
    /// </summary>
    
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 离开组织日期
    /// </summary>
    
    public DateTime EndDate { get; set; }

    /// <summary>
    ///是否当前所在组织
    /// </summary>
    
    public bool Current { get; set; }

    /// <summary>
    /// 组织名字
    /// </summary>
    
    public string Name { get; set; }

    /// <summary>
    /// 语音名
    /// </summary>
    
    public string PhoneticName { get; set; }

    /// <summary>
    /// 组织部门
    /// </summary>
    
    public string Department { get; set; }

    /// <summary>
    /// 组织工作主题
    /// </summary>
    
    public string Title { get; set; }

    /// <summary>
    /// 员工的职位描述
    /// </summary>
    
    public string JobDescription { get; set; }

    /// <summary>
    /// 与组织有关的符号
    /// </summary>
    
    public string Symbol { get; set; }

    /// <summary>
    ///与组织有关的域名
    /// </summary>
    
    public string Domain { get; set; }

    /// <summary>
    /// 组织办公室位置
    /// </summary>
    
    public string Location { get; set; }
}
