using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the POOL_EXTENDED_PARAMS_SECURE_POOL structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-pool_extended_params_secure_pool
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POOL_EXTENDED_PARAMS_SECURE_POOL
    {
        /// HANDLE->void*
        public System.IntPtr SecurePoolHandle;

        /// PVOID->void*
        public System.IntPtr Buffer;

        /// ULONG_PTR->unsigned int
        public uint Cookie;

        /// ULONG->unsigned int
        public uint SecurePoolFlags;
    }
}
