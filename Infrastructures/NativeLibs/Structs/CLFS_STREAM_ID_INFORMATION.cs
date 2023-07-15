using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_STREAM_ID_INFORMATION structure holds a value that identifies a stream in a Common Log File System (CLFS) log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_clfs_stream_id_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_STREAM_ID_INFORMATION
    {
        /// <summary>
        /// An 8-bit value that identifies a stream.
        /// </summary>
        public byte StreamIdentifier;
    }
}
