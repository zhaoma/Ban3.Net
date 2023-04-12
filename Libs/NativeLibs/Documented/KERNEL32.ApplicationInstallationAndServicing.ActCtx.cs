using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is Application Installation and Servicing parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-actctxa
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        3 (0x0003),  (0x), ActivateActCtx, 0x00020840, None
        4 (0x0004),  (0x), ActivateActCtxWorker, 0x0001bed0, None
        13 (0x000d),  (0x), AddRefActCtx, 0x00022a30, None
        14 (0x000e),  (0x), AddRefActCtxWorker, 0x0001ea80, None
        179 (0x00b3),  (0x), CreateActCtxA, 0x00022380, None
        180 (0x00b4),  (0x), CreateActCtxW, 0x00021950, None
        181 (0x00b5),  (0x), CreateActCtxWWorker, 0x000137b0, None
        263 (0x0107),  (0x), DeactivateActCtx, 0x00020860, None
        264 (0x0108),  (0x), DeactivateActCtxWorker, 0x0001c010, None
        376 (0x0178),  (0x), FindActCtxSectionGuid, 0x0001c450, None
        377 (0x0179),  (0x), FindActCtxSectionGuidWorker, 0x00012f90, None
        378 (0x017a),  (0x), FindActCtxSectionStringA, 0x00066e50, None
        379 (0x017b),  (0x), FindActCtxSectionStringW, 0x000218c0, None
        380 (0x017c),  (0x), FindActCtxSectionStringWWorker, 0x000132b0, None
        533 (0x0215),  (0x), GetCurrentActCtx, 0x00022740, None
        534 (0x0216),  (0x), GetCurrentActCtxWorker, 0x0001cea0, None
        1093 (0x0445),  (0x), QueryActCtxSettingsW, 0x0003c3e0, None
        1094 (0x0446),  (0x), QueryActCtxSettingsWWorker, 0x00012b70, None
        1095 (0x0447),  (0x), QueryActCtxW, 0x0001e760, None
        1096 (0x0448),  (0x), QueryActCtxWWorker, 0x000124d0, None
        1205 (0x04b5),  (0x), ReleaseActCtx, 0x000219e0, None
        1206 (0x04b6),  (0x), ReleaseActCtxWorker, 0x0001dfd0, None
        1589 (0x0635),  (0x), ZombifyActCtx, 0x0003d360, None
        1590 (0x0636),  (0x), ZombifyActCtxWorker, 0x00044410, None

         */


        /// <summary>
        /// activates the specified activation context. 
        /// It does this by pushing the specified activation context to the top of the activation stack. 
        /// The specified activation context is thus associated with the current thread and any appropriate side-by-side API functions.
        /// </summary>
        /// <param name="hActCtx">Handle to an ACTCTX structure that contains information on the activation context that is to be made active.</param>
        /// <param name="lpCookie"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ActivateActCtx(
            IntPtr hActCtx,
            out IntPtr lpCookie);

        /// <summary>
        /// The AddRefActCtx function increments the reference count of the specified activation context.
        /// </summary>
        /// <param name="hActCtx">Handle to an ACTCTX structure that contains information on the activation context for which the reference count is to be incremented.</param>
        /// <param name=""></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern void AddRefActCtx(
            IntPtr hActCtx
            );

        /// <summary>
        /// The CreateActCtx function creates an activation context.
        /// </summary>
        /// <param name="hActCtx">Pointer to an ACTCTX structure that contains information about the activation context to be created.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateActCtx(
            ref IntPtr hActCtx
            );

        /// <summary>
        /// The DeactivateActCtx function deactivates the activation context corresponding to the specified cookie.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-deactivateactctx
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="ulCookie"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool DeactivateActCtx(
            int dwFlags,
            IntPtr ulCookie
            );

        /// <summary>
        /// The FindActCtxSectionGuid function retrieves information on a specific GUID 
        /// in the current activation context and returns a ACTCTX_SECTION_KEYED_DATA structure.
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="lpExtensionGuid"></param>
        /// <param name="ulSectionId"></param>
        /// <param name="lpGuidToFind"></param>
        /// <param name="ReturnedData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool FindActCtxSectionGuid(
            int dwFlags,
            string lpExtensionGuid,
            int ulSectionId,
            string lpGuidToFind,
            ref ACTCTX_SECTION_KEYED_DATA ReturnedData
            );

        /// <summary>
        /// The FindActCtxSectionString function retrieves information on a specific string 
        /// in the current activation context and returns a ACTCTX_SECTION_KEYED_DATA structure.
        /// </summary>
        /// <param name="dwFlags">
        /// Flags that determine how this function is to operate. 
        /// Only the following flag is currently defined.
        /// </param>
        /// <param name="lpExtensionGuid"></param>
        /// <param name="ulSectionId"></param>
        /// <param name="lpStringToFind"></param>
        /// <param name="ReturnedData"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool FindActCtxSectionString(
            int dwFlags,
            string lpExtensionGuid,
            int ulSectionId,
            string lpStringToFind,
            ref ACTCTX_SECTION_KEYED_DATA ReturnedData
            );

        /// <summary>
        /// The GetCurrentActCtx function returns the handle to the active activation context of the calling thread.
        /// </summary>
        /// <param name="lphActCtx">
        /// Pointer to the returned ACTCTX structure that contains information on the active activation context.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns TRUE. Otherwise, it returns FALSE.
        /// This function sets errors that can be retrieved by calling GetLastError. 
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool GetCurrentActCtx(
            ref IntPtr lphActCtx
            );

        /// <summary>
        /// The QueryActCtxSettingsW function specifies the activation context, and the namespace and name of the attribute that is to be queried.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-queryactctxsettingsw
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="hActCtx"></param>
        /// <param name="settingsNameSpace"></param>
        /// <param name="settingName"></param>
        /// <param name="pvBuffer"></param>
        /// <param name="dwBuffer"></param>
        /// <param name="pdwWrittenOrRequired"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool QueryActCtxSettings(
            int dwFlags,
            IntPtr hActCtx,
            string settingsNameSpace,
            string settingName,
            ref byte[] pvBuffer,
            int dwBuffer,
            ref int pdwWrittenOrRequired
            );

        /// <summary>
        /// The QueryActCtxW function queries the activation context.
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="hActCtx"></param>
        /// <param name="pvSubInstance"></param>
        /// <param name="pvBuffer"></param>
        /// <param name="cbBuffer"></param>
        /// <param name="pcbWrittenOrRequired"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool QueryActCtx(
            int dwFlags,
            IntPtr hActCtx,
            IntPtr pvSubInstance,
            ref byte[] pvBuffer,
            int cbBuffer,
            ref int pcbWrittenOrRequired
            );

        /// <summary>
        /// The ReleaseActCtx function decrements the reference count of the specified activation context.
        /// </summary>
        /// <param name="hActCtx"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void ReleaseActCtx(
            ref IntPtr hActCtx
            );


        /// <summary>
        /// The ZombifyActCtx function deactivates the specified activation context, but does not deallocate it.
        /// </summary>
        /// <param name="hActCtx">
        /// Handle to the activation context that is to be deactivated.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns TRUE. 
        /// If a null handle is passed in the hActCtx parameter, NULL_INVALID_PARAMETER will be returned. 
        /// Otherwise, it returns FALSE.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool ZombifyActCtx(
            ref IntPtr hActCtx
            );
    }
}