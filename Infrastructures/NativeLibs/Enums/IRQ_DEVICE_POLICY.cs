using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IRQ_DEVICE_POLICY enumeration type indicates the policy the operating system 
    /// can use to assign the interrupts from a device to different processors.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_irq_device_policy
    /// </summary>
    public enum IRQ_DEVICE_POLICY
    {
        /// <summary>
        /// The device does not require any particular assignment of interrupts to processors.
        /// </summary>
        IrqPolicyMachineDefault = 0,

        /// <summary>
        /// The operating system should assign interrupts from the device to processors that are close to the device. 
        /// On non-NUMA computers, the effect of this value is identical to that of IrqPolicyAllProcessorsInMachine.
        /// </summary>
        IrqPolicyAllCloseProcessors = 1,

        /// <summary>
        /// The operating system should assign a single interrupt for the device to one processor that is close to the device. 
        /// On non-NUMA computers, the operating system can assign the interrupt to any processor.
        /// </summary>
        IrqPolicyOneCloseProcessor = 2,

        /// <summary>
        /// The operating system should assign interrupts from the device to all processors.
        /// </summary>
        IrqPolicyAllProcessorsInMachine = 3,

        /// <summary>
        /// The operating system should assign interrupts from the device to a specific set of processors.
        /// </summary>
        IrqPolicySpecifiedProcessors = 4,

        /// <summary>
        /// The operating system should assign different message-signaled interrupts to different processors, if possible.
        /// </summary>
        IrqPolicySpreadMessagesAcrossAllProcessors = 5,

        /// <summary>
        /// Reserved for system use. Do not use in your driver.
        /// </summary>
        IrqPolicyAllProcessorsInMachineWhenSteered = 6
    }
}
