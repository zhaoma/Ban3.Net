using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// ntsecapi.h This header is used by Security and Identity.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/
    /// </summary>
    public static partial class ADVAPI32
    {
        /*
         
        1038 (0x040e),  (0x), AuditComputeEffectivePolicyBySid, 0x00034300, None
        1039 (0x040f),  (0x), AuditComputeEffectivePolicyByToken, 0x000363c0, None
        1040 (0x0410),  (0x), AuditEnumerateCategories, 0x00034320, None
        1041 (0x0411),  (0x), AuditEnumeratePerUserPolicy, 0x00034340, None
        1042 (0x0412),  (0x), AuditEnumerateSubCategories, 0x00034360, None
        1043 (0x0413),  (0x), AuditFree, 0x00024d20, None
        1044 (0x0414),  (0x), AuditLookupCategoryGuidFromCategoryId, 0x000364b0, None
        1045 (0x0415),  (0x), AuditLookupCategoryIdFromCategoryGuid, 0x000364f0, None
        1046 (0x0416),  (0x), AuditLookupCategoryNameA, 0x00036550, None
        1047 (0x0417),  (0x), AuditLookupCategoryNameW, 0x00034380, None
        1048 (0x0418),  (0x), AuditLookupSubCategoryNameA, 0x000365c0, None
        1049 (0x0419),  (0x), AuditLookupSubCategoryNameW, 0x000343a0, None
        1050 (0x041a),  (0x), AuditQueryGlobalSaclA, 0x00036630, None
        1051 (0x041b),  (0x), AuditQueryGlobalSaclW, 0x000343c0, None
        1052 (0x041c),  (0x), AuditQueryPerUserPolicy, 0x00024d00, None
        1053 (0x041d),  (0x), AuditQuerySecurity, 0x000343e0, None
        1054 (0x041e),  (0x), AuditQuerySystemPolicy, 0x00024cc0, None
        1055 (0x041f),  (0x), AuditSetGlobalSaclA, 0x000366b0, None
        1056 (0x0420),  (0x), AuditSetGlobalSaclW, 0x00034400, None
        1057 (0x0421),  (0x), AuditSetPerUserPolicy, 0x00034420, None
        1058 (0x0422),  (0x), AuditSetSecurity, 0x00034440, None
        1059 (0x0423),  (0x), AuditSetSystemPolicy, 0x00034460, None

        1435 (0x059b),  (0x), LsaAddAccountRights, 0x000351f0, None
        1436 (0x059c),  (0x), LsaAddPrivilegesToAccount, 0x00036960, None
        1437 (0x059d),  (0x), LsaClearAuditLog, 0x000369f0, None
        1438 (0x059e),  (0x), LsaClose, 0x00035210, None
        1439 (0x059f),  (0x), LsaCreateAccount, 0x00036a70, None
        1440 (0x05a0),  (0x), LsaCreateSecret, 0x00035230, None
        1441 (0x05a1),  (0x), LsaCreateTrustedDomain, 0x00036b30, None
        1442 (0x05a2),  (0x), LsaCreateTrustedDomainEx, 0x000382d0, None
        1443 (0x05a3),  (0x), LsaDelete, 0x00035250, None
        1444 (0x05a4),  (0x), LsaDeleteTrustedDomain, 0x00038420, None
        1445 (0x05a5),  (0x), LsaEnumerateAccountRights, 0x00035270, None
        1446 (0x05a6),  (0x), LsaEnumerateAccounts, 0x00036bf0, None
        1447 (0x05a7),  (0x), LsaEnumerateAccountsWithUserRight, 0x00035290, None
        1448 (0x05a8),  (0x), LsaEnumeratePrivileges, 0x00036cb0, None
        1449 (0x05a9),  (0x), LsaEnumeratePrivilegesOfAccount, 0x00036d70, None
        1450 (0x05aa),  (0x), LsaEnumerateTrustedDomains, 0x00036e00, None
        1451 (0x05ab),  (0x), LsaEnumerateTrustedDomainsEx, 0x000384b0, None
        1452 (0x05ac),  (0x), LsaFreeMemory, 0x000352b0, None
        1453 (0x05ad),  (0x), LsaGetAppliedCAPIDs, 0x00036ed0, None
        1454 (0x05ae),  (0x), LsaGetQuotasForAccount, 0x00036ff0, None
        1455 (0x05af),  (0x), LsaGetRemoteUserName, 0x00037080, None
        1456 (0x05b0),  (0x), LsaGetSystemAccessAccount, 0x000371b0, None
        1457 (0x05b1),  (0x), LsaGetUserName, 0x00019f20, None
        1458 (0x05b2),  (0x), LsaICLookupNames, 0x000352d0, None
        1459 (0x05b3),  (0x), LsaICLookupNamesWithCreds, 0x00035310, None
        1460 (0x05b4),  (0x), LsaICLookupSids, 0x00035350, None
        1461 (0x05b5),  (0x), LsaICLookupSidsWithCreds, 0x00035380, None
        1462 (0x05b6),  (0x), LsaInvokeTrustScanner, 0x00025970, None
        1463 (0x05b7),  (0x), LsaLookupNames2, 0x000353c0, None
        1464 (0x05b8),  (0x), LsaLookupNames, 0x00037240, None
        1465 (0x05b9),  (0x), LsaLookupPrivilegeDisplayName, 0x00037360, None
        1466 (0x05ba),  (0x), LsaLookupPrivilegeName, 0x00037620, None
        1467 (0x05bb),  (0x), LsaLookupPrivilegeValue, 0x0001a1f0, None
        1468 (0x05bc),  (0x), LsaLookupSids2, 0x000353f0, None
        1469 (0x05bd),  (0x), LsaLookupSids, 0x00035420, None
        1470 (0x05be),  (0x), LsaManageSidNameMapping, 0x00038580, None
        1471 (0x05bf),  (0x), LsaNtStatusToWinError, 0x0001e870, None
        1472 (0x05c0),  (0x), LsaOpenAccount, 0x000376d0, None
        1473 (0x05c1),  (0x), LsaOpenPolicy, 0x00035450, None
        1474 (0x05c2),  (0x), LsaOpenPolicySce, 0x00037790, None
        1475 (0x05c3),  (0x), LsaOpenSecret, 0x00035470, None
        1476 (0x05c4),  (0x), LsaOpenTrustedDomain, 0x00037860, None
        1477 (0x05c5),  (0x), LsaOpenTrustedDomainByName, 0x00038650, None
        1478 (0x05c6),  (0x), LsaQueryCAPs, 0x00037920, None
        1479 (0x05c7),  (0x), LsaQueryDomainInformationPolicy, 0x00038710, None
        1480 (0x05c8),  (0x), LsaQueryForestTrustInformation2, 0x000259f0, None
        1481 (0x05c9),  (0x), LsaQueryForestTrustInformation, 0x000387b0, None
        1482 (0x05ca),  (0x), LsaQueryInfoTrustedDomain, 0x00037a30, None
        1483 (0x05cb),  (0x), LsaQueryInformationPolicy, 0x00035490, None
        1484 (0x05cc),  (0x), LsaQuerySecret, 0x000354b0, None
        1485 (0x05cd),  (0x), LsaQuerySecurityObject, 0x00037b00, None
        1486 (0x05ce),  (0x), LsaQueryTrustedDomainInfo, 0x00038850, None
        1487 (0x05cf),  (0x), LsaQueryTrustedDomainInfoByName, 0x00038920, None
        1488 (0x05d0),  (0x), LsaRemoveAccountRights, 0x000354e0, None
        1489 (0x05d1),  (0x), LsaRemovePrivilegesFromAccount, 0x00037bb0, None
        1490 (0x05d2),  (0x), LsaRetrievePrivateData, 0x00035510, None
        1491 (0x05d3),  (0x), LsaSetCAPs, 0x00037c40, None
        1492 (0x05d4),  (0x), LsaSetDomainInformationPolicy, 0x000389d0, None
        1493 (0x05d5),  (0x), LsaSetForestTrustInformation2, 0x00025a90, None
        1494 (0x05d6),  (0x), LsaSetForestTrustInformation, 0x00038a70, None
        1495 (0x05d7),  (0x), LsaSetInformationPolicy, 0x00035530, None
        1496 (0x05d8),  (0x), LsaSetInformationTrustedDomain, 0x00037d30, None
        1497 (0x05d9),  (0x), LsaSetQuotasForAccount, 0x00038010, None
        1498 (0x05da),  (0x), LsaSetSecret, 0x00035550, None
        1499 (0x05db),  (0x), LsaSetSecurityObject, 0x000380a0, None
        1500 (0x05dc),  (0x), LsaSetSystemAccessAccount, 0x000381a0, None
        1501 (0x05dd),  (0x), LsaSetTrustedDomainInfoByName, 0x00038b10, None
        1502 (0x05de),  (0x), LsaSetTrustedDomainInformation, 0x00038e00, None
        1503 (0x05df),  (0x), LsaStorePrivateData, 0x00035570, None

         */
    }
}
