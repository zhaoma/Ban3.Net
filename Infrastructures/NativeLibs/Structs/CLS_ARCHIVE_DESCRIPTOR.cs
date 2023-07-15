using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Used by the GetNextLogArchiveExtent function to return information about log archive extents.
    /// https://learn.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_archive_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_ARCHIVE_DESCRIPTOR
    {
        /// <summary>
        /// The offset in the container to the first byte of the archive extent.
        /// </summary>
        public ulong coffLow;

        /// <summary>
        /// The offset in the container to the last byte of the archive extent.
        /// </summary>
        public ulong coffHigh;

        /// <summary>
        /// The container information structure that describes the container associated with the archive extent.
        /// </summary>
        public CLS_CONTAINER_INFORMATION infoContainer;
    }
}
