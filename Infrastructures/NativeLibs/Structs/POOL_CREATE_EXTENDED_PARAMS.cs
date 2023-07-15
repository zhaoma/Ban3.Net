using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the POOL_CREATE_EXTENDED_PARAMS structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-pool_create_extended_params
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POOL_CREATE_EXTENDED_PARAMS
    {
        public uint Version;
    }
}
