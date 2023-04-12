using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_SESSION_CONNECT_INFO structure provides information about a user session.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_session_connect_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_SESSION_CONNECT_INFO
    {
        /// <summary>
        /// Session ID. This member contains the Terminal Services session identifier of the user session for which the driver is receiving this notification.
        /// </summary>
        public uint SessionId;

        /// <summary>
        /// Indicates whether the user session is a local session or a remote session. 
        /// If TRUE, the user is logged on locally. 
        /// If FALSE, the user is logged on remotely.
        /// </summary>
        public bool LocalSession;
    }
}
