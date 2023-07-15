using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The share access structure used by file systems for only link files.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_link_share_access
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LINK_SHARE_ACCESS
    {
        /// <summary>
        /// The number of open requests to the file.
        /// </summary>
        public uint OpenCount;

        /// <summary>
        /// File associated with the file object has been opened for delete access.
        /// </summary>
        public uint Deleters;

        /// <summary>
        /// File associated with the file object has been opened for delete sharing access.
        /// </summary>
        public uint SharedDelete;
    }
}
