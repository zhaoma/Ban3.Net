using System;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IDeviceEndpoint
{
    DeviceAt DeviceAt { get; set; }

    DeviceBoundary DeviceBoundary { get; set; }


}

