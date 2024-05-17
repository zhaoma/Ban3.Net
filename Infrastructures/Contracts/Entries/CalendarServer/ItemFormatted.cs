using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class ItemFormatted:Item
{
    /// <summary>
    /// 性别翻译或格式化
    /// </summary>
    [DataMember]
    public string FormattedValue { get; set; }
}
