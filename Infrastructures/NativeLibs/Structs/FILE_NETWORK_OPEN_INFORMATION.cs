using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_NETWORK_OPEN_INFORMATION structure is used as an argument to ZwQueryInformationFile.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_network_open_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_NETWORK_OPEN_INFORMATION
    {
        /// <summary>
        /// Specifies the time that the file was created.
        /// </summary>
        public LARGE_INTEGER CreationTime;

        /// <summary>
        /// Specifies the time that the file was last accessed.
        /// </summary>
        public LARGE_INTEGER LastAccessTime;

        /// <summary>
        /// Specifies he time that the file was last written to.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;

        /// <summary>
        /// Specifies the time that the file was last changed.
        /// </summary>
        public LARGE_INTEGER ChangeTime;

        /// <summary>
        /// Specifies the file allocation size, in bytes. 
        /// Usually, this value is a multiple of the sector or cluster size of the underlying physical device.
        /// </summary>
        public LARGE_INTEGER AllocationSize;

        /// <summary>
        /// Specifies the absolute end-of-file position as a byte offset from the start of the file. 
        /// EndOfFile specifies the byte offset to the end of the file. 
        /// Because this value is zero-based, it actually refers to the first free byte in the file. 
        /// In other words, EndOfFile is the offset to the byte immediately following the last valid byte in the file.
        /// </summary>
        public LARGE_INTEGER EndOfFile;

        /// <summary>
        /// Specifies one or more FILE_ATTRIBUTE_XXX flags. 
        /// </summary>
        public uint FileAttributes;
    }
}
