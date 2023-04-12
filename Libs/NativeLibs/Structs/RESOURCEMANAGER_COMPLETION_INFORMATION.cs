using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The RESOURCEMANAGER_COMPLETION_INFORMATION structure is not used.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_resourcemanager_completion_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RESOURCEMANAGER_COMPLETION_INFORMATION
    {
        /// HANDLE->void*
        public System.IntPtr IoCompletionPortHandle;

        /// ULONG_PTR->unsigned int
        public uint CompletionKey;
    }
}
