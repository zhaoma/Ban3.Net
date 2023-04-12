using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The REG_NOTIFY_CLASS enumeration type specifies the type of registry operation that the configuration manager is passing to a RegistryCallback routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_reg_notify_class
    /// </summary>
    public enum REG_NOTIFY_CLASS
    {
        /// <summary>
        /// Specifies that a thread is attempting to delete a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtDeleteKey,

        /// <summary>
        /// Specifies that a thread is attempting to delete a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value on Windows Server 2003 and later versions of the Windows operating system.
        /// </summary>
        RegNtPreDeleteKey,

        /// <summary>
        /// Specifies that a thread is attempting to set a value entry for a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtSetValueKey,

        /// <summary>
        /// Specifies that a thread is attempting to set a value entry for a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value on Windows Server 2003 and later versions of the Windows operating system.
        /// </summary>
        RegNtPreSetValueKey,

        /// <summary>
        /// Specifies that a thread is attempting to delete a value entry for a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtDeleteValueKey,

        /// <summary>
        /// Specifies that a thread is attempting to delete a value entry for a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value on Windows Server 2003 and later versions of the Windows operating system.
        /// </summary>
        RegNtPreDeleteValueKey,

        /// <summary>
        /// Specifies that a thread is attempting to set the metadata for a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtSetInformationKey,

        /// <summary>
        /// Specifies that a thread is attempting to set the metadata for a key. 
        /// This value indicates a pre-notification call to RegistryCallback.
        /// Use this value on Windows Server 2003 and later versions of the Windows operating system.
        /// </summary>
        RegNtPreSetInformationKey,

        /// <summary>
        /// Specifies that a thread is attempting to rename a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtRenameKey,

        /// <summary>
        /// Specifies that a thread is attempting to rename a key. 
        /// This value indicates a pre-notification call to RegistryCallback.
        /// Use this value on Windows Server 2003 and later versions of the Windows operating system.
        /// </summary>
        RegNtPreRenameKey,

        /// <summary>
        /// Specifies that a thread is attempting to enumerate a subkey of a key. 
        /// This value indicates a pre-notification call to RegistryCallback. 
        /// Use this value only on Windows XP.
        /// </summary>
        RegNtEnumerateKey,
        RegNtPreEnumerateKey,
        RegNtEnumerateValueKey,
        RegNtPreEnumerateValueKey,
        RegNtQueryKey,
        RegNtPreQueryKey,
        RegNtQueryValueKey,
        RegNtPreQueryValueKey,
        RegNtQueryMultipleValueKey,
        RegNtPreQueryMultipleValueKey,
        RegNtPreCreateKey,
        RegNtPostCreateKey,
        RegNtPreOpenKey,
        RegNtPostOpenKey,
        RegNtKeyHandleClose,
        RegNtPreKeyHandleClose,
        RegNtPostDeleteKey,
        RegNtPostSetValueKey,
        RegNtPostDeleteValueKey,
        RegNtPostSetInformationKey,
        RegNtPostRenameKey,
        RegNtPostEnumerateKey,
        RegNtPostEnumerateValueKey,
        RegNtPostQueryKey,
        RegNtPostQueryValueKey,
        RegNtPostQueryMultipleValueKey,
        RegNtPostKeyHandleClose,
        RegNtPreCreateKeyEx,
        RegNtPostCreateKeyEx,
        RegNtPreOpenKeyEx,
        RegNtPostOpenKeyEx,
        RegNtPreFlushKey,
        RegNtPostFlushKey,
        RegNtPreLoadKey,
        RegNtPostLoadKey,
        RegNtPreUnLoadKey,
        RegNtPostUnLoadKey,
        RegNtPreQueryKeySecurity,
        RegNtPostQueryKeySecurity,
        RegNtPreSetKeySecurity,
        RegNtPostSetKeySecurity,
        RegNtCallbackObjectContextCleanup,
        RegNtPreRestoreKey,
        RegNtPostRestoreKey,
        RegNtPreSaveKey,
        RegNtPostSaveKey,
        RegNtPreReplaceKey,
        RegNtPostReplaceKey,
        RegNtPreQueryKeyName,
        RegNtPostQueryKeyName,
        RegNtPreSaveMergedKey,
        RegNtPostSaveMergedKey,
        MaxRegNtNotifyClass
    }
}
