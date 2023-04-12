using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a mouse event passed to a WH_MOUSE hook procedure, MouseProc.
    /// This is an extension of the MOUSEHOOKSTRUCT structure that includes information about wheel movement or the use of the X button.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mousehookstructex
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEHOOKSTRUCTEX
    {
        public uint mouseData;
    }
}