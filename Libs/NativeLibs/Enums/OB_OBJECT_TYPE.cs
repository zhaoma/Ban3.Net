using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    [Flags]
    public enum OB_OBJECT_TYPE
    {
        /// <summary>
        /// for process handle operations
        /// </summary>
        PsProcessType,

        /// <summary>
        /// for thread handle operations
        /// </summary>
        PsThreadType,

        /// <summary>
        /// for desktop handle operations. 
        /// This value is supported in Windows 10 and not in the earlier versions of the operating system.
        /// </summary>
        ExDesktopObjectType
    }
}
