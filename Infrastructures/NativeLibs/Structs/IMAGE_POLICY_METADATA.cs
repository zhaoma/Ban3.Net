using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This structure is not supported.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_image_policy_metadata
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IMAGE_POLICY_METADATA
    {
        /// UCHAR->unsigned char
        public byte Version;

        /// UCHAR[7]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Reserved0;

        /// ULONGLONG->unsigned __int64
        public ulong ApplicationId;

        /// DWORD[]
        public IMAGE_POLICY_ENTRY[] Policies;
    }
}
