//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 通信波特率
/// </summary>
public enum DeviceBoundary
{
    [Description( "9600bps" )]
    bps96 = 9600,

    [Description( "19200bps" )]
    bps192 = 19200,

    [Description( "38400bps" )]
    bps384 = 38400,

    [Description( "76800bps" )]
    bps768 = 76800,
}