using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRANSACTION_OUTCOME enumeration defines the outcomes (results) that KTM can assign to a transaction.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_transaction_outcome
    /// </summary>
    public enum TRANSACTION_OUTCOME
    {
        /// <summary>
        /// The transaction has not yet been committed or rolled back.
        /// </summary>
        TransactionOutcomeUndetermined,

        /// <summary>
        /// The transaction has been committed.
        /// </summary>
        TransactionOutcomeCommitted,

        /// <summary>
        /// The transaction has been rolled back.
        /// </summary>
        TransactionOutcomeAborted
    }
}
