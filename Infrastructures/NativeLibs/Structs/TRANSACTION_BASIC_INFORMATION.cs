using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRANSACTION_BASIC_INFORMATION structure contains information about a transaction object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_transaction_basic_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTION_BASIC_INFORMATION
    {
        /// <summary>
        /// A GUID that KTM has assigned to the transaction object. 
        /// This value is also known as the transaction's unit of work (UOW) identifier.
        /// </summary>
        public GUID TransactionId;

        /// <summary>
        /// A TRANSACTION_STATE-typed value that specifies the transaction's current state.
        /// </summary>
        public uint State;

        /// <summary>
        /// A TRANSACTION_OUTCOME-typed value that specifies the transaction's outcome (result).
        /// </summary>
        public uint Outcome;
    }
}
