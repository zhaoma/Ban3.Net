//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Common;

/// <summary>
/// 
/// </summary>
public interface Error
{
    [Description( "code" )]
    string Code { get; set; }

    [Description( "message" )]
    string Message { get; set; }
}