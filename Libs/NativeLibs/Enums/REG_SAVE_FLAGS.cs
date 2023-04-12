﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum REG_SAVE_FLAGS:uint
    {
        /// <summary>
        /// The key or hive is saved in standard format. The standard format is the only format supported by Windows 2000.
        /// </summary>
        REG_STANDARD_FORMAT = 1,

        /// <summary>
        /// The key or hive is saved in the latest format. The latest format is supported starting with Windows XP. 
        /// After the key or hive is saved in this format, it cannot be loaded on an earlier system.
        /// </summary>
        REG_LATEST_FORMAT = 2,

        /// <summary>
        /// The hive is saved with no compression, for faster save operations. 
        /// The hKey parameter must specify the root of a hive under HKEY_LOCAL_MACHINE or HKEY_USERS. 
        /// For example, HKLM\SOFTWARE is the root of a hive.
        /// </summary>
        REG_NO_COMPRESSION = 4
    }
}
