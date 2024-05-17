using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 生日信息
/// </summary>
public class Birthday
{
    /// <summary>
    /// 生日日期
    /// </summary>
    [DataMember]
    public DateTime Date { get; set; }

    /// <summary>
    ///生日的自由格式
    /// </summary>
    [DataMember]
    public string Text { get; set; }
}
