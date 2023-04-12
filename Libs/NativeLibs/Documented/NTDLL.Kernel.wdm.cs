using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class NTDLL
    {
        /*
         
        272 (0x0110),  (0x), NtCommitComplete, 0x00073450, None
        273 (0x0111),  (0x), NtCommitEnlistment, 0x00073460, None
        275 (0x0113),  (0x), NtCommitTransaction, 0x00073480, None
        292 (0x0124),  (0x), NtCreateEnlistment, 0x00073580, None
        316 (0x013c),  (0x), NtCreateResourceManager, 0x000736c0, None
        327 (0x0147),  (0x), NtCreateTransaction, 0x00073750, None
        328 (0x0148),  (0x), NtCreateTransactionManager, 0x00073760, None
        360 (0x0168),  (0x), NtEnumerateTransactionObject, 0x00073900, None
        390 (0x0186),  (0x), NtGetNotificationResourceManager, 0x00073a90, None
        417 (0x01a1),  (0x), NtManagePartition, 0x00073c00, None
        431 (0x01af),  (0x), NtOpenEnlistment, 0x00073cb0, None
        450 (0x01c2),  (0x), NtOpenResourceManager, 0x00073d90, None
        459 (0x01cb),  (0x), NtOpenTransaction, 0x00073df0, None
        460 (0x01cc),  (0x), NtOpenTransactionManager, 0x00073e00, None
        462 (0x01ce),  (0x), NtPowerInformation, 0x000730e0, None
        463 (0x01cf),  (0x), NtPrePrepareComplete, 0x00073e20, None
        464 (0x01d0),  (0x), NtPrePrepareEnlistment, 0x00073e30, None
        465 (0x01d1),  (0x), NtPrepareComplete, 0x00073e40, None
        466 (0x01d2),  (0x), NtPrepareEnlistment, 0x00073e50, None
        491 (0x01eb),  (0x), NtQueryInformationEnlistment, 0x00073f80, None
        496 (0x01f0),  (0x), NtQueryInformationResourceManager, 0x00073fb0, None
        499 (0x01f3),  (0x), NtQueryInformationTransaction, 0x00073fc0, None
        500 (0x01f4),  (0x), NtQueryInformationTransactionManager, 0x00073fd0, None
        539 (0x021b),  (0x), NtReadOnlyEnlistment, 0x00074170, None
        542 (0x021e),  (0x), NtRecoverEnlistment, 0x00074180, None
        543 (0x021f),  (0x), NtRecoverResourceManager, 0x00074190, None
        544 (0x0220),  (0x), NtRecoverTransactionManager, 0x000741a0, None
        555 (0x022b),  (0x), NtRenameTransactionManager, 0x00074220, None
        570 (0x023a),  (0x), NtRollbackComplete, 0x000742c0, None
        571 (0x023b),  (0x), NtRollbackEnlistment, 0x000742d0, None
        573 (0x023d),  (0x), NtRollbackTransaction, 0x000742f0, None
        574 (0x023e),  (0x), NtRollforwardTransactionManager, 0x00074300, None
        597 (0x0255),  (0x), NtSetInformationEnlistment, 0x00074450, None
        603 (0x025b),  (0x), NtSetInformationResourceManager, 0x00074480, None
        607 (0x025f),  (0x), NtSetInformationTransaction, 0x000744b0, None
        608 (0x0260),  (0x), NtSetInformationTransactionManager, 0x000744c0, None
        636 (0x027c),  (0x), NtSinglePhaseReject, 0x00074660, None
        
        761 (0x02f9),  (0x), RtlAnsiCharToUnicodeChar, 0x00061f60, None
        762 (0x02fa),  (0x), RtlAnsiStringToUnicodeSize, 0x0002ae00, None
        767 (0x02ff),  (0x), RtlAppendUnicodeStringToString, 0x000511b0, None
        768 (0x0300),  (0x), RtlAppendUnicodeToString, 0x0003ff20, None
        775 (0x0307),  (0x), RtlAreBitsClear, 0x000ce840, None
        776 (0x0308),  (0x), RtlAreBitsSet, 0x00067c10, None
        794 (0x031a),  (0x), RtlCheckRegistryKey, 0x000d16f0, None
        801 (0x0321),  (0x), RtlClearAllBits, 0x000ce910, None
        802 (0x0322),  (0x), RtlClearBit, 0x00087360, None
        803 (0x0323),  (0x), RtlClearBits, 0x00061c50, None
        807 (0x0327),  (0x), RtlCmDecodeMemIoResource, 0x000d67b0, None
        808 (0x0328),  (0x), RtlCmEncodeMemIoResource, 0x000d6830, None
        813 (0x032d),  (0x), RtlCompareMemory, 0x00088340, None
        816 (0x0330),  (0x), RtlCompareUnicodeString, 0x000505a0, None
        830 (0x033e),  (0x), RtlConvertLongToLargeInteger, 0x00088990, None
        835 (0x0343),  (0x), RtlConvertUlongToLargeInteger, 0x000889a0, None
        869 (0x0365),  (0x), RtlCreateRegistryKey, 0x000d1730, None
        870 (0x0366),  (0x), RtlCreateSecurityDescriptor, 0x00058850, None
        909 (0x038d),  (0x), RtlDeleteRegistryValue, 0x000d1770, None
        944 (0x03b0),  (0x), RtlDowncaseUnicodeChar, 0x000ce160, None
        973 (0x03cd),  (0x), RtlEqualUnicodeString, 0x00051360, None
        992 (0x03e0),  (0x), RtlFillMemory, 0x000883c0, None
        1000 (0x03e8),  (0x), RtlFindClearBits, 0x000ceca0, None
        1001 (0x03e9),  (0x), RtlFindClearBitsAndSet, 0x00061b00, None
        1002 (0x03ea),  (0x), RtlFindClearRuns, 0x000cef50, None
        1005 (0x03ed),  (0x), RtlFindLastBackwardRunClear, 0x000cf190, None
        1006 (0x03ee),  (0x), RtlFindLeastSignificantBit, 0x000cf270, None
        1007 (0x03ef),  (0x), RtlFindLongestRunClear, 0x000cf310, None
        1009 (0x03f1),  (0x), RtlFindMostSignificantBit, 0x000cf350, None
        1010 (0x03f2),  (0x), RtlFindNextForwardRunClear, 0x000cf3f0, None
        1011 (0x03f3),  (0x), RtlFindSetBits, 0x000cf4f0, None
        1012 (0x03f4),  (0x), RtlFindSetBitsAndClear, 0x000cf7b0, None
        1026 (0x0402),  (0x), RtlFreeAnsiString, 0x00043c70, None
        1033 (0x0409),  (0x), RtlFreeUTF8String, 0x00043c70, None
        1034 (0x040a),  (0x), RtlFreeUnicodeString, 0x00043c70, None
        1036 (0x040c),  (0x), RtlGUIDFromString, 0x000e2c40, None
        1113 (0x0459),  (0x), RtlGetVersion, 0x0002ff90, None
        1115 (0x045b),  (0x), RtlHashUnicodeString, 0x00027a10, None
        1129 (0x0469),  (0x), RtlInitAnsiString, 0x00075150, None
        1130 (0x046a),  (0x), RtlInitAnsiStringEx, 0x00060040, None
        1137 (0x0471),  (0x), RtlInitString, 0x00075110, None
        1138 (0x0472),  (0x), RtlInitStringEx, 0x000ce7d0, None
        1140 (0x0474),  (0x), RtlInitUTF8String, 0x000ce7e0, None
        1141 (0x0475),  (0x), RtlInitUTF8StringEx, 0x000ce7d0, None
        1142 (0x0476),  (0x), RtlInitUnicodeString, 0x00075190, None
        1146 (0x047a),  (0x), RtlInitializeBitMap, 0x0006d6a0, None
        1171 (0x0493),  (0x), RtlInt64ToUnicodeString, 0x000d0b10, None
        1173 (0x0495),  (0x), RtlIntegerToUnicodeString, 0x00052b80, None
        1181 (0x049d),  (0x), RtlIoDecodeMemIoResource, 0x000d6a30, None
        1182 (0x049e),  (0x), RtlIoEncodeMemIoResource, 0x000d6af0, None
        1246 (0x04de),  (0x), RtlLengthSecurityDescriptor, 0x00068840, None
        1273 (0x04f9),  (0x), RtlMoveMemory, 0x00088480, None
        1293 (0x050d),  (0x), RtlNumberOfClearBits, 0x000cfc70, None
        1294 (0x050e),  (0x), RtlNumberOfClearBitsInRange, 0x000cfc90, None
        1295 (0x050f),  (0x), RtlNumberOfSetBits, 0x000cfcc0, None
        1297 (0x0511),  (0x), RtlNumberOfSetBitsUlongPtr, 0x00087d00, None
        1344 (0x0540),  (0x), RtlQueryRegistryValues, 0x000d18f0, None
        1517 (0x05ed),  (0x), RtlUTF8StringToUnicodeString, 0x000eaca0, None
        1518 (0x05ee),  (0x), RtlUTF8ToUnicodeN, 0x0005d2f0, None
        1548 (0x060c),  (0x), RtlUpcaseUnicodeChar, 0x000402d0, None
        1565 (0x061d),  (0x), RtlValidRelativeSecurityDescriptor, 0x0006b850, None
        1566 (0x061e),  (0x), RtlValidSecurityDescriptor, 0x000682e0, None
        1599 (0x063f),  (0x), RtlZeroMemory, 0x00088450, None

         
        1813 (0x0715),  (0x), ZwClose, 0x00072bc0, None
        1815 (0x0717),  (0x), ZwCommitComplete, 0x00073450, None
        1816 (0x0718),  (0x), ZwCommitEnlistment, 0x00073460, None
        1818 (0x071a),  (0x), ZwCommitTransaction, 0x00073480, None
        1832 (0x0728),  (0x), ZwCreateDirectoryObject, 0x00073550, None
        1835 (0x072b),  (0x), ZwCreateEnlistment, 0x00073580, None
        1838 (0x072e),  (0x), ZwCreateFile, 0x00073040, None
        1843 (0x0733),  (0x), ZwCreateKey, 0x00072cc0, None
        1844 (0x0734),  (0x), ZwCreateKeyTransacted, 0x000735e0, None
        1860 (0x0744),  (0x), ZwCreateSection, 0x00072f90, None
        1870 (0x074e),  (0x), ZwCreateTransaction, 0x00073750, None
        1871 (0x074f),  (0x), ZwCreateTransactionManager, 0x00073760, None
        1884 (0x075c),  (0x), ZwDeleteKey, 0x00073820, None
        1887 (0x075f),  (0x), ZwDeleteValueKey, 0x00073850, None
        1900 (0x076c),  (0x), ZwEnumerateKey, 0x00072e10, None
        1902 (0x076e),  (0x), ZwEnumerateTransactionObject, 0x00073900, None
        1903 (0x076f),  (0x), ZwEnumerateValueKey, 0x00072c00, None
        1913 (0x0779),  (0x), ZwFlushKey, 0x00073980, None
        1932 (0x078c),  (0x), ZwGetNotificationResourceManager, 0x00073a90, None
        1945 (0x0799),  (0x), ZwLoadDriver, 0x00073b40, None
        1956 (0x07a4),  (0x), ZwMakeTemporaryObject, 0x00073be0, None
        1962 (0x07aa),  (0x), ZwMapViewOfSection, 0x00072d70, None
        1972 (0x07b4),  (0x), ZwOpenEnlistment, 0x00073cb0, None
        1973 (0x07b5),  (0x), ZwOpenEvent, 0x00072ef0, None
        1975 (0x07b7),  (0x), ZwOpenFile, 0x00072e20, None
        1978 (0x07ba),  (0x), ZwOpenKey, 0x00072bf0, None
        1979 (0x07bb),  (0x), ZwOpenKeyEx, 0x00073cf0, None
        1980 (0x07bc),  (0x), ZwOpenKeyTransacted, 0x00073d00, None
        1981 (0x07bd),  (0x), ZwOpenKeyTransactedEx, 0x00073d10, None
        1991 (0x07c7),  (0x), ZwOpenResourceManager, 0x00073d90, None
        1992 (0x07c8),  (0x), ZwOpenSection, 0x00072e60, None
        1995 (0x07cb),  (0x), ZwOpenSymbolicLinkObject, 0x00073dc0, None
        2000 (0x07d0),  (0x), ZwOpenTransaction, 0x00073df0, None
        2001 (0x07d1),  (0x), ZwOpenTransactionManager, 0x00073e00, None
        2004 (0x07d4),  (0x), ZwPrePrepareComplete, 0x00073e20, None
        2005 (0x07d5),  (0x), ZwPrePrepareEnlistment, 0x00073e30, None
        2006 (0x07d6),  (0x), ZwPrepareComplete, 0x00073e40, None
        2007 (0x07d7),  (0x), ZwPrepareEnlistment, 0x00073e50, None
        2029 (0x07ed),  (0x), ZwQueryFullAttributesFile, 0x00073f50, None
        2031 (0x07ef),  (0x), ZwQueryInformationByName, 0x00073f70, None
        2032 (0x07f0),  (0x), ZwQueryInformationEnlistment, 0x00073f80, None
        2033 (0x07f1),  (0x), ZwQueryInformationFile, 0x00072be0, None
        2037 (0x07f5),  (0x), ZwQueryInformationResourceManager, 0x00073fb0, None
        2040 (0x07f8),  (0x), ZwQueryInformationTransaction, 0x00073fc0, None
        2041 (0x07f9),  (0x), ZwQueryInformationTransactionManager, 0x00073fd0, None
        2046 (0x07fe),  (0x), ZwQueryKey, 0x00072c30, None
        2061 (0x080d),  (0x), ZwQuerySymbolicLinkObject, 0x000740d0, None
        2069 (0x0815),  (0x), ZwQueryValueKey, 0x00072c40, None
        2078 (0x081e),  (0x), ZwReadFile, 0x00072b30, None
        2080 (0x0820),  (0x), ZwReadOnlyEnlistment, 0x00074170, None
        2083 (0x0823),  (0x), ZwRecoverEnlistment, 0x00074180, None
        2084 (0x0824),  (0x), ZwRecoverResourceManager, 0x00074190, None
        2085 (0x0825),  (0x), ZwRecoverTransactionManager, 0x000741a0, None
        2111 (0x083f),  (0x), ZwRollbackComplete, 0x000742c0, None
        2112 (0x0840),  (0x), ZwRollbackEnlistment, 0x000742d0, None
        2114 (0x0842),  (0x), ZwRollbackTransaction, 0x000742f0, None
        2115 (0x0843),  (0x), ZwRollforwardTransactionManager, 0x00074300, None
        2138 (0x085a),  (0x), ZwSetInformationEnlistment, 0x00074450, None
        2139 (0x085b),  (0x), ZwSetInformationFile, 0x00072d60, None
        2144 (0x0860),  (0x), ZwSetInformationResourceManager, 0x00074480, None
        2148 (0x0864),  (0x), ZwSetInformationTransaction, 0x000744b0, None
        2171 (0x087b),  (0x), ZwSetValueKey, 0x000730f0, None
        2177 (0x0881),  (0x), ZwSinglePhaseReject, 0x00074660, None
        2195 (0x0893),  (0x), ZwUnloadDriver, 0x00074750, None
        2201 (0x0899),  (0x), ZwUnmapViewOfSection, 0x00072d90, None
        2235 (0x08bb),  (0x), ZwWriteFile, 0x00072b50, None
         
         */

        /// <summary>
        /// The ZwCommitComplete routine notifies KTM that the calling resource manager has finished committing a transaction's data.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-ntcommitcomplete
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCommitComplete(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwCommitEnlistment routine initiates the commit operation for a specified enlistment's transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-ntcommitenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCommitEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwCommitTransaction routine initiates a commit operation for a specified transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-ntcommittransaction
        /// </summary>
        /// <param name="TransactionHandle"></param>
        /// <param name="Wait"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCommitTransaction(
            IntPtr TransactionHandle,
            bool Wait
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCreateEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCreateResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCreateTransaction();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtCreateTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtEnumerateTransactionObject();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtGetNotificationResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtManagePartition();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtOpenEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtOpenResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtOpenTransaction();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtOpenTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtPowerInformation();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtPrePrepareComplete();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtPrePrepareEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtPrepareComplete();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtPrepareEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtQueryInformationEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtQueryInformationResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtQueryInformationTransaction();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtQueryInformationTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtReadOnlyEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRecoverEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRecoverResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRecoverTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRenameTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRollbackComplete();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRollbackEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRollbackTransaction();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtRollforwardTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtSetInformationEnlistment();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtSetInformationResourceManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtSetInformationTransaction();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtSetInformationTransactionManager();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS NtSinglePhaseReject();


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlAnsiCharToUnicodeChar();

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlAnsiStringToUnicodeSize();

        /// <summary>
        /// The RtlAppendUnicodeStringToString routine concatenates two Unicode strings.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlappendunicodestringtostring
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlAppendUnicodeStringToString(
            IntPtr Destination,
            IntPtr Source
            );

        /// <summary>
        /// The RtlAppendUnicodeToString routine concatenates the supplied Unicode string to a buffered Unicode string.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlappendunicodetostring
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlAppendUnicodeToString(
            IntPtr Destination,
            [MarshalAs(UnmanagedType.LPWStr)] string Source
            );

        /// <summary>
        /// The RtlAreBitsClear routine determines whether a given range of bits within a bitmap variable is clear.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlarebitsclear
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="StartingIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool RtlAreBitsClear(
            IntPtr BitMapHeader,
            uint StartingIndex,
            uint Length
            );

        /// <summary>
        /// The RtlAreBitsSet routine determines whether a given range of bits within a bitmap variable is set.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlarebitsset
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="StartingIndex"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool RtlAreBitsSet(
            IntPtr BitMapHeader,
            uint StartingIndex,
            uint Length
            );

        /// <summary>
        /// The RtlCheckRegistryKey routine checks for the existence of a given named key in the registry.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcheckregistrykey
        /// </summary>
        /// <param name="RelativeTo"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCheckRegistryKey(
            uint RelativeTo,
            [MarshalAs(UnmanagedType.LPWStr)] string Path
            );

        /// <summary>
        /// The RtlClearAllBits routine sets all bits in a given bitmap variable to zero.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlclearallbits
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlClearAllBits(
            IntPtr BitMapHeader
            );

        /// <summary>
        /// The RtlClearBit routine sets the specified bit in a bitmap to zero.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlclearbit
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="BitNumber"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlClearBit(
            IntPtr BitMapHeader,
            uint BitNumber
            );

        /// <summary>
        /// The RtlClearBits routine sets all bits in the specified range of bits in the bitmap to zero.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlclearbits
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="StartingIndex"></param>
        /// <param name="NumberToClear"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlClearBits(
            IntPtr BitMapHeader,
            uint StartingIndex,
            uint NumberToClear
            );

        /// <summary>
        /// The RtlCmDecodeMemIoResource routine provides the starting address and length of a CM_PARTIAL_RESOURCE_DESCRIPTOR structure that describes a range of memory or I/O port addresses.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcmdecodememioresource
        /// </summary>
        /// <param name="Descriptor"></param>
        /// <param name="Start"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCmDecodeMemIoResource(
            System.IntPtr Descriptor,
            ref ulong Start
            );

        /// <summary>
        /// The RtlCmEncodeMemIoResource routine updates a CM_PARTIAL_RESOURCE_DESCRIPTOR structure to describe a range of memory or I/O port addresses.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcmencodememioresource
        /// </summary>
        /// <param name="Descriptor"></param>
        /// <param name="Type"></param>
        /// <param name="Length"></param>
        /// <param name="Start"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCmEncodeMemIoResource(
            System.IntPtr Descriptor, 
            byte Type,
            ulong Length, 
            ulong Start
            );

        /// <summary>
        /// The RtlCompareMemory routine compares two blocks of memory and returns the number of bytes that match until the first difference.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcomparememory
        /// </summary>
        /// <param name="Source1"></param>
        /// <param name="Source2"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCompareMemory(
            IntPtr Source1,
            IntPtr Source2,
            uint Length
            );

        /// <summary>
        /// The RtlCompareUnicodeString routine compares two Unicode strings.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcompareunicodestring
        /// </summary>
        /// <param name="String1"></param>
        /// <param name="String2"></param>
        /// <param name="CaseInSensitive"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCompareUnicodeString(
            IntPtr String1,
            IntPtr String2,
            bool CaseInSensitive
            );

        /// <summary>
        /// The RtlConvertLongToLargeInteger routine converts the input signed integer to a signed large integer.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlconvertlongtolargeinteger
        /// </summary>
        /// <param name="SignedInteger"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlConvertLongToLargeInteger(
            long SignedInteger
            );

        /// <summary>
        /// The RtlConvertUlongToLargeInteger routine converts the input unsigned integer to a signed large integer.
        /// For Windows XP and later versions of Windows, do not use this routine; use the native support for __int64.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlconvertulongtolargeinteger
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlConvertUlongToLargeInteger();

        /// <summary>
        /// The RtlCreateRegistryKey routine adds a key object in the registry along a given relative path.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcreateregistrykey
        /// </summary>
        /// <param name="RelativeTo"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCreateRegistryKey(
            uint RelativeTo,
            [MarshalAs(UnmanagedType.LPWStr)] string Path
            );

        /// <summary>
        /// The RtlCreateSecurityDescriptor routine initializes a new absolute-format security descriptor.
        /// On return,the security descriptor is initialized with no system ACL,
        /// no discretionary ACL, no owner, no primary group, and all control flags set to zero.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcreatesecuritydescriptor
        /// </summary>
        /// <param name="SecurityDescriptor"></param>
        /// <param name="Revision"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlCreateSecurityDescriptor(
            IntPtr SecurityDescriptor,
            uint Revision
            );

        /// <summary>
        /// The RtlDeleteRegistryValue routine removes the specified entry name and the associated values from the registry along the given relative path.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtldeleteregistryvalue
        /// </summary>
        /// <param name="RelativeTo"></param>
        /// <param name="Path"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlDeleteRegistryValue(
            uint RelativeTo,
            [MarshalAs(UnmanagedType.LPWStr)] string Path,
            [In][MarshalAs(UnmanagedType.LPWStr)] string ValueName
            );

        /// <summary>
        /// The RtlDowncaseUnicodeChar routine converts the specified Unicode character to lowercase.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtldowncaseunicodechar
        /// </summary>
        /// <param name="SourceCharacter"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern char RtlDowncaseUnicodeChar(
            char SourceCharacter
            );

        /// <summary>
        /// The RtlEqualUnicodeString routine compares two Unicode strings to determine whether they are equal.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlequalunicodestring
        /// </summary>
        /// <param name="String1"></param>
        /// <param name="String2"></param>
        /// <param name="CaseInSensitive"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlEqualUnicodeString(
            IntPtr String1,
            IntPtr String2,
            bool CaseInSensitive
            );

        /// <summary>
        /// The RtlFillMemory routine fills a block of memory with the specified fill value.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfillmemory
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Length"></param>
        /// <param name="Fill"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFillMemory(
            IntPtr Destination,
            uint Length,
            uint Fill
            );

        /// <summary>
        /// The RtlFindClearBits routine searches for a range of clear bits of a requested size within a bitmap.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindclearbits
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="NumberToFind"></param>
        /// <param name="HintIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindClearBits(
            IntPtr BitMapHeader,
            uint NumberToFind,
            uint HintIndex
            );

        /// <summary>
        /// The RtlFindClearBitsAndSet routine searches for a range of clear bits of a requested size within a bitmap and sets all bits in the range when it has been located.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindclearbitsandset
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="NumberToFind"></param>
        /// <param name="HintIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindClearBitsAndSet(
            IntPtr BitMapHeader,
            uint NumberToFind,
            uint HintIndex
            );

        /// <summary>
        /// The RtlFindClearRuns routine finds the specified number of runs of clear bits within a given bitmap.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindclearruns
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindClearRuns(
            IntPtr BitMapHeader,
            ref IntPtr RunArray,
            uint SizeOfRunArray,
            bool LocateLongestRuns
            );

        /// <summary>
        /// The RtlFindLastBackwardRunClear routine searches a given bitmap for the preceding clear run of bits, starting from the specified index position.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindlastbackwardrunclear
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="FromIndex"></param>
        /// <param name="StartingRunIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindLastBackwardRunClear(
            IntPtr BitMapHeader,
            uint FromIndex,
            ref uint StartingRunIndex
            );

        /// <summary>
        /// The RtlFindLeastSignificantBit routine returns the zero-based position of the least significant nonzero bit in its parameter.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindleastsignificantbit
        /// </summary>
        /// <param name="Set"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern byte RtlFindLeastSignificantBit(
            ulong Set
            );

        /// <summary>
        /// The RtlFindLongestRunClear routine searches for the largest contiguous range of clear bits within a given bitmap.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindlongestrunclear
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="StartingRunIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindLongestRunClear(
            IntPtr BitMapHeader,
            ref uint StartingRunIndex
            );

        /// <summary>
        /// The RtlFindMostSignificantBit routine returns the zero-based position of the most significant nonzero bit in its parameter.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindmostsignificantbit
        /// </summary>
        /// <param name="Set"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern byte RtlFindMostSignificantBit(
            ulong Set
            );

        /// <summary>
        /// The RtlFindNextForwardRunClear routine searches a given bitmap variable for the next clear run of bits, starting from the specified index position.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindnextforwardrunclear
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="Index"></param>
        /// <param name="StartingRunIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindNextForwardRunClear(
            IntPtr BitMapHeader,
            uint Index, 
            ref uint StartingRunIndex
            );

        /// <summary>
        /// The RtlFindSetBits routine searches for a range of set bits of a requested size within a bitmap.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindsetbits
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="NumberToFind"></param>
        /// <param name="HintIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlFindSetBits(
            IntPtr BitMapHeader,
            uint NumberToFind,
            uint HintIndex
            );

        /// <summary>
        /// The RtlFindSetBitsAndClear routine searches for a range of set bits of a requested size within a bitmap and clears all bits in the range when it has been located.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfindsetbitsandclear
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="NumberToFind"></param>
        /// <param name="HintIndex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RtlFindSetBitsAndClear(
            IntPtr BitMapHeader,
            uint NumberToFind,
            uint HintIndex
            );

        /// <summary>
        /// The RtlFreeAnsiString routine releases storage that was allocated by RtlUnicodeStringToAnsiString.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfreeansistring
        /// </summary>
        /// <param name="AnsiString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern void RtlFreeAnsiString(
            IntPtr AnsiString
            );

        /// <summary>
        /// The RtlFreeUTF8String function releases storage that was allocated by RtlUnicodeStringToUTF8String.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfreeutf8string
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern void RtlFreeUTF8String(
            IntPtr utf8String
            );

        /// <summary>
        /// The RtlFreeUnicodeString routine releases storage that was allocated by RtlAnsiStringToUnicodeString or RtlUpcaseUnicodeString.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfreeunicodestring
        /// </summary>
        /// <param name="UnicodeString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern void RtlFreeUnicodeString(
            IntPtr UnicodeString
            );

        /// <summary>
        /// The RtlGUIDFromString routine converts the given Unicode string to a GUID in binary format.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlguidfromstring
        /// </summary>
        /// <param name="GuidString"></param>
        /// <param name="Guid"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlGUIDFromString(
            System.IntPtr GuidString, 
            ref GUID Guid
            );

        /// <summary>
        /// The RtlGetVersion routine returns version information about the currently running operating system.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlgetversion
        /// </summary>
        /// <param name="lpVersionInformation"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlGetVersion(
            ref IntPtr lpVersionInformation
            );

        /// <summary>
        /// The RtlHashUnicodeString routine creates a hash value from a given Unicode string and hash algorithm.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlhashunicodestring
        /// </summary>
        /// <param name="String"></param>
        /// <param name="CaseInSensitive"></param>
        /// <param name="HashAlgorithm"></param>
        /// <param name="HashValue"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlHashUnicodeString(
            System.IntPtr String, 
            byte CaseInSensitive, 
            uint HashAlgorithm, 
            ref uint HashValue
            );

        /// <summary>
        /// The RtlInitAnsiString routine initializes a counted string of ANSI characters.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitansistring
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitAnsiString(
            ref IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitAnsiStringEx();

        /// <summary>
        /// The RtlInitString routine initializes a counted string of 8-bit characters.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitstring
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitString(
            ref IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        /// <summary>
        /// The RtlInitStringEx routine initializes a counted string of 8-bit characters.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitstringex
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitStringEx(
            ref IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        /// <summary>
        /// The RtlInitUTF8String function initializes a counted string of UTF-8 characters.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitutf8string
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitUTF8String(
            IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        /// <summary>
        /// The RtlInitUTF8StringEx routine initializes a counted string of UTF-8 characters.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitutf8stringex
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitUTF8StringEx(
            IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitUnicodeString(
            ref IntPtr DestinationString,
            [MarshalAs(UnmanagedType.LPWStr)] string SourceString
            );

        /// <summary>
        /// The RtlInitializeBitMap routine initializes the header of a bitmap variable.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlinitializebitmap
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <param name="BitMapBuffer"></param>
        /// <param name="SizeOfBitMap"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInitializeBitMap(
            ref IntPtr BitMapHeader,
            uint BitMapBuffer,
            uint SizeOfBitMap
            );

        /// <summary>
        /// The RtlInt64ToUnicodeString routine converts a specified unsigned 64-bit integer value to a Unicode string that represents the value in a specified base.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlint64tounicodestring
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Base">
        /// 
        /// </param>
        /// <param name="String"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlInt64ToUnicodeString(
            uint Value,
            uint Base,
            ref IntPtr String
            );

        /// <summary>
        /// The RtlIntegerToUnicodeString routine converts an unsigned integer value to a null-terminated string of one or more Unicode characters in the specified base.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlintegertounicodestring
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Base"></param>
        /// <param name="String"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlIntegerToUnicodeString(
            uint Value, 
            uint Base, 
            System.IntPtr String
            );

        /// <summary>
        /// The RtlIoDecodeMemIoResource routine provides the address information that is contained in an IO_RESOURCE_DESCRIPTOR structure that describes a range of memory or I/O port addresses.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtliodecodememioresource
        /// </summary>
        /// <param name="Descriptor"></param>
        /// <param name="Alignment"></param>
        /// <param name="MinimumAddress"></param>
        /// <param name="MaximumAddress"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern ulong RtlIoDecodeMemIoResource(
            System.IntPtr Descriptor,
            ref ulong Alignment, 
            ref ulong MinimumAddress, 
            ref ulong MaximumAddress
            );

        /// <summary>
        /// The RtlIoEncodeMemIoResource routine updates an IO_RESOURCE_DESCRIPTOR structure to describe a range of memory or I/O port addresses.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlioencodememioresource
        /// </summary>
        /// <param name="Descriptor"></param>
        /// <param name="Type"></param>
        /// <param name="Length"></param>
        /// <param name="Alignment"></param>
        /// <param name="MinimumAddress"></param>
        /// <param name="MaximumAddress"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlIoEncodeMemIoResource(
            System.IntPtr Descriptor,
            byte Type, 
            ulong Length, 
            ulong Alignment, 
            ulong MinimumAddress, 
            ulong MaximumAddress
            );

        /// <summary>
        /// The RtlLengthSecurityDescriptor routine returns the size of a given security descriptor.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtllengthsecuritydescriptor
        /// </summary>
        /// <param name="SecurityDescriptor">Pointer to a SECURITY_DESCRIPTOR.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RtlLengthSecurityDescriptor(
            IntPtr SecurityDescriptor
            );

        /// <summary>
        /// The RtlMoveMemory routine copies the contents of a source memory block to a destination memory block,
        /// and supports overlapping source and destination memory blocks.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlmovememory
        /// </summary>
        /// <param name="Destination">A pointer to the destination memory block to copy the bytes to.</param>
        /// <param name="Source">A pointer to the source memory block to copy the bytes from.</param>
        /// <param name="Length">The number of bytes to copy from the source to the destination.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern void RtlMoveMemory(
            IntPtr Destination,
            IntPtr Source,
            uint      Length
            );

        /// <summary>
        /// The RtlNumberOfClearBits routine returns a count of the clear bits in a given bitmap variable.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlnumberofclearbits
        /// </summary>
        /// <param name="BitMapHeader"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RtlNumberOfClearBits(
            IntPtr BitMapHeader
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlNumberOfClearBitsInRange();

        /// <summary>
        /// The RtlNumberOfSetBits routine returns a count of the set bits in a given bitmap variable.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlnumberofsetbits
        /// </summary>
        /// <param name="BitMapHeader">
        ///A pointer to the RTL_BITMAP structure that describes the bitmap. This structure must have been initialized by the RtlInitializeBitMap routine.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RtlNumberOfSetBits(
            IntPtr BitMapHeader
            );

        /// <summary>
        /// The RtlNumberOfSetBitsUlongPtr routine returns the number of bits in the specified ULONG_PTR integer value that are set to one.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlnumberofsetbitsulongptr
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint RtlNumberOfSetBitsUlongPtr(
            uint Target
            );

        /// <summary>
        /// The RtlQueryRegistryValues routine allows the caller to query several values from the registry subtree with a single call.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlqueryregistryvalues
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="QueryTable"></param>
        /// <param name="Context"></param>
        /// <param name="Environment"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlQueryRegistryValues(
            [MarshalAs(UnmanagedType.LPWStr)] string Path, 
            System.IntPtr QueryTable, 
            System.IntPtr Context, 
            System.IntPtr Environment
            );

        /// <summary>
        /// The RtlUTF8StringToUnicodeString function converts the specified UTF8 source string into a Unicode string in accordance with the current system locale information.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlutf8stringtounicodestring
        /// </summary>
        /// <param name="DestinationString"></param>
        /// <param name="SourceString"></param>
        /// <param name="AllocateDestinationString"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlUTF8StringToUnicodeString(
            IntPtr DestinationString,
            IntPtr SourceString,
            bool AllocateDestinationString
            );

        /// <summary>
        /// The RtlUTF8ToUnicodeN routine converts a UTF-8 string to a Unicode string.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlutf8tounicoden
        /// </summary>
        /// <param name="UnicodeStringDestination"></param>
        /// <param name="UnicodeStringMaxByteCount"></param>
        /// <param name="UnicodeStringActualByteCount"></param>
        /// <param name="UTF8StringSource"></param>
        /// <param name="UTF8StringByteCount"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS RtlUTF8ToUnicodeN(
            IntPtr UnicodeStringDestination, 
            uint UnicodeStringMaxByteCount, 
            ref uint UnicodeStringActualByteCount, 
            [MarshalAs(UnmanagedType.LPStr)] string UTF8StringSource, 
            uint UTF8StringByteCount
            );

        /// <summary>
        /// The RtlUpcaseUnicodeChar routine converts the specified Unicode character to uppercase.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlupcaseunicodechar
        /// </summary>
        /// <param name="SourceCharacter">Specifies the character to convert.</param>
        /// <returns>RtlUpcaseUnicodeChar returns the uppercase version of the specified Unicode character.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern char RtlUpcaseUnicodeChar(
            char SourceCharacter
            );

        /// <summary>
        /// The RtlValidRelativeSecurityDescriptor routine checks the validity of a self-relative security descriptor.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlvalidrelativesecuritydescriptor
        /// </summary>
        /// <param name="SecurityDescriptorInput">
        /// A pointer to the buffer that contains the security descriptor in self-relative format.
        /// The buffer must begin with a SECURITY_DESCRIPTOR structure,
        /// which is followed by the rest of the security descriptor data.
        /// </param>
        /// <param name="SecurityDescriptorLength">The size of the SecurityDescriptorInput structure.</param>
        /// <param name="RequiredInformation">
        /// A SECURITY_INFORMATION value that specifies the information that is required to be contained in the security descriptor.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool RtlValidRelativeSecurityDescriptor(
            IntPtr SecurityDescriptorInput,
            uint SecurityDescriptorLength,
            SECURITY_INFORMATION RequiredInformation
            );

        /// <summary>
        /// The RtlValidSecurityDescriptor routine checks a given security descriptor's validity.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlvalidsecuritydescriptor
        /// </summary>
        /// <param name="SecurityDescriptor"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool RtlValidSecurityDescriptor(
            IntPtr SecurityDescriptor
            );

        /// <summary>
        /// The RtlZeroMemory routine fills a block of memory with zeros, given a pointer to the block and the length, in bytes, to be filled.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlzeromemory
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Length"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void RtlZeroMemory(
            IntPtr Destination,
            uint Length
            );

        /// <summary>
        /// The ZwClose routine closes an object handle.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwclose
        /// </summary>
        /// <param name="Handle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwClose(
            IntPtr Handle
            );

        /// <summary>
        /// The ZwCommitComplete routine notifies KTM that the calling resource manager has finished committing a transaction's data.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcommitcomplete
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCommitComplete(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwCommitEnlistment routine initiates the commit operation for a specified enlistment's transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcommitenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCommitEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwCommitTransaction routine initiates a commit operation for a specified transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcommittransaction
        /// </summary>
        /// <param name="TransactionHandle"></param>
        /// <param name="Wait"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCommitTransaction(
            IntPtr TransactionHandle,
            bool Wait
            );

        /// <summary>
        /// The ZwCreateDirectoryObject routine creates or opens an object-directory object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatedirectoryobject
        /// </summary>
        /// <param name="DirectoryHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateDirectoryObject(
            ref IntPtr DirectoryHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
            );

        /// <summary>
        /// The ZwCreateEnlistment routine creates a new enlistment object for a transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreateenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="TransactionHandle"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="NotificationMask"></param>
        /// <param name="EnlistmentKey"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateEnlistment(
            ref System.IntPtr EnlistmentHandle,
            ACCESS_MASK DesiredAccess, 
            System.IntPtr ResourceManagerHandle, 
            System.IntPtr TransactionHandle, 
            System.IntPtr ObjectAttributes,
            uint CreateOptions, 
            System.IntPtr NotificationMask, 
            System.IntPtr EnlistmentKey
            );

        /// <summary>
        /// The ZwCreateFile routine creates a new file or opens an existing file.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatefile
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="IoStatusBlock"></param>
        /// <param name="AllocationSize"></param>
        /// <param name="FileAttributes"></param>
        /// <param name="ShareAccess"></param>
        /// <param name="CreateDisposition"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="EaBuffer"></param>
        /// <param name="EaLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateFile(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint IoStatusBlock,
            IntPtr AllocationSize,
            uint FileAttributes,
            uint ShareAccess,
            uint CreateDisposition,
            uint CreateOptions,
            IntPtr EaBuffer,
            uint EaLength
            );

        /// <summary>
        /// The ZwCreateKey routine creates a new registry key or opens an existing one.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatekey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="TitleIndex"></param>
        /// <param name="Class"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="Disposition"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateKey(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint TitleIndex,
            uint Class,
            uint CreateOptions,
            ref uint Disposition
            );

        /// <summary>
        /// The ZwCreateKeyTransacted routine creates a new registry key or opens an existing one, and it associates the key with a transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatekeytransacted
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="TitleIndex"></param>
        /// <param name="Class"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="TransactionHandle"></param>
        /// <param name="Disposition"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateKeyTransacted(
	        ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint TitleIndex,
            uint Class,
            uint CreateOptions,
            IntPtr TransactionHandle,
            ref uint Disposition
            );

        /// <summary>
        /// The ZwCreateSection routine creates a section object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatesection
        /// </summary>
        /// <param name="SectionHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="MaximumSize"></param>
        /// <param name="SectionPageProtection"></param>
        /// <param name="AllocationAttributes"></param>
        /// <param name="FileHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateSection(
            ref IntPtr SectionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr MaximumSize,
            uint SectionPageProtection,
            uint AllocationAttributes,
            IntPtr FileHandle
            );

        /// <summary>
        /// The ZwCreateTransaction routine creates a transaction object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatetransaction
        /// </summary>
        /// <param name="TransactionHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="Uow"></param>
        /// <param name="TmHandle"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="IsolationLevel"></param>
        /// <param name="IsolationFlags"></param>
        /// <param name="Timeout"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTransaction(
            ref IntPtr TransactionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            GUID Uow,
            IntPtr TmHandle,
            uint  CreateOptions,
            uint IsolationLevel,
            uint IsolationFlags,
            uint Timeout,
            uint Description
            );

        /// <summary>
        /// The ZwCreateTransactionManager routine creates a new transaction manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwcreatetransactionmanager
        /// </summary>
        /// <param name="TmHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="LogFileName"></param>
        /// <param name="CreateOptions"></param>
        /// <param name="CommitStrength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTransactionManager(
            IntPtr TmHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr LogFileName,
            uint CreateOptions,
            uint CommitStrength
            );

        /// <summary>
        /// The ZwDeleteKey routine deletes an open key from the registry.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwdeletekey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteKey(
	        IntPtr KeyHandle
            );

        /// <summary>
        /// The ZwDeleteValueKey routine deletes a value entry matching a name from an open key in the registry. 
	    /// If no such entry exists, an error is returned.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwdeletevaluekey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="ValueName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteValueKey(
	        IntPtr KeyHandle,
            IntPtr ValueName
            );

        /// <summary>
        /// The ZwEnumerateKey routine returns information about a subkey of an open registry key.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwenumeratekey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="Index"></param>
        /// <param name="KeyInformationClass"></param>
        /// <param name="KeyInformation"></param>
        /// <param name="Length"></param>
        /// <param name="ResultLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateKey(
            IntPtr KeyHandle,
            uint Index,
            KEY_INFORMATION_CLASS KeyInformationClass,
            ref IntPtr KeyInformation,
            uint Length,
            ref uint ResultLength
            );

        /// <summary>
        /// The ZwEnumerateTransactionObject routine enumerates the KTM objects on a computer.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwenumeratetransactionobject
        /// </summary>
        /// <param name="RootObjectHandle"></param>
        /// <param name="QueryType"></param>
        /// <param name="ObjectCursor"></param>
        /// <param name="ObjectCursorLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateTransactionObject(
            IntPtr RootObjectHandle,
            IntPtr QueryType,
            ref IntPtr ObjectCursor,
            uint ObjectCursorLength,
            ref uint ReturnLength
            );

        /// <summary>
        /// The ZwEnumerateValueKey routine gets information about the value entries of an open key.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwenumeratevaluekey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="Index"></param>
        /// <param name="KeyValueInformationClass"></param>
        /// <param name="KeyValueInformation"></param>
        /// <param name="Length"></param>
        /// <param name="ResultLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateValueKey(
            IntPtr KeyHandle,
            uint Index,
            KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
            ref IntPtr KeyValueInformation,
            uint Length,
            ref uint  ResultLength
            );

        /// <summary>
        /// The ZwFlushKey routine forces a registry key to be committed to disk.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwflushkey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushKey(
	        IntPtr KeyHandle
            );

        /// <summary>
        /// The ZwGetNotificationResourceManager routine retrieves the next transaction notification from a specified resource manager's notification queue.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwgetnotificationresourcemanager
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="TransactionNotification"></param>
        /// <param name="NotificationLength"></param>
        /// <param name="Timeout"></param>
        /// <param name="ReturnLength"></param>
        /// <param name="Asynchronous"></param>
        /// <param name="AsynchronousContext"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetNotificationResourceManager(
            IntPtr ResourceManagerHandle,
            ref IntPtr TransactionNotification,
            uint NotificationLength,
            IntPtr Timeout,
            ref uint ReturnLength,
            uint Asynchronous,
            IntPtr AsynchronousContext
            );

        /// <summary>
        /// The ZwLoadDriver routine loads a driver into the system.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwloaddriver
        /// </summary>
        /// <param name="DriverServiceName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadDriver(
	        IntPtr DriverServiceName
            );

        /// <summary>
        /// The ZwMakeTemporaryObject routine changes the attributes of an object to make it temporary.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwmaketemporaryobject
        /// </summary>
        /// <param name="Handle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMakeTemporaryObject(
	        IntPtr Handle
            );

        /// <summary>
        /// The ZwMapViewOfSection routine maps a view of a section into the virtual address space of a subject process.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwmapviewofsection
        /// </summary>
        /// <param name="SectionHandle"></param>
        /// <param name="ProcessHandle"></param>
        /// <param name="BaseAddress"></param>
        /// <param name="ZeroBits"></param>
        /// <param name="CommitSize"></param>
        /// <param name="SectionOffset"></param>
        /// <param name="ViewSize"></param>
        /// <param name="InheritDisposition"></param>
        /// <param name="AllocationType"></param>
        /// <param name="Win32Protect"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMapViewOfSection(
            IntPtr SectionHandle,
            IntPtr ProcessHandle,
            ref IntPtr BaseAddress,
            uint ZeroBits,
            uint CommitSize,
            ref IntPtr SectionOffset,
            ref uint ViewSize,
            uint InheritDisposition,
            uint  AllocationType,
            uint Win32Protect
            );

        /// <summary>
        /// The ZwOpenEnlistment routine obtains a handle to an existing enlistment object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="RmHandle"></param>
        /// <param name="EnlistmentGuid"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenEnlistment(
            ref IntPtr EnlistmentHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr RmHandle,
            GUID EnlistmentGuid,
            IntPtr ObjectAttributes
        );

        /// <summary>
        /// The ZwOpenEvent routine opens a handle to an existing named event object with the specified desired access.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenevent
        /// </summary>
        /// <param name="EventHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenEvent(
            ref IntPtr EventHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
	        );

        /// <summary>
        /// The ZwOpenFile routine opens an existing file, directory, device, or volume.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenfile
        /// </summary>
        /// <param name="FileHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="IoStatusBlock"></param>
        /// <param name="ShareAccess"></param>
        /// <param name="OpenOptions"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenFile(
            ref IntPtr FileHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            ref IntPtr IoStatusBlock,
            uint ShareAccess,
            uint OpenOptions
            );

        /// <summary>
        /// The ZwOpenKey routine opens an existing registry key.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenkey
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenKey(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
	        );

        /// <summary>
        /// The ZwOpenKeyEx routine opens an existing registry key.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenkeyex
        /// </summary>
        /// <param name="KeyHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="OpenOptions"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenKeyEx(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint OpenOptions
	        );

        /// <summary>
        /// The ZwOpenKeyTransacted routine opens an existing registry key and associates the key with a transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenkeytransacted
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="TransactionHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenKeyTransacted(
            ref IntPtr ResourceManagerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr TransactionHandle
        );

        /// <summary>
        /// The ZwOpenKeyTransactedEx routine opens an existing registry key and associates the key with a transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenkeytransactedex
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="OpenOptions"></param>
        /// <param name="TransactionHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenKeyTransactedEx(
            ref IntPtr ResourceManagerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint OpenOptions,
            IntPtr TransactionHandle
        );

        /// <summary>
        /// The ZwOpenResourceManager routine returns a handle to an existing resource manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopenresourcemanager
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="TmHandle"></param>
        /// <param name="ResourceManagerGuid"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenResourceManager(
            ref IntPtr ResourceManagerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr TmHandle,
            GUID ResourceManagerGuid,
            IntPtr ObjectAttributes
            );

        /// <summary>
        /// The ZwOpenSection routine opens a handle for an existing section object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopensection
        /// </summary>
        /// <param name="LinkHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenSection(
            ref IntPtr LinkHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
            );

        /// <summary>
        /// The ZwOpenSymbolicLinkObject routine opens an existing symbolic link.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopensymboliclinkobject
        /// </summary>
        /// <param name="LinkHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenSymbolicLinkObject(
            ref IntPtr LinkHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
            );

        /// <summary>
        /// The ZwOpenTransaction routine obtains a handle to an existing transaction object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopentransaction
        /// </summary>
        /// <param name="TransactionHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="Uow"></param>
        /// <param name="TmHandle"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenTransaction(
            IntPtr TransactionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            GUID Uow,
            IntPtr TmHandle
            );

        /// <summary>
        /// The ZwOpenTransactionManager routine obtains a handle to an existing transaction manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwopentransactionmanager
        /// </summary>
        /// <param name="TmHandle"></param>
        /// <param name="DesiredAccess"></param>
        /// <param name="ObjectAttributes"></param>
        /// <param name="LogFileName"></param>
        /// <param name="TmIdentity"></param>
        /// <param name="OpenOptions"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenTransactionManager(
            ref System.IntPtr TmHandle,
            uint DesiredAccess,
            System.IntPtr ObjectAttributes,
            System.IntPtr LogFileName,
            GUID TmIdentity,
            uint OpenOptions
            );

        /// <summary>
        /// The ZwPrePrepareComplete routine notifies KTM that the calling resource manager has finished preliminary preparation of a transaction's data.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwprepreparecomplete
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrePrepareComplete(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwPrePrepareEnlistment routine initiates the pre-prepare operation for a specified enlistment's transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwpreprepareenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrePrepareEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwPrepareComplete routine notifies KTM that the calling resource manager has finished preparing a transaction's data.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwpreparecomplete
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrepareComplete(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwPrepareEnlistment routine initiates the prepare operation for a specified enlistment's transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwprepareenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="TmVirtualClock"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrepareEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwQueryFullAttributesFile routine supplies network open information for the specified file.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryfullattributesfile
        /// </summary>
        /// <param name="ObjectAttributes"></param>
        /// <param name="FileInformation"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryFullAttributesFile(
            IntPtr ObjectAttributes,
            IntPtr FileInformation
            );

        /// <summary>
        /// ZwQueryInformationByName returns the requested information about a file specified by file name.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationbyname
        /// </summary>
        /// <param name="ObjectAttributes"></param>
        /// <param name="IoStatusBlock"></param>
        /// <param name="FileInformation"></param>
        /// <param name="Length"></param>
        /// <param name="FileInformationClass"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationByName(
            IntPtr ObjectAttributes,
            IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
            );

        /// <summary>
        /// The ZwQueryInformationEnlistment routine retrieves information about a specified enlistment object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationenlistment
        /// </summary>
        /// <param name="EnlistmentHandle"></param>
        /// <param name="EnlistmentInformationClass"></param>
        /// <param name="EnlistmentInformation"></param>
        /// <param name="EnlistmentInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationEnlistment(
            IntPtr EnlistmentHandle,
            ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
            IntPtr EnlistmentInformation,
            uint EnlistmentInformationLength,
            ref uint ReturnLength
            );

        /// <summary>
        /// The ZwQueryInformationFile routine returns various kinds of information about a file object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationfile
        /// </summary>
        /// <param name="FileHandle"></param>
        /// <param name="IoStatusBlock"></param>
        /// <param name="FileInformation"></param>
        /// <param name="Length"></param>
        /// <param name="FileInformationClass"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationFile(
            System.IntPtr FileHandle,
            System.IntPtr IoStatusBlock,
            System.IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
            );

        /// <summary>
        /// The ZwQueryInformationResourceManager routine retrieves information about a specified resource manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationresourcemanager
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="ResourceManagerInformationClass"></param>
        /// <param name="ResourceManagerInformation"></param>
        /// <param name="ResourceManagerInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationResourceManager(
            IntPtr ResourceManagerHandle,
            RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
            IntPtr ResourceManagerInformation,
            uint ResourceManagerInformationLength,
            ref uint ReturnLength
            );

        /// <summary>
        /// The ZwQueryInformationTransaction routine retrieves information about a specified transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationtransaction
        /// </summary>
        /// <param name="TransactionHandle"></param>
        /// <param name="TransactionInformationClass"></param>
        /// <param name="TransactionInformation"></param>
        /// <param name="TransactionInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationTransaction(
            IntPtr TransactionHandle,
            TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
            IntPtr TransactionInformation,
            uint TransactionInformationLength,
            ref uint ReturnLength
            );

        /// <summary>
        /// The ZwQueryInformationTransactionManager routine retrieves information about a specified transaction manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryinformationtransactionmanager
        /// </summary>
        /// <param name="TransactionManagerHandle"></param>
        /// <param name="TransactionManagerInformationClass"></param>
        /// <param name="TransactionManagerInformation"></param>
        /// <param name="TransactionManagerInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationTransactionManager(
            IntPtr TransactionManagerHandle,
            TRANSACTIONMANAGER_INFORMATION_CLASS TransactionManagerInformationClass,
            IntPtr TransactionManagerInformation,
            uint TransactionManagerInformationLength,
            ref uint ReturnLength
            );

        /// <summary>
        /// The ZwQueryKey routine provides information about the class of a registry key, and the number and sizes of its subkeys.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwquerykey
        /// </summary>
        /// <param name="KeyHandle">
        /// Handle to the registry key to obtain information about. 
        /// This handle is created by a successful call to ZwCreateKey or ZwOpenKey.
        /// </param>
        /// <param name="KeyInformationClass">
        /// Specifies a KEY_INFORMATION_CLASS value that determines the type of information returned in the KeyInformation buffer.
        /// </param>
        /// <param name="KeyInformation">
        /// Pointer to a caller-allocated buffer that receives the requested information.
        /// </param>
        /// <param name="Length">
        /// Specifies the size, in bytes, of the KeyInformation buffer.
        /// </param>
        /// <param name="ResultLength">
        /// Pointer to a variable that receives the size, in bytes, of the requested key information. 
        /// If ZwQueryKey returns STATUS_SUCCESS, the variable contains the amount of data returned. 
        /// If ZwQueryKey returns STATUS_BUFFER_OVERFLOW or STATUS_BUFFER_TOO_SMALL, 
        /// you can use the value of the variable to determine the required buffer size.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryKey(
            System.IntPtr KeyHandle,
            KEY_INFORMATION_CLASS KeyInformationClass,
            System.IntPtr KeyInformation,
            uint Length,
            ref uint ResultLength
            );

        /// <summary>
        /// The ZwQuerySymbolicLinkObject routine returns a Unicode string that contains the target of a symbolic link.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwquerysymboliclinkobject
        /// </summary>
        /// <param name="LinkHandle">
        /// Handle to the symbolic-link object that you want to query. 
        /// This handle is created by a successful call to ZwOpenSymbolicLinkObject.
        /// </param>
        /// <param name="LinkTarget">Pointer to an initialized Unicode string that receives the target of the symbolic link.</param>
        /// <param name="ReturnedLength">
        /// contains the maximum number of bytes to copy into the Unicode string at LinkTarget. 
        /// On output, the unsigned long integer contains the length of the Unicode string naming the target of the symbolic link.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySymbolicLinkObject(
            IntPtr LinkHandle,
            IntPtr LinkTarget,
            ref uint ReturnedLength
            );

        /// <summary>
        /// The ZwQueryValueKey routine returns a value entry for a registry key.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwqueryvaluekey
        /// </summary>
        /// <param name="KeyHandle">
        /// Handle to the key to read value entries from. This handle is created by a successful call to ZwCreateKey or ZwOpenKey.
        /// </param>
        /// <param name="ValueName">
        /// Pointer to the name of the value entry to obtain data for.
        /// </param>
        /// <param name="KeyValueInformationClass">
        /// A KEY_VALUE_INFORMATION_CLASS value that determines the type of information returned in the KeyValueInformation buffer.
        /// </param>
        /// <param name="KeyValueInformation">
        /// Pointer to a caller-allocated buffer that receives the requested information.
        /// </param>
        /// <param name="Length">
        /// Specifies the size, in bytes, of the KeyValueInformation buffer.
        /// </param>
        /// <param name="ResultLength">
        /// Pointer to a variable that receives the size, in bytes, of the key information. 
        /// If the ZwQueryValueKey routine returns STATUS_SUCCESS, callers can use the value of this variable to determine the amount of data returned. 
        /// If the routine returns STATUS_BUFFER_OVERFLOW or STATUS_BUFFER_TOO_SMALL, 
        /// callers can use the value of this variable to determine the size of buffer required to hold the key information.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryValueKey(
            System.IntPtr KeyHandle,
            System.IntPtr ValueName,
            KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
            System.IntPtr KeyValueInformation,
            uint Length,
            ref uint ResultLength
            );

        /// <summary>
        /// The ZwReadFile routine reads data from an open file.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwreadfile
        /// </summary>
        /// <param name="FileHandle">
        /// Handle to the file object. This handle is created by a successful call to ZwCreateFile or ZwOpenFile.
        /// </param>
        /// <param name="Event">
        /// Optionally, a handle to an event object to set to the signaled state after the read operation completes. 
        /// Device and intermediate drivers should set this parameter to NULL.
        /// </param>
        /// <param name="ApcRoutine">
        /// This parameter is reserved. Device and intermediate drivers should set this pointer to NULL.
        /// </param>
        /// <param name="ApcContext">
        /// This parameter is reserved. Device and intermediate drivers should set this pointer to NULL.
        /// </param>
        /// <param name="IoStatusBlock">
        /// Pointer to an IO_STATUS_BLOCK structure that receives the final completion status and information about the requested read operation.
        /// The Information member receives the number of bytes actually read from the file.
        /// </param>
        /// <param name="Buffer">
        /// Pointer to a caller-allocated buffer that receives the data read from the file.
        /// </param>
        /// <param name="Length">
        /// The size, in bytes, of the buffer pointed to by Buffer.
        /// </param>
        /// <param name="ByteOffset">
        /// Pointer to a variable that specifies the starting byte offset in the file where the read operation will begin. 
        /// If an attempt is made to read beyond the end of the file, ZwReadFile returns an error.
        /// </param>
        /// <param name="Key">Device and intermediate drivers should set this pointer to NULL.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadFile(
            System.IntPtr FileHandle,
            System.IntPtr Event,
            System.IntPtr ApcRoutine,
            System.IntPtr ApcContext,
            System.IntPtr IoStatusBlock,
            System.IntPtr Buffer,
            uint Length,
            ref LARGE_INTEGER ByteOffset,
            ref uint Key
            );

        /// <summary>
        /// The ZwReadOnlyEnlistment routine sets a specified enlistment to be read-only.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwreadonlyenlistment
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
        /// </param>
        /// <param name="TmVirtualClock">
        /// A pointer to a virtual clock value. 
        /// This parameter is optional and can be NULL.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadOnlyEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwRecoverEnlistment routine initiates a recovery operation for the transaction that is associated with a specified enlistment.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrecoverenlistment
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_RECOVER access to the object.
        /// </param>
        /// <param name="EnlistmentKey">
        /// A pointer to the enlistment key value that the resource manager previously specified as the EnlistmentKey parameter to ZwCreateEnlistment. 
        /// This parameter is optional and can be NULL if the resource manager did not provide an enlistment key when it called ZwCreateEnlistment.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRecoverEnlistment(
            IntPtr EnlistmentHandle,
            IntPtr EnlistmentKey
            );

        /// <summary>
        /// The ZwRecoverResourceManager routine tries to recover the transaction that is associated with each enlistment of a specified resource manager object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrecoverresourcemanager
        /// </summary>
        /// <param name="ResourceManagerHandle">
        /// A handle to a resource manager object that was obtained by a previous call to ZwCreateResourceManager or ZwOpenResourceManager. 
        /// The handle must have RESOURCEMANAGER_RECOVER access to the object.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRecoverResourceManager(
            IntPtr ResourceManagerHandle
            );

        /// <summary>
        /// The ZwRecoverTransactionManager routine reconstructs the state of the transaction manager object (including all transactions, enlistments, and resource managers) from the recovery information that is in the log stream.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrecovertransactionmanager
        /// </summary>
        /// <param name="TransactionManagerHandle">
        /// A handle to a transaction manager object that was obtained by a previous call to ZwCreateTransactionManager or ZwOpenTransactionManager. 
        /// The handle must have TRANSACTIONMANAGER_RECOVER access to the object.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRecoverTransactionManager(
            IntPtr TransactionManagerHandle
            );

        /// <summary>
        /// The ZwRollbackComplete routine notifies KTM that the calling resource manager has finished rolling back a transaction's data.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrollbackcomplete
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
        /// </param>
        /// <param name="TmVirtualClock">
        /// A pointer to a virtual clock value. 
        /// This parameter is optional and can be NULL. 
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRollbackComplete(
             IntPtr EnlistmentHandle,
             IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwRollbackEnlistment routine rolls back the transaction that is associated with a specified enlistment.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrollbackenlistment
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
        /// </param>
        /// <param name="TmVirtualClock">
        /// A pointer to a virtual clock value. 
        /// This parameter is optional and can be NULL. 
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRollbackEnlistment(
             IntPtr EnlistmentHandle,
             IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwRollbackTransaction routine initiates a rollback operation for a specified transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrollbacktransaction
        /// </summary>
        /// <param name="TransactionHandle">
        /// A handle to a transaction object that was obtained by a previous call to ZwCreateTransaction or ZwOpenTransaction. 
        /// The handle must have TRANSACTION_ROLLBACK access to the object.
        /// </param>
        /// <param name="Wait">
        /// A Boolean value that the caller sets to TRUE for synchronous operation or FALSE for asynchronous operation. 
        /// If this parameter is set to TRUE, the call does not return until the rollback operation is complete.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRollbackTransaction(
            IntPtr TransactionHandle,
            bool Wait
            );

        /// <summary>
        /// The ZwRollforwardTransactionManager routine initiates recovery operations for all of the in-progress transactions that are assigned to a specified transaction manager.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwrollforwardtransactionmanager
        /// </summary>
        /// <param name="TransactionManagerHandle">
        /// A handle to a transaction manager object that was obtained by a previous call to ZwCreateTransactionManager or ZwOpenTransactionManager.
        /// The handle must have TRANSACTIONMANAGER_RECOVER access to the object.
        /// </param>
        /// <param name="TmVirtualClock">
        /// A pointer to a virtual clock value. 
        /// This parameter is optional and can be NULL. 
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRollforwardTransactionManager(
             IntPtr TransactionManagerHandle,
             IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwSetInformationEnlistment routine sets information for a specified enlistment object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsetinformationenlistment
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_SET_INFORMATION access to the object.
        /// </param>
        /// <param name="EnlistmentInformationClass">
        /// A ENLISTMENT_INFORMATION_CLASS-typed enumeration value that specifies the type of information to be set. 
        /// This value must be EnlistmentRecoveryInformation.
        /// 
        /// The enumeration's EnlistmentBasicInformation and EnlistmentFullInformation values are not used with ZwSetInformationEnlistment.
        /// </param>
        /// <param name="EnlistmentInformation">
        /// A pointer to a caller-allocated buffer that contains caller-defined recovery information for the enlistment.
        /// </param>
        /// <param name="EnlistmentInformationLength">
        /// The length, in bytes, of the buffer that the EnlistmentInformation parameter points to.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationEnlistment(
              IntPtr EnlistmentHandle,
              ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
              IntPtr EnlistmentInformation,
              uint EnlistmentInformationLength
            );

        /// <summary>
        /// The ZwSetInformationFile routine changes various kinds of information about a file object.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsetinformationfile
        /// </summary>
        /// <param name="FileHandle">
        /// Handle to the file object. This handle is created by a successful call to ZwCreateFile or ZwOpenFile.
        /// </param>
        /// <param name="IoStatusBlock">
        /// Pointer to an IO_STATUS_BLOCK structure that receives the final completion status and information about the requested operation.
        /// The Information member receives the number of bytes set on the file.
        /// </param>
        /// <param name="FileInformation">
        /// Pointer to a buffer that contains the information to set for the file. 
        /// The particular structure in this buffer is determined by the FileInformationClass parameter. 
        /// For example, if the FileInformationClass parameter is set to the FileDispositionInformationEx constant, 
        /// this parameter should be a pointer to a FILE_DISPOSITION_INFORMATION_EX structure.
        /// </param>
        /// <param name="Length">
        /// The size, in bytes, of the FileInformation buffer.
        /// </param>
        /// <param name="FileInformationClass">
        /// The type of information, supplied in the buffer pointed to by FileInformation, to set for the file.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationFile(
            System.IntPtr FileHandle,
            System.IntPtr IoStatusBlock,
            System.IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
            );

        /// <summary>
        /// The ZwSetInformationResourceManager routine is not used.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsetinformationresourcemanager
        /// </summary>
        /// <param name="ResourceManagerHandle"></param>
        /// <param name="ResourceManagerInformationClass"></param>
        /// <param name="ResourceManagerInformation"></param>
        /// <param name="ResourceManagerInformationLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationResourceManager(
            IntPtr ResourceManagerHandle,
            RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
            IntPtr ResourceManagerInformation,
            uint ResourceManagerInformationLength
            );

        /// <summary>
        /// The ZwSetInformationTransaction routine sets information for a specified transaction.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsetinformationtransaction
        /// </summary>
        /// <param name="TransactionHandle">
        /// A handle to a transaction object that was obtained by a previous call to ZwCreateTransaction or ZwOpenTransaction. 
        /// The handle must have TRANSACTION_SET_INFORMATION access to the object.
        /// </param>
        /// <param name="TransactionInformationClass">
        /// A TRANSACTION_INFORMATION_CLASS-typed value that specifies the type of information to set. 
        /// The value must be TransactionPropertiesInformation.
        /// </param>
        /// <param name="TransactionInformation">
        /// A pointer to a caller-allocated buffer that contains the information to set. 
        /// The buffer's structure type must be TRANSACTION_PROPERTIES_INFORMATION.
        /// </param>
        /// <param name="TransactionInformationLength">
        /// The length, in bytes, of the buffer that the TransactionInformation parameter points to.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationTransaction(
            IntPtr TransactionHandle,
            TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
            IntPtr TransactionInformation,
            uint TransactionInformationLength
            );

        /// <summary>
        /// The ZwSetValueKey routine creates or replaces a registry key's value entry.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsetvaluekey
        /// </summary>
        /// <param name="KeyHandle">
        /// Handle to the registry key to write a value entry for. 
        /// This handle is created by a successful call to ZwCreateKey or ZwOpenKey.
        /// </param>
        /// <param name="ValueName">
        /// Pointer to the name of the value entry for which the data is to be written. 
        /// This parameter can be a NULL pointer if the value entry has no name. 
        /// If a name string is specified and the given name is not unique relative to its containing key, 
        /// the data for an existing value entry is replaced.
        /// </param>
        /// <param name="TitleIndex">
        /// This parameter is reserved. Device and intermediate drivers should set this parameter to zero.
        /// </param>
        /// <param name="Type">
        /// Device drivers should not attempt to call ZwSetValueKey to explicitly write value entries in a subkey of the \Registry...\ResourceMap key.
        /// Only the system can write value entries to the \Registry...\HardwareDescription tree.
        /// </param>
        /// <param name="Data">
        /// Pointer to a caller-allocated buffer that contains the data for the value entry.
        /// </param>
        /// <param name="DataSize">
        /// Specifies the size, in bytes, of the Data buffer. 
        /// If Type is REG_XXX_SZ, this value must include space for any terminating zeros.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetValueKey(
            IntPtr KeyHandle,
            IntPtr ValueName,
            uint TitleIndex,
            REG_KEY_TYPE Type,
            IntPtr Data,
            uint DataSize
            );

        /// <summary>
        /// The ZwSinglePhaseReject routine informs KTM that the calling resource manager will not support single-phase commit operations for a specified enlistment.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwsinglephasereject
        /// </summary>
        /// <param name="EnlistmentHandle">
        /// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. 
        /// The handle must have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
        /// </param>
        /// <param name="TmVirtualClock">
        /// A pointer to a virtual clock value. This parameter is optional and can be NULL.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSinglePhaseReject(
            IntPtr EnlistmentHandle,
            IntPtr TmVirtualClock
            );

        /// <summary>
        /// The ZwUnloadDriver routine unloads a driver from the system. 
        /// Use this routine with extreme caution (see the Remarks section below).
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwunloaddriver
        /// </summary>
        /// <param name="DriverServiceName">
        /// Pointer to a counted Unicode string that specifies a path to the driver's registry key, 
        /// \Registry\Machine\System\CurrentControlSet\Services\<DriverName>, 
        /// where DriverName is the name of the driver.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnloadDriver(
            IntPtr DriverServiceName
            );

        /// <summary>
        /// The ZwUnmapViewOfSection routine unmaps a view of a section from the virtual address space of a subject process.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwunmapviewofsection
        /// </summary>
        /// <param name="ProcessHandle">
        /// Handle to a process object that was previously passed to ZwMapViewOfSection.
        /// </param>
        /// <param name="BaseAddress">
        /// Pointer to the base virtual address of the view to unmap. This value can be any virtual address within the view.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnmapViewOfSection(
            IntPtr ProcessHandle,
            IntPtr BaseAddress
            );

        /// <summary>
        /// The ZwWriteFile routine writes data to an open file.
        /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-zwwritefile
        /// </summary>
        /// <param name="FileHandle">
        /// Handle to the file object. 
        /// This handle is created by a successful call to ZwCreateFile or ZwOpenFile.
        /// </param>
        /// <param name="Event">
        /// Optionally, a handle to an event object to set to the signaled state after the write operation completes. 
        /// Device and intermediate drivers should set this parameter to NULL.
        /// </param>
        /// <param name="ApcRoutine">
        /// This parameter is reserved. 
        /// Device and intermediate drivers should set this pointer to NULL.
        /// </param>
        /// <param name="ApcContext">
        /// This parameter is reserved. 
        /// Device and intermediate drivers should set this pointer to NULL.
        /// </param>
        /// <param name="IoStatusBlock">
        /// Pointer to an IO_STATUS_BLOCK structure that receives the final completion status and information about the requested write operation. 
        /// The Information member receives the number of bytes actually written to the file.
        /// </param>
        /// <param name="Buffer">
        /// Pointer to a caller-allocated buffer that contains the data to write to the file.
        /// </param>
        /// <param name="Length">
        /// The size, in bytes, of the buffer pointed to by Buffer.
        /// </param>
        /// <param name="ByteOffset">
        /// Pointer to a variable that specifies the starting byte offset in the file for beginning the write operation. 
        /// If Length and ByteOffset specify a write operation past the current end-of-file mark, 
        /// ZwWriteFile automatically extends the file and updates the end-of-file mark; 
        /// any bytes that are not explicitly written between such old and new end-of-file marks are defined to be zero.
        /// 
        /// If the call to ZwCreateFile set only the DesiredAccess flag FILE_APPEND_DATA, ByteOffset is ignored. 
        /// Data in the given Buffer, for Length bytes, is written starting at the current end of file.
        /// 
        /// If the call to ZwCreateFile set either of the CreateOptions flags, 
        /// FILE_SYNCHRONOUS_IO_ALERT or FILE_SYNCHRONOUS_IO_NONALERT, 
        /// the I/O Manager maintains the current file position. If so, 
        /// the caller of ZwWriteFile can specify that the current file position offset be used instead of an explicit ByteOffset value. 
        /// This specification can be made by using one of the following methods:
        /// 
        /// Specify a pointer to a LARGE_INTEGER value with the HighPart member set to -1 and the LowPart member set to the system-defined value FILE_USE_FILE_POINTER_POSITION.
        /// Pass a NULL pointer for ByteOffset.
        /// </param>
        /// <param name="Key">
        /// Device and intermediate drivers should set this pointer to NULL.
        /// </param>
        /// <returns>ZwWriteFile returns STATUS_SUCCESS on success or the appropriate NTSTATUS error code on failure.</returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWriteFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            IntPtr ByteOffset,
            ref uint Key
            );
    }
}
