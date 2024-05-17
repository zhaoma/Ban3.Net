using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 传记信息
/// </summary>
public class Biographie
{
    /// <summary>
    /// 简短传记
    /// </summary>
    [DataMember]
    public string Type { get; set; }
}
