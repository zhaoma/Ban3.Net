using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_APPCONTAINER_INFORMATION structure specifies all the information in a token that is necessary for an app container.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_appcontainer_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_APPCONTAINER_INFORMATION
    {
        public IntPtr TokenAppContainer;

    }
}