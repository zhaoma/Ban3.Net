//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Photo
{
    /// <summary>
    ///照片的Url
    /// </summary>
    
    public string Url { get; set; }

    /// <summary>
    /// 照片是否是默认照片
    /// </summary>
    
    public string Default { get; set; }
}
