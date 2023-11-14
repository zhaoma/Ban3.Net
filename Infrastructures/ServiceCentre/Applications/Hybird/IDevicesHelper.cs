// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 通信设备接口声明
/// </summary>
public interface IDevicesHelper
{
    /// <summary>
    /// 通信
    /// </summary>
    /// <param name="deviceEndpoint">设备地址</param>
    /// <param name="deviceControl">控制指令</param>
    /// <param name="deviceAnswer">设备应答</param>
    /// <returns></returns>
    Task<bool> TryCommunicate(
        IDeviceEndpoint deviceEndpoint,
        IDeviceControl deviceControl,
        out IDeviceAnswer deviceAnswer
    );
}