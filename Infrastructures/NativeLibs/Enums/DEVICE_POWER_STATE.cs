using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_POWER_STATE enumeration type indicates a device power state.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_power_state
    /// </summary>
    public enum DEVICE_POWER_STATE
    {
        /// <summary>
        /// Indicates an unspecified device power state.
        /// </summary>
        PowerDeviceUnspecified,

        /// <summary>
        /// Indicates a maximum device power state, which corresponds to device working state D0.
        /// </summary>
        PowerDeviceD0,

        /// <summary>
        /// Indicates a device sleeping state less than PowerDeviceD0 and greater than PowerDeviceD2, 
        /// which corresponds to device power state D1.
        /// </summary>
        PowerDeviceD1,

        /// <summary>
        /// Indicates a device sleeping state less than PowerDeviceD1 and greater than PowerDeviceD3, 
        /// which corresponds to device power state D2.
        /// </summary>
        PowerDeviceD2,

        /// <summary>
        /// Indicates the lowest-powered device sleeping state, which corresponds to device power state D3.
        /// </summary>
        PowerDeviceD3,

        /// <summary>
        /// The number of device power state values for this enumeration type that represent actual power states. 
        /// The value of the other device power states is less than this value.
        /// </summary>
        PowerDeviceMaximum
    }
}
