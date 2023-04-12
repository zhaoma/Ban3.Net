using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winuser.h
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-addclipboardformatlistener
    /// </summary>
    public static partial class USER32
    {
        /*
         
        1505 (0x05e1),  (0x), AddClipboardFormatListener, 0x0002cfa0, None
        1541 (0x0605),  (0x), ChangeClipboardChain, 0x000871a0, None
        1588 (0x0634),  (0x), CloseClipboard, 0x0002c9c0, None
        1601 (0x0641),  (0x), CountClipboardFormats, 0x0002bb80, None
        1739 (0x06cb),  (0x), EmptyClipboard, 0x00032610, None
        1755 (0x06db),  (0x), EnumClipboardFormats, 0x000320c0, None
        1817 (0x0719),  (0x), GetClipboardData, 0x0002b430, None
        1818 (0x071a),  (0x), GetClipboardFormatNameA, 0x00085f20, None
        1819 (0x071b),  (0x), GetClipboardFormatNameW, 0x0002c960, None
        1820 (0x071c),  (0x), GetClipboardOwner, 0x0002cd90, None
        1821 (0x071d),  (0x), GetClipboardSequenceNumber, 0x0002c7e0, None
        1822 (0x071e),  (0x), GetClipboardViewer, 0x00087280, None
        1906 (0x0772),  (0x), GetOpenClipboardWindow, 0x0002cd20, None
        1932 (0x078c),  (0x), GetPriorityClipboardFormat, 0x000872a0, None
        1975 (0x07b7),  (0x), GetUpdatedClipboardFormats, 0x000872c0, None
        2066 (0x0812),  (0x), IsClipboardFormatAvailable, 0x000235c0, None
        2176 (0x0880),  (0x), OpenClipboard, 0x0002b970, None
        2243 (0x08c3),  (0x), RegisterClipboardFormatA, 0x00003140, None
        2244 (0x08c4),  (0x), RegisterClipboardFormatW, 0x00026c50, None
        2273 (0x08e1),  (0x), RemoveClipboardFormatListener, 0x0002cf80, None
        2310 (0x0906),  (0x), SetClipboardData, 0x00030090, None
        2311 (0x0907),  (0x), SetClipboardViewer, 0x00032590, None
         
         */

        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-addclipboardformatlistener
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be placed in the clipboard format listener list.
        /// </param>
        /// <returns>Returns TRUE if successful, FALSE otherwise. Call GetLastError for additional details.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(
            IntPtr hwnd
        );

        /// <summary>
        /// Removes a specified window from the chain of clipboard viewers.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changeclipboardchain
        /// </summary>
        /// <param name="hWndRemove">
        /// A handle to the window to be removed from the chain. 
        /// The handle must have been passed to the SetClipboardViewer function.
        /// </param>
        /// <param name="hWndNewNext">
        /// A handle to the window that follows the hWndRemove window in the clipboard viewer chain. 
        /// (This is the handle returned by SetClipboardViewer, 
        /// unless the sequence was changed in response to a WM_CHANGECBCHAIN message.)
        /// </param>
        /// <returns>
        /// The return value indicates the result of passing the WM_CHANGECBCHAIN message to the windows in the clipboard viewer chain.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeClipboardChain(
            IntPtr hWndRemove,
            IntPtr hWndNewNext
        );

        /// <summary>
        /// Closes the clipboard.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closeclipboard
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseClipboard();

        /// <summary>
        /// Retrieves the number of different data formats currently on the clipboard.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-countclipboardformats
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the number of different data formats currently on the clipboard.
        /// If the function fails, the return value is zero. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int CountClipboardFormats();

        /// <summary>
        /// Empties the clipboard and frees handles to data in the clipboard. 
        /// The function then assigns ownership of the clipboard 
        /// to the window that currently has the clipboard open.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-emptyclipboard
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EmptyClipboard();

        /// <summary>
        /// Enumerates the data formats currently available on the clipboard.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumclipboardformats
        /// </summary>
        /// <param name="format">
        /// A clipboard format that is known to be available.
        /// To start an enumeration of clipboard formats, set format to zero.
        /// When format is zero, the function retrieves the first available clipboard format.
        /// For subsequent calls during an enumeration, 
        /// set format to the result of the previous EnumClipboardFormats call.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the clipboard format that follows the specified format, namely the next available clipboard format.
        /// If the function fails, the return value is zero. 
        /// To get extended error information, call GetLastError. If the clipboard is not open, the function fails.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint EnumClipboardFormats(
            uint format
            );

        /// <summary>
        /// Retrieves data from the clipboard in a specified format. 
        /// The clipboard must have been opened previously.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboarddata
        /// </summary>
        /// <param name="format">
        /// A clipboard format.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a clipboard object in the specified format.
        /// If the function fails, the return value is NULL. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetClipboardData(
            uint format
            );

        /// <summary>
        /// Retrieves from the clipboard the name of the specified registered format. 
        /// The function copies the name to the specified buffer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardformatnamea
        /// </summary>
        /// <param name="format">The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</param>
        /// <param name="lpszFormatName">The buffer that is to receive the format name.</param>
        /// <param name="cchMaxCount">
        /// The maximum length, in characters, of the string to be copied to the buffer. 
        /// If the name exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the string copied to the buffer.
        /// If the function fails, the return value is zero, indicating that the requested format does not exist or is predefined. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int GetClipboardFormatNameA(
           uint format, 
           [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszFormatName, 
           int cchMaxCount
           );

        /// same as GetClipboardFormatNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern int GetClipboardFormatNameW(
           uint format,
           [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszFormatName,
           int cchMaxCount
           );

        /// <summary>
        /// Retrieves the window handle of the current owner of the clipboard.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardowner
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that owns the clipboard.
        /// If the clipboard is not owned, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetClipboardOwner();

        /// <summary>
        /// Retrieves the clipboard sequence number for the current window station.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardsequencenumber
        /// </summary>
        /// <returns>
        /// The return value is the clipboard sequence number. 
        /// If you do not have WINSTA_ACCESSCLIPBOARD access to the window station, the function returns zero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetClipboardSequenceNumber();

        /// <summary>
        /// Retrieves the handle to the first window in the clipboard viewer chain.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipboardviewer
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the first window in the clipboard viewer chain.
        /// If there is no clipboard viewer, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetClipboardViewer();

        /// <summary>
        /// Retrieves the handle to the window that currently has the clipboard open.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getopenclipboardwindow
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that has the clipboard open. 
        /// If no window has the clipboard open, the return value is NULL. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        /// <summary>
        /// Retrieves the first available clipboard format in the specified list.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpriorityclipboardformat
        /// </summary>
        /// <param name="paFormatPriorityList">The clipboard formats, in priority order.</param>
        /// <param name="cFormats">
        /// The number of entries in the paFormatPriorityList array. 
        /// This value must not be greater than the number of entries in the list.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the first clipboard format in the list for which data is available. 
        /// If the clipboard is empty, the return value is NULL. 
        /// If the clipboard contains data, but not in any of the specified formats, the return value is –1. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int GetPriorityClipboardFormat(
            ref uint paFormatPriorityList, 
            int cFormats
            );

        /// <summary>
        /// Retrieves the currently supported clipboard formats.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getupdatedclipboardformats
        /// </summary>
        /// <param name="lpuiFormats">An array of clipboard formats.</param>
        /// <param name="cFormats">The number of entries in the array pointed to by lpuiFormats.</param>
        /// <param name="pcFormatsOut">The actual number of clipboard formats in the array pointed to by lpuiFormats.</param>
        /// <returns>
        /// The function returns TRUE if successful; otherwise, FALSE. 
        /// Call GetLastError for additional details.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUpdatedClipboardFormats(
            ref uint lpuiFormats, 
            uint cFormats, 
            ref uint pcFormatsOut
            );

        /// <summary>
        /// Determines whether the clipboard contains data in the specified format.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isclipboardformatavailable
        /// </summary>
        /// <param name="format">A standard or registered clipboard format.</param>
        /// <returns>
        /// If the clipboard format is available, the return value is nonzero.
        /// If the clipboard format is not available, the return value is zero.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsClipboardFormatAvailable(
            uint format
            );

        /// <summary>
        /// Opens the clipboard for examination and prevents other applications from modifying the clipboard content.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openclipboard
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be associated with the open clipboard. 
        /// If this parameter is NULL, the open clipboard is associated with the current task.
        /// </param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenClipboard(
                IntPtr hWndNewOwner
            );

        /// <summary>
        /// Registers a new clipboard format. This format can then be used as a valid clipboard format.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerclipboardformata
        /// </summary>
        /// <param name="lpszFormat">
        /// The name of the new format.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the registered clipboard format.
        /// If the function fails, the return value is zero. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegisterClipboardFormatA(
               [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszFormat
           );

        /// same as RegisterClipboardFormatA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RegisterClipboardFormatW(
               [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszFormat
           );

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-removeclipboardformatlistener
        /// </summary>
        /// <param name="hwnd">A handle to the window to remove from the clipboard format listener list.</param>
        /// <returns>Returns TRUE if successful, FALSE otherwise. Call GetLastError for additional details.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveClipboardFormatListener(
                IntPtr hwnd
            );

        /// <summary>
        /// Places data on the clipboard in a specified clipboard format.
        /// The window must be the current clipboard owner, and the application must have called the OpenClipboard function.
        /// (When responding to the WM_RENDERFORMAT message, the clipboard owner must not call OpenClipboard before calling SetClipboardData.)
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclipboarddata
        /// </summary>
        /// <param name="uFormat"></param>
        /// <param name="hMem"></param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the data.
        /// If the function fails, the return value is NULL. 
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr SetClipboardData(
            uint uFormat,
            IntPtr hMem
            );

        /// <summary>
        /// Adds the specified window to the chain of clipboard viewers. 
        /// Clipboard viewer windows receive a WM_DRAWCLIPBOARD message whenever the content of the clipboard changes. 
        /// This function is used for backward compatibility with earlier versions of Windows.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setclipboardviewer
        /// </summary>
        /// <param name="hWndNewViewer"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr SetClipboardViewer(
            IntPtr hWndNewViewer
            );
    }
}
