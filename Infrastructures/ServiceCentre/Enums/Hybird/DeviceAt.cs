using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 设备接入
/// </summary>
public enum DeviceAt
{
    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,

    [Description("串口")]
    SerialPort,

    [Description("USB")]
    USB
}

