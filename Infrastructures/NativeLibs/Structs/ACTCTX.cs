using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ACTCTX structure is used by the CreateActCtx function to create the activation context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACTCTXA
    {
        /// <summary>
        /// The size, in bytes, of this structure. This is used to determine the version of this structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Flags that indicate how the values included in this structure are to be used.
        /// </summary>
        public ActCtxFlag dwFlags;

        /// <summary>
        /// Null-terminated string specifying the path of the manifest file or PE image to be used to create the activation context. 
        /// If this path refers to an EXE or DLL file, the lpResourceName member is required.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpSource;

        /// <summary>
        /// Identifies the type of processor used. 
        /// Specifies the system's processor architecture.
        /// </summary>
        public ushort wProcessorArchitecture;

        /// <summary>
        /// Specifies the language manifest that should be used. The default is the current user's current UI language.
        /// If the requested language cannot be found, an approximation is searched for using the following order:
        /// The current user's specific language. For example, for US English (1033).
        /// The current user's primary language. For example, for English (9).
        /// The current system's specific language.
        /// The current system's primary language.
        /// A nonspecific worldwide language.Language neutral (0).
        /// </summary>
        public ushort wLangId;

        /// <summary>
        /// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the system-wide store.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpAssemblyDirectory;

        /// <summary>
        /// Pointer to a null-terminated string that contains the resource name to be loaded from the PE specified in hModule or lpSource. 
        /// If the resource name is an integer, set this member using MAKEINTRESOURCE. 
        /// This member is required if lpSource refers to an EXE or DLL.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpResourceName;

        /// <summary>
        /// The name of the current application. If the value of this member is set to null, 
        /// the name of the executable that launched the current process is used.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpApplicationName;

        /// <summary>
        /// Use this member rather than lpSource if you have already loaded a DLL 
        /// and wish to use it to create activation contexts rather than using a path in lpSource. 
        /// See lpResourceName for the rules of looking up resources in this module.
        /// </summary>
        public System.IntPtr hModule;
    }
    
    /// <summary>
    /// The ACTCTX structure is used by the CreateActCtx function to create the activation context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ACTCTXW
    {
        /// <summary>
        /// The size, in bytes, of this structure. This is used to determine the version of this structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Flags that indicate how the values included in this structure are to be used.
        /// </summary>
        public ActCtxFlag dwFlags;

        /// <summary>
        /// Null-terminated string specifying the path of the manifest file or PE image to be used to create the activation context. 
        /// If this path refers to an EXE or DLL file, the lpResourceName member is required.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string lpSource;

        /// <summary>
        /// Identifies the type of processor used. 
        /// Specifies the system's processor architecture.
        /// </summary>
        public ushort wProcessorArchitecture;

        /// <summary>
        /// Specifies the language manifest that should be used. The default is the current user's current UI language.
        /// If the requested language cannot be found, an approximation is searched for using the following order:
        /// The current user's specific language. For example, for US English (1033).
        /// The current user's primary language. For example, for English (9).
        /// The current system's specific language.
        /// The current system's primary language.
        /// A nonspecific worldwide language.Language neutral (0).
        /// </summary>
        public ushort wLangId;

        /// <summary>
        /// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the system-wide store.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string lpAssemblyDirectory;

        /// <summary>
        /// Pointer to a null-terminated string that contains the resource name to be loaded from the PE specified in hModule or lpSource. 
        /// If the resource name is an integer, set this member using MAKEINTRESOURCE. 
        /// This member is required if lpSource refers to an EXE or DLL.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string lpResourceName;

        /// <summary>
        /// The name of the current application. If the value of this member is set to null, 
        /// the name of the executable that launched the current process is used.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string lpApplicationName;

        /// <summary>
        /// Use this member rather than lpSource if you have already loaded a DLL 
        /// and wish to use it to create activation contexts rather than using a path in lpSource. 
        /// See lpResourceName for the rules of looking up resources in this module.
        /// </summary>
        public System.IntPtr hModule;
    }
}
