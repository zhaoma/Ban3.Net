﻿using System;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    [Flags]
    public enum RegNotifyFiltercs:ulong
    {
        /// <summary>
        /// Notify the caller if a subkey is added or deleted.
        /// </summary>
        REG_NOTIFY_CHANGE_NAME = 0x00000001L,

        /// <summary>
        /// Notify the caller of changes to the attributes of the key, such as the security descriptor information.
        /// </summary>
        REG_NOTIFY_CHANGE_ATTRIBUTES = 0x00000002L,

        /// <summary>
        /// Notify the caller of changes to a value of the key. This can include adding or deleting a value, or changing an existing value.
        /// </summary>
        REG_NOTIFY_CHANGE_LAST_SET = 0x00000004L,

        /// <summary>
        /// Notify the caller of changes to the security descriptor of the key.
        /// </summary>
        REG_NOTIFY_CHANGE_SECURITY = 0x00000008L,

        /// <summary>
        /// Indicates that the lifetime of the registration must not be tied to the lifetime of the thread issuing the RegNotifyChangeKeyValue call.
        /// Note  This flag value is only supported in Windows 8 and later.
        /// </summary>
        REG_NOTIFY_THREAD_AGNOSTIC = 0x10000000L
    }
}
