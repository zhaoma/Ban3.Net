using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_IO_STATISTICS_HEADER structure holds the header portion of a CLFS_IO_STATISTICS structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cls_io_statistics_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_IO_STATISTICS_HEADER
    {
        /// <summary>
        /// The major version of the CLFS_IO_STATISTICS structure.
        /// </summary>
        public byte ubMajorVersion;

        /// <summary>
        /// The minor version of the CLFS_IO_STATISTICS structure.
        /// </summary>
        public byte ubMinorVersion;

        /// <summary>
        /// Reserved for future use. This member is ignored.
        /// CLFS_IOSTATS_CLASS
        /// </summary>
        public uint eStatsClass;

        /// <summary>
        /// The size, in bytes, of the CLFS_IO_STATISTICS structure, including the header.
        /// </summary>
        public ushort cbLength;

        /// <summary>
        /// The offset, in bytes, from the beginning of the CLFS_IO_STATISTICS structure to the beginning of the statistics data. 
        /// This member allows for transparent modifications to the header.
        /// </summary>
        public uint coffData;
    }
}
