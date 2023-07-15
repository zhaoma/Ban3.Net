using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum RegRestoreFlags:ulong
    {
        /// <summary>
        /// If specified, the restore operation is executed even if open handles exist at or beneath the location 
        /// in the registry hierarchy to which the hKey parameter points.
        /// </summary>
        REG_FORCE_RESTORE=0x00000008L,

        /// <summary>
        /// If specified, a new, volatile (memory only) set of registry information, 
        /// or hive, is created.If REG_WHOLE_HIVE_VOLATILE is specified, 
        /// the key identified by the hKey parameter must be either the HKEY_USERS or HKEY_LOCAL_MACHINE value.
        /// </summary>
        REG_WHOLE_HIVE_VOLATILE=0x00000001L
    }
}
