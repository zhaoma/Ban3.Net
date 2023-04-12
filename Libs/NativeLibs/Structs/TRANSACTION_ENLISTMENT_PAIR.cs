using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTION_ENLISTMENT_PAIR structure contains information about an enlistment that is associated with a transaction object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transaction_enlistment_pair
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTION_ENLISTMENT_PAIR
    {
        /// <summary>
        /// A GUID that KTM has assigned to the enlistment.
        /// </summary>
        public GUID EnlistmentId;

        /// <summary>
        /// A GUID that KTM has assigned to the resource manager that created the enlistment.
        /// </summary>
        public GUID ResourceManagerId;
    }
}
