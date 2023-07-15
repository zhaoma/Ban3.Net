using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_WAKE_DEPTH enumeration specifies the deepest device power state from 
    /// which a device can trigger a wake signal.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_wake_depth
    /// </summary>
    public enum DEVICE_WAKE_DEPTH
    {
        /// <summary>
        /// There is no device power state that can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthNotWakeable,

        /// <summary>
        /// D0 is the deepest device power state from which the device can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthD0,

        /// <summary>
        /// D1 is the deepest low-power device power state from which the device can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthD1,

        /// <summary>
        /// D2 is the deepest low-power device power state from which the device can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthD2,

        /// <summary>
        /// D3hot is the deepest low-power device power state from which the device can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthD3hot,

        /// <summary>
        /// D3cold is the deepest low-power device power state from which the device can trigger a wake signal.
        /// </summary>
        DeviceWakeDepthD3cold,

        /// <summary>
        /// Reserved for use by the operating system.
        /// </summary>
        DeviceWakeDepthMaximum
    }
}
