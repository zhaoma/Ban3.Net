using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KINTERRUPT_MODE enumeration type indicates whether an interrupt is level-triggered or edge-triggered.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_kinterrupt_mode
    /// </summary>
    public enum KINTERRUPT_MODE
    {
        /// <summary>
        /// The interrupt is level-triggered. 
        /// This is the mode for traditional PCI line-based interrupts.
        /// </summary>
        LevelSensitive,

        /// <summary>
        /// The interrupt is edge-triggered. This is the mode for PCI message-signaled interrupts.
        /// </summary>
        Latched
    }
}
