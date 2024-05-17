using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 组织
/// </summary>
public class Organization
{
    /// <summary>
    /// 组织类型
    /// </summary>
    [DataMember]
    public string Type { get; set; }

    /// <summary>
    ///查看器的翻译
    /// </summary>
    [DataMember]
    public string FormattedType { get; set; }

    /// <summary>
    /// 加入组织日期
    /// </summary>
    [DataMember]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 离开组织日期
    /// </summary>
    [DataMember]
    public DateTime EndDate { get; set; }

    /// <summary>
    ///是否当前所在组织
    /// </summary>
    [DataMember]
    public bool Current { get; set; }

    /// <summary>
    /// 组织名字
    /// </summary>
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// 语音名
    /// </summary>
    [DataMember]
    public string PhoneticName { get; set; }

    /// <summary>
    /// 组织部门
    /// </summary>
    [DataMember]
    public string Department { get; set; }

    /// <summary>
    /// 组织工作主题
    /// </summary>
    [DataMember]
    public string Title { get; set; }

    /// <summary>
    /// 员工的职位描述
    /// </summary>
    [DataMember]
    public string JobDescription { get; set; }

    /// <summary>
    /// 与组织有关的符号
    /// </summary>
    [DataMember]
    public string Symbol { get; set; }

    /// <summary>
    ///与组织有关的域名
    /// </summary>
    [DataMember]
    public string Domain { get; set; }

    /// <summary>
    /// 组织办公室位置
    /// </summary>
    [DataMember]
    public string Location { get; set; }
}
