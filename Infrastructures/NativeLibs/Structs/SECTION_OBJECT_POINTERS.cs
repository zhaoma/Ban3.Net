using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SECTION_OBJECT_POINTERS structure, allocated by a file system or a redirector driver, 
    /// is used by the memory manager and cache manager to store file-mapping and cache-related information for a file stream.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_section_object_pointers
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECTION_OBJECT_POINTERS
    {
        public IntPtr DataSectionObject;
        public IntPtr SharedCacheMap;
        public IntPtr ImageSectionObject;
    }
}
