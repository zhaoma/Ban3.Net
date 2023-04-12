using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
    /// https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-filetime
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        /// <summary>
        /// The low-order part of the file time.
        /// </summary>
        public uint dwLowDateTime;

        /// <summary>
        /// The high-order part of the file time.
        /// </summary>
        public uint dwHighDateTime;
    }
}
