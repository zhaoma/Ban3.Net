using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes time information for time conversion routines.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-time_fields
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TIME_FIELDS
    {
        /// <summary>
        /// Specifies a value from 1601 on.
        /// </summary>
        public byte Year;

        /// <summary>
        /// Specifies a value from 1 to 12.
        /// </summary>
        public byte Month;

        /// <summary>
        /// Specifies a value from 1 to 31.
        /// </summary>
        public byte Day;

        /// <summary>
        /// Specifies a value from 0 to 23.
        /// </summary>
        public byte Hour;

        /// <summary>
        /// Specifies a value from 0 to 59.
        /// </summary>
        public byte Minute;

        /// <summary>
        /// Specifies a value from 0 to 59.
        /// </summary>
        public byte Second;

        /// <summary>
        /// Specifies a value from 0 to 999.
        /// </summary>
        public byte Milliseconds;

        /// <summary>
        /// Specifies a value from 0 to 6 (Sunday to Saturday).
        /// </summary>
        public byte Weekday;
    }
}
