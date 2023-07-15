using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winuser.h Window Stations and Desktops parts
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closedesktop
    /// </summary>
    public static partial class USER32
    {
        /*
         *
        1589 (0x0635),  (0x), CloseDesktop, 0x00033bf0, None
        1593 (0x0639),  (0x), CloseWindowStation, 0x00033c00, None
        1607 (0x0647),  (0x), CreateDesktopA, 0x00089390, None
        1608 (0x0648),  (0x), CreateDesktopExA, 0x000893d0, None
        1609 (0x0649),  (0x), CreateDesktopExW, 0x0002c270, None
        1610 (0x064a),  (0x), CreateDesktopW, 0x0002c230, None
        1631 (0x065f),  (0x), CreateWindowStationA, 0x00089590, None
        1632 (0x0660),  (0x), CreateWindowStationW, 0x0001dad0, None
        1756 (0x06dc),  (0x), EnumDesktopWindows, 0x00021840, None
        1757 (0x06dd),  (0x), EnumDesktopsA, 0x00003430, None
        1758 (0x06de),  (0x), EnumDesktopsW, 0x00004f60, None
        1771 (0x06eb),  (0x), EnumWindowStationsA, 0x00003410, None
        1772 (0x06ec),  (0x), EnumWindowStationsW, 0x00004f40, None
        1935 (0x078f),  (0x), GetProcessWindowStation, 0x000342c0, None
        1965 (0x07ad),  (0x), GetThreadDesktop, 0x00034360, None
        1976 (0x07b8),  (0x), GetUserObjectInformationA, 0x0002c550, None
        1977 (0x07b9),  (0x), GetUserObjectInformationW, 0x000343b0, None
        2177 (0x0881),  (0x), OpenDesktopA, 0x0001b4f0, None
        2178 (0x0882),  (0x), OpenDesktopW, 0x0001a620, None
        2180 (0x0884),  (0x), OpenInputDesktop, 0x00034740, None
        2182 (0x0886),  (0x), OpenWindowStationA, 0x0001c520, None
        2183 (0x0887),  (0x), OpenWindowStationW, 0x0001b480, None
        2359 (0x0937),  (0x), SetProcessWindowStation, 0x00034d90, None
        2376 (0x0948),  (0x), SetThreadDesktop, 0x0002c210, None
        2381 (0x094d),  (0x), SetUserObjectInformationA, 0x00089fc0, None
        2382 (0x094e),  (0x), SetUserObjectInformationW, 0x0008a040, None
        2425 (0x0979),  (0x), SwitchDesktop, 0x0002cce0, None
         *
         */

        /// <summary>
        /// Closes an open handle to a desktop object.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closedesktop
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be closed.
        /// This can be a handle returned by the CreateDesktop, OpenDesktop, or OpenInputDesktop functions.
        /// Do not specify the handle returned by the GetThreadDesktop function.
        /// </param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop(
            IntPtr hDesktop
        );

        /// <summary>
        /// Closes an open window station handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closewindowstation
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station to be closed.
        /// This handle is returned by the CreateWindowStation or OpenWindowStation function.
        /// Do not specify the handle returned by the GetProcessWindowStation function.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseWindowStation(
            IntPtr hWinSta
        );

        /// <summary>
        /// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the SetProcessWindowStation function.
        /// To specify the size of the heap for the desktop, use the CreateDesktopEx function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdesktopa
        /// </summary>
        /// <param name="lpszDesktop"></param>
        /// <param name="lpszDevice"></param>
        /// <param name="pDevmode"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="lpsa"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateDesktopA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDesktop,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDevice,
            ref IntPtr pDevmode,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa
        );

        /// almost same as CreateDesktopA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateDesktopW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszDesktop,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszDevice,
            ref IntPtr pDevmode,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa
        );

        /// <summary>
        /// Creates a new desktop with the specified heap, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the SetProcessWindowStation function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdesktopexa
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters (\).</param>
        /// <param name="lpszDevice">This parameter is reserved and must be NULL.</param>
        /// <param name="pDevmode">This parameter is reserved and must be NULL.</param>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// DF_ALLOWOTHERACCOUNTHOOK=0x0001         Enables processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="dwDesiredAccess">The requested access to the desktop.</param>
        /// <param name="lpsa">
        /// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes.
        /// If lpsa is NULL, the handle cannot be inherited.
        /// The lpSecurityDescriptor member of the structure specifies a security descriptor for the new desktop.
        /// If this parameter is NULL, the desktop inherits its security descriptor from the parent window station.
        /// </param>
        /// <param name="ulHeapSize">The size of the desktop heap, in kilobytes.</param>
        /// <param name="pvoid">This parameter is reserved and must be NULL.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateDesktopExA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDesktop,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDevice,
            ref IntPtr pDevmode,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa,
            uint ulHeapSize,
            IntPtr pvoid
        );

        /// almost same as CreateDesktopExA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateDesktopExW(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDesktop,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDevice,
            ref IntPtr pDevmode,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa,
            uint ulHeapSize,
            IntPtr pvoid
        );

        /// <summary>
        /// Creates a window station object, associates it with the calling process, and assigns it to the current session.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowstationa
        /// </summary>
        /// <param name="lpwinsta">The name of the window station to be created.</param>
        /// <param name="dwFlags">
        /// If this parameter is CWF_CREATE_ONLY and the window station already exists, the call fails.
        /// If this flag is not specified and the window station already exists,
        /// the function succeeds and returns a new handle to the existing window station.
        /// Windows XP/2000:  This parameter is reserved and must be zero.
        /// </param>
        /// <param name="dwDesiredAccess">The type of access the returned handle has to the window station.</param>
        /// <param name="lpsa">
        /// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes.
        /// If lpsa is NULL, the handle cannot be inherited.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateWindowStationA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpwinsta,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa
        );

        /// almost same as CreateWindowStationA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateWindowStationW(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpwinsta,
            uint dwFlags,
            uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpsa
        );

        /// <summary>
        /// Enumerates all desktops associated with the specified window station of the calling process.
        /// The function passes the name of each desktop, in turn, to an application-defined callback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdesktopsa
        /// </summary>
        /// <param name="hwinsta">
        /// A handle to the window station whose desktops are to be enumerated.
        /// This handle is returned by the CreateWindowStation, GetProcessWindowStation, or OpenWindowStation function, and must have the WINSTA_ENUMDESKTOPS access right.
        /// For more information, see Window Station Security and Access Rights.
        /// If this parameter is NULL, the current window station is used.
        /// </param>
        /// <param name="lpEnumFunc">A pointer to an application-defined EnumDesktopProc callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopsA(
            IntPtr hwinsta,
            NAMEENUMPROCA lpEnumFunc,
            [MarshalAs(UnmanagedType.SysInt)] int lParam
        );

        /// almost same as EnumDesktopsA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopsW(
            IntPtr hwinsta,
            NAMEENUMPROCW lpEnumFunc,
            [MarshalAs(UnmanagedType.SysInt)] int lParam
        );

        /// <summary>
        /// Enumerates all top-level windows associated with the specified desktop.
        /// It passes the handle to each window, in turn, to an application-defined callback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdesktopwindows
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated.
        /// This handle is returned by the CreateDesktop, GetThreadDesktop, OpenDesktop, or OpenInputDesktop function, and must have the DESKTOP_READOBJECTS access right.
        /// For more information, see Desktop Security and Access Rights.
        /// If this parameter is NULL, the current desktop is used.
        /// </param>
        /// <param name="lpfn">A pointer to an application-defined EnumWindowsProc callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows(
            IntPtr hDesktop,
            WNDENUMPROC lpfn,
            [MarshalAs(UnmanagedType.SysInt)] int lParam
        );

        /// <summary>
        /// Enumerates all window stations in the current session.
        /// The function passes the name of each window station, in turn, to an application-defined callback function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumwindowstationsa
        /// </summary>
        /// <param name="lpEnumFunc">A pointer to an application-defined EnumWindowStationProc callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindowStationsA(
            NAMEENUMPROCA lpEnumFunc,
            [MarshalAs(UnmanagedType.SysInt)] int lParam
        );

        /// almost same as EnumWindowStationsA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindowStationsW(
            NAMEENUMPROCW lpEnumFunc,
            [MarshalAs(UnmanagedType.SysInt)] int lParam
        );

        /// <summary>
        /// Retrieves a handle to the current window station for the calling process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getprocesswindowstation
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetProcessWindowStation();

        /// <summary>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getthreaddesktop
        /// </summary>
        /// <param name="dwThreadId">The thread identifier. The GetCurrentThreadId and CreateProcess functions return thread identifiers.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetThreadDesktop(
            uint dwThreadId
        );

        /// <summary>
        /// Retrieves information about the specified window station or desktop object.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getuserobjectinformationa
        /// </summary>
        /// <param name="hObj">
        /// A handle to the window station or desktop object.
        /// This handle is returned by the CreateWindowStation, OpenWindowStation, CreateDesktop, or OpenDesktop function.
        /// </param>
        /// <param name="nIndex"></param>
        /// <param name="pvInfo"></param>
        /// <param name="nLength"></param>
        /// <param name="lpnLengthNeeded"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUserObjectInformationA(
            IntPtr hObj,
            USER_OBJECT_INDEX nIndex,
            IntPtr pvInfo,
            uint nLength,
            ref uint lpnLengthNeeded
        );

        /// almost same as GetUserObjectInformationA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUserObjectInformationW(
            IntPtr hObj,
            USER_OBJECT_INDEX nIndex,
            IntPtr pvInfo,
            uint nLength,
            ref uint lpnLengthNeeded
        );

        /// <summary>
        /// Opens the specified desktop object.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-opendesktopa
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be opened. Desktop names are case-insensitive.
        /// This desktop must belong to the current window station.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// DF_ALLOWOTHERACCOUNTHOOK=0x0001             Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="fInherit">
        /// If this value is TRUE, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">The access to the desktop.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenDesktopA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDesktop,
            uint dwFlags,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            uint dwDesiredAccess
        );

        /// almost same as OpenDesktopA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenDesktopW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszDesktop,
            uint dwFlags,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            uint dwDesiredAccess
        );

        /// <summary>
        /// Opens the desktop that receives user input.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openinputdesktop
        /// </summary>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// DF_ALLOWOTHERACCOUNTHOOK=0x0001             Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="fInherit">
        /// If this value is TRUE, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">The access to the desktop.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenInputDesktop(
            uint dwFlags,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            uint dwDesiredAccess
        );

        /// <summary>
        /// Opens the specified window station.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openwindowstationa
        /// </summary>
        /// <param name="lpszWinSta">
        /// The name of the window station to be opened. Window station names are case-insensitive.
        /// This window station must belong to the current session.
        /// </param>
        /// <param name="fInherit">
        /// If this value is TRUE, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">The access to the window station.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenWindowStationA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszWinSta,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            uint dwDesiredAccess
        );

        /// almost same as OpenWindowStationA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenWindowStationW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszWinSta,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            uint dwDesiredAccess
        );

        /// <summary>
        /// Assigns the specified window station to the calling process.
        /// This enables the process to access objects in the window station such as desktops, the clipboard, and global atoms.
        /// All subsequent operations on the window station use the access rights granted to hWinSta.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocesswindowstation
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station.
        /// This can be a handle returned by the CreateWindowStation, OpenWindowStation, or GetProcessWindowStation function.
        /// This window station must be associated with the current session.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProcessWindowStation(IntPtr hWinSta);

        /// <summary>
        /// Assigns the specified desktop to the calling thread.
        /// All subsequent operations on the desktop use the access rights granted to the desktop.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreaddesktop
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be assigned to the calling thread.
        /// This handle is returned by the CreateDesktop, GetThreadDesktop, OpenDesktop, or OpenInputDesktop function.
        /// This desktop must be associated with the current window station for the process.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetThreadDesktop(IntPtr hDesktop);

        /// <summary>
        /// Sets information about the specified window station or desktop object.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setuserobjectinformationa
        /// </summary>
        /// <param name="hObj">
        /// A handle to the window station, desktop object or a current process pseudo handle.
        /// This handle can be returned by the CreateWindowStation, OpenWindowStation, CreateDesktop, OpenDesktop or GetCurrentProcess function.
        /// </param>
        /// <param name="nIndex">
        /// The object information to be set.This parameter can be the following value.
        /// UOI_FLAGS=1
        /// UOI_TIMERPROC_EXCEPTION_SUPPRESSION=7
        /// </param>
        /// <param name="pvInfo">A pointer to a buffer containing the object information, or a BOOL.</param>
        /// <param name="nLength">The size of the information contained in the buffer pointed to by pvInfo, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetUserObjectInformationA(
            IntPtr hObj,
            USER_OBJECT_INDEX nIndex,
            IntPtr pvInfo,
            uint nLength
        );

        /// almost same as SetUserObjectInformationA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetUserObjectInformationW(
            IntPtr hObj,
            int nIndex,
            IntPtr pvInfo,
            uint nLength
        );

        /// <summary>
        /// Makes the specified desktop visible and activates it.
        /// This enables the desktop to receive input from the user.
        /// The calling process must have DESKTOP_SWITCHDESKTOP access to the desktop for the SwitchDesktop function to succeed.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-switchdesktop
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop. This handle is returned by the CreateDesktop and OpenDesktop functions.
        /// This desktop must be associated with the current window station for the process.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SwitchDesktop(
            IntPtr hDesktop
        );

        #region callback functions

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NAMEENUMPROCA(
            [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder param0,
            IntPtr param1
        );

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int NAMEENUMPROCW(
            [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder param0,
            IntPtr param1
        );

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int WNDENUMPROC(
            IntPtr param0,
            IntPtr param1
        );

        #endregion
    }
}