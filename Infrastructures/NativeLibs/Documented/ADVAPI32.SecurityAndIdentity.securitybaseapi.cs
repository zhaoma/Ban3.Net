using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// securitybaseapi.h This header is used by multiple technologies.
    ///     Event Tracing
    ///     Security and Identity
    /// This file is Security and Identity parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/
    /// https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-accesscheck
    /// </summary>
    public static partial class ADVAPI32
    {
        /*

        1007 (0x03ef),  (0x), AccessCheck, 0x00034160, None
        1009 (0x03f1),  (0x), AccessCheckAndAuditAlarmW, 0x000340a0, None
        1010 (0x03f2),  (0x), AccessCheckByType, 0x00034140, None
        1012 (0x03f4),  (0x), AccessCheckByTypeAndAuditAlarmW, 0x000340c0, None
        1013 (0x03f5),  (0x), AccessCheckByTypeResultList, 0x00034120, None
        1016 (0x03f8),  (0x), AccessCheckByTypeResultListAndAuditAlarmByHandleW, 0x000340e0, None
        1017 (0x03f9),  (0x), AccessCheckByTypeResultListAndAuditAlarmW, 0x00034100, None
        1018 (0x03fa),  (0x), AddAccessAllowedAce, 0x0001f040, None
        1019 (0x03fb),  (0x), AddAccessAllowedAceEx, 0x0001fb60, None
        1020 (0x03fc),  (0x), AddAccessAllowedObjectAce, 0x00034180, None
        1021 (0x03fd),  (0x), AddAccessDeniedAce, 0x000341c0, None
        1022 (0x03fe),  (0x), AddAccessDeniedAceEx, 0x000341a0, None
        1023 (0x03ff),  (0x), AddAccessDeniedObjectAce, 0x000341e0, None
        1024 (0x0400),  (0x), AddAce, 0x00034200, None
        1025 (0x0401),  (0x), AddAuditAccessAce, 0x00034240, None
        1026 (0x0402),  (0x), AddAuditAccessAceEx, 0x00034220, None
        1027 (0x0403),  (0x), AddAuditAccessObjectAce, 0x00034260, None
        1029 (0x0405),  (0x), AddMandatoryAce, KERNELBASE.AddMandatoryAce, None
        1032 (0x0408),  (0x), AdjustTokenGroups, 0x00034280, None
        1033 (0x0409),  (0x), AdjustTokenPrivileges, 0x0001fd10, None
        1034 (0x040a),  (0x), AllocateAndInitializeSid, 0x0001ef60, None
        1035 (0x040b),  (0x), AllocateLocallyUniqueId, 0x000342a0, None
        1036 (0x040c),  (0x), AreAllAccessesGranted, 0x000342c0, None
        1037 (0x040d),  (0x), AreAnyAccessesGranted, 0x000342e0, None
        1097 (0x0449),  (0x), CheckTokenMembership, 0x0001f410, None
        1134 (0x046e),  (0x), ConvertToAutoInheritPrivateObjectSecurity, 0x00034560, None
        1135 (0x046f),  (0x), CopySid, 0x0001ec20, None
        1137 (0x0471),  (0x), CreatePrivateObjectSecurity, 0x00023440, None
        1138 (0x0472),  (0x), CreatePrivateObjectSecurityEx, 0x00034580, None
        1139 (0x0473),  (0x), CreatePrivateObjectSecurityWithMultipleInheritance, 0x000345a0, None
        1144 (0x0478),  (0x), CreateRestrictedToken, 0x00020710, None
        1149 (0x047d),  (0x), CreateWellKnownSid, 0x00020310, None
        1237 (0x04d5),  (0x), DeleteAce, 0x0001fcf0, None
        1240 (0x04d8),  (0x), DestroyPrivateObjectSecurity, 0x00023480, None
        1242 (0x04da),  (0x), DuplicateToken, 0x0001ef80, None
        1243 (0x04db),  (0x), DuplicateTokenEx, 0x00020100, None
        1282 (0x0502),  (0x), EqualDomainSid, 0x00034e50, None
        1283 (0x0503),  (0x), EqualPrefixSid, 0x00034e70, None
        1284 (0x0504),  (0x), EqualSid, 0x000202a0, None
        1302 (0x0516),  (0x), FindFirstFreeAce, 0x00034ef0, None
        1310 (0x051e),  (0x), FreeSid, 0x0001fb40, None
        1313 (0x0521),  (0x), GetAce, 0x00034f10, None
        1314 (0x0522),  (0x), GetAclInformation, 0x00034f30, None
        1327 (0x052f),  (0x), GetFileSecurityW, 0x000121e0, None
        1332 (0x0534),  (0x), GetKernelObjectSecurity, 0x00024d50, None
        1333 (0x0535),  (0x), GetLengthSid, 0x0001eb10, None
        1349 (0x0545),  (0x), GetPrivateObjectSecurity, 0x00034f90, None
        1350 (0x0546),  (0x), GetSecurityDescriptorControl, 0x00034fb0, None
        1351 (0x0547),  (0x), GetSecurityDescriptorDacl, 0x0001f180, None
        1352 (0x0548),  (0x), GetSecurityDescriptorGroup, 0x00034fd0, None
        1353 (0x0549),  (0x), GetSecurityDescriptorLength, 0x00023460, None
        1354 (0x054a),  (0x), GetSecurityDescriptorOwner, 0x00024d90, None
        1355 (0x054b),  (0x), GetSecurityDescriptorRMControl, 0x00034ff0, None
        1356 (0x054c),  (0x), GetSecurityDescriptorSacl, 0x000244f0, None
        1364 (0x0554),  (0x), GetSidIdentifierAuthority, 0x00035050, None
        1365 (0x0555),  (0x), GetSidLengthRequired, 0x00035070, None
        1366 (0x0556),  (0x), GetSidSubAuthority, 0x0001ef00, None
        1367 (0x0557),  (0x), GetSidSubAuthorityCount, 0x0001f060, None
        1370 (0x055a),  (0x), GetTokenInformation, 0x0001e660, None
        1382 (0x0566),  (0x), GetWindowsAccountDomainSid, 0x00035090, None
        1395 (0x0573),  (0x), ImpersonateAnonymousToken, 0x000350f0, None
        1396 (0x0574),  (0x), ImpersonateLoggedOnUser, 0x000204c0, None
        1398 (0x0576),  (0x), ImpersonateSelf, 0x00020690, None
        1399 (0x0577),  (0x), InitializeAcl, 0x0001f1a0, None
        1400 (0x0578),  (0x), InitializeSecurityDescriptor, 0x0001f2c0, None
        1401 (0x0579),  (0x), InitializeSid, 0x00035130, None
        1410 (0x0582),  (0x), IsTokenRestricted, 0x00035150, None
        1412 (0x0584),  (0x), IsValidAcl, 0x00035170, None
        1414 (0x0586),  (0x), IsValidSecurityDescriptor, 0x00035190, None
        1415 (0x0587),  (0x), IsValidSid, 0x0001ef40, None
        1416 (0x0588),  (0x), IsWellKnownSid, 0x000351b0, None
        1514 (0x05ea),  (0x), MakeAbsoluteSD, 0x00024d30, None
        1515 (0x05eb),  (0x), MakeSelfRelativeSD, 0x000355b0, None
        1516 (0x05ec),  (0x), MapGenericMask, 0x000355d0, None
        1524 (0x05f4),  (0x), ObjectCloseAuditAlarmW, 0x00035600, None
        1526 (0x05f6),  (0x), ObjectDeleteAuditAlarmW, 0x00035620, None
        1528 (0x05f8),  (0x), ObjectOpenAuditAlarmW, 0x00035640, None
        1530 (0x05fa),  (0x), ObjectPrivilegeAuditAlarmW, 0x00035660, None
        1577 (0x0629),  (0x), PrivilegeCheck, 0x000356a0, None
        1579 (0x062b),  (0x), PrivilegedServiceAuditAlarmW, 0x000356c0, None
        1587 (0x0633),  (0x), QuerySecurityAccessMask, 0x00035700, None
        1709 (0x06ad),  (0x), RevertToSelf, 0x0001f7b0, None
        1727 (0x06bf),  (0x), SetAclInformation, 0x00035af0, None
        1736 (0x06c8),  (0x), SetFileSecurityW, 0x00024df0, None
        1739 (0x06cb),  (0x), SetKernelObjectSecurity, 0x000206f0, None
        1744 (0x06d0),  (0x), SetPrivateObjectSecurity, 0x00035b50, None
        1745 (0x06d1),  (0x), SetPrivateObjectSecurityEx, 0x00035b30, None
        1746 (0x06d2),  (0x), SetSecurityAccessMask, 0x00035b70, None
        1747 (0x06d3),  (0x), SetSecurityDescriptorControl, 0x00035b80, None
        1748 (0x06d4),  (0x), SetSecurityDescriptorDacl, 0x0001f020, None
        1749 (0x06d5),  (0x), SetSecurityDescriptorGroup, 0x000245d0, None
        1750 (0x06d6),  (0x), SetSecurityDescriptorOwner, 0x0001fb20, None
        1751 (0x06d7),  (0x), SetSecurityDescriptorRMControl, 0x00035ba0, None
        1752 (0x06d8),  (0x), SetSecurityDescriptorSacl, 0x00035bc0, None
        1760 (0x06e0),  (0x), SetTokenInformation, 0x00024530, None

         */
    }
}
