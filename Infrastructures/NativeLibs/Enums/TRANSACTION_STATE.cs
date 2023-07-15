using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRANSACTION_STATE enumeration defines the states that KTM can assign to a transaction.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_transaction_state
    /// </summary>
    public enum TRANSACTION_STATE
    {
        /// <summary>
        /// The transaction's state is neither in doubt nor committed.
        /// </summary>
        TransactionStateNormal,

        /// <summary>
        /// The transaction's state is in doubt (that is, KTM cannot determine whether the transaction should be committed or rolled back). 
        /// A transaction that has been prepared enters the "in doubt" state if its superior transaction manager becomes unavailable.
        /// </summary>
        TransactionStateIndoubt,

        /// <summary>
        /// The transaction has been committed. Commit notifications might (or might not) have been delivered to all enlistments.
        /// </summary>
        TransactionStateCommittedNotify
    }
}
