using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_IS_REMOTE_DEVICE_INFORMATION structure is used as an argument to the ZwQueryInformationFile routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_is_remote_device_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_IS_REMOTE_DEVICE_INFORMATION
    {
        /// <summary>
        /// A value that indicates whether the file system that contains the file is a remote file system.
        /// </summary>
        public bool IsRemote;
    }
}
