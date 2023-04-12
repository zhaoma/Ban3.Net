using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Format for CET_U XSTATE component.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_xsave_cet_u_format
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XSAVE_CET_U_FORMAT
    {
        /// ULONG64->unsigned __int64
        public ulong Ia32CetUMsr;

        /// ULONG64->unsigned __int64
        public ulong Ia32Pl3SspMsr;
    }
}
