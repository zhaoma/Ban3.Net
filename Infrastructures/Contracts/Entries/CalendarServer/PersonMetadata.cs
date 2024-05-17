using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class PersonMetadata
{
    /// <summary>
    /// 数据来源
    /// </summary>
    [DataMember]
    public Source Sources { get; set; }

    /// <summary>
    /// 曾经有过的资源名称：认证的电话号码，网址
    /// </summary>
    [DataMember]
    public string PreviousResourceNames { get; set; }

    /// <summary>
    /// 与此资源相关的人员的资源名称.
    /// </summary>
    [DataMember]
    public string LinkedPeopleResourceNames { get; set; }

    /// <summary>
    /// 资源是否被删除
    /// </summary>
    [DataMember]
    public bool Deleted { get; set; }
}
