using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 
/// </summary>
public interface IDevicesHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="deviceEndpoint"></param>
    /// <param name="deviceControl"></param>
    /// <param name="deviceAnswer"></param>
    /// <returns></returns>
    Task<bool> TryControl(
        DeviceEndpoint deviceEndpoint,
        DeviceControl deviceControl,
        out DeviceAnswer deviceAnswer
	);
}

