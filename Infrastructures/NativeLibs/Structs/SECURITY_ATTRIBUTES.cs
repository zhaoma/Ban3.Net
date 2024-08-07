﻿using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SECURITY_ATTRIBUTES structure contains the security descriptor for an object 
    /// and specifies whether the handle retrieved by specifying this structure is inheritable. 
    /// This structure provides security settings for objects created by various functions, 
    /// such as CreateFile, CreatePipe, CreateProcess, RegCreateKeyEx, or RegSaveKeyEx.
    /// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa379560(v=vs.85)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        /*
         
            typedef struct _SECURITY_ATTRIBUTES {
              DWORD  nLength;
              LPVOID lpSecurityDescriptor;
              BOOL   bInheritHandle;
            } SECURITY_ATTRIBUTES, *PSECURITY_ATTRIBUTES, *LPSECURITY_ATTRIBUTES;
         
         */

        /// <summary>
        /// The size, in bytes, of this structure. 
        /// Set this value to the size of the SECURITY_ATTRIBUTES structure.
        /// </summary>
        public uint nLength;

        /// <summary>
        /// A pointer to a SECURITY_DESCRIPTOR structure that controls access to the object. 
        /// If the value of this member is NULL, 
        /// the object is assigned the default security descriptor associated with the access token of the calling process. 
        /// This is not the same as granting access to everyone by assigning a NULL discretionary access control list (DACL). 
        /// By default, the default DACL in the access token of a process allows access only to the user represented by the access token.
        /// </summary>
        public IntPtr lpSecurityDescriptor;

        /// <summary>
        /// A Boolean value that specifies whether the returned handle is inherited when a new process is created. 
        /// If this member is TRUE, the new process inherits the handle.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.Bool)]
        public bool bInheritHandle;
    }
}
