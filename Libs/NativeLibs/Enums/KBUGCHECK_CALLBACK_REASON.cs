using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KBUGCHECK_CALLBACK_REASON enumeration type specifies the situations in which a bug-check callback executes.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_kbugcheck_callback_reason
    /// </summary>
    public enum KBUGCHECK_CALLBACK_REASON
    {
        /// <summary>
        /// Reserved for system use. Do not use.
        /// </summary>
        KbCallbackInvalid,

        /// <summary>
        /// Reserved for system use. Do not use.
        /// </summary>
        KbCallbackReserved1,

        /// <summary>
        /// The callback function provides data to append to the secondary data area of the crash dump file 
        /// when the system issues a bug check. For more information about this type of callback, 
        /// see Implementing a KbCallbackSecondaryDumpData Callback Routine.
        /// </summary>
        KbCallbackSecondaryDumpData,

        /// <summary>
        /// Specifies that the system should call the callback function each time it writes data to a crash dump file. 
        /// Drivers for devices that monitor the system state can use this type of callback. 
        /// For more information about this type of callback, see Implementing a KbCallbackDumpIo Callback Routine.
        /// </summary>
        KbCallbackDumpIo,

        /// <summary>
        /// The callback function adds one or more pages of driver-specific data to the primary section of the crash dump file 
        /// when the operating system issues a bug check. 
        /// For more information about this type of callback, see Implementing a KbCallbackAddPages Callback Routine.
        /// </summary>
        KbCallbackAddPages,

        /// <summary>
        /// Specifies that the callback is executed to get the amount of data the driver wants to store in the dump file. 
        /// This enumeration value is supported in Windows Server 2008 and later versions of Windows.
        /// </summary>
        KbCallbackSecondaryMultiPartDumpData,

        /// <summary>
        /// The callback function removes one or more pages of driver-supplied data from the crash dump file. 
        /// For more information, see KBUGCHECK_REMOVE_PAGES.
        /// </summary>
        KbCallbackRemovePages,

        /// <summary>
        /// Specifies that the callback is executed to add virtual memory ranges the driver wants to preserve in the carved minidump file. 
        /// This enumeration value is supported starting in Windows 10, version 1809 and Windows Server 2019. 
        /// For more information about this type of callback, see Implementing a KbCallbackTriageDumpData Callback Routine.
        /// </summary>
        KbCallbackTriageDumpData,

        /// <summary>
        /// Reserved for system use. Do not use.
        /// </summary>
        KbCallbackReserved2
    }
}
