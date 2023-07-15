using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_POSITION_INFORMATION structure is used as an argument to routines that query or set file information.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_position_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_POSITION_INFORMATION
    {
        /// <summary>
        /// The byte offset of the current file pointer.
        /// </summary>
        public LARGE_INTEGER CurrentByteOffset;
    }
}
