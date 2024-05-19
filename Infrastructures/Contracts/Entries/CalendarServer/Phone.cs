//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Phone
{
    /// <summary>
    /// 电话号码
    /// </summary>
    
    public string Value { get; set; }

    /// <summary>
    /// 电话号码的类别
    /// </summary>
    
    public string Type { get; set; }
}
