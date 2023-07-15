using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KTMOBJECT_TYPE enumeration identifies the types of objects that KTM supports.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_ktmobject_type
    /// </summary>
    public enum KTMOBJECT_TYPE
    {
        /// <summary>
        /// KTM transaction objects.
        /// </summary>
        KTMOBJECT_TRANSACTION,

        /// <summary>
        /// KTM transaction manager objects.
        /// </summary>
        KTMOBJECT_TRANSACTION_MANAGER,

        /// <summary>
        /// KTM resource manager objects.
        /// </summary>
        KTMOBJECT_RESOURCE_MANAGER,

        /// <summary>
        /// KTM enlistment objects.
        /// </summary>
        KTMOBJECT_ENLISTMENT,

        /// <summary>
        /// Invalid object type.
        /// </summary>
        KTMOBJECT_INVALID
    }
}
