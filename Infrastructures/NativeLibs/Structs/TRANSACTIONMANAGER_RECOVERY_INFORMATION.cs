using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTIONMANAGER_RECOVERY_INFORMATION structure contains information about a transaction manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transactionmanager_recovery_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTIONMANAGER_RECOVERY_INFORMATION
    {
        /// <summary>
        /// The last log sequence number of the last log record that KTM obtained from CLFS during the most recent recovery operation.
        /// </summary>
        public ulong LastRecoveredLsn;
    }
}
