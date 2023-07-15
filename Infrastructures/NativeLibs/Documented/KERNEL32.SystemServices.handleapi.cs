using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class KERNEL32
    {
        /*
         *
        138 (0x008a),  (0x), CloseHandle, 0x000250a0, None
        307 (0x0133),  (0x), DuplicateHandle, 0x000250b0, None
        616 (0x0268),  (0x), GetHandleInformation, 0x000250c0, None
        1342 (0x053e),  (0x), SetHandleInformation, 0x000250d0, None
         *
         */

        /// <summary>
        /// Closes an open object handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int CloseHandle(IntPtr hObject);

        /// <summary>
        /// Duplicates an object handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-duplicatehandle
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// A handle to the process with the handle to be duplicated.
        /// The handle must have the PROCESS_DUP_HANDLE access right.
        /// </param>
        /// <param name="hSourceHandle">
        /// The handle to be duplicated.
        /// This is an open object handle that is valid in the context of the source process.
        /// For a list of objects whose handles can be duplicated, see the following Remarks section.
        /// </param>
        /// <param name="hTargetProcessHandle"></param>
        /// <param name="lpTargetHandle"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="dwOptions"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle(
            IntPtr hSourceProcessHandle, 
            IntPtr hSourceHandle, 
            IntPtr hTargetProcessHandle,
            ref IntPtr lpTargetHandle,
            uint dwDesiredAccess, 
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
            DUPLICATE_HANDLE_OPTIONS dwOptions
            );

        /// <summary>
        /// Retrieves certain properties of an object handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-gethandleinformation
        /// </summary>
        /// <param name="hObject">A handle to an object whose information is to be retrieved.</param>
        /// <param name="lpdwFlags">
        /// A pointer to a variable that receives a set of bit flags that specify properties of the object handle or 0.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetHandleInformation(
            IntPtr hObject, 
            ref OBJECT_HANDLE_FLAGS lpdwFlags
            );

        /// <summary>
        /// Sets certain properties of an object handle.
        /// https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-sethandleinformation
        /// </summary>
        /// <param name="hObject">
        /// A handle to an object whose information is to be set.
        /// </param>
        /// <param name="dwMask">A mask that specifies the bit flags to be changed. Use the same constants shown in the description of dwFlags.</param>
        /// <param name="dwFlags">
        /// Set of bit flags that specifies properties of the object handle.
        /// This parameter can be 0 or one or more of the following values.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetHandleInformation(
            IntPtr hObject,
            uint dwMask,
            OBJECT_HANDLE_FLAGS dwFlags
        );
    }
}
