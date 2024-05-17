using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 链接地址
/// </summary>
public class Url:Item
{
    /// <summary>
    /// URL的类型
    /// </summary>
    [DataMember]
    public string Type { get; set; }

    /// <summary>
    /// 查看账户的只读类型
    /// </summary>
    [DataMember]
    public string FormattedType { get; set; }
}
