using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Reserved for system use.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-system_pool_zeroing_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_POOL_ZEROING_INFORMATION
    {
        public byte PoolZeroingSupportPresent;
    }
}
