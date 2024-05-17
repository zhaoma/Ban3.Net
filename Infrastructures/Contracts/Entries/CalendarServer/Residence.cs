using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址
/// </summary>
public class Residence : Item
{
    /// <summary>
    ///是否是现居住地址
    /// </summary>
    [DataMember]
    public bool Current { get; set; }
}
