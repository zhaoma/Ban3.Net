using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The ENLISTMENT_INFORMATION_CLASS enumeration identifies the type of information 
    /// that the ZwSetInformationEnlistment routine can set and that the ZwQueryInformationEnlistment 
    /// routine can retrieve for an enlistment object.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_enlistment_information_class
    /// </summary>
    public enum ENLISTMENT_INFORMATION_CLASS
    {
        /// <summary>
        /// Information about an enlistment object is stored in an ENLISTMENT_BASIC_INFORMATION structure.
        /// </summary>
        EnlistmentBasicInformation,

        /// <summary>
        /// A resource manager is setting or obtaining customized recovery information for an enlistment.
        /// To learn more about recovery information, see ZwSetInformationEnlistment.
        /// </summary>
        EnlistmentRecoveryInformation,

        /// <summary>
        /// Information about an enlistment object is stored in an ENLISTMENT_CRM_INFORMATION structure.
        /// </summary>
        EnlistmentCrmInformation
    }
}
