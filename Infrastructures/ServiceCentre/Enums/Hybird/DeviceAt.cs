//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 设备接入
/// </summary>
public enum DeviceAt
{
    /// <summary />
    [Description( "TCP" )]
    TCP,

    /// <summary />
    [Description( "UDP" )]
    UDP,

    /// <summary />
    [Description( "串口" )]
    SerialPort,

    /// <summary />
    [Description( "USB" )]
    USB
}