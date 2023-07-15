using System;
using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.CompilerServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// This header is used by Security and Identity.
    /// https://learn.microsoft.com/en-us/windows/win32/api/sddl/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
	
        1122 (0x0462),  (0x), ConvertSecurityDescriptorToStringSecurityDescriptorA, 0x00049630, None
        1123 (0x0463),  (0x), ConvertSecurityDescriptorToStringSecurityDescriptorW, 0x00049700, None
        1124 (0x0464),  (0x), ConvertSidToStringSidA, 0x0001e680, None
        1125 (0x0465),  (0x), ConvertSidToStringSidW, 0x0001e490, None
        1130 (0x046a),  (0x), ConvertStringSecurityDescriptorToSecurityDescriptorA, 0x00024720, None
        1131 (0x046b),  (0x), ConvertStringSecurityDescriptorToSecurityDescriptorW, 0x000186a0, None
        1132 (0x046c),  (0x), ConvertStringSidToSidA, 0x000499c0, None
        1133 (0x046d),  (0x), ConvertStringSidToSidW, 0x000198a0, None
	
	    */

        /// <summary>
        /// The ConvertSecurityDescriptorToStringSecurityDescriptor function converts a security descriptor to a string format.
        /// https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertsecuritydescriptortostringsecuritydescriptora
        /// </summary>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="RequestedStringSDRevision"></param>
        /// <param name="SecurityInformation"></param>
        /// <param name="StringSecurityDescriptor">
	    /// [out] LPSTR *StringSecurityDescriptor,
	    /// </param>
        /// <param name="StringSecurityDescriptorLen"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertSecurityDescriptorToStringSecurityDescriptorA(
  IntPtr SecurityDescriptor,
  uint RequestedStringSDRevision,
   SECURITY_INFORMATION SecurityInformation,
  [MarshalAs(UnmanagedType.LPStr)] StringBuilder StringSecurityDescriptor,
 ref ulong StringSecurityDescriptorLen
);

        ///almost same as ConvertSecurityDescriptorToStringSecurityDescriptorA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertSecurityDescriptorToStringSecurityDescriptorW(
  IntPtr SecurityDescriptor,
  uint RequestedStringSDRevision,
   SECURITY_INFORMATION SecurityInformation,
  [MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringSecurityDescriptor,
 ref ulong StringSecurityDescriptorLen
);

        /// <summary>
        /// The ConvertSidToStringSid function converts a security identifier (SID) to a string format suitable for display, storage, or transmission.
        /// https://learn.microsoft.com/en-us/windows/win32/api/sddl/nf-sddl-convertsidtostringsida
        /// </summary>
        /// <param name="Sid">A pointer to the SID structure to be converted.</param>
        /// <param name="StringSid">
	    /// A pointer to a variable that receives a pointer to a null-terminated SID string.
	    /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertSidToStringSidA(
 IntPtr Sid,
  [MarshalAs(UnmanagedType.LPStr)] StringBuilder StringSid
);

        /// amost same as ConvertSidToStringSidA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertSidToStringSidW(
  IntPtr Sid,
  [MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringSid
);

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="StringSecurityDescriptor"></param>
        /// <param name="StringSDRevision"></param>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="SecurityDescriptorSize"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertStringSecurityDescriptorToSecurityDescriptorA(
  [MarshalAs(UnmanagedType.LPStr)] StringBuilder StringSecurityDescriptor,
 uint StringSDRevision,
 ref IntPtr SecurityDescriptor,
 ref ulong SecurityDescriptorSize
);

        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertStringSecurityDescriptorToSecurityDescriptorW(
  [MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringSecurityDescriptor,
 uint  StringSDRevision,
 ref IntPtr SecurityDescriptor,
 ref ulong SecurityDescriptorSize
);

        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertStringSidToSidA(
[MarshalAs(UnmanagedType.LPStr)] StringBuilder StringSid,
ref IntPtr Sid
);

        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertStringSidToSidW(
 [MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringSid,
ref IntPtr Sid
);

    }
}

