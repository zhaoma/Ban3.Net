﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTIONMANAGER_BASIC_INFORMATION structure contains information about a transaction manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transactionmanager_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTIONMANAGER_BASIC_INFORMATION
    {
        /// <summary>
        /// A GUID that KTM has assigned to a transaction manager object.
        /// </summary>
        public GUID TmIdentity;

        /// <summary>
        /// The virtual clock value that is currently associated with a transaction manager object.
        /// </summary>
        public LARGE_INTEGER VirtualClock;
    }
}
