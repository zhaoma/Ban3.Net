using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_RESET_TYPE enumeration specifies the type of device reset 
    /// that is being requested by a call to the DeviceReset routine of 
    /// the GUID_DEVICE_RESET_INTERFACE_STANDARD interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_reset_type
    /// </summary>
    public enum DEVICE_RESET_TYPE
    {
        /// <summary>
        /// A function-level device reset, which is restricted to a specific device.
        /// </summary>
        FunctionLevelDeviceReset,

        /// <summary>
        /// A platform-level device reset, which affects a specific device 
        /// and all other devices that are connected to it via the same power rail or reset line.
        /// </summary>
        PlatformLevelDeviceReset
    }
}
