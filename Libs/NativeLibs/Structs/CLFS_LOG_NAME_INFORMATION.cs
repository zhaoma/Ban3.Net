using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_LOG_NAME_INFORMATION structure holds the name of a Common Log File System (CLFS) stream or log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_clfs_log_name_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_LOG_NAME_INFORMATION
    {
        /// <summary>
        /// The size, in bytes, of the log name.
        /// </summary>
        public ushort NameLengthInBytes;

        /// <summary>
        /// An array of wide characters that holds the log name.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Name;
    }
}
