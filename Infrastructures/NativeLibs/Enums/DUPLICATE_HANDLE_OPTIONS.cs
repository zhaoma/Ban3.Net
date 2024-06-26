﻿namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-duplicatehandle
    /// </summary>
    public enum DUPLICATE_HANDLE_OPTIONS : uint
    {
        Zero=0,

        /// <summary>
        /// Closes the source handle.
        /// This occurs regardless of any error status returned. 
        /// </summary>
        DUPLICATE_CLOSE_SOURCE = 0x00000001,

        /// <summary>
        /// Ignores the dwDesiredAccess parameter.
        /// The duplicate handle has the same access as the source handle. 
        /// </summary>
        DUPLICATE_SAME_ACCESS = 0x00000002
    }
}