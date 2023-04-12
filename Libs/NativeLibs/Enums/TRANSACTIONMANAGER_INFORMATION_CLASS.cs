using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRANSACTIONMANAGER_INFORMATION_CLASS enumeration specifies the type of information that the ZwQueryInformationTransactionManager routine can retrieve for a transaction manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_transactionmanager_information_class
    /// </summary>
    public enum TRANSACTIONMANAGER_INFORMATION_CLASS
    {
        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTIONMANAGER_BASIC_INFORMATION structure.
        /// </summary>
        TransactionManagerBasicInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTIONMANAGER_LOG_INFORMATION structure.
        /// </summary>
        TransactionManagerLogInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTIONMANAGER_LOGPATH_INFORMATION structure.
        /// </summary>
        TransactionManagerLogPathInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTIONMANAGER_RECOVERY_INFORMATION structure.
        /// </summary>
        TransactionManagerRecoveryInformation
    }
}
