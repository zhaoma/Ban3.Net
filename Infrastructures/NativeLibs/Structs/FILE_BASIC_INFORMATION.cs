using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_BASIC_INFORMATION structure contains timestamps and basic attributes of a file. 
    /// It is used as an argument to routines that query or set file information.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_BASIC_INFORMATION
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
        /// Specifies the time that the file was last written to.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;

        /// <summary>
        /// Specifies the last time the file was changed.
        /// </summary>
        public LARGE_INTEGER ChangeTime;

        /// <summary>
        /// Specifies one or more FILE_ATTRIBUTE_XXX flags. 
        /// For descriptions of these flags, see File Attribute Constants in the Microsoft Windows SDK.
        /// </summary>
        public uint FileAttributes;

    }
}
