using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ENLISTMENT_BASIC_INFORMATION structure contains information about an enlistment object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_enlistment_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENLISTMENT_BASIC_INFORMATION
    {
        /// <summary>
        /// A GUID that KTM has assigned to the enlistment object.
        /// </summary>
        public GUID EnlistmentId;

        /// <summary>
        /// A GUID that KTM has assigned to the transaction object that is associated with the enlistment object that the EnlistmentId member identifies.
        /// </summary>
        public GUID TransactionId;

        /// <summary>
        /// A GUID that KTM has assigned to the resource manager that created the enlistment.
        /// </summary>
        public GUID ResourceManagerId;
    }
}
