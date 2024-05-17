using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Metadata
{
    /// <summary>
    /// 主领域
    /// </summary>       
    [DataMember]
    public bool Primary { get; set; }

    /// <summary>
    /// 验证该字段是否正确
    /// </summary>        
    [DataMember]
    public bool Verified { get; set; }

    /// <summary>
    /// 该领域的来源
    /// </summary>        
    [DataMember]
    public Source Source { get; set; }
}
