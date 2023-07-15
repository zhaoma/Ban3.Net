using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum REG_CREATEKEY_OPTIONS:ulong
    {
        /// <summary>
        /// If this flag is set, the function ignores the samDesired parameter and attempts 
        /// to open the key with the access required to backup or restore the key. 
        /// If the calling thread has the SE_BACKUP_NAME privilege enabled, 
        /// the key is opened with the ACCESS_SYSTEM_SECURITY and KEY_READ access rights. 
        /// If the calling thread has the SE_RESTORE_NAME privilege enabled, beginning with Windows Vista, 
        /// the key is opened with the ACCESS_SYSTEM_SECURITY, DELETE and KEY_WRITE access rights. 
        /// If both privileges are enabled, the key has the combined access rights for both privileges.
        /// </summary>
        REG_OPTION_BACKUP_RESTORE = 0x00000004L,

        /// <summary>
        /// This key is a symbolic link. The target path is assigned to the L"SymbolicLinkValue" value of the key. 
        /// The target path must be an absolute registry path.
        /// </summary>
        REG_OPTION_CREATE_LINK = 0x00000002L,

        /// <summary>
        /// This key is not volatile; this is the default. 
        /// The information is stored in a file and is preserved when the system is restarted. 
        /// The RegSaveKey function saves keys that are not volatile.
        /// </summary>
        REG_OPTION_NON_VOLATILE = 0x00000000L,

        /// <summary>
        /// All keys created by the function are volatile. 
        /// The information is stored in memory and is not preserved when the corresponding registry hive is unloaded. 
        /// For HKEY_LOCAL_MACHINE, this occurs only when the system initiates a full shutdown. For registry keys loaded by the RegLoadKey function, 
        /// this occurs when the corresponding RegUnLoadKey is performed. 
        /// The RegSaveKey function does not save volatile keys. This flag is ignored for keys that already exist.
        /// </summary>
        REG_OPTION_VOLATILE = 0x00000001L
    }
}
