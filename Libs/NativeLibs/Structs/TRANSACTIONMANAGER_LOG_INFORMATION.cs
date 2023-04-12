using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTIONMANAGER_LOG_INFORMATION structure contains information about a transaction manager object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTIONMANAGER_LOG_INFORMATION
    {
        /// <summary>
        /// A GUID that KTM uses to identify restart records in a transaction manager object's log stream.
        /// </summary>
        public GUID LogIdentity;
    }
}
