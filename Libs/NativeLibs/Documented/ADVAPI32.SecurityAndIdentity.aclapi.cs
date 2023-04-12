using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// aclapi.h This header is used by Security and Identity.
    /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1075 (0x0433),  (0x), BuildExplicitAccessWithNameA, 0x000238c0, None
        1076 (0x0434),  (0x), BuildExplicitAccessWithNameW, 0x000238c0, None
        1081 (0x0439),  (0x), BuildSecurityDescriptorA, 0x00040030, None
        1082 (0x043a),  (0x), BuildSecurityDescriptorW, 0x000234a0, None
        1083 (0x043b),  (0x), BuildTrusteeWithNameA, 0x00040860, None
        1084 (0x043c),  (0x), BuildTrusteeWithNameW, 0x00040860, None
        1085 (0x043d),  (0x), BuildTrusteeWithObjectsAndNameA, 0x00040890, None
        1086 (0x043e),  (0x), BuildTrusteeWithObjectsAndNameW, 0x00040890, None
        1087 (0x043f),  (0x), BuildTrusteeWithObjectsAndSidA, 0x000408f0, None
        1088 (0x0440),  (0x), BuildTrusteeWithObjectsAndSidW, 0x000408f0, None
        1089 (0x0441),  (0x), BuildTrusteeWithSidA, 0x000204e0, None
        1090 (0x0442),  (0x), BuildTrusteeWithSidW, 0x000204e0, None
        1309 (0x051d),  (0x), FreeInheritedFromArray, 0x00040130, None
        1315 (0x0523),  (0x), GetAuditedPermissionsFromAclA, 0x00040170, None
        1316 (0x0524),  (0x), GetAuditedPermissionsFromAclW, 0x000401c0, None
        1320 (0x0528),  (0x), GetEffectiveRightsFromAclA, 0x00040220, None
        1321 (0x0529),  (0x), GetEffectiveRightsFromAclW, 0x00040270, None
        1324 (0x052c),  (0x), GetExplicitEntriesFromAclA, 0x00034f70, None
        1325 (0x052d),  (0x), GetExplicitEntriesFromAclW, 0x00034f70, None
        1330 (0x0532),  (0x), GetInheritanceSourceA, 0x000402e0, None
        1331 (0x0533),  (0x), GetInheritanceSourceW, 0x000402f0, None
        1342 (0x053e),  (0x), GetNamedSecurityInfoA, 0x00040350, None
        1345 (0x0541),  (0x), GetNamedSecurityInfoW, 0x00023420, None
        1357 (0x054d),  (0x), GetSecurityInfo, 0x0001efa0, None
        1374 (0x055e),  (0x), GetTrusteeFormA, 0x000409c0, None
        1375 (0x055f),  (0x), GetTrusteeFormW, 0x000409c0, None
        1376 (0x0560),  (0x), GetTrusteeNameA, 0x000409e0, None
        1377 (0x0561),  (0x), GetTrusteeNameW, 0x000409e0, None
        1378 (0x0562),  (0x), GetTrusteeTypeA, 0x00040a00, None
        1379 (0x0563),  (0x), GetTrusteeTypeW, 0x00040a00, None
        1433 (0x0599),  (0x), LookupSecurityDescriptorPartsA, 0x000403a0, None
        1434 (0x059a),  (0x), LookupSecurityDescriptorPartsW, 0x000405c0, None
        1731 (0x06c3),  (0x), SetEntriesInAclA, 0x00024830, None
        1732 (0x06c4),  (0x), SetEntriesInAclW, 0x00020510, None
        1740 (0x06cc),  (0x), SetNamedSecurityInfoA, 0x00024600, None
        1743 (0x06cf),  (0x), SetNamedSecurityInfoW, 0x00035b10, None
        1753 (0x06d9),  (0x), SetSecurityInfo, 0x00020070, None
        1816 (0x0718),  (0x), TreeResetNamedSecurityInfoA, 0x000407a0, None
        1817 (0x0719),  (0x), TreeResetNamedSecurityInfoW, 0x00011ef0, None
        1818 (0x071a),  (0x), TreeSetNamedSecurityInfoA, 0x000407a0, None
        1819 (0x071b),  (0x), TreeSetNamedSecurityInfoW, 0x000407b0, None
         
         */


        /// <summary>
        /// The BuildExplicitAccessWithName function initializes an EXPLICIT_ACCESS structure with data specified by the caller. The trustee is identified by a name string.
        /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-buildexplicitaccesswithnamea
        /// </summary>
        /// <param name="pExplicitAccess"></param>
        /// <param name="pTrusteeName"></param>
        /// <param name="AccessPermissions"></param>
        /// <param name="AccessMode"></param>
        /// <param name="Inheritance"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildExplicitAccessWithNameA(
            ref IntPtr pExplicitAccess,
            [MarshalAs(UnmanagedType.LPStr)] string pTrusteeName,
            ACCESS_MASK AccessPermissions,
            ACCESS_MODE AccessMode,
            uint Inheritance
        );

        /// almost same as BuildExplicitAccessWithNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildExplicitAccessWithNameW(
            ref IntPtr pExplicitAccess,
            [MarshalAs(UnmanagedType.LPWStr)] string pTrusteeName,
            ACCESS_MASK AccessPermissions,
            ACCESS_MODE AccessMode,
            uint Inheritance
        );

        /// <summary>
        /// The BuildSecurityDescriptor function allocates and initializes a new security descriptor.
        /// </summary>
        /// <param name="pOwner"></param>
        /// <param name="pGroup"></param>
        /// <param name="cCountOfAccessEntries"></param>
        /// <param name="pListOfAccessEntries"></param>
        /// <param name="cCountOfAuditEntries"></param>
        /// <param name="pListOfAuditEntries"></param>
        /// <param name="pOldSD"></param>
        /// <param name="pSizeNewSD"></param>
        /// <param name="pNewSD"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint BuildSecurityDescriptorA(
            System.IntPtr pOwner,
            System.IntPtr pGroup,
            uint cCountOfAccessEntries,
            System.IntPtr pListOfAccessEntries,
            uint cCountOfAuditEntries,
            System.IntPtr pListOfAuditEntries,
            System.IntPtr pOldSD,
            ref uint pSizeNewSD,
            ref System.IntPtr pNewSD
        );

        /// almost same as BuildSecurityDescriptorA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint BuildSecurityDescriptorW(
            System.IntPtr pOwner,
            System.IntPtr pGroup,
            uint cCountOfAccessEntries,
            System.IntPtr pListOfAccessEntries,
            uint cCountOfAuditEntries,
            System.IntPtr pListOfAuditEntries,
            System.IntPtr pOldSD,
            ref uint pSizeNewSD,
            ref System.IntPtr pNewSD
        );

        /// <summary>
        /// The BuildTrusteeWithName function initializes a TRUSTEE structure.
        /// The caller specifies the trustee name.
        /// The function sets other members of the structure to default values.
        /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-buildtrusteewithnamea
        /// </summary>
        /// <param name="pTrustee"></param>
        /// <param name="pName"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithNameA(
            ref IntPtr pTrustee,
            [MarshalAs(UnmanagedType.LPStr)] string pName
        );

        /// almost same as BuildTrusteeWithNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithNameW(
            ref IntPtr pTrustee,
            [MarshalAs(UnmanagedType.LPWStr)] string pName
        );

        /// <summary>
        /// The BuildTrusteeWithObjectsAndName function initializes a TRUSTEE structure
        /// with the object-specific access control entry (ACE) information and initializes the remaining members of the structure to default values.
        /// The caller also specifies the name of the trustee.
        /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-buildtrusteewithobjectsandnamea
        /// </summary>
        /// <param name="pTrustee"></param>
        /// <param name="pObjName"></param>
        /// <param name="ObjectType"></param>
        /// <param name="ObjectTypeName"></param>
        /// <param name="InheritedObjectTypeName"></param>
        /// <param name="Name"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithObjectsAndNameA(
            ref IntPtr pTrustee,
            IntPtr pObjName,
            SE_OBJECT_TYPE ObjectType,
            [MarshalAs(UnmanagedType.LPStr)] string ObjectTypeName,
            [MarshalAs(UnmanagedType.LPStr)] string InheritedObjectTypeName,
            [MarshalAs(UnmanagedType.LPStr)] string Name
        );

        /// almost same as BuildTrusteeWithObjectsAndNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithObjectsAndNameW(
            ref IntPtr pTrustee,
            IntPtr pObjName,
            SE_OBJECT_TYPE ObjectType,
            [MarshalAs(UnmanagedType.LPWStr)] string ObjectTypeName,
            [MarshalAs(UnmanagedType.LPWStr)] string InheritedObjectTypeName,
            [MarshalAs(UnmanagedType.LPWStr)] string Name
        );

        /// <summary>
        /// The BuildTrusteeWithObjectsAndSid function initializes a TRUSTEE structure
        /// with the object-specific access control entry (ACE) information and initializes the remaining members of the structure to default values.
        /// The caller also specifies the SID structure that represents the security identifier of the trustee.
        /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-buildtrusteewithobjectsandsida
        /// </summary>
        /// <param name="pTrustee">
        /// A pointer to a TRUSTEE structure to initialize. The BuildTrusteeWithObjectsAndSid function does not allocate any memory.
        /// If this parameter is NULL or a pointer that is not valid, the results are undefined.
        /// </param>
        /// <param name="pObjSid">
        /// A pointer to an OBJECTS_AND_SID structure that contains information about the trustee and the securable object.
        /// </param>
        /// <param name="pObjectGuid">
        /// A pointer to a GUID structure that describes the ObjectType GUID to be added to the TRUSTEE structure.
        /// </param>
        /// <param name="pInheritedObjectGuid">
        /// A pointer to a GUID structure that describes the InheritedObjectType GUID to be added to the TRUSTEE structure.
        /// </param>
        /// <param name="pSid">
        /// A pointer to a SID structure that identifies the trustee.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithObjectsAndSidA(
            ref IntPtr pTrustee,
            IntPtr pObjSid,
            ref GUID pObjectGuid,
            ref GUID pInheritedObjectGuid,
            System.IntPtr pSid
        );

        /// almost same as BuildTrusteeWithObjectsAndSidA
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithObjectsAndSidW(
            ref IntPtr pTrustee,
            IntPtr pObjSid,
            ref GUID pObjectGuid,
            ref GUID pInheritedObjectGuid,
            System.IntPtr pSid
        );

        /// <summary>
        /// The BuildTrusteeWithSid function initializes a TRUSTEE structure.
        /// The caller specifies the security identifier (SID) of the trustee.
        /// The function sets other members of the structure to default values and does not look up the name associated with the SID.
        /// https://learn.microsoft.com/en-us/windows/win32/api/aclapi/nf-aclapi-buildtrusteewithsida
        /// </summary>
        /// <param name="pTrustee"></param>
        /// <param name="pSid"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithSidA(
            ref IntPtr pTrustee,
            System.IntPtr pSid
        );

        /// almost same as BuildTrusteeWithSidA
        [DllImport(Dll, SetLastError = true)]
        public static extern void BuildTrusteeWithSidW(
            ref IntPtr pTrustee,
            System.IntPtr pSid
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint FreeInheritedFromArray(
            IntPtr pInheritArray,
            uint AceCnt,
            IntPtr pfnArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetAuditedPermissionsFromAclA(
            IntPtr pacl,
            IntPtr pTrustee,
            IntPtr pSuccessfulAuditedRights,
            IntPtr pFailedAuditRights
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetAuditedPermissionsFromAclW(
            IntPtr pacl,
            IntPtr pTrustee,
            IntPtr pSuccessfulAuditedRights,
            IntPtr pFailedAuditRights
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetEffectiveRightsFromAclA(
            IntPtr pacl,
            IntPtr pTrustee,
            ref IntPtr pAccessRights
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetEffectiveRightsFromAclW(
            IntPtr pacl,
            IntPtr pTrustee,
            ref IntPtr pAccessRights
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetExplicitEntriesFromAclA(
            IntPtr pacl,
            ref uint pcCountOfExplicitEntries,
            ref IntPtr pListOfExplicitEntries
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetExplicitEntriesFromAclW(
            IntPtr pacl,
            ref uint pcCountOfExplicitEntries,
            ref IntPtr pListOfExplicitEntries
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetInheritanceSourceA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            [MarshalAs(UnmanagedType.Bool)] bool Container,
            ref System.IntPtr pObjectClassGuids,
            uint GuidCount,
            ref ACL pAcl,
            IntPtr pfnArray,
            ref GENERIC_MAPPING pGenericMapping,
            IntPtr pInheritArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetInheritanceSourceW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            [MarshalAs(UnmanagedType.Bool)] bool Container,
            ref System.IntPtr pObjectClassGuids,
            uint GuidCount,
            ref ACL pAcl,
            IntPtr pfnArray,
            ref GENERIC_MAPPING pGenericMapping,
            IntPtr pInheritArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetNamedSecurityInfoA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            ref IntPtr ppsidGroup,
            ref IntPtr ppDacl,
            ref IntPtr ppSacl,
            ref IntPtr ppSecurityDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetNamedSecurityInfoW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            ref IntPtr ppsidGroup,
            ref IntPtr ppDacl,
            ref IntPtr ppSacl,
            ref IntPtr ppSecurityDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetSecurityInfo(
            IntPtr handle,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            ref IntPtr ppsidGroup,
            ref IntPtr ppDacl,
            ref IntPtr ppSacl,
            ref IntPtr ppSecurityDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeFormA(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeFormW(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeNameA(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeNameW(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeTypeA(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void GetTrusteeTypeW(
            IntPtr pTrustee
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void LookupSecurityDescriptorPartsA(
            ref IntPtr ppOwner,
            ref IntPtr ppGroup,
            ref uint pcCountOfAccessEntries,
            ref IntPtr ppListOfAccessEntries,
            ref uint pcCountOfAuditEntries,
            ref IntPtr ppListOfAuditEntries,
            IntPtr pSD
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void LookupSecurityDescriptorPartsW(
            ref IntPtr ppOwner,
            ref IntPtr ppGroup,
            ref uint pcCountOfAccessEntries,
            ref IntPtr ppListOfAccessEntries,
            ref uint pcCountOfAuditEntries,
            ref IntPtr ppListOfAuditEntries,
            IntPtr pSD
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void SetEntriesInAclA(
            uint cCountOfExplicitEntries,
            IntPtr pListOfExplicitEntries,
            IntPtr OldAcl,
            ref IntPtr NewAcl
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void SetEntriesInAclW(
            uint cCountOfExplicitEntries,
            IntPtr pListOfExplicitEntries,
            IntPtr OldAcl,
            ref IntPtr NewAcl
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void SetNamedSecurityInfoA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            ref IntPtr ppsidGroup,
            ref IntPtr ppDacl,
            ref IntPtr ppSacl
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void SetNamedSecurityInfoW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            ref IntPtr ppsidGroup,
            ref IntPtr ppDacl,
            ref IntPtr ppSacl
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern void SetSecurityInfo(
            IntPtr handle,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            IntPtr ppsidGroup,
            IntPtr ppDacl,
            IntPtr ppSacl
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern void TreeResetNamedSecurityInfoA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            IntPtr ppsidGroup,
            IntPtr ppDacl,
            IntPtr ppSacl,
            bool KeepExplicit,
            IntPtr fnProgress,
            PROG_INVOKE_SETTING ProgressInvokeSetting,
            IntPtr Args
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void TreeResetNamedSecurityInfoW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr ppsidOwner,
            IntPtr ppsidGroup,
            IntPtr ppDacl,
            IntPtr ppSacl,
            bool KeepExplicit,
            IntPtr fnProgress,
            PROG_INVOKE_SETTING ProgressInvokeSetting,
            IntPtr Args
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void TreeSetNamedSecurityInfoA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr pOwner,
            IntPtr pGroup,
            IntPtr pDacl,
            IntPtr pSacl,
            uint dwAction,
            IntPtr fnProgress,
            PROG_INVOKE_SETTING ProgressInvokeSetting,
            IntPtr Args
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void TreeSetNamedSecurityInfoW(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            IntPtr pOwner,
            IntPtr pGroup,
            IntPtr pDacl,
            IntPtr pSacl,
            uint dwAction,
            IntPtr fnProgress,
            PROG_INVOKE_SETTING ProgressInvokeSetting,
            IntPtr Args
        );
    }
}
