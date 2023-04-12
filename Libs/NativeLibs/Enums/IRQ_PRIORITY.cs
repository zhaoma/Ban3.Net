using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IRQ_PRIORITY enumeration type indicates the priority the system 
    /// should give to servicing a device's interrupts.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_irq_priority
    /// </summary>
    public enum IRQ_PRIORITY
    {
        /// <summary>
        /// Specifies that the device does not require any particular priority for its interrupts.
        /// </summary>
        IrqPriorityUndefined,

        /// <summary>
        /// Specifies that the device's interrupts are of low priority. 
        /// This setting is appropiate for devices that can tolerate higher-than-normal latency.
        /// </summary>
        IrqPriorityLow,

        /// <summary>
        /// Specifies that the device's interrupts are of normal priority.
        /// </summary>
        IrqPriorityNormal,

        /// <summary>
        /// Specifies that the device's interrupts are of high priority. 
        /// This setting is appropriate for devices that require low latency.
        /// </summary>
        IrqPriorityHigh
    }
}
