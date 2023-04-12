using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KINTERRUPT_POLARITY enumeration indicates how a device signals an interrupt request on an interrupt line.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_kinterrupt_polarity
    /// </summary>
    public enum KINTERRUPT_POLARITY
    {
        /// <summary>
        /// The interrupt polarity is unknown.
        /// </summary>
        InterruptPolarityUnknown,

        /// <summary>
        /// Active-high interrupt. The interrupt input type is level-triggered, 
        /// and an interrupt request is indicated by a high signal level on the interrupt line. 
        /// The request remains active as long as the line remains high.
        /// </summary>
        InterruptActiveHigh,

        /// <summary>
        /// Rising-edge-triggered interrupt. The interrupt input type is edge-triggered, 
        /// and an interrupt request is indicated by a low-to-high transition on the interrupt line.
        /// </summary>
        InterruptRisingEdge,

        /// <summary>
        /// Active-low interrupt. The interrupt input type is level-triggered, 
        /// and an interrupt request is indicated by a low signal level on the interrupt line. 
        /// The request remains active as long as the line remains low.
        /// </summary>
        InterruptActiveLow,

        /// <summary>
        /// Falling-edge-triggered interrupt. The interrupt input type is edge-triggered, 
        /// and an interrupt request is indicated by a high-to-low transition on the interrupt line.
        /// </summary>
        InterruptFallingEdge,

        /// <summary>
        /// Active-both interrupt. The interrupt input type is edge-triggered, 
        /// and an interrupt request is indicated by a low-to-high or a high-to-low transition on the interrupt line. 
        /// After a low-to-high transition signals an interrupt request, the interrupt line remains high 
        /// until a high-to-low transition signals the next interrupt request. 
        /// Similarly, after a high-to-low transition signals an interrupt request, 
        /// the interrupt line remains low until a low-to-high transition signals the next interrupt request.
        /// </summary>
        InterruptActiveBoth,

        /// <summary>
        /// Reserved for use by the operating system.
        /// </summary>
        InterruptActiveBothTriggerLow,

        /// <summary>
        /// Reserved for use by the operating system.
        /// </summary>
        InterruptActiveBothTriggerHigh
    }
}
