using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-io_status_block64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_STATUS_BLOCK64
    {
    }
}
