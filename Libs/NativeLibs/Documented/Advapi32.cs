using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class ADVAPI32
    {
        const string Dll = "advapi32.dll";

        /*
        
        1000 (0x03e8),  (0x), Ordinal_1000, 0x0003c370, None
        1001 (0x03e9),  (0x), I_ScGetCurrentGroupStateW, 0x00033bd0, None
        1002 (0x03ea),  (0x), A_SHAFinal, NTDLL.A_SHAFinal, None
        1003 (0x03eb),  (0x), A_SHAInit, NTDLL.A_SHAInit, None
        1004 (0x03ec),  (0x), A_SHAUpdate, NTDLL.A_SHAUpdate, None
        *   1005 (0x03ed),  (0x), AbortSystemShutdownA, 0x00043be0, None
        *   1006 (0x03ee),  (0x), AbortSystemShutdownW, 0x00043c50, None
        *   1007 (0x03ef),  (0x), AccessCheck, 0x00034160, None
        *   1008 (0x03f0),  (0x), AccessCheckAndAuditAlarmA, 0x000460f0, None
        *   1009 (0x03f1),  (0x), AccessCheckAndAuditAlarmW, 0x000340a0, None
        *   1010 (0x03f2),  (0x), AccessCheckByType, 0x00034140, None
        *   1011 (0x03f3),  (0x), AccessCheckByTypeAndAuditAlarmA, 0x00046200, None
        *   1012 (0x03f4),  (0x), AccessCheckByTypeAndAuditAlarmW, 0x000340c0, None
        *   1013 (0x03f5),  (0x), AccessCheckByTypeResultList, 0x00034120, None
        *   1014 (0x03f6),  (0x), AccessCheckByTypeResultListAndAuditAlarmA, 0x00046320, None
        *   1015 (0x03f7),  (0x), AccessCheckByTypeResultListAndAuditAlarmByHandleA, 0x00046440, None
        *   1016 (0x03f8),  (0x), AccessCheckByTypeResultListAndAuditAlarmByHandleW, 0x000340e0, None
        *   1017 (0x03f9),  (0x), AccessCheckByTypeResultListAndAuditAlarmW, 0x00034100, None
        *   1018 (0x03fa),  (0x), AddAccessAllowedAce, 0x0001f040, None
        *   1019 (0x03fb),  (0x), AddAccessAllowedAceEx, 0x0001fb60, None
        *   1020 (0x03fc),  (0x), AddAccessAllowedObjectAce, 0x00034180, None
        *   1021 (0x03fd),  (0x), AddAccessDeniedAce, 0x000341c0, None
        *   1022 (0x03fe),  (0x), AddAccessDeniedAceEx, 0x000341a0, None
        *   1023 (0x03ff),  (0x), AddAccessDeniedObjectAce, 0x000341e0, None
        *   1024 (0x0400),  (0x), AddAce, 0x00034200, None
        *   1025 (0x0401),  (0x), AddAuditAccessAce, 0x00034240, None
        *   1026 (0x0402),  (0x), AddAuditAccessAceEx, 0x00034220, None
        *   1027 (0x0403),  (0x), AddAuditAccessObjectAce, 0x00034260, None
        *   1028 (0x0404),  (0x), AddConditionalAce, 0x00048e20, None
        *   1029 (0x0405),  (0x), AddMandatoryAce, KERNELBASE.AddMandatoryAce, None
        *   1030 (0x0406),  (0x), AddUsersToEncryptedFile, 0x00033610, None
        1031 (0x0407),  (0x), AddUsersToEncryptedFileEx, 0x00033670, None
        *   1032 (0x0408),  (0x), AdjustTokenGroups, 0x00034280, None
        *   1033 (0x0409),  (0x), AdjustTokenPrivileges, 0x0001fd10, None
        *   1034 (0x040a),  (0x), AllocateAndInitializeSid, 0x0001ef60, None
        *   1035 (0x040b),  (0x), AllocateLocallyUniqueId, 0x000342a0, None
        *   1036 (0x040c),  (0x), AreAllAccessesGranted, 0x000342c0, None
        *   1037 (0x040d),  (0x), AreAnyAccessesGranted, 0x000342e0, None
        *   1038 (0x040e),  (0x), AuditComputeEffectivePolicyBySid, 0x00034300, None
        *   1039 (0x040f),  (0x), AuditComputeEffectivePolicyByToken, 0x000363c0, None
        *   1040 (0x0410),  (0x), AuditEnumerateCategories, 0x00034320, None
        *   1041 (0x0411),  (0x), AuditEnumeratePerUserPolicy, 0x00034340, None
        *   1042 (0x0412),  (0x), AuditEnumerateSubCategories, 0x00034360, None
        *   1043 (0x0413),  (0x), AuditFree, 0x00024d20, None
        *   1044 (0x0414),  (0x), AuditLookupCategoryGuidFromCategoryId, 0x000364b0, None
        *   1045 (0x0415),  (0x), AuditLookupCategoryIdFromCategoryGuid, 0x000364f0, None
        *   1046 (0x0416),  (0x), AuditLookupCategoryNameA, 0x00036550, None
        *   1047 (0x0417),  (0x), AuditLookupCategoryNameW, 0x00034380, None
        *   1048 (0x0418),  (0x), AuditLookupSubCategoryNameA, 0x000365c0, None
        *   1049 (0x0419),  (0x), AuditLookupSubCategoryNameW, 0x000343a0, None
        *   1050 (0x041a),  (0x), AuditQueryGlobalSaclA, 0x00036630, None
        *   1051 (0x041b),  (0x), AuditQueryGlobalSaclW, 0x000343c0, None
        *   1052 (0x041c),  (0x), AuditQueryPerUserPolicy, 0x00024d00, None
        *   1053 (0x041d),  (0x), AuditQuerySecurity, 0x000343e0, None
        *   1054 (0x041e),  (0x), AuditQuerySystemPolicy, 0x00024cc0, None
        *   1055 (0x041f),  (0x), AuditSetGlobalSaclA, 0x000366b0, None
        *   1056 (0x0420),  (0x), AuditSetGlobalSaclW, 0x00034400, None
        *   1057 (0x0421),  (0x), AuditSetPerUserPolicy, 0x00034420, None
        *   1058 (0x0422),  (0x), AuditSetSecurity, 0x00034440, None
        *   1059 (0x0423),  (0x), AuditSetSystemPolicy, 0x00034460, None
        *   1060 (0x0424),  (0x), BackupEventLogA, 0x0004f440, None
        *   1061 (0x0425),  (0x), BackupEventLogW, 0x0004f4c0, None
        1062 (0x0426),  (0x), BaseRegCloseKey, 0x00044030, None
        1063 (0x0427),  (0x), BaseRegCreateKey, 0x00044060, None
        1064 (0x0428),  (0x), BaseRegDeleteKeyEx, 0x000440a0, None
        1065 (0x0429),  (0x), BaseRegDeleteValue, 0x000440d0, None
        1066 (0x042a),  (0x), BaseRegFlushKey, 0x00044100, None
        1067 (0x042b),  (0x), BaseRegGetVersion, 0x00026350, None
        1068 (0x042c),  (0x), BaseRegLoadKey, 0x00044130, None
        1069 (0x042d),  (0x), BaseRegOpenKey, 0x00044160, None
        1070 (0x042e),  (0x), BaseRegRestoreKey, 0x00044190, None
        1071 (0x042f),  (0x), BaseRegSaveKeyEx, 0x000441c0, None
        1072 (0x0430),  (0x), BaseRegSetKeySecurity, 0x000441f0, None
        1073 (0x0431),  (0x), BaseRegSetValue, 0x00044220, None
        1074 (0x0432),  (0x), BaseRegUnLoadKey, 0x00044250, None
        *   1075 (0x0433),  (0x), BuildExplicitAccessWithNameA, 0x000238c0, None
        *   1076 (0x0434),  (0x), BuildExplicitAccessWithNameW, 0x000238c0, None
        1077 (0x0435),  (0x), BuildImpersonateExplicitAccessWithNameA, 0x0003fff0, None
        1078 (0x0436),  (0x), BuildImpersonateExplicitAccessWithNameW, 0x0003fff0, None
        1079 (0x0437),  (0x), BuildImpersonateTrusteeA, 0x00040840, None
        1080 (0x0438),  (0x), BuildImpersonateTrusteeW, 0x00040840, None
        *   1081 (0x0439),  (0x), BuildSecurityDescriptorA, 0x00040030, None
        *   1082 (0x043a),  (0x), BuildSecurityDescriptorW, 0x000234a0, None
        *   1083 (0x043b),  (0x), BuildTrusteeWithNameA, 0x00040860, None
        *   1084 (0x043c),  (0x), BuildTrusteeWithNameW, 0x00040860, None
        *   1085 (0x043d),  (0x), BuildTrusteeWithObjectsAndNameA, 0x00040890, None
        *   1086 (0x043e),  (0x), BuildTrusteeWithObjectsAndNameW, 0x00040890, None
        *   1087 (0x043f),  (0x), BuildTrusteeWithObjectsAndSidA, 0x000408f0, None
        *   1088 (0x0440),  (0x), BuildTrusteeWithObjectsAndSidW, 0x000408f0, None
        1089 (0x0441),  (0x), BuildTrusteeWithSidA, 0x000204e0, None
        1090 (0x0442),  (0x), BuildTrusteeWithSidW, 0x000204e0, None
        1091 (0x0443),  (0x), CancelOverlappedAccess, 0x00040e30, None
        *   1092 (0x0444),  (0x), ChangeServiceConfig2A, 0x00034480, None
        *   1093 (0x0445),  (0x), ChangeServiceConfig2W, 0x000344a0, None
        *   1094 (0x0446),  (0x), ChangeServiceConfigA, 0x000344c0, None
        *   1095 (0x0447),  (0x), ChangeServiceConfigW, 0x000344e0, None
        1096 (0x0448),  (0x), CheckForHiberboot, 0x0001f5c0, None
        *   1097 (0x0449),  (0x), CheckTokenMembership, 0x0001f410, None
        *   1098 (0x044a),  (0x), ClearEventLogA, 0x0004f6c0, None
        *   1099 (0x044b),  (0x), ClearEventLogW, 0x0004f740, None
        1100 (0x044c),  (0x), CloseCodeAuthzLevel, 0x0001e8e0, None
        1101 (0x044d),  (0x), CloseEncryptedFileRaw, 0x000336d0, None
        *   1102 (0x044e),  (0x), CloseEventLog, 0x00023c30, None
        *   1103 (0x044f),  (0x), CloseServiceHandle, 0x00020330, None
        1104 (0x0450),  (0x), CloseThreadWaitChainSession, 0x0005b980, None
        *   1105 (0x0451),  (0x), CloseTrace, 0x00020410, None
        1106 (0x0452),  (0x), CommandLineFromMsiDescriptor, 0x0001fd30, None
        1107 (0x0453),  (0x), ComputeAccessTokenFromCodeAuthzLevel, 0x0001b560, None
        *   1108 (0x0454),  (0x), ControlService, 0x00034540, None
        *   1109 (0x0455),  (0x), ControlServiceExA, 0x00034500, None
        *   1110 (0x0456),  (0x), ControlServiceExW, 0x00034520, None
        *   1111 (0x0457),  (0x), ControlTraceA, 0x00025380, None
        *   1112 (0x0458),  (0x), ControlTraceW, 0x00023300, None
        1113 (0x0459),  (0x), ConvertAccessToSecurityDescriptorA, 0x00040eb0, None
        1114 (0x045a),  (0x), ConvertAccessToSecurityDescriptorW, 0x00040fb0, None
        1115 (0x045b),  (0x), ConvertSDToStringSDDomainW, 0x00049480, None
        1116 (0x045c),  (0x), ConvertSDToStringSDRootDomainA, 0x000494e0, None
        1117 (0x045d),  (0x), ConvertSDToStringSDRootDomainW, 0x000495d0, None
        1118 (0x045e),  (0x), ConvertSecurityDescriptorToAccessA, 0x00041010, None
        1119 (0x045f),  (0x), ConvertSecurityDescriptorToAccessNamedA, 0x00041010, None
        1120 (0x0460),  (0x), ConvertSecurityDescriptorToAccessNamedW, 0x00041040, None
        1121 (0x0461),  (0x), ConvertSecurityDescriptorToAccessW, 0x00041040, None
        *   1122 (0x0462),  (0x), ConvertSecurityDescriptorToStringSecurityDescriptorA, 0x00049630, None
        *   1123 (0x0463),  (0x), ConvertSecurityDescriptorToStringSecurityDescriptorW, 0x00049700, None
        *   1124 (0x0464),  (0x), ConvertSidToStringSidA, 0x0001e680, None
        *   1125 (0x0465),  (0x), ConvertSidToStringSidW, 0x0001e490, None
        1126 (0x0466),  (0x), ConvertStringSDToSDDomainA, 0x00049790, None
        1127 (0x0467),  (0x), ConvertStringSDToSDDomainW, 0x00049850, None
        1128 (0x0468),  (0x), ConvertStringSDToSDRootDomainA, 0x000498d0, None
        1129 (0x0469),  (0x), ConvertStringSDToSDRootDomainW, 0x00049960, None
        *   1130 (0x046a),  (0x), ConvertStringSecurityDescriptorToSecurityDescriptorA, 0x00024720, None
        *   1131 (0x046b),  (0x), ConvertStringSecurityDescriptorToSecurityDescriptorW, 0x000186a0, None
        *   1132 (0x046c),  (0x), ConvertStringSidToSidA, 0x000499c0, None
        *   1133 (0x046d),  (0x), ConvertStringSidToSidW, 0x000198a0, None
        *   1134 (0x046e),  (0x), ConvertToAutoInheritPrivateObjectSecurity, 0x00034560, None
        *   1135 (0x046f),  (0x), CopySid, 0x0001ec20, None
        1136 (0x0470),  (0x), CreateCodeAuthzLevel, 0x0003ade0, None
        *   1137 (0x0471),  (0x), CreatePrivateObjectSecurity, 0x00023440, None
        *   1138 (0x0472),  (0x), CreatePrivateObjectSecurityEx, 0x00034580, None
        *   1139 (0x0473),  (0x), CreatePrivateObjectSecurityWithMultipleInheritance, 0x000345a0, None
        1140 (0x0474),  (0x), CreateProcessAsUserA, 0x000345c0, None
        1141 (0x0475),  (0x), CreateProcessAsUserW, 0x00020430, None
        1142 (0x0476),  (0x), CreateProcessWithLogonW, 0x00048a30, None
        1143 (0x0477),  (0x), CreateProcessWithTokenW, 0x00048a70, None
        *   1144 (0x0478),  (0x), CreateRestrictedToken, 0x00020710, None
        *   1145 (0x0479),  (0x), CreateServiceA, 0x000345e0, None
        1146 (0x047a),  (0x), CreateServiceEx, 0x00025420, None
        *   1147 (0x047b),  (0x), CreateServiceW, 0x00034600, None
        *   1148 (0x047c),  (0x), CreateTraceInstanceId, ntdll.EtwCreateTraceInstanceId, None
        *   1149 (0x047d),  (0x), CreateWellKnownSid, 0x00020310, None
        1150 (0x047e),  (0x), CredBackupCredentials, 0x00034620, None
        1151 (0x047f),  (0x), CredDeleteA, 0x00034640, None
        1152 (0x0480),  (0x), CredDeleteW, 0x00034660, None
        1153 (0x0481),  (0x), CredEncryptAndMarshalBinaryBlob, 0x00034680, None
        1154 (0x0482),  (0x), CredEnumerateA, 0x000346a0, None
        1155 (0x0483),  (0x), CredEnumerateW, 0x00020650, None
        1156 (0x0484),  (0x), CredFindBestCredentialA, 0x000346c0, None
        1157 (0x0485),  (0x), CredFindBestCredentialW, 0x000346e0, None
        1158 (0x0486),  (0x), CredFree, 0x00034700, None
        1159 (0x0487),  (0x), CredGetSessionTypes, 0x00034710, None
        1160 (0x0488),  (0x), CredGetTargetInfoA, 0x00034730, None
        1161 (0x0489),  (0x), CredGetTargetInfoW, 0x00034750, None
        1162 (0x048a),  (0x), CredIsMarshaledCredentialA, 0x00036900, None
        1163 (0x048b),  (0x), CredIsMarshaledCredentialW, 0x00034770, None
        1164 (0x048c),  (0x), CredIsProtectedA, 0x00034790, None
        1165 (0x048d),  (0x), CredIsProtectedW, 0x000347b0, None
        1166 (0x048e),  (0x), CredMarshalCredentialA, 0x000347d0, None
        1167 (0x048f),  (0x), CredMarshalCredentialW, 0x000347f0, None
        1168 (0x0490),  (0x), CredProfileLoaded, 0x00034830, None
        1169 (0x0491),  (0x), CredProfileLoadedEx, 0x00034810, None
        1170 (0x0492),  (0x), CredProfileUnloaded, 0x00034840, None
        1171 (0x0493),  (0x), CredProtectA, 0x00034850, None
        1172 (0x0494),  (0x), CredProtectW, 0x00034870, None
        1173 (0x0495),  (0x), CredReadA, 0x00034890, None
        1174 (0x0496),  (0x), CredReadByTokenHandle, 0x000348b0, None
        1175 (0x0497),  (0x), CredReadDomainCredentialsA, 0x000348d0, None
        1176 (0x0498),  (0x), CredReadDomainCredentialsW, 0x000348f0, None
        1177 (0x0499),  (0x), CredReadW, 0x00034910, None
        1178 (0x049a),  (0x), CredRenameA, 0x00036940, None
        1179 (0x049b),  (0x), CredRenameW, 0x00036940, None
        1180 (0x049c),  (0x), CredRestoreCredentials, 0x00034930, None
        1181 (0x049d),  (0x), CredUnmarshalCredentialA, 0x00034950, None
        1182 (0x049e),  (0x), CredUnmarshalCredentialW, 0x00034970, None
        1183 (0x049f),  (0x), CredUnprotectA, 0x00034990, None
        1184 (0x04a0),  (0x), CredUnprotectW, 0x000349b0, None
        1185 (0x04a1),  (0x), CredWriteA, 0x000349d0, None
        1186 (0x04a2),  (0x), CredWriteDomainCredentialsA, 0x000349f0, None
        1187 (0x04a3),  (0x), CredWriteDomainCredentialsW, 0x00034a10, None
        1188 (0x04a4),  (0x), CredWriteW, 0x00034a30, None
        1189 (0x04a5),  (0x), CredpConvertCredential, 0x00034a50, None
        1190 (0x04a6),  (0x), CredpConvertOneCredentialSize, 0x00034a70, None
        1191 (0x04a7),  (0x), CredpConvertTargetInfo, 0x00034a90, None
        1192 (0x04a8),  (0x), CredpDecodeCredential, 0x00034ab0, None
        1193 (0x04a9),  (0x), CredpEncodeCredential, 0x00034ad0, None
        1194 (0x04aa),  (0x), CredpEncodeSecret, 0x00034af0, None

        *   1195 (0x04ab),  (0x), CryptAcquireContextA, 0x0001fb00, None
        *   1196 (0x04ac),  (0x), CryptAcquireContextW, 0x0001f330, None
        *   1197 (0x04ad),  (0x), CryptContextAddRef, 0x00034b10, None
        *   1198 (0x04ae),  (0x), CryptCreateHash, 0x0001eee0, None
        *   1199 (0x04af),  (0x), CryptDecrypt, 0x00024550, None
        *   1200 (0x04b0),  (0x), CryptDeriveKey, 0x00034b30, None
        *   1201 (0x04b1),  (0x), CryptDestroyHash, 0x0001f310, None
        *   1202 (0x04b2),  (0x), CryptDestroyKey, 0x0001f370, None
        *   1203 (0x04b3),  (0x), CryptDuplicateHash, 0x00034b50, None
        *   1204 (0x04b4),  (0x), CryptDuplicateKey, 0x00034b70, None
        *   1205 (0x04b5),  (0x), CryptEncrypt, 0x00034b90, None
        *   1206 (0x04b6),  (0x), CryptEnumProviderTypesA, 0x00034bb0, None
        *   1207 (0x04b7),  (0x), CryptEnumProviderTypesW, 0x00034bd0, None
        *   1208 (0x04b8),  (0x), CryptEnumProvidersA, 0x00034bf0, None
        *   1209 (0x04b9),  (0x), CryptEnumProvidersW, 0x00034c10, None
        *   1210 (0x04ba),  (0x), CryptExportKey, 0x0001efe0, None
        *   1211 (0x04bb),  (0x), CryptGenKey, 0x000245b0, None
        *   1212 (0x04bc),  (0x), CryptGenRandom, 0x000202c0, None
        *   1213 (0x04bd),  (0x), CryptGetDefaultProviderA, 0x00034c30, None
        *   1214 (0x04be),  (0x), CryptGetDefaultProviderW, 0x00020140, None
        *   1215 (0x04bf),  (0x), CryptGetHashParam, 0x0001ec40, None
        *   1216 (0x04c0),  (0x), CryptGetKeyParam, 0x00034c50, None
        *   1217 (0x04c1),  (0x), CryptGetProvParam, 0x00034c70, None
        *   1218 (0x04c2),  (0x), CryptGetUserKey, 0x00034c90, None
        *   1219 (0x04c3),  (0x), CryptHashData, 0x0001f000, None
        *   1220 (0x04c4),  (0x), CryptHashSessionKey, 0x00034cb0, None
        *   1221 (0x04c5),  (0x), CryptImportKey, 0x0001efc0, None
        *   1222 (0x04c6),  (0x), CryptReleaseContext, 0x0001f490, None
        *   1223 (0x04c7),  (0x), CryptSetHashParam, 0x0001f4d0, None
        *   1224 (0x04c8),  (0x), CryptSetKeyParam, 0x00034cd0, None
        *   1225 (0x04c9),  (0x), CryptSetProvParam, 0x00034cf0, None
        *   1226 (0x04ca),  (0x), CryptSetProviderA, 0x00034d10, None
        *   1227 (0x04cb),  (0x), CryptSetProviderExA, 0x00034d30, None
        *   1228 (0x04cc),  (0x), CryptSetProviderExW, 0x00034d50, None
        *   1229 (0x04cd),  (0x), CryptSetProviderW, 0x00034d70, None
        *   1230 (0x04ce),  (0x), CryptSignHashA, 0x00034d90, None
        *   1231 (0x04cf),  (0x), CryptSignHashW, 0x00034db0, None
        *   1232 (0x04d0),  (0x), CryptVerifySignatureA, 0x00034dd0, None
        *   1233 (0x04d1),  (0x), CryptVerifySignatureW, 0x0001f350, None

        *   1234 (0x04d2),  (0x), CveEventWrite, KERNELBASE.CveEventWrite, None
        1235 (0x04d3),  (0x), DecryptFileA, 0x00033700, None
        1236 (0x04d4),  (0x), DecryptFileW, 0x000337a0, None
        *   1237 (0x04d5),  (0x), DeleteAce, 0x0001fcf0, None
        *   1238 (0x04d6),  (0x), DeleteService, 0x00034df0, None
        1239 (0x04d7),  (0x), DeregisterEventSource, 0x00020bf0, None
        *   1240 (0x04d8),  (0x), DestroyPrivateObjectSecurity, 0x00023480, None
        *   1241 (0x04d9),  (0x), DuplicateEncryptionInfoFile, 0x00033800, None
        *   1242 (0x04da),  (0x), DuplicateToken, 0x0001ef80, None
        *   1243 (0x04db),  (0x), DuplicateTokenEx, 0x00020100, None
        1244 (0x04dc),  (0x), ElfBackupEventLogFileA, 0x0004fdb0, None
        1245 (0x04dd),  (0x), ElfBackupEventLogFileW, 0x0004fe60, None
        1246 (0x04de),  (0x), ElfChangeNotify, 0x0004ff10, None
        1247 (0x04df),  (0x), ElfClearEventLogFileA, 0x0004ffd0, None
        1248 (0x04e0),  (0x), ElfClearEventLogFileW, 0x00050070, None
        1249 (0x04e1),  (0x), ElfCloseEventLog, 0x00023c60, None
        1250 (0x04e2),  (0x), ElfDeregisterEventSource, 0x00020c20, None
        1251 (0x04e3),  (0x), ElfFlushEventLog, 0x00050110, None
        1252 (0x04e4),  (0x), ElfNumberOfRecords, 0x00050120, None
        1253 (0x04e5),  (0x), ElfOldestRecord, 0x000501d0, None
        1254 (0x04e6),  (0x), ElfOpenBackupEventLogA, 0x00050280, None
        1255 (0x04e7),  (0x), ElfOpenBackupEventLogW, 0x00050390, None
        1256 (0x04e8),  (0x), ElfOpenEventLogA, 0x000504a0, None
        1257 (0x04e9),  (0x), ElfOpenEventLogW, 0x00023cd0, None
        1258 (0x04ea),  (0x), ElfReadEventLogA, 0x00050630, None
        1259 (0x04eb),  (0x), ElfReadEventLogW, 0x00050740, None
        1260 (0x04ec),  (0x), ElfRegisterEventSourceA, 0x00022f10, None
        1261 (0x04ed),  (0x), ElfRegisterEventSourceW, 0x00020960, None
        1262 (0x04ee),  (0x), ElfReportEventA, 0x00050990, None
        1263 (0x04ef),  (0x), ElfReportEventAndSourceW, 0x00050b90, None
        1264 (0x04f0),  (0x), ElfReportEventW, 0x00020e50, None
        *   1265 (0x04f1),  (0x), EnableTrace, 0x00024380, None
        *   1266 (0x04f2),  (0x), EnableTraceEx2, 0x000232c0, None
        *   1267 (0x04f3),  (0x), EnableTraceEx, 0x000243b0, None
        1268 (0x04f4),  (0x), EncryptFileA, 0x00033870, None
        1269 (0x04f5),  (0x), EncryptFileW, 0x00033910, None
        1270 (0x04f6),  (0x), EncryptedFileKeyInfo, 0x00033970, None
        *   1271 (0x04f7),  (0x), EncryptionDisable, 0x000339d0, None
        *   1272 (0x04f8),  (0x), EnumDependentServicesA, 0x00045a10, None
        *   1273 (0x04f9),  (0x), EnumDependentServicesW, 0x00034e10, None
        1274 (0x04fa),  (0x), EnumDynamicTimeZoneInformation, 0x00034e30, None
        1275 (0x04fb),  (0x), EnumServiceGroupW, 0x00045af0, None
        *   1276 (0x04fc),  (0x), EnumServicesStatusA, 0x00045c00, None
        *   1277 (0x04fd),  (0x), EnumServicesStatusExA, 0x000210d0, None
        *   1278 (0x04fe),  (0x), EnumServicesStatusExW, 0x00023880, None
        *   1279 (0x04ff),  (0x), EnumServicesStatusW, 0x00045ce0, None
        *   1280 (0x0500),  (0x), EnumerateTraceGuids, 0x00022260, None
        *   1281 (0x0501),  (0x), EnumerateTraceGuidsEx, 0x00020590, None
        *   1282 (0x0502),  (0x), EqualDomainSid, 0x00034e50, None
        *   1283 (0x0503),  (0x), EqualPrefixSid, 0x00034e70, None
        *   1284 (0x0504),  (0x), EqualSid, 0x000202a0, None
        *   1285 (0x0505),  (0x), EventAccessControl, 0x00034e90, None
        *   1286 (0x0506),  (0x), EventAccessQuery, 0x00034eb0, None
        *   1287 (0x0507),  (0x), EventAccessRemove, 0x00034ed0, None
        *   1288 (0x0508),  (0x), EventActivityIdControl, ntdll.EtwEventActivityIdControl, None
        *   1289 (0x0509),  (0x), EventEnabled, ntdll.EtwEventEnabled, None
        *   1290 (0x050a),  (0x), EventProviderEnabled, ntdll.EtwEventProviderEnabled, None
        *   1291 (0x050b),  (0x), EventRegister, ntdll.EtwEventRegister, None
        *   1292 (0x050c),  (0x), EventSetInformation, ntdll.EtwEventSetInformation, None
        *   1293 (0x050d),  (0x), EventUnregister, ntdll.EtwEventUnregister, None
        *   1294 (0x050e),  (0x), EventWrite, ntdll.EtwEventWrite, None
        *   1295 (0x050f),  (0x), EventWriteEndScenario, ntdll.EtwEventWriteEndScenario, None
        *   1296 (0x0510),  (0x), EventWriteEx, ntdll.EtwEventWriteEx, None
        *   1297 (0x0511),  (0x), EventWriteStartScenario, ntdll.EtwEventWriteStartScenario, None
        *   1298 (0x0512),  (0x), EventWriteString, ntdll.EtwEventWriteString, None
        *   1299 (0x0513),  (0x), EventWriteTransfer, ntdll.EtwEventWriteTransfer, None
        1300 (0x0514),  (0x), FileEncryptionStatusA, 0x00033a10, None
        1301 (0x0515),  (0x), FileEncryptionStatusW, 0x00033ab0, None
        *   1302 (0x0516),  (0x), FindFirstFreeAce, 0x00034ef0, None
        1303 (0x0517),  (0x), FlushEfsCache, 0x00033af0, None
        *   1304 (0x0518),  (0x), FlushTraceA, 0x00043990, None
        *   1305 (0x0519),  (0x), FlushTraceW, 0x000439c0, None
        1306 (0x051a),  (0x), FreeEncryptedFileKeyInfo, 0x00033b70, None
        1307 (0x051b),  (0x), FreeEncryptedFileMetadata, 0x000212b0, None
        *   1308 (0x051c),  (0x), FreeEncryptionCertificateHashList, 0x00033ba0, None
        *   1309 (0x051d),  (0x), FreeInheritedFromArray, 0x00040130, None
        *   1310 (0x051e),  (0x), FreeSid, 0x0001fb40, None
        1311 (0x051f),  (0x), GetAccessPermissionsForObjectA, 0x00041070, None
        1312 (0x0520),  (0x), GetAccessPermissionsForObjectW, 0x000412f0, None
        *   1313 (0x0521),  (0x), GetAce, 0x00034f10, None
        *   1314 (0x0522),  (0x), GetAclInformation, 0x00034f30, None
        *   1315 (0x0523),  (0x), GetAuditedPermissionsFromAclA, 0x00040170, None
        *   1316 (0x0524),  (0x), GetAuditedPermissionsFromAclW, 0x000401c0, None
        1317 (0x0525),  (0x), GetCurrentHwProfileA, 0x00033440, None
        1318 (0x0526),  (0x), GetCurrentHwProfileW, 0x0001f7c0, None
        1319 (0x0527),  (0x), GetDynamicTimeZoneInformationEffectiveYears, 0x00034f50, None
        *   1320 (0x0528),  (0x), GetEffectiveRightsFromAclA, 0x00040220, None
        *   1321 (0x0529),  (0x), GetEffectiveRightsFromAclW, 0x00040270, None
        1322 (0x052a),  (0x), GetEncryptedFileMetadata, 0x00033bd0, None
        *   1323 (0x052b),  (0x), GetEventLogInformation, 0x00023b60, None
        *   1324 (0x052c),  (0x), GetExplicitEntriesFromAclA, 0x00034f70, None
        *   1325 (0x052d),  (0x), GetExplicitEntriesFromAclW, 0x00034f70, None
        *   1326 (0x052e),  (0x), GetFileSecurityA, 0x00046560, None
        *   1327 (0x052f),  (0x), GetFileSecurityW, 0x000121e0, None
        1328 (0x0530),  (0x), GetInformationCodeAuthzLevelW, 0x0003b360, None
        1329 (0x0531),  (0x), GetInformationCodeAuthzPolicyW, 0x0001bbc0, None
        *   1330 (0x0532),  (0x), GetInheritanceSourceA, 0x000402e0, None
        *   1331 (0x0533),  (0x), GetInheritanceSourceW, 0x000402f0, None
        *   1332 (0x0534),  (0x), GetKernelObjectSecurity, 0x00024d50, None
        *   1333 (0x0535),  (0x), GetLengthSid, 0x0001eb10, None
        1334 (0x0536),  (0x), GetLocalManagedApplicationData, 0x000399e0, None
        1335 (0x0537),  (0x), GetLocalManagedApplications, 0x00039c00, None
        1336 (0x0538),  (0x), GetManagedApplicationCategories, 0x00039e40, None
        1337 (0x0539),  (0x), GetManagedApplications, 0x00039ea0, None
        1338 (0x053a),  (0x), GetMultipleTrusteeA, 0x00040980, None
        1339 (0x053b),  (0x), GetMultipleTrusteeOperationA, 0x000409a0, None
        1340 (0x053c),  (0x), GetMultipleTrusteeOperationW, 0x000409a0, None
        1341 (0x053d),  (0x), GetMultipleTrusteeW, 0x00040980, None
        *   1342 (0x053e),  (0x), GetNamedSecurityInfoA, 0x00040350, None
        1343 (0x053f),  (0x), GetNamedSecurityInfoExA, 0x000413d0, None
        1344 (0x0540),  (0x), GetNamedSecurityInfoExW, 0x000415a0, None
        *   1345 (0x0541),  (0x), GetNamedSecurityInfoW, 0x00023420, None
        *   1346 (0x0542),  (0x), GetNumberOfEventLogRecords, 0x0004f7d0, None
        *   1347 (0x0543),  (0x), GetOldestEventLogRecord, 0x0004f810, None
        1348 (0x0544),  (0x), GetOverlappedAccessResults, 0x00041860, None
        *   1349 (0x0545),  (0x), GetPrivateObjectSecurity, 0x00034f90, None
        *   1350 (0x0546),  (0x), GetSecurityDescriptorControl, 0x00034fb0, None
        *   1351 (0x0547),  (0x), GetSecurityDescriptorDacl, 0x0001f180, None
        *   1352 (0x0548),  (0x), GetSecurityDescriptorGroup, 0x00034fd0, None
        *   1353 (0x0549),  (0x), GetSecurityDescriptorLength, 0x00023460, None
        *   1354 (0x054a),  (0x), GetSecurityDescriptorOwner, 0x00024d90, None
        *   1355 (0x054b),  (0x), GetSecurityDescriptorRMControl, 0x00034ff0, None
        *   1356 (0x054c),  (0x), GetSecurityDescriptorSacl, 0x000244f0, None
        *   1357 (0x054d),  (0x), GetSecurityInfo, 0x0001efa0, None
        1358 (0x054e),  (0x), GetSecurityInfoExA, 0x00041980, None
        1359 (0x054f),  (0x), GetSecurityInfoExW, 0x00041b30, None
        *   1360 (0x0550),  (0x), GetServiceDisplayNameA, 0x00045d10, None
        *   1361 (0x0551),  (0x), GetServiceDisplayNameW, 0x00035010, None
        *   1362 (0x0552),  (0x), GetServiceKeyNameA, 0x00045db0, None
        *   1363 (0x0553),  (0x), GetServiceKeyNameW, 0x00035030, None
        *   1364 (0x0554),  (0x), GetSidIdentifierAuthority, 0x00035050, None
        *   1365 (0x0555),  (0x), GetSidLengthRequired, 0x00035070, None
        *   1366 (0x0556),  (0x), GetSidSubAuthority, 0x0001ef00, None
        *   1367 (0x0557),  (0x), GetSidSubAuthorityCount, 0x0001f060, None
        1368 (0x0558),  (0x), GetStringConditionFromBinary, 0x00049070, None
        1369 (0x0559),  (0x), GetThreadWaitChain, 0x0005b9e0, None
        *   1370 (0x055a),  (0x), GetTokenInformation, 0x0001e660, None
        *   1371 (0x055b),  (0x), GetTraceEnableFlags, ntdll.EtwGetTraceEnableFlags, None
        *   1372 (0x055c),  (0x), GetTraceEnableLevel, ntdll.EtwGetTraceEnableLevel, None
        *   1373 (0x055d),  (0x), GetTraceLoggerHandle, ntdll.EtwGetTraceLoggerHandle, None
        *   1374 (0x055e),  (0x), GetTrusteeFormA, 0x000409c0, None
        *   1375 (0x055f),  (0x), GetTrusteeFormW, 0x000409c0, None
        *   1376 (0x0560),  (0x), GetTrusteeNameA, 0x000409e0, None
        *   1377 (0x0561),  (0x), GetTrusteeNameW, 0x000409e0, None
        *   1378 (0x0562),  (0x), GetTrusteeTypeA, 0x00040a00, None
        *   1379 (0x0563),  (0x), GetTrusteeTypeW, 0x00040a00, None
        1380 (0x0564),  (0x), GetUserNameA, 0x00023390, None
        1381 (0x0565),  (0x), GetUserNameW, 0x0001f2e0, None
        *   1382 (0x0566),  (0x), GetWindowsAccountDomainSid, 0x00035090, None
        1383 (0x0567),  (0x), I_QueryTagInformation, api-ms-win-service-private-l1-1-0.I_QueryTagInformation, None
        1384 (0x0568),  (0x), I_ScIsSecurityProcess, api-ms-win-service-private-l1-1-0.I_ScIsSecurityProcess, None
        1385 (0x0569),  (0x), I_ScPnPGetServiceName, api-ms-win-service-private-l1-1-0.I_ScPnPGetServiceName, None
        1386 (0x056a),  (0x), I_ScQueryServiceConfig, api-ms-win-service-private-l1-1-0.I_ScQueryServiceConfig, None
        1387 (0x056b),  (0x), I_ScRegisterPreshutdownRestart, api-ms-win-service-private-l1-1-1.I_ScRegisterPreshutdownRestart, None
        1388 (0x056c),  (0x), I_ScReparseServiceDatabase, 0x00025430, None
        1389 (0x056d),  (0x), I_ScSendPnPMessage, api-ms-win-service-private-l1-1-0.I_ScSendPnPMessage, None
        1390 (0x056e),  (0x), I_ScSendTSMessage, api-ms-win-service-private-l1-1-0.I_ScSendTSMessage, None
        1391 (0x056f),  (0x), I_ScSetServiceBitsA, 0x000350b0, None
        1392 (0x0570),  (0x), I_ScSetServiceBitsW, 0x000350d0, None
        1393 (0x0571),  (0x), I_ScValidatePnPService, api-ms-win-service-private-l1-1-0.I_ScValidatePnPService, None
        1394 (0x0572),  (0x), IdentifyCodeAuthzLevelW, 0x0001bd30, None
        *   1395 (0x0573),  (0x), ImpersonateAnonymousToken, 0x000350f0, None
        *   1396 (0x0574),  (0x), ImpersonateLoggedOnUser, 0x000204c0, None
        1397 (0x0575),  (0x), ImpersonateNamedPipeClient, 0x00035110, None
        *   1398 (0x0576),  (0x), ImpersonateSelf, 0x00020690, None
        *   1399 (0x0577),  (0x), InitializeAcl, 0x0001f1a0, None
        *   1400 (0x0578),  (0x), InitializeSecurityDescriptor, 0x0001f2c0, None
        *   1401 (0x0579),  (0x), InitializeSid, 0x00035130, None
        *   1402 (0x057a),  (0x), InitiateShutdownA, 0x00043cb0, None
        *   1403 (0x057b),  (0x), InitiateShutdownW, 0x00023940, None
        *   1404 (0x057c),  (0x), InitiateSystemShutdownA, 0x00043d80, None
        *   1405 (0x057d),  (0x), InitiateSystemShutdownExA, 0x00043e60, None
        *   1406 (0x057e),  (0x), InitiateSystemShutdownExW, 0x00045690, None
        *   1407 (0x057f),  (0x), InitiateSystemShutdownW, 0x00043f40, None
        1408 (0x0580),  (0x), InstallApplication, 0x00039ed0, None
        1409 (0x0581),  (0x), IsTextUnicode, 0x0001e9d0, None
        *   1410 (0x0582),  (0x), IsTokenRestricted, 0x00035150, None
        1411 (0x0583),  (0x), IsTokenUntrusted, 0x0003b1a0, None
        *   1412 (0x0584),  (0x), IsValidAcl, 0x00035170, None
        1413 (0x0585),  (0x), IsValidRelativeSecurityDescriptor, KERNELBASE.IsValidRelativeSecurityDescriptor, None
        *   1414 (0x0586),  (0x), IsValidSecurityDescriptor, 0x00035190, None
        *   1415 (0x0587),  (0x), IsValidSid, 0x0001ef40, None
        *   1416 (0x0588),  (0x), IsWellKnownSid, 0x000351b0, None
        1417 (0x0589),  (0x), LockServiceDatabase, 0x00045e50, None
        *   1418 (0x058a),  (0x), LogonUserA, 0x00048b80, None
        *   1419 (0x058b),  (0x), LogonUserExA, 0x00048cc0, None
        1420 (0x058c),  (0x), LogonUserExExW, 0x000351d0, None
        *   1421 (0x058d),  (0x), LogonUserExW, 0x00048d00, None
        *   1422 (0x058e),  (0x), LogonUserW, 0x00023f50, None
        *   1423 (0x058f),  (0x), LookupAccountNameA, 0x000465e0, None
        *   1424 (0x0590),  (0x), LookupAccountNameW, 0x0001f390, None
        *   1425 (0x0591),  (0x), LookupAccountSidA, 0x000469e0, None
        *   1426 (0x0592),  (0x), LookupAccountSidW, 0x0001ec60, None
        *   1427 (0x0593),  (0x), LookupPrivilegeDisplayNameA, 0x00046f60, None
        *   1428 (0x0594),  (0x), LookupPrivilegeDisplayNameW, 0x000470e0, None
        *   1429 (0x0595),  (0x), LookupPrivilegeNameA, 0x00047240, None
        *   1430 (0x0596),  (0x), LookupPrivilegeNameW, 0x00047370, None
        *   1431 (0x0597),  (0x), LookupPrivilegeValueA, 0x00024440, None
        *   1432 (0x0598),  (0x), LookupPrivilegeValueW, 0x00019fd0, None
        *   1433 (0x0599),  (0x), LookupSecurityDescriptorPartsA, 0x000403a0, None
        *   1434 (0x059a),  (0x), LookupSecurityDescriptorPartsW, 0x000405c0, None
        *   1435 (0x059b),  (0x), LsaAddAccountRights, 0x000351f0, None
        *   1436 (0x059c),  (0x), LsaAddPrivilegesToAccount, 0x00036960, None
        *   1437 (0x059d),  (0x), LsaClearAuditLog, 0x000369f0, None
        *   1438 (0x059e),  (0x), LsaClose, 0x00035210, None
        *   1439 (0x059f),  (0x), LsaCreateAccount, 0x00036a70, None
        *   1440 (0x05a0),  (0x), LsaCreateSecret, 0x00035230, None
        *   1441 (0x05a1),  (0x), LsaCreateTrustedDomain, 0x00036b30, None
        *   1442 (0x05a2),  (0x), LsaCreateTrustedDomainEx, 0x000382d0, None
        *   1443 (0x05a3),  (0x), LsaDelete, 0x00035250, None
        *   1444 (0x05a4),  (0x), LsaDeleteTrustedDomain, 0x00038420, None
        *   1445 (0x05a5),  (0x), LsaEnumerateAccountRights, 0x00035270, None
        *   1446 (0x05a6),  (0x), LsaEnumerateAccounts, 0x00036bf0, None
        *   1447 (0x05a7),  (0x), LsaEnumerateAccountsWithUserRight, 0x00035290, None
        *   1448 (0x05a8),  (0x), LsaEnumeratePrivileges, 0x00036cb0, None
        *   1449 (0x05a9),  (0x), LsaEnumeratePrivilegesOfAccount, 0x00036d70, None
        *   1450 (0x05aa),  (0x), LsaEnumerateTrustedDomains, 0x00036e00, None
        *   1451 (0x05ab),  (0x), LsaEnumerateTrustedDomainsEx, 0x000384b0, None
        *   1452 (0x05ac),  (0x), LsaFreeMemory, 0x000352b0, None
        *   1453 (0x05ad),  (0x), LsaGetAppliedCAPIDs, 0x00036ed0, None
        *   1454 (0x05ae),  (0x), LsaGetQuotasForAccount, 0x00036ff0, None
        *   1455 (0x05af),  (0x), LsaGetRemoteUserName, 0x00037080, None
        *   1456 (0x05b0),  (0x), LsaGetSystemAccessAccount, 0x000371b0, None
        *   1457 (0x05b1),  (0x), LsaGetUserName, 0x00019f20, None
        *   1458 (0x05b2),  (0x), LsaICLookupNames, 0x000352d0, None
        *   1459 (0x05b3),  (0x), LsaICLookupNamesWithCreds, 0x00035310, None
        *   1460 (0x05b4),  (0x), LsaICLookupSids, 0x00035350, None
        *   1461 (0x05b5),  (0x), LsaICLookupSidsWithCreds, 0x00035380, None
        *   1462 (0x05b6),  (0x), LsaInvokeTrustScanner, 0x00025970, None
        *   1463 (0x05b7),  (0x), LsaLookupNames2, 0x000353c0, None
        *   1464 (0x05b8),  (0x), LsaLookupNames, 0x00037240, None
        *   1465 (0x05b9),  (0x), LsaLookupPrivilegeDisplayName, 0x00037360, None
        *   1466 (0x05ba),  (0x), LsaLookupPrivilegeName, 0x00037620, None
        *   1467 (0x05bb),  (0x), LsaLookupPrivilegeValue, 0x0001a1f0, None
        *   1468 (0x05bc),  (0x), LsaLookupSids2, 0x000353f0, None
        *   1469 (0x05bd),  (0x), LsaLookupSids, 0x00035420, None
        *   1470 (0x05be),  (0x), LsaManageSidNameMapping, 0x00038580, None
        *   1471 (0x05bf),  (0x), LsaNtStatusToWinError, 0x0001e870, None
        *   1472 (0x05c0),  (0x), LsaOpenAccount, 0x000376d0, None
        *   1473 (0x05c1),  (0x), LsaOpenPolicy, 0x00035450, None
        *   1474 (0x05c2),  (0x), LsaOpenPolicySce, 0x00037790, None
        *   1475 (0x05c3),  (0x), LsaOpenSecret, 0x00035470, None
        *   1476 (0x05c4),  (0x), LsaOpenTrustedDomain, 0x00037860, None
        *   1477 (0x05c5),  (0x), LsaOpenTrustedDomainByName, 0x00038650, None
        *   1478 (0x05c6),  (0x), LsaQueryCAPs, 0x00037920, None
        *   1479 (0x05c7),  (0x), LsaQueryDomainInformationPolicy, 0x00038710, None
        *   1480 (0x05c8),  (0x), LsaQueryForestTrustInformation2, 0x000259f0, None
        *   1481 (0x05c9),  (0x), LsaQueryForestTrustInformation, 0x000387b0, None
        *   1482 (0x05ca),  (0x), LsaQueryInfoTrustedDomain, 0x00037a30, None
        *   1483 (0x05cb),  (0x), LsaQueryInformationPolicy, 0x00035490, None
        *   1484 (0x05cc),  (0x), LsaQuerySecret, 0x000354b0, None
        *   1485 (0x05cd),  (0x), LsaQuerySecurityObject, 0x00037b00, None
        *   1486 (0x05ce),  (0x), LsaQueryTrustedDomainInfo, 0x00038850, None
        *   1487 (0x05cf),  (0x), LsaQueryTrustedDomainInfoByName, 0x00038920, None
        *   1488 (0x05d0),  (0x), LsaRemoveAccountRights, 0x000354e0, None
        *   1489 (0x05d1),  (0x), LsaRemovePrivilegesFromAccount, 0x00037bb0, None
        *   1490 (0x05d2),  (0x), LsaRetrievePrivateData, 0x00035510, None
        *   1491 (0x05d3),  (0x), LsaSetCAPs, 0x00037c40, None
        *   1492 (0x05d4),  (0x), LsaSetDomainInformationPolicy, 0x000389d0, None
        *   1493 (0x05d5),  (0x), LsaSetForestTrustInformation2, 0x00025a90, None
        *   1494 (0x05d6),  (0x), LsaSetForestTrustInformation, 0x00038a70, None
        *   1495 (0x05d7),  (0x), LsaSetInformationPolicy, 0x00035530, None
        *   1496 (0x05d8),  (0x), LsaSetInformationTrustedDomain, 0x00037d30, None
        *   1497 (0x05d9),  (0x), LsaSetQuotasForAccount, 0x00038010, None
        *   1498 (0x05da),  (0x), LsaSetSecret, 0x00035550, None
        *   1499 (0x05db),  (0x), LsaSetSecurityObject, 0x000380a0, None
        *   1500 (0x05dc),  (0x), LsaSetSystemAccessAccount, 0x000381a0, None
        *   1501 (0x05dd),  (0x), LsaSetTrustedDomainInfoByName, 0x00038b10, None
        *   1502 (0x05de),  (0x), LsaSetTrustedDomainInformation, 0x00038e00, None
        *   1503 (0x05df),  (0x), LsaStorePrivateData, 0x00035570, None
        1504 (0x05e0),  (0x), MD4Final, NTDLL.MD4Final, None
        1505 (0x05e1),  (0x), MD4Init, NTDLL.MD4Init, None
        1506 (0x05e2),  (0x), MD4Update, NTDLL.MD4Update, None
        1507 (0x05e3),  (0x), MD5Final, NTDLL.MD5Final, None
        1508 (0x05e4),  (0x), MD5Init, NTDLL.MD5Init, None
        1509 (0x05e5),  (0x), MD5Update, NTDLL.MD5Update, None
        1510 (0x05e6),  (0x), MIDL_user_free_Ext, 0x000362c0, None
        1511 (0x05e7),  (0x), MSChapSrvChangePassword2, 0x00035c90, None
        1512 (0x05e8),  (0x), MSChapSrvChangePassword, 0x00035d20, None
        1513 (0x05e9),  (0x), MakeAbsoluteSD2, 0x00035590, None
        *   1514 (0x05ea),  (0x), MakeAbsoluteSD, 0x00024d30, None
        *   1515 (0x05eb),  (0x), MakeSelfRelativeSD, 0x000355b0, None
        *   1516 (0x05ec),  (0x), MapGenericMask, 0x000355d0, None
        *   1517 (0x05ed),  (0x), NotifyBootConfigStatus, 0x00023ef0, None
        *   1518 (0x05ee),  (0x), NotifyChangeEventLog, 0x0004f890, None
        1519 (0x05ef),  (0x), NotifyServiceStatusChange, 0x00025410, None
        *   1520 (0x05f0),  (0x), NotifyServiceStatusChangeA, 0x000355e0, None
        *   1521 (0x05f1),  (0x), NotifyServiceStatusChangeW, 0x00024e30, None
        1522 (0x05f2),  (0x), NpGetUserName, 0x00048d40, None
        *   1523 (0x05f3),  (0x), ObjectCloseAuditAlarmA, 0x000474c0, None
        *   1524 (0x05f4),  (0x), ObjectCloseAuditAlarmW, 0x00035600, None
        *   1525 (0x05f5),  (0x), ObjectDeleteAuditAlarmA, 0x00047520, None
        *   1526 (0x05f6),  (0x), ObjectDeleteAuditAlarmW, 0x00035620, None
        *   1527 (0x05f7),  (0x), ObjectOpenAuditAlarmA, 0x00047580, None
        *   1528 (0x05f8),  (0x), ObjectOpenAuditAlarmW, 0x00035640, None
        *   1529 (0x05f9),  (0x), ObjectPrivilegeAuditAlarmA, 0x00047690, None
        *   1530 (0x05fa),  (0x), ObjectPrivilegeAuditAlarmW, 0x00035660, None
        *   1531 (0x05fb),  (0x), OpenBackupEventLogA, 0x0004f8d0, None
        *   1532 (0x05fc),  (0x), OpenBackupEventLogW, 0x0004f9a0, None
        1533 (0x05fd),  (0x), OpenEncryptedFileRawA, 0x00033ca0, None
        1534 (0x05fe),  (0x), OpenEncryptedFileRawW, 0x00033d40, None
        *   1535 (0x05ff),  (0x), OpenEventLogA, 0x0004fa50, None
        *   1536 (0x0600),  (0x), OpenEventLogW, 0x00023b00, None
        1537 (0x0601),  (0x), OpenProcessToken, 0x0001ea00, None
        *   1538 (0x0602),  (0x), OpenSCManagerA, 0x00020570, None
        *   1539 (0x0603),  (0x), OpenSCManagerW, 0x000203d0, None
        *   1540 (0x0604),  (0x), OpenServiceA, 0x00035680, None
        *   1541 (0x0605),  (0x), OpenServiceW, 0x000203f0, None
        1542 (0x0606),  (0x), OpenThreadToken, 0x0001e890, None
        1543 (0x0607),  (0x), OpenThreadWaitChainSession, 0x0005bb40, None
        *   1544 (0x0608),  (0x), OpenTraceA, 0x00043b30, None
        *   1545 (0x0609),  (0x), OpenTraceW, 0x00020460, None
        *   1546 (0x060a),  (0x), OperationEnd, 0x00036160, None
        *   1547 (0x060b),  (0x), OperationStart, 0x00036210, None
        1548 (0x060c),  (0x), PerfAddCounters, 0x00010330, None
        1549 (0x060d),  (0x), PerfCloseQueryHandle, 0x00010550, None
        1550 (0x060e),  (0x), PerfCreateInstance, api-ms-win-core-perfcounters-l1-2-0.PerfCreateInstance, None
        1551 (0x060f),  (0x), PerfDecrementULongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfDecrementULongCounterValue, None
        1552 (0x0610),  (0x), PerfDecrementULongLongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfDecrementULongLongCounterValue, None
        1553 (0x0611),  (0x), PerfDeleteCounters, 0x000442b0, None
        1554 (0x0612),  (0x), PerfDeleteInstance, api-ms-win-core-perfcounters-l1-2-0.PerfDeleteInstance, None
        1555 (0x0613),  (0x), PerfEnumerateCounterSet, 0x00018220, None
        1556 (0x0614),  (0x), PerfEnumerateCounterSetInstances, 0x00011ac0, None
        1557 (0x0615),  (0x), PerfIncrementULongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfIncrementULongCounterValue, None
        1558 (0x0616),  (0x), PerfIncrementULongLongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfIncrementULongLongCounterValue, None
        1559 (0x0617),  (0x), PerfOpenQueryHandle, 0x00011d70, None
        1560 (0x0618),  (0x), PerfQueryCounterData, 0x00010b50, None
        1561 (0x0619),  (0x), PerfQueryCounterInfo, 0x000103d0, None
        1562 (0x061a),  (0x), PerfQueryCounterSetRegistrationInfo, 0x000182d0, None
        1563 (0x061b),  (0x), PerfQueryInstance, api-ms-win-core-perfcounters-l1-2-0.PerfQueryInstance, None
        1564 (0x061c),  (0x), PerfRegCloseKey, 0x000233c0, None
        1565 (0x061d),  (0x), PerfRegEnumKey, 0x00050d70, None
        1566 (0x061e),  (0x), PerfRegEnumValue, 0x00050dc0, None
        1567 (0x061f),  (0x), PerfRegQueryInfoKey, 0x00021300, None
        1568 (0x0620),  (0x), PerfRegQueryValue, 0x00012d20, None
        1569 (0x0621),  (0x), PerfRegSetValue, 0x00050eb0, None
        1570 (0x0622),  (0x), PerfSetCounterRefValue, api-ms-win-core-perfcounters-l1-2-0.PerfSetCounterRefValue, None
        1571 (0x0623),  (0x), PerfSetCounterSetInfo, api-ms-win-core-perfcounters-l1-2-0.PerfSetCounterSetInfo, None
        1572 (0x0624),  (0x), PerfSetULongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfSetULongCounterValue, None
        1573 (0x0625),  (0x), PerfSetULongLongCounterValue, api-ms-win-core-perfcounters-l1-2-0.PerfSetULongLongCounterValue, None
        1574 (0x0626),  (0x), PerfStartProvider, api-ms-win-core-perfcounters-l1-2-0.PerfStartProvider, None
        1575 (0x0627),  (0x), PerfStartProviderEx, api-ms-win-core-perfcounters-l1-2-0.PerfStartProviderEx, None
        1576 (0x0628),  (0x), PerfStopProvider, api-ms-win-core-perfcounters-l1-2-0.PerfStopProvider, None
        *   1577 (0x0629),  (0x), PrivilegeCheck, 0x000356a0, None
        *   1578 (0x062a),  (0x), PrivilegedServiceAuditAlarmA, 0x00047700, None
        *   1579 (0x062b),  (0x), PrivilegedServiceAuditAlarmW, 0x000356c0, None
        1580 (0x062c),  (0x), ProcessIdleTasks, 0x000362d0, None
        1581 (0x062d),  (0x), ProcessIdleTasksW, 0x00036360, None
        *   1582 (0x062e),  (0x), ProcessTrace, 0x000202f0, None
        *   1583 (0x062f),  (0x), QueryAllTracesA, 0x00025390, None
        *   1584 (0x0630),  (0x), QueryAllTracesW, 0x000356e0, None
        1585 (0x0631),  (0x), QueryLocalUserServiceName, 0x00025440, None
        *   1586 (0x0632),  (0x), QueryRecoveryAgentsOnEncryptedFile, 0x00033d90, None
        *   1587 (0x0633),  (0x), QuerySecurityAccessMask, 0x00035700, None
        *   1588 (0x0634),  (0x), QueryServiceConfig2A, 0x00035710, None
        *   1589 (0x0635),  (0x), QueryServiceConfig2W, 0x00024dd0, None
        *   1590 (0x0636),  (0x), QueryServiceConfigA, 0x00035730, None
        *   1591 (0x0637),  (0x), QueryServiceConfigW, 0x000238a0, None
        *   1592 (0x0638),  (0x), QueryServiceDynamicInformation, 0x00035750, None
        *   1593 (0x0639),  (0x), QueryServiceLockStatusA, 0x00045ee0, None
        *   1594 (0x063a),  (0x), QueryServiceLockStatusW, 0x00045f80, None
        *   1595 (0x063b),  (0x), QueryServiceObjectSecurity, 0x00035770, None
        *   1596 (0x063c),  (0x), QueryServiceStatus, 0x00023920, None
        *   1597 (0x063d),  (0x), QueryServiceStatusEx, 0x00020550, None
        *   1598 (0x063e),  (0x), QueryTraceA, 0x000439f0, None
        *   1599 (0x063f),  (0x), QueryTraceProcessingHandle, 0x00035790, None
        *   1600 (0x0640),  (0x), QueryTraceW, 0x000121a0, None
        1601 (0x0641),  (0x), QueryUserServiceName, 0x00025450, None
        1602 (0x0642),  (0x), QueryUserServiceNameForContext, 0x00025460, None
        *   1603 (0x0643),  (0x), QueryUsersOnEncryptedFile, 0x00033df0, None
        1604 (0x0644),  (0x), ReadEncryptedFileRaw, 0x00033e50, None
        *   1605 (0x0645),  (0x), ReadEventLogA, 0x0004fac0, None
        *   1606 (0x0646),  (0x), ReadEventLogW, 0x0004fb20, None
        *   1607 (0x0647),  (0x), RegCloseKey, 0x0001eaf0, None
        *   1608 (0x0648),  (0x), RegConnectRegistryA, 0x000445e0, None
        *   1609 (0x0649),  (0x), RegConnectRegistryExA, 0x00044600, None
        *   1610 (0x064a),  (0x), RegConnectRegistryExW, 0x00024bf0, None
        *   1611 (0x064b),  (0x), RegConnectRegistryW, 0x00024bd0, None
        *   1612 (0x064c),  (0x), RegCopyTreeA, 0x00044880, None
        *   1613 (0x064d),  (0x), RegCopyTreeW, 0x000357c0, None
        *   1614 (0x064e),  (0x), RegCreateKeyA, 0x00022e20, None
        *   1615 (0x064f),  (0x), RegCreateKeyExA, 0x0001ef20, None
        *   1616 (0x0650),  (0x), RegCreateKeyExW, 0x0001ec00, None
        *   1617 (0x0651),  (0x), RegCreateKeyTransactedA, 0x000448e0, None
        *   1618 (0x0652),  (0x), RegCreateKeyTransactedW, 0x000237d0, None
        *   1619 (0x0653),  (0x), RegCreateKeyW, 0x0001f430, None
        *   1620 (0x0654),  (0x), RegDeleteKeyA, 0x0001f080, None
        *   1621 (0x0655),  (0x), RegDeleteKeyExA, 0x000357e0, None
        *   1622 (0x0656),  (0x), RegDeleteKeyExW, 0x000223f0, None
        *   1623 (0x0657),  (0x), RegDeleteKeyTransactedA, 0x00044ac0, None
        *   1624 (0x0658),  (0x), RegDeleteKeyTransactedW, 0x00022b50, None
        *   1625 (0x0659),  (0x), RegDeleteKeyValueA, 0x00035800, None
        *   1626 (0x065a),  (0x), RegDeleteKeyValueW, 0x00035820, None
        *   1627 (0x065b),  (0x), RegDeleteKeyW, 0x0001f0d0, None
        *   1628 (0x065c),  (0x), RegDeleteTreeA, 0x00035840, None
        *   1629 (0x065d),  (0x), RegDeleteTreeW, 0x00024590, None
        *   1630 (0x065e),  (0x), RegDeleteValueA, 0x000204a0, None
        *   1631 (0x065f),  (0x), RegDeleteValueW, 0x00020210, None
        *   1632 (0x0660),  (0x), RegDisablePredefinedCache, 0x00020530, None
        *   1633 (0x0661),  (0x), RegDisablePredefinedCacheEx, 0x00035860, None
        *   1634 (0x0662),  (0x), RegDisableReflectionKey, 0x000212a0, None
        *   1635 (0x0663),  (0x), RegEnableReflectionKey, 0x000212a0, None
        *   1636 (0x0664),  (0x), RegEnumKeyA, 0x00022e70, None
        *   1637 (0x0665),  (0x), RegEnumKeyExA, 0x00022a80, None
        *   1638 (0x0666),  (0x), RegEnumKeyExW, 0x0001eaa0, None
        *   1639 (0x0667),  (0x), RegEnumKeyW, 0x0001eb30, None
        *   1640 (0x0668),  (0x), RegEnumValueA, 0x00022a60, None
        *   1641 (0x0669),  (0x), RegEnumValueW, 0x0001eb70, None
        *   1642 (0x066a),  (0x), RegFlushKey, 0x00020670, None
        *   1643 (0x066b),  (0x), RegGetKeySecurity, 0x00035870, None
        *   1644 (0x066c),  (0x), RegGetValueA, 0x00035890, None
        *   1645 (0x066d),  (0x), RegGetValueW, 0x00020120, None
        *   1646 (0x066e),  (0x), RegLoadAppKeyA, 0x000358b0, None
        *   1647 (0x066f),  (0x), RegLoadAppKeyW, 0x000358d0, None
        *   1648 (0x0670),  (0x), RegLoadKeyA, 0x000358f0, None
        *   1649 (0x0671),  (0x), RegLoadKeyW, 0x00035910, None
        *   1650 (0x0672),  (0x), RegLoadMUIStringA, 0x00035930, None
        *   1651 (0x0673),  (0x), RegLoadMUIStringW, 0x00035950, None
        *   1652 (0x0674),  (0x), RegNotifyChangeKeyValue, 0x00020050, None
        *   1653 (0x0675),  (0x), RegOpenCurrentUser, 0x00020480, None
        *   1654 (0x0676),  (0x), RegOpenKeyA, 0x000200b0, None
        *   1655 (0x0677),  (0x), RegOpenKeyExA, 0x0001ebe0, None
        *   1656 (0x0678),  (0x), RegOpenKeyExW, 0x0001e980, None
        *   1657 (0x0679),  (0x), RegOpenKeyTransactedA, 0x00044940, None
        *   1658 (0x067a),  (0x), RegOpenKeyTransactedW, 0x00023830, None
        *   1659 (0x067b),  (0x), RegOpenKeyW, 0x0001ed00, None
        *   1660 (0x067c),  (0x), RegOpenUserClassesRoot, 0x00035970, None
        *   1661 (0x067d),  (0x), RegOverridePredefKey, 0x00044990, None
        *   1662 (0x067e),  (0x), RegQueryInfoKeyA, 0x0001fac0, None
        *   1663 (0x067f),  (0x), RegQueryInfoKeyW, 0x0001ead0, None
        *   1664 (0x0680),  (0x), RegQueryMultipleValuesA, 0x00035990, None
        *   1665 (0x0681),  (0x), RegQueryMultipleValuesW, 0x000359b0, None
        *   1666 (0x0682),  (0x), RegQueryReflectionKey, 0x00036140, None
        *   1667 (0x0683),  (0x), RegQueryValueA, 0x000120a0, None
        *   1668 (0x0684),  (0x), RegQueryValueExA, 0x0001ea20, None
        *   1669 (0x0685),  (0x), RegQueryValueExW, 0x0001e8b0, None
        *   1670 (0x0686),  (0x), RegQueryValueW, 0x0001edb0, None
        *   1671 (0x0687),  (0x), RegRenameKey, 0x00044a50, None
        *   1672 (0x0688),  (0x), RegReplaceKeyA, 0x00044de0, None
        *   1673 (0x0689),  (0x), RegReplaceKeyW, 0x00045790, None
        *   1674 (0x068a),  (0x), RegRestoreKeyA, 0x000359d0, None
        *   1675 (0x068b),  (0x), RegRestoreKeyW, 0x000359f0, None
        *   1676 (0x068c),  (0x), RegSaveKeyA, 0x00045020, None
        *   1677 (0x068d),  (0x), RegSaveKeyExA, 0x00035a10, None
        *   1678 (0x068e),  (0x), RegSaveKeyExW, 0x00035a30, None
        *   1679 (0x068f),  (0x), RegSaveKeyW, 0x00045190, None
        *   1680 (0x0690),  (0x), RegSetKeySecurity, 0x00035a50, None
        *   1681 (0x0691),  (0x), RegSetKeyValueA, 0x00035a70, None
        *   1682 (0x0692),  (0x), RegSetKeyValueW, 0x00024510, None
        *   1683 (0x0693),  (0x), RegSetValueA, 0x000452d0, None
        *   1684 (0x0694),  (0x), RegSetValueExA, 0x00020090, None
        *   1685 (0x0695),  (0x), RegSetValueExW, 0x0001ebc0, None
        *   1686 (0x0696),  (0x), RegSetValueW, 0x000453c0, None
        *   1687 (0x0697),  (0x), RegUnLoadKeyA, 0x00035a90, None
        *   1688 (0x0698),  (0x), RegUnLoadKeyW, 0x00035ab0, None
        *   1689 (0x0699),  (0x), RegisterEventSourceA, 0x00022eb0, None
        *   1690 (0x069a),  (0x), RegisterEventSourceW, 0x00020900, None
        1691 (0x069b),  (0x), RegisterIdleTask, 0x00024930, None
        *   1692 (0x069c),  (0x), RegisterServiceCtrlHandlerA, 0x00035ad0, None
        *   1693 (0x069d),  (0x), RegisterServiceCtrlHandlerExA, 0x00024e10, None
        *   1694 (0x069e),  (0x), RegisterServiceCtrlHandlerExW, 0x00024570, None
        *   1695 (0x069f),  (0x), RegisterServiceCtrlHandlerW, 0x000206d0, None
        *   1696 (0x06a0),  (0x), RegisterTraceGuidsA, ntdll.EtwRegisterTraceGuidsA, None
        *   1697 (0x06a1),  (0x), RegisterTraceGuidsW, ntdll.EtwRegisterTraceGuidsW, None
        1698 (0x06a2),  (0x), RegisterWaitChainCOMCallback, 0x0005bc00, None
        1699 (0x06a3),  (0x), RemoteRegEnumKeyWrapper, 0x00044b10, None
        1700 (0x06a4),  (0x), RemoteRegEnumValueWrapper, 0x00044c30, None
        1701 (0x06a5),  (0x), RemoteRegQueryInfoKeyWrapper, 0x00044ce0, None
        1702 (0x06a6),  (0x), RemoteRegQueryMultipleValues2Wrapper, 0x000454c0, None
        1703 (0x06a7),  (0x), RemoteRegQueryMultipleValuesWrapper, 0x000455b0, None
        1704 (0x06a8),  (0x), RemoteRegQueryValueWrapper, 0x00044d90, None
        *   1705 (0x06a9),  (0x), RemoveTraceCallback, sechost.RemoveTraceCallback, None
        *   1706 (0x06aa),  (0x), RemoveUsersFromEncryptedFile, 0x00033e80, None
        1707 (0x06ab),  (0x), ReportEventA, 0x0004fb80, None
        1708 (0x06ac),  (0x), ReportEventW, 0x00020c90, None
        *   1709 (0x06ad),  (0x), RevertToSelf, 0x0001f7b0, None
        1710 (0x06ae),  (0x), SafeBaseRegGetKeySecurity, 0x00044280, None
        1711 (0x06af),  (0x), SaferCloseLevel, 0x0001e8e0, None
        1712 (0x06b0),  (0x), SaferComputeTokenFromLevel, 0x0001b560, None
        1713 (0x06b1),  (0x), SaferCreateLevel, 0x0003ade0, None
        1714 (0x06b2),  (0x), SaferGetLevelInformation, 0x0003b360, None
        1715 (0x06b3),  (0x), SaferGetPolicyInformation, 0x0001bbc0, None
        1716 (0x06b4),  (0x), SaferIdentifyLevel, 0x0001bd30, None
        1717 (0x06b5),  (0x), SaferRecordEventLogEntry, 0x0003c930, None
        1718 (0x06b6),  (0x), SaferSetLevelInformation, 0x0003cf30, None
        1719 (0x06b7),  (0x), SaferSetPolicyInformation, 0x0003bcb0, None
        1720 (0x06b8),  (0x), SaferiChangeRegistryScope, 0x0003de80, None
        1721 (0x06b9),  (0x), SaferiCompareTokenLevels, 0x0001aea0, None
        1722 (0x06ba),  (0x), SaferiIsDllAllowed, 0x0003c230, None
        1723 (0x06bb),  (0x), SaferiIsExecutableFileType, 0x0003e3e0, None
        1724 (0x06bc),  (0x), SaferiPopulateDefaultsInRegistry, 0x0003dec0, None
        1725 (0x06bd),  (0x), SaferiRecordEventLogEntry, 0x0003c930, None
        1726 (0x06be),  (0x), SaferiSearchMatchingHashRules, 0x0001fa50, None
        *   1727 (0x06bf),  (0x), SetAclInformation, 0x00035af0, None
        1728 (0x06c0),  (0x), SetEncryptedFileMetadata, 0x00033ee0, None
        1729 (0x06c1),  (0x), SetEntriesInAccessListA, 0x00041df0, None
        1730 (0x06c2),  (0x), SetEntriesInAccessListW, 0x00041e30, None
        *   1731 (0x06c3),  (0x), SetEntriesInAclA, 0x00024830, None
        *   1732 (0x06c4),  (0x), SetEntriesInAclW, 0x00020510, None
        1733 (0x06c5),  (0x), SetEntriesInAuditListA, 0x00041e70, None
        1734 (0x06c6),  (0x), SetEntriesInAuditListW, 0x00041ea0, None
        *   1735 (0x06c7),  (0x), SetFileSecurityA, 0x000477a0, None
        *   1736 (0x06c8),  (0x), SetFileSecurityW, 0x00024df0, None
        1737 (0x06c9),  (0x), SetInformationCodeAuthzLevelW, 0x0003cf30, None
        1738 (0x06ca),  (0x), SetInformationCodeAuthzPolicyW, 0x0003bcb0, None
        *   1739 (0x06cb),  (0x), SetKernelObjectSecurity, 0x000206f0, None
        *   1740 (0x06cc),  (0x), SetNamedSecurityInfoA, 0x00024600, None
        1741 (0x06cd),  (0x), SetNamedSecurityInfoExA, 0x00041ed0, None
        1742 (0x06ce),  (0x), SetNamedSecurityInfoExW, 0x000421f0, None
        *   1743 (0x06cf),  (0x), SetNamedSecurityInfoW, 0x00035b10, None
        *   1744 (0x06d0),  (0x), SetPrivateObjectSecurity, 0x00035b50, None
        *   1745 (0x06d1),  (0x), SetPrivateObjectSecurityEx, 0x00035b30, None
        *   1746 (0x06d2),  (0x), SetSecurityAccessMask, 0x00035b70, None
        *   1747 (0x06d3),  (0x), SetSecurityDescriptorControl, 0x00035b80, None
        *   1748 (0x06d4),  (0x), SetSecurityDescriptorDacl, 0x0001f020, None
        *   1749 (0x06d5),  (0x), SetSecurityDescriptorGroup, 0x000245d0, None
        *   1750 (0x06d6),  (0x), SetSecurityDescriptorOwner, 0x0001fb20, None
        *   1751 (0x06d7),  (0x), SetSecurityDescriptorRMControl, 0x00035ba0, None
        *   1752 (0x06d8),  (0x), SetSecurityDescriptorSacl, 0x00035bc0, None
        *   1753 (0x06d9),  (0x), SetSecurityInfo, 0x00020070, None
        1754 (0x06da),  (0x), SetSecurityInfoExA, 0x00042410, None
        1755 (0x06db),  (0x), SetSecurityInfoExW, 0x00042700, None
        1756 (0x06dc),  (0x), SetServiceBits, 0x00046030, None
        *   1757 (0x06dd),  (0x), SetServiceObjectSecurity, 0x00035be0, None
        *   1758 (0x06de),  (0x), SetServiceStatus, 0x000203b0, None
        1759 (0x06df),  (0x), SetThreadToken, 0x0001ed90, None
        *   1760 (0x06e0),  (0x), SetTokenInformation, 0x00024530, None
        *   1761 (0x06e1),  (0x), SetTraceCallback, sechost.SetTraceCallback, None
        *   1762 (0x06e2),  (0x), SetUserFileEncryptionKey, 0x00033ef0, None
        1763 (0x06e3),  (0x), SetUserFileEncryptionKeyEx, 0x00033f40, None
        *   1764 (0x06e4),  (0x), StartServiceA, 0x00035c00, None
        *   1765 (0x06e5),  (0x), StartServiceCtrlDispatcherA, 0x00024e50, None
        *   1766 (0x06e6),  (0x), StartServiceCtrlDispatcherW, 0x000206b0, None
        *   1767 (0x06e7),  (0x), StartServiceW, 0x00024db0, None
        *   1768 (0x06e8),  (0x), StartTraceA, 0x000253a0, None
        *   1769 (0x06e9),  (0x), StartTraceW, 0x00023900, None
        *   1770 (0x06ea),  (0x), StopTraceA, 0x00043a20, None
        *   1771 (0x06eb),  (0x), StopTraceW, 0x00035c20, None
        1772 (0x06ec),  (0x), System();001, CRYPTBASE.System();001, None
        1773 (0x06ed),  (0x), System();002, CRYPTBASE.System();002, None
        1774 (0x06ee),  (0x), System();003, CRYPTBASE.System();003, None
        1775 (0x06ef),  (0x), System();004, CRYPTBASE.System();004, None
        1776 (0x06f0),  (0x), System();005, CRYPTBASE.System();005, None
        1777 (0x06f1),  (0x), System();006, CRYPTSP.System();006, None
        1778 (0x06f2),  (0x), System();007, CRYPTSP.System();007, None
        1779 (0x06f3),  (0x), System();008, CRYPTSP.System();008, None
        1780 (0x06f4),  (0x), System();009, CRYPTSP.System();009, None
        1781 (0x06f5),  (0x), System();010, CRYPTSP.System();010, None
        1782 (0x06f6),  (0x), System();011, CRYPTSP.System();011, None
        1783 (0x06f7),  (0x), System();012, CRYPTSP.System();012, None
        1784 (0x06f8),  (0x), System();013, CRYPTSP.System();013, None
        1785 (0x06f9),  (0x), System();014, CRYPTSP.System();014, None
        1786 (0x06fa),  (0x), System();015, CRYPTSP.System();015, None
        1787 (0x06fb),  (0x), System();016, CRYPTSP.System();016, None
        1788 (0x06fc),  (0x), System();017, 0x00036370, None
        1789 (0x06fd),  (0x), System();018, CRYPTSP.System();018, None
        1790 (0x06fe),  (0x), System();019, 0x000363b0, None
        1791 (0x06ff),  (0x), System();020, CRYPTSP.System();020, None
        1792 (0x0700),  (0x), System();021, CRYPTSP.System();021, None
        1793 (0x0701),  (0x), System();022, CRYPTSP.System();022, None
        1794 (0x0702),  (0x), System();023, CRYPTSP.System();023, None
        1795 (0x0703),  (0x), System();024, CRYPTSP.System();024, None
        1796 (0x0704),  (0x), System();025, CRYPTSP.System();025, None
        1797 (0x0705),  (0x), System();026, CRYPTSP.System();026, None
        1798 (0x0706),  (0x), System();027, CRYPTSP.System();027, None
        1799 (0x0707),  (0x), System();028, CRYPTBASE.System();028, None
        1800 (0x0708),  (0x), System();029, CRYPTBASE.System();029, None
        1801 (0x0709),  (0x), System();030, CRYPTSP.System();030, None
        1802 (0x070a),  (0x), System();031, CRYPTSP.System();031, None
        1803 (0x070b),  (0x), System();032, CRYPTSP.System();032, None
        1804 (0x070c),  (0x), System();033, CRYPTSP.System();033, None
        1805 (0x070d),  (0x), System();034, CRYPTBASE.System();034, None
        1806 (0x070e),  (0x), System();035, CRYPTSP.CheckSignatureInFile, None
        1807 (0x070f),  (0x), System();036, CRYPTBASE.System();036, None
        1808 (0x0710),  (0x), System();040, CRYPTBASE.System();040, None
        1809 (0x0711),  (0x), System();041, CRYPTBASE.System();041, None
        *   1810 (0x0712),  (0x), TraceEvent, ntdll.EtwLogTraceEvent, None
        *   1811 (0x0713),  (0x), TraceEventInstance, ntdll.EtwTraceEventInstance, None
        *   1812 (0x0714),  (0x), TraceMessage, ntdll.EtwTraceMessage, None
        *   1813 (0x0715),  (0x), TraceMessageVa, ntdll.EtwTraceMessageVa, None
        *   1814 (0x0716),  (0x), TraceQueryInformation, api-ms-win-eventing-controller-l1-1-0.TraceQueryInformation, None
        *   1815 (0x0717),  (0x), TraceSetInformation, 0x00035c40, None
        *   1816 (0x0718),  (0x), TreeResetNamedSecurityInfoA, 0x000407a0, None
        *   1817 (0x0719),  (0x), TreeResetNamedSecurityInfoW, 0x00011ef0, None
        *   1818 (0x071a),  (0x), TreeSetNamedSecurityInfoA, 0x000407a0, None
        *   1819 (0x071b),  (0x), TreeSetNamedSecurityInfoW, 0x000407b0, None
        1820 (0x071c),  (0x), TrusteeAccessToObjectA, 0x00042920, None
        1821 (0x071d),  (0x), TrusteeAccessToObjectW, 0x00042af0, None
        1822 (0x071e),  (0x), UninstallApplication, 0x00039ef0, None
        1823 (0x071f),  (0x), UnlockServiceDatabase, 0x00046070, None
        1824 (0x0720),  (0x), UnregisterIdleTask, 0x00021220, None
        *   1825 (0x0721),  (0x), UnregisterTraceGuids, ntdll.EtwUnregisterTraceGuids, None
        *   1826 (0x0722),  (0x), UpdateTraceA, 0x00043a50, None
        *   1827 (0x0723),  (0x), UpdateTraceW, 0x00043a80, None
        1828 (0x0724),  (0x), UsePinForEncryptedFilesA, 0x00033fa0, None
        1829 (0x0725),  (0x), UsePinForEncryptedFilesW, 0x00034000, None
        1830 (0x0726),  (0x), WaitServiceState, 0x00035c70, None
        1831 (0x0727),  (0x), WmiCloseBlock, 0x00023330, None
        1832 (0x0728),  (0x), WmiDevInstToInstanceNameA, 0x000558e0, None
        1833 (0x0729),  (0x), WmiDevInstToInstanceNameW, 0x000559a0, None
        1834 (0x072a),  (0x), WmiEnumerateGuids, 0x00055a70, None
        1835 (0x072b),  (0x), WmiExecuteMethodA, 0x00055c10, None
        1836 (0x072c),  (0x), WmiExecuteMethodW, 0x00055c90, None
        1837 (0x072d),  (0x), WmiFileHandleToInstanceNameA, 0x00055f90, None
        1838 (0x072e),  (0x), WmiFileHandleToInstanceNameW, 0x000561b0, None
        1839 (0x072f),  (0x), WmiFreeBuffer, 0x000563a0, None
        1840 (0x0730),  (0x), WmiMofEnumerateResourcesA, 0x00057470, None
        1841 (0x0731),  (0x), WmiMofEnumerateResourcesW, 0x00057660, None
        1842 (0x0732),  (0x), WmiNotificationRegistrationA, 0x000563e0, None
        1843 (0x0733),  (0x), WmiNotificationRegistrationW, 0x00056420, None
        1844 (0x0734),  (0x), WmiOpenBlock, 0x00022410, None
        1845 (0x0735),  (0x), WmiQueryAllDataA, 0x00056460, None
        1846 (0x0736),  (0x), WmiQueryAllDataMultipleA, 0x000564b0, None
        1847 (0x0737),  (0x), WmiQueryAllDataMultipleW, 0x00056500, None
        1848 (0x0738),  (0x), WmiQueryAllDataW, 0x000566b0, None
        1849 (0x0739),  (0x), WmiQueryGuidInformation, 0x000568a0, None
        1850 (0x073a),  (0x), WmiQuerySingleInstanceA, 0x00056950, None
        1851 (0x073b),  (0x), WmiQuerySingleInstanceMultipleA, 0x000569f0, None
        1852 (0x073c),  (0x), WmiQuerySingleInstanceMultipleW, 0x00056b50, None
        1853 (0x073d),  (0x), WmiQuerySingleInstanceW, 0x00022540, None
        1854 (0x073e),  (0x), WmiReceiveNotificationsA, 0x00056d60, None
        1855 (0x073f),  (0x), WmiReceiveNotificationsW, 0x00056da0, None
        1856 (0x0740),  (0x), WmiSetSingleInstanceA, 0x00056de0, None
        1858 (0x0742),  (0x), WmiSetSingleItemA, 0x00057000, None
        1859 (0x0743),  (0x), WmiSetSingleItemW, 0x00057080, None
        1860 (0x0744),  (0x), WriteEncryptedFileRaw, 0x00034070, None

         */

    }
}
