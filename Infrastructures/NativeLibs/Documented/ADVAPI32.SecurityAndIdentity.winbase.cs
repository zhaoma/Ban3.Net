using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    ///     Application Installation and Servicing
    ///     Application Recovery and Restart
    ///     Backup
    ///     Data Access and Storage
    ///     Data Exchange
    ///     Developer Notes
    ///     eventlogprov
    ///     Hardware Counter Profiling
    ///     Internationalization for Windows Applications
    ///     Menus and Other Resources
    ///     Operation Recorder
    ///     Remote Desktop Services
    ///     Security and Identity
    ///     System Services
    ///     Window Stations and Desktops
    ///     Windows and Messages
    /// This file is Security and Identity parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckandauditalarma
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1008 (0x03f0),  (0x), AccessCheckAndAuditAlarmA, 0x000460f0, None
        1011 (0x03f3),  (0x), AccessCheckByTypeAndAuditAlarmA, 0x00046200, None
        1014 (0x03f6),  (0x), AccessCheckByTypeResultListAndAuditAlarmA, 0x00046320, None
        1015 (0x03f7),  (0x), AccessCheckByTypeResultListAndAuditAlarmByHandleA, 0x00046440, None
        1028 (0x0404),  (0x), AddConditionalAce, 0x00048e20, None
        1326 (0x052e),  (0x), GetFileSecurityA, 0x00046560, None
        1418 (0x058a),  (0x), LogonUserA, 0x00048b80, None
        1419 (0x058b),  (0x), LogonUserExA, 0x00048cc0, None
        1421 (0x058d),  (0x), LogonUserExW, 0x00048d00, None
        1422 (0x058e),  (0x), LogonUserW, 0x00023f50, None
        1423 (0x058f),  (0x), LookupAccountNameA, 0x000465e0, None
        1424 (0x0590),  (0x), LookupAccountNameW, 0x0001f390, None
        1425 (0x0591),  (0x), LookupAccountSidA, 0x000469e0, None
        1426 (0x0592),  (0x), LookupAccountSidW, 0x0001ec60, None
        1427 (0x0593),  (0x), LookupPrivilegeDisplayNameA, 0x00046f60, None
        1428 (0x0594),  (0x), LookupPrivilegeDisplayNameW, 0x000470e0, None
        1429 (0x0595),  (0x), LookupPrivilegeNameA, 0x00047240, None
        1430 (0x0596),  (0x), LookupPrivilegeNameW, 0x00047370, None
        1431 (0x0597),  (0x), LookupPrivilegeValueA, 0x00024440, None
        1432 (0x0598),  (0x), LookupPrivilegeValueW, 0x00019fd0, None
        1523 (0x05f3),  (0x), ObjectCloseAuditAlarmA, 0x000474c0, None
        1525 (0x05f5),  (0x), ObjectDeleteAuditAlarmA, 0x00047520, None
        1527 (0x05f7),  (0x), ObjectOpenAuditAlarmA, 0x00047580, None
        1529 (0x05f9),  (0x), ObjectPrivilegeAuditAlarmA, 0x00047690, None
        1578 (0x062a),  (0x), PrivilegedServiceAuditAlarmA, 0x00047700, None
        1735 (0x06c7),  (0x), SetFileSecurityA, 0x000477a0, None

         */

        /// <summary>
        /// The AccessCheckAndAuditAlarm function determines whether a security descriptor grants a specified set of access rights to the client being impersonated by the calling thread.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckandauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="ObjectName"></param>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="GenericMapping"></param>
        /// <param name="ObjectCreation"></param>
        /// <param name="GrantedAccess"></param>
        /// <param name="AccessStatus"></param>
        /// <param name="pfGenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AccessCheckAndAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ObjectTypeName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ObjectName,
            IntPtr SecurityDescriptor,
            uint DesiredAccess,
            ref GENERIC_MAPPING GenericMapping,
            [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
            ref uint GrantedAccess,
            ref int AccessStatus,
            ref int pfGenerateOnClose
        );

        /// <summary>
        /// The AccessCheckByTypeAndAuditAlarm function determines whether a security descriptor grants a specified set of access rights to the client being impersonated by the calling thread.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckbytypeandauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="ObjectName"></param>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="PrincipalSelfSid"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="AuditType"></param>
        /// <param name="Flags"></param>
        /// <param name="ObjectTypeList"></param>
        /// <param name="ObjectTypeListLength"></param>
        /// <param name="GenericMapping"></param>
        /// <param name="ObjectCreation"></param>
        /// <param name="GrantedAccess"></param>
        /// <param name="AccessStatus"></param>
        /// <param name="pfGenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AccessCheckByTypeAndAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectTypeName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            uint DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            ref OBJECT_TYPE_LIST ObjectTypeList,
            uint ObjectTypeListLength,
            ref GENERIC_MAPPING GenericMapping,
            [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
            ref uint GrantedAccess,
            ref int AccessStatus,
            ref int pfGenerateOnClose
        );

        /// <summary>
        /// The AccessCheckByTypeResultListAndAuditAlarm function determines whether a security descriptor grants a specified set of access rights to the client being impersonated by the calling thread.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckbytyperesultlistandauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="ObjectName"></param>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="PrincipalSelfSid"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="AuditType"></param>
        /// <param name="Flags"></param>
        /// <param name="ObjectTypeList"></param>
        /// <param name="ObjectTypeListLength"></param>
        /// <param name="GenericMapping"></param>
        /// <param name="ObjectCreation"></param>
        /// <param name="GrantedAccess"></param>
        /// <param name="AccessStatusList"></param>
        /// <param name="pfGenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AccessCheckByTypeResultListAndAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectTypeName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            uint DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            ref OBJECT_TYPE_LIST ObjectTypeList,
            uint ObjectTypeListLength,
            ref GENERIC_MAPPING GenericMapping,
            [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
            ref uint GrantedAccess,
            ref uint AccessStatusList,
            ref int pfGenerateOnClose
        );

        /// <summary>
        /// The AccessCheckByTypeResultListAndAuditAlarmByHandle function determines whether a security descriptor grants a specified set of access rights to the client that the calling thread is impersonating.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-accesscheckbytyperesultlistandauditalarmbyhandlea
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ClientToken"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="ObjectName"></param>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="PrincipalSelfSid"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="AuditType"></param>
        /// <param name="Flags"></param>
        /// <param name="ObjectTypeList"></param>
        /// <param name="ObjectTypeListLength"></param>
        /// <param name="GenericMapping"></param>
        /// <param name="ObjectCreation"></param>
        /// <param name="GrantedAccess"></param>
        /// <param name="AccessStatusList"></param>
        /// <param name="pfGenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AccessCheckByTypeResultListAndAuditAlarmByHandleA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            IntPtr ClientToken,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectTypeName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            uint DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            ref OBJECT_TYPE_LIST ObjectTypeList,
            uint ObjectTypeListLength,
            ref GENERIC_MAPPING GenericMapping,
            [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
            ref uint GrantedAccess,
            ref uint AccessStatusList,
            ref int pfGenerateOnClose
        );

        /// <summary>
        /// The AddConditionalAce function adds a conditional access control entry (ACE) to the specified access control list (ACL).
        /// A conditional ACE specifies a logical condition that is evaluated during access checks.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-addconditionalace
        /// </summary>
        /// <param name="pAcl"></param>
        /// <param name="dwAceRevision"></param>
        /// <param name="AceFlags"></param>
        /// <param name="AceType"></param>
        /// <param name="AccessMask"></param>
        /// <param name="pSid"></param>
        /// <param name="ConditionStr"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddConditionalAce(
            ref ACL pAcl,
            uint dwAceRevision,
            uint AceFlags,
            byte AceType,
            uint AccessMask,
            IntPtr pSid,
            IntPtr ConditionStr,
            ref uint ReturnLength
        );

        /// <summary>
        /// The GetFileSecurity function obtains specified information about the security of a file or directory.
        /// The information obtained is constrained by the caller's access rights and privileges.
        /// The GetNamedSecurityInfo function provides functionality similar to GetFileSecurity for files as well as other types of objects.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getfilesecuritya
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="RequestedInformation"></param>
        /// <param name="pSecurityDescriptor"></param>
        /// <param name="nLength"></param>
        /// <param name="lpnLengthNeeded"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileSecurityA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpFileName,
            uint RequestedInformation,
            IntPtr pSecurityDescriptor,
            uint nLength,
            ref uint lpnLengthNeeded
        );

        /// <summary>
        /// The LogonUser function attempts to log a user on to the local computer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-logonusera
        /// </summary>
        /// <param name="lpszUsername"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUserA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszUsername,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDomain,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszPassword,
            uint dwLogonType,
            uint dwLogonProvider,
            ref IntPtr phToken
        );

        /// almost same as LogonUserA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUserW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszUsername,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszDomain,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszPassword,
            uint dwLogonType,
            uint dwLogonProvider,
            ref IntPtr phToken
        );

        /// <summary>
        /// The LogonUserEx function attempts to log a user on to the local computer.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-logonuserexa
        /// </summary>
        /// <param name="lpszUsername"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <param name="ppLogonSid"></param>
        /// <param name="ppProfileBuffer"></param>
        /// <param name="pdwProfileLength"></param>
        /// <param name="pQuotaLimits"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUserExA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszUsername,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszDomain,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpszPassword,
            uint dwLogonType,
            uint dwLogonProvider,
            ref IntPtr phToken,
            ref IntPtr ppLogonSid,
            ref IntPtr ppProfileBuffer,
            ref uint pdwProfileLength,
            ref QUOTA_LIMITS pQuotaLimits
        );

        /// almost same as LogonUserExA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUserExW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszUsername,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszDomain,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszPassword,
            uint dwLogonType,
            uint dwLogonProvider,
            ref IntPtr phToken,
            ref IntPtr ppLogonSid,
            ref IntPtr ppProfileBuffer,
            ref uint pdwProfileLength,
            ref QUOTA_LIMITS pQuotaLimits
        );

        /// <summary>
        /// The LookupAccountName function accepts the name of a system and an account as input.
        /// It retrieves a security identifier (SID) for the account and the name of the domain on which the account was found.
        /// The LsaLookupNames function can also retrieve computer accounts.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupaccountnamea
        /// </summary>
        /// <param name="lpSystemName"></param>
        /// <param name="lpAccountName"></param>
        /// <param name="Sid"></param>
        /// <param name="cbSid"></param>
        /// <param name="ReferencedDomainName"></param>
        /// <param name="cchReferencedDomainName"></param>
        /// <param name="peUse"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupAccountNameA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpAccountName,
            IntPtr Sid,
            ref uint cbSid,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ReferencedDomainName,
            ref uint cchReferencedDomainName,
            ref SID_NAME_USE peUse
        );

        /// almost same as LookupAccountNameA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupAccountNameW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpAccountName,
            IntPtr Sid,
            ref uint cbSid,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder ReferencedDomainName,
            ref uint cchReferencedDomainName,
            ref SID_NAME_USE peUse
        );

        /// <summary>
        /// The LookupAccountSid function accepts a security identifier (SID) as input.
        /// It retrieves the name of the account for this SID and the name of the first domain on which this SID is found.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupaccountsida
        /// </summary>
        /// <param name="lpSystemName"></param>
        /// <param name="Sid"></param>
        /// <param name="Name"></param>
        /// <param name="cchName"></param>
        /// <param name="ReferencedDomainName"></param>
        /// <param name="cchReferencedDomainName"></param>
        /// <param name="peUse"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupAccountSidA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpSystemName,
            IntPtr Sid,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder Name,
            ref uint cchName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ReferencedDomainName,
            ref uint cchReferencedDomainName,
            ref SID_NAME_USE peUse
        );

        /// almost same as LookupAccountSidA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupAccountSidW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpSystemName,
            IntPtr Sid,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Name,
            ref uint cchName,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder ReferencedDomainName,
            ref uint cchReferencedDomainName,
            ref SID_NAME_USE peUse
        );

        /// <summary>
        /// The LookupPrivilegeDisplayName function retrieves the display name that represents a specified privilege.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegedisplaynamea
        /// </summary>
        /// <param name="lpSystemName"></param>
        /// <param name="lpName"></param>
        /// <param name="lpDisplayName"></param>
        /// <param name="cchDisplayName"></param>
        /// <param name="lpLanguageId"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeDisplayNameA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpDisplayName,
            ref uint cchDisplayName,
            ref uint lpLanguageId
        );

        /// almost same as LookupPrivilegeDisplayNameA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeDisplayNameW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpName,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpDisplayName,
            ref uint cchDisplayName,
            ref uint lpLanguageId
        );

        /// <summary>
        /// The LookupPrivilegeName function retrieves the name that corresponds to the privilege represented on a specific system by a specified locally unique identifier (LUID).
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegenamea
        /// </summary>
        /// <param name="lpSystemName"></param>
        /// <param name="lpLuid"></param>
        /// <param name="lpName"></param>
        /// <param name="cchName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeNameA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpSystemName,
            ref LUID lpLuid,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpName,
            ref uint cchName
        );

        /// almost same as LookupPrivilegeNameA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeNameW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpSystemName,
            ref LUID lpLuid,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpName,
            ref uint cchName
        );

        /// <summary>
        /// The LookupPrivilegeValue function retrieves the locally unique identifier (LUID) used on a specified system to locally represent the specified privilege name.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lookupprivilegevaluea
        /// </summary>
        /// <param name="lpSystemName"></param>
        /// <param name="lpName"></param>
        /// <param name="lpLuid"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeValueA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpName,
            ref LUID lpLuid
        );

        /// almost same as LookupPrivilegeValueA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeValueW(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpSystemName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpName,
            ref LUID lpLuid
        );

        /// <summary>
        /// The ObjectCloseAuditAlarm function generates an audit message in the security event log when a handle to a private object is deleted.
        /// Alarms are not currently supported.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-objectcloseauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="GenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ObjectCloseAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [MarshalAs(UnmanagedType.Bool)] bool GenerateOnClose
        );

        /// <summary>
        /// The ObjectDeleteAuditAlarm function generates audit messages when an object is deleted.
        /// Alarms are not currently supported.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-objectdeleteauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="GenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ObjectDeleteAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [MarshalAs(UnmanagedType.Bool)] bool GenerateOnClose
        );

        /// <summary>
        /// The ObjectOpenAuditAlarm function generates audit messages when a client application attempts to gain access to an object or to create a new one.
        /// Alarms are not currently supported.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-objectopenauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="ObjectName"></param>
        /// <param name="pSecurityDescriptor"></param>
        /// <param name="ClientToken"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="GrantedAccess"></param>
        /// <param name="Privileges"></param>
        /// <param name="ObjectCreation"></param>
        /// <param name="AccessGranted"></param>
        /// <param name="GenerateOnClose"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ObjectOpenAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ObjectTypeName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder ObjectName,
            IntPtr pSecurityDescriptor,
            IntPtr ClientToken,
            uint DesiredAccess,
            uint GrantedAccess,
            ref PRIVILEGE_SET Privileges,
            [MarshalAs(UnmanagedType.Bool)] bool ObjectCreation,
            [MarshalAs(UnmanagedType.Bool)] bool AccessGranted,
            ref int GenerateOnClose
        );

        /// <summary>
        /// The ObjectPrivilegeAuditAlarm function generates an audit message in the security event log.
        /// A protected server can use this function to log attempts by a client to use a specified set of privileges with an open handle to a private object.
        /// Alarms are not currently supported.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-objectprivilegeauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="HandleId"></param>
        /// <param name="ClientToken"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="Privileges"></param>
        /// <param name="AccessGranted"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ObjectPrivilegeAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            IntPtr HandleId,
            IntPtr ClientToken,
            uint DesiredAccess,
            ref PRIVILEGE_SET Privileges,
            [MarshalAs(UnmanagedType.Bool)] bool AccessGranted
        );

        /// <summary>
        /// The PrivilegedServiceAuditAlarm function generates an audit message in the security event log.
        /// A protected server can use this function to log attempts by a client to use a specified set of privileges.
        /// Alarms are not currently supported.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-privilegedserviceauditalarma
        /// </summary>
        /// <param name="SubsystemName"></param>
        /// <param name="ServiceName"></param>
        /// <param name="ClientToken"></param>
        /// <param name="Privileges"></param>
        /// <param name="AccessGranted"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PrivilegedServiceAuditAlarmA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string SubsystemName,
            [In] [MarshalAs(UnmanagedType.LPStr)] string ServiceName,
            IntPtr ClientToken,
            ref PRIVILEGE_SET Privileges,
            [MarshalAs(UnmanagedType.Bool)] bool AccessGranted
        );

        /// <summary>
        /// The SetFileSecurity function sets the security of a file or directory object.
        /// This function is obsolete. Use the SetNamedSecurityInfo function instead.
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setfilesecuritya
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="SecurityInformation"></param>
        /// <param name="pSecurityDescriptor"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetFileSecurityA(
            [In] [MarshalAs(UnmanagedType.LPStr)] string lpFileName,
            uint SecurityInformation,
            IntPtr pSecurityDescriptor
        );
    }
}
