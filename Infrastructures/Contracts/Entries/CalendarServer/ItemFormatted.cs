﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class ItemFormatted:MetaValue
{
    /// <summary>
    /// 性别翻译或格式化
    /// </summary>
    
    public string FormattedValue { get; set; }
}
