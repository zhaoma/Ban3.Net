using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTION_ENLISTMENTS_INFORMATION structure contains information about the enlistments that are associated with a transaction object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transaction_enlistments_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTION_ENLISTMENTS_INFORMATION
    {
        /// <summary>
        /// The number of enlistments that are associated with a transaction object. 
        /// This is also the number of elements in the array that the EnlistmentPair member specifies.
        /// </summary>
        public uint NumberOfEnlistments;

        /// <summary>
        /// A caller-allocated array of TRANSACTION_ENLISTMENT_PAIR structures.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public TRANSACTION_ENLISTMENT_PAIR[] EnlistmentPair;
    }
}
