using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRANSACTION_INFORMATION_CLASS enumeration specifies the type of information that ZwSetInformationTransaction can set and ZwQueryInformationTransaction can retrieve for a transaction manager object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_transaction_information_class
    /// </summary>
    public enum TRANSACTION_INFORMATION_CLASS
    {
        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTION_BASIC_INFORMATION structure.
        /// </summary>
        TransactionBasicInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTION_PROPERTIES_INFORMATION structure.
        /// </summary>
        TransactionPropertiesInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTION_ENLISTMENTS_INFORMATION structure.
        /// </summary>
        TransactionEnlistmentInformation,

        /// <summary>
        /// Information about a transaction manager object is stored in a TRANSACTION_SUPERIOR_ENLISTMENT_INFORMATION structure.
        /// </summary>
        TransactionSuperiorEnlistmentInformation
    }
}
