using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EXTENDED_CREATE_INFORMATION structure is the EaBuffer field in NtCreateFile 
    /// when the FILE_CONTAINS_EXTENDED_CREATE_INFORMATION flag is set in NtCreateFile's CreateOption parameter.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-extended_create_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EXTENDED_CREATE_INFORMATION
    {
        /// <summary>
        /// Flags for the extended create. ExtendedCreateFlags can be one of the following values. 
        /// When either of these flags are specified, 
        /// NtCreateFile's file object is marked as opened for copy intent in its FileObjectExtension. 
        /// Filters can check for this stored state by calling IoCheckFileObjectOpenedAsCopySource or IoCheckFileObjectOpenedAsCopyDestination
        /// 
        /// EX_CREATE_FLAG_FILE_SOURCE_OPEN_FOR_COPY    0x00000001  Signals that the file is being opened as the source file for a file copy.
        /// EX_CREATE_FLAG_FILE_DEST_OPEN_FOR_COPY      0x00000002  Signals that the file is being opened as the destination file for a file copy.
        /// 
        /// The presence of one of the above flags is not enough to ensure that read/writes (I/O operations) on the file object are trustworthy, 
        /// as any user-mode process can provide these flags at create time.
        /// </summary>
        public long ExtendedCreateFlags;

        /// <summary>
        /// Pointer to the extended attributes buffer.
        /// </summary>
        public System.IntPtr EaBuffer;

        /// <summary>
        /// Length of the buffer that EaBuffer points to.
        /// </summary>
        public uint EaLength;
    }
}
