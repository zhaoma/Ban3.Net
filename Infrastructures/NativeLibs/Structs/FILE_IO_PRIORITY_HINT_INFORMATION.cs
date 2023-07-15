using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The FILE_IO_PRIORITY_HINT_INFORMATION structure is used by the ZwQueryInformationFile and ZwSetInformationFile routines 
    /// to query and set the default IRP priority hint for requests on the specified file handle.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_file_io_priority_hint_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_IO_PRIORITY_HINT_INFORMATION
    {
        /// <summary>
        /// Specifies the IO_PRIORITY_HINT value that indicates the priority hint for a file handle.
        /// </summary>
        public IO_PRIORITY_HINT PriorityHint;
    }
}
