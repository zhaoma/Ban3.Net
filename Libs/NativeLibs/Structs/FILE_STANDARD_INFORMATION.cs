using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_STANDARD_INFORMATION structure is used as an argument to routines that query or set file information.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_standard_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_STANDARD_INFORMATION
    {
        /// <summary>
        /// The file allocation size in bytes. 
        /// Usually, this value is a multiple of the sector or cluster size of the underlying physical device.
        /// </summary>
        public LARGE_INTEGER AllocationSize;

        /// <summary>
        /// The end of file location as a byte offset.
        /// </summary>
        public LARGE_INTEGER EndOfFile;

        /// <summary>
        /// The number of hard links to the file.
        /// </summary>
        public uint NumberOfLinks;

        /// <summary>
        /// The delete pending status. TRUE indicates that a file deletion has been requested.
        /// </summary>
        public byte DeletePending;

        /// <summary>
        /// The file directory status. TRUE indicates the file object represents a directory.
        /// </summary>
        public byte Directory;
    }
}
