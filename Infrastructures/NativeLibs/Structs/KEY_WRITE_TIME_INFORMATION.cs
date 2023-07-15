using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KEY_WRITE_TIME_INFORMATION structure is used by the system to set the last write time for a registry key.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_key_write_time_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_WRITE_TIME_INFORMATION
    {
        /// <summary>
        /// Specifies the last time that the key was changed. 
        /// This time value is expressed in absolute system time format. 
        /// Absolute system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;
    }
}
