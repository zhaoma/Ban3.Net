using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// DPC = deferred procedure call
    /// The KDPC_WATCHDOG_INFORMATION structure holds time-out information about the current deferred procedure call (DPC).
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_kdpc_watchdog_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KDPC_WATCHDOG_INFORMATION
    {
        /// <summary>
        /// Time limit for a single, current deferred procedure call. 
        /// If DPC time-out has been disabled, this value is set to 0.
        /// </summary>
        public uint DpcTimeLimit;

        /// <summary>
        /// Time remaining for the current deferred procedure call, if DPC time-out has been enabled.
        /// </summary>
        public uint DpcTimeCount;

        /// <summary>
        /// Total time limit permitted for a sequence of deferred procedure calls. 
        /// If DPC watchdog has been disabled, this value is set to zero.
        /// </summary>
        public uint DpcWatchdogLimit;

        /// <summary>
        /// Time value remaining for the current sequence of deferred procedure calls, if enabled.
        /// </summary>
        public uint DpcWatchdogCount;

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public uint Reserved;
    }
}
