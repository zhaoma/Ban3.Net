using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The RESOURCEMANAGER_BASIC INFORMATION structure contains information about a resource manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_resourcemanager_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RESOURCEMANAGER_BASIC_INFORMATION
    {
        /// GUID->_GUID
        public GUID ResourceManagerId;

        /// ULONG->unsigned int
        public uint DescriptionLength;

        /// WCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Description;
    }
}
