using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 自定义数据项
/// </summary>
public class UserDefined
{
    /// <summary>
    /// 用户指定的键.
    /// </summary>
    [DataMember]
    public string Key { get; set; }
}
