using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Indicates the power state of the monitor being displayed on.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_monitor_display_state
    /// </summary>
    public enum MONITOR_DISPLAY_STATE
    {
        /// <summary>
        /// This indicates that the monitor is off.
        /// </summary>
        PowerMonitorOff,

        /// <summary>
        /// This indicates that the monitor is on.
        /// </summary>
        PowerMonitorOn,

        /// <summary>
        /// This indicates that the monitor is dim.
        /// </summary>
        PowerMonitorDim
    }
}
