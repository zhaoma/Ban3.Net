using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EXT_SET_PARAMETERS structure contains an extended set of parameters for the ExSetTimer routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ext_set_parameters_v0
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EXT_SET_PARAMETERS
    {
        /// <summary>
        /// The version number of this EXT_SET_PARAMETERS structure. 
        /// The ExInitializeSetTimerParameters routine sets this member to the correct version number.
        /// </summary>
        public uint Version;

        /// <summary>
        /// Set to zero. 
        /// The ExInitializeSetTimerParameters routine sets this member to zero.
        /// </summary>
        public uint Reserved;

        /// <summary>
        /// The maximum time, in system time units (100-nanosecond intervals), 
        /// that the timer can wait to wake the processor after the timer reaches its expiration time. 
        /// Only after the processor wakes can the timer expire. 
        /// If a timer is set to expire when the processor is in a low-power state, 
        /// the timer will not wake the processor to expire until the expiration time plus the NoWakeTolerance delay is exceeded. As an option, a driver can set this member to EX_TIMER_UNLIMITED_TOLERANCE, which indicates that the timer never wakes the processor and, thus, cannot expire until the processor wakes for some other reason.
        /// 
        /// Do not set this member to a negative value (other than EX_TIMER_UNLIMITED_TOLERANCE). 
        /// Otherwise, the routine bug checks.
        /// </summary>
        public long NoWakeTolerance;
    }
}
