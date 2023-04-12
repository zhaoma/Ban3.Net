using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about the menu and first multiple-document interface (MDI) child window of an MDI client window.
    /// An application passes a pointer to this structure as the lpParam parameter of the CreateWindow function when creating an MDI client window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-clientcreatestruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLIENTCREATESTRUCT
    {
        /// <summary>
        /// A handle to the MDI application's window menu.
        /// An MDI application can retrieve this handle from the menu of the MDI frame window by using the GetSubMenu function.
        /// </summary>
        public System.IntPtr hWindowMenu;

        /// <summary>
        /// The child window identifier of the first MDI child window created.
        /// </summary>
        public uint idFirstChild;
    }
}