using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POWER_ACTION enumeration identifies the system power actions that can occur on a computer.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-power_action
    /// </summary>
    public enum POWER_ACTION
    {
        /// <summary>
        /// No power action is taking place.
        /// </summary>
        PowerActionNone,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        PowerActionReserved,

        /// <summary>
        /// The computer is entering a system sleeping (S1, S2, or S3) state.
        /// </summary>
        PowerActionSleep,

        /// <summary>
        /// The computer is entering its hibernation (S4) state.
        /// </summary>
        PowerActionHibernate,

        /// <summary>
        /// The computer is entering its shutdown (S5) state. After all devices have entered their off (D3) state, 
        /// the computer remains powered on until an administrator presses the power button.
        /// </summary>
        PowerActionShutdown,

        /// <summary>
        /// The computer is entering its shutdown (S5) state. After all devices have entered their off (D3) state, 
        /// the computer automatically powers off and then immediately restarts and returns to its working (S0) state.
        /// </summary>
        PowerActionShutdownReset,

        /// <summary>
        /// The computer is entering its shutdown (S5) state. 
        /// After all devices have entered their off (D3) state, the computer automatically powers off.
        /// </summary>
        PowerActionShutdownOff,

        /// <summary>
        /// The computer is being ejected from an ACPI-compatible dock device. Typically, the computer's power state does not change.
        /// </summary>
        PowerActionWarmEject,
        PowerActionDisplayOff
    }
}
