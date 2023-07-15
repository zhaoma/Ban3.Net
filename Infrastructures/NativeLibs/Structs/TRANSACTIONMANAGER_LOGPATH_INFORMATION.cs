using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTIONMANAGER_LOGPATH_INFORMATION structure contains information about a transaction manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transactionmanager_logpath_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTIONMANAGER_LOGPATH_INFORMATION
    {
        /// ULONG->unsigned int
        public uint LogPathLength;

        /// WCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string LogPath;
    }
}
