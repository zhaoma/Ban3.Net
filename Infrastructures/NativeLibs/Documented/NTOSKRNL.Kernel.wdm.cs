using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static unsafe partial class NTOSKRNL
    {
        /*
         
        101 (0x0065),  (0x), CmCallbackGetKeyObjectID, 0x008696b0, None
        102 (0x0066),  (0x), CmCallbackGetKeyObjectIDEx, 0x006826c0, None
        103 (0x0067),  (0x), CmCallbackReleaseKeyObjectIDEx, 0x00682800, None
        104 (0x0068),  (0x), CmGetBoundTransaction, 0x006499a0, None
        105 (0x0069),  (0x), CmGetCallbackVersion, 0x008697e0, None
         
        107 (0x006b),  (0x), CmRegisterCallback, 0x007ccbd0, None
        108 (0x006c),  (0x), CmRegisterCallbackEx, 0x00869800, None
        110 (0x006e),  (0x), CmSetCallbackObjectContext, 0x005d08c0, None
        111 (0x006f),  (0x), CmUnRegisterCallback, 0x00869850, None
        
        159 (0x009f),  (0x), ExAcquireFastMutex, 0x00278da0, None
        160 (0x00a0),  (0x), ExAcquireFastMutexUnsafe, 0x00274980, None
        161 (0x00a1),  (0x), ExAcquireFastResourceExclusive, 0x0038e060, None
        162 (0x00a2),  (0x), ExAcquireFastResourceShared, 0x0038e740, None
        
        166 (0x00a6),  (0x), ExAcquireResourceExclusiveLite, 0x0027a8c0, None
        167 (0x00a7),  (0x), ExAcquireResourceSharedLite, 0x0027ac80, None
        168 (0x00a8),  (0x), ExAcquireRundownProtection, 0x00219590, None
        169 (0x00a9),  (0x), ExAcquireRundownProtectionCacheAware, 0x00219540, None
        170 (0x00aa),  (0x), ExAcquireRundownProtectionCacheAwareEx, 0x00202470, None
        171 (0x00ab),  (0x), ExAcquireRundownProtectionEx, 0x002024c0, None
        172 (0x00ac),  (0x), ExAcquireSharedStarveExclusive, 0x00301a20, None
        173 (0x00ad),  (0x), ExAcquireSharedWaitForExclusive, 0x005b2300, None
        174 (0x00ae),  (0x), ExAcquireSpinLockExclusive, 0x0034c850, None
        175 (0x00af),  (0x), ExAcquireSpinLockExclusiveAtDpcLevel, 0x0033a210, None
        176 (0x00b0),  (0x), ExAcquireSpinLockShared, 0x00346b90, None
        177 (0x00b1),  (0x), ExAcquireSpinLockSharedAtDpcLevel, 0x00336110, None
        181 (0x00b5),  (0x), ExAllocateCacheAwareRundownProtection, 0x0060eb10, None
        182 (0x00b6),  (0x), ExAllocatePool, 0x002541d0, None
        183 (0x00b7),  (0x), ExAllocatePool2, 0x009b5280, None
        184 (0x00b8),  (0x), ExAllocatePool3, 0x009b5340, None
        185 (0x00b9),  (0x), ExAllocatePoolWithQuota, 0x005b0b70, None
        186 (0x00ba),  (0x), ExAllocatePoolWithQuotaTag, 0x0029d680, None
        187 (0x00bb),  (0x), ExAllocatePoolWithTag, 0x009b5030, None
        188 (0x00bc),  (0x), ExAllocatePoolWithTagPriority, 0x00292360, None
        189 (0x00bd),  (0x), ExAllocateTimer, 0x00205f00, None
        192 (0x00c0),  (0x), ExCancelTimer, 0x00206930, None
        196 (0x00c4),  (0x), ExConvertExclusiveToSharedLite, 0x00233210, None
        200 (0x00c8),  (0x), ExCreateCallback, 0x00649cc0, None
        202 (0x00ca),  (0x), ExDeleteLookasideListEx, 0x00240790, None
        203 (0x00cb),  (0x), ExDeleteNPagedLookasideList, 0x00399ff0, None
        204 (0x00cc),  (0x), ExDeletePagedLookasideList, 0x00240710, None
        205 (0x00cd),  (0x), ExDeleteResourceLite, 0x002c9da0, None
        206 (0x00ce),  (0x), ExDeleteTimer, 0x00206060, None
        211 (0x00d3),  (0x), ExEnterCriticalRegionAndAcquireResourceExclusive, 0x0027abc0, None
        221 (0x00dd),  (0x), ExFlushLookasideListEx, 0x002407d0, None
        224 (0x00e0),  (0x), ExFreeCacheAwareRundownProtection, 0x00202080, None
        225 (0x00e1),  (0x), ExFreePool, 0x009b5010, None
        226 (0x00e2),  (0x), ExFreePoolWithTag, 0x009b5010, None
        229 (0x00e5),  (0x), ExGetExclusiveWaiterCount, 0x005b2970, None
        230 (0x00e6),  (0x), ExGetFirmwareEnvironmentVariable, 0x0064cc50, None
        231 (0x00e7),  (0x), ExGetFirmwareType, 0x003cf220, None
        233 (0x00e9),  (0x), ExGetPreviousMode, 0x002736c0, None
        234 (0x00ea),  (0x), ExGetSharedWaiterCount, 0x005b29b0, None
        238 (0x00ee),  (0x), ExInitializeFastResource, 0x003990b0, None
        239 (0x00ef),  (0x), ExInitializeLookasideListEx, 0x00202b60, None
        240 (0x00f0),  (0x), ExInitializeNPagedLookasideList, 0x0037a180, None
        241 (0x00f1),  (0x), ExInitializePagedLookasideList, 0x005dad20, None
        242 (0x00f2),  (0x), ExInitializePushLock, 0x00205240, None
        243 (0x00f3),  (0x), ExInitializeResourceLite, 0x00324e50, None
        244 (0x00f4),  (0x), ExInitializeRundownProtection, 0x00205240, None
        245 (0x00f5),  (0x), ExInitializeRundownProtectionCacheAware, 0x0060ea70, None
        248 (0x00f8),  (0x), ExInterlockedAddLargeInteger, 0x005b43c0, None
        249 (0x00f9),  (0x), ExInterlockedAddUlong, 0x003793a0, None
        251 (0x00fb),  (0x), ExInterlockedInsertHeadList, 0x00222f10, None
        252 (0x00fc),  (0x), ExInterlockedInsertTailList, 0x00222f90, None
        253 (0x00fd),  (0x), ExInterlockedPopEntryList, 0x005b4420, None
        254 (0x00fe),  (0x), ExInterlockedPushEntryList, 0x005b4470, None
        255 (0x00ff),  (0x), ExInterlockedRemoveHeadList, 0x00223040, None
        260 (0x0104),  (0x), ExIsProcessorFeaturePresent, 0x002532d0, None
        261 (0x0105),  (0x), ExIsResourceAcquiredExclusiveLite, 0x00213560, None
        262 (0x0106),  (0x), ExIsResourceAcquiredSharedLite, 0x002a14e0, None
        263 (0x0107),  (0x), ExIsSoftBoot, 0x0039a940, None
        264 (0x0108),  (0x), ExLocalTimeToSystemTime, 0x00234270, None
        266 (0x010a),  (0x), ExNotifyCallback, 0x00230d70, None
        267 (0x010b),  (0x), ExQueryDepthSList, 0x0021b250, None
        270 (0x010e),  (0x), ExQueryTimerResolution, 0x003cec00, None
        277 (0x0115),  (0x), ExRaiseStatus, 0x0021b950, None
        279 (0x0117),  (0x), ExReInitializeRundownProtection, 0x0037e020, None
        280 (0x0118),  (0x), ExReInitializeRundownProtectionCacheAware, 0x002107f0, None
        283 (0x011b),  (0x), ExRegisterCallback, 0x0037e400, None
        286 (0x011e),  (0x), ExReinitializeResourceLite, 0x0021e3f0, None
        295 (0x0127),  (0x), ExReleaseFastMutex, 0x00207460, None
        296 (0x0128),  (0x), ExReleaseFastMutexUnsafe, 0x00274b10, None
        304 (0x0130),  (0x), ExReleaseResourceAndLeaveCriticalRegion, 0x0027bd90, None
        306 (0x0132),  (0x), ExReleaseResourceForThreadLite, 0x0021c9b0, None
        307 (0x0133),  (0x), ExReleaseResourceLite, 0x0027a110, None
        308 (0x0134),  (0x), ExReleaseRundownProtection, 0x0021b9c0, None
        309 (0x0135),  (0x), ExReleaseRundownProtectionCacheAware, 0x0021b000, None
        310 (0x0136),  (0x), ExReleaseRundownProtectionCacheAwareEx, 0x002022d0, None
        311 (0x0137),  (0x), ExReleaseRundownProtectionEx, 0x005b3020, None
        312 (0x0138),  (0x), ExReleaseSpinLockExclusive, 0x00221e70, None
        313 (0x0139),  (0x), ExReleaseSpinLockExclusiveFromDpcLevel, 0x003240e0, None
        314 (0x013a),  (0x), ExReleaseSpinLockShared, 0x0021b0d0, None
        315 (0x013b),  (0x), ExReleaseSpinLockSharedFromDpcLevel, 0x00335f10, None
        316 (0x013c),  (0x), ExRundownCompleted, 0x00272800, None
        317 (0x013d),  (0x), ExRundownCompletedCacheAware, 0x00210840, None
        319 (0x013f),  (0x), ExSetFirmwareEnvironmentVariable, 0x0094f580, None
        321 (0x0141),  (0x), ExSetResourceOwnerPointer, 0x005b2a30, None
        322 (0x0142),  (0x), ExSetResourceOwnerPointerEx, 0x002f1670, None
        323 (0x0143),  (0x), ExSetTimer, 0x00206740, None
        324 (0x0144),  (0x), ExSetTimerResolution, 0x005af920, None
        327 (0x0147),  (0x), ExSizeOfRundownProtectionCacheAware, 0x00779590, None
        332 (0x014c),  (0x), ExSystemTimeToLocalTime, 0x002546d0, None
        344 (0x0158),  (0x), ExTryConvertSharedSpinLockExclusive, 0x00380eb0, None
        346 (0x015a),  (0x), ExTryToAcquireFastMutex, 0x002097b0, None
        351 (0x015f),  (0x), ExUnregisterCallback, 0x00380d10, None
        357 (0x0165),  (0x), ExWaitForRundownProtectionRelease, 0x002f84b0, None
        358 (0x0166),  (0x), ExWaitForRundownProtectionReleaseCacheAware, 0x00210730, None
        372 (0x0174),  (0x), FirstEntrySList, 0x00403720, None

         
        2177 (0x0881),  (0x), ZwSinglePhaseReject, 0x00074660, None
        2195 (0x0893),  (0x), ZwUnloadDriver, 0x00074750, None
        2201 (0x0899),  (0x), ZwUnmapViewOfSection, 0x00072d90, None
        2235 (0x08bb),  (0x), ZwWriteFile, 0x00072b50, None
         */


        /// same as Ntdll
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnloadDriver(
            IntPtr DriverServiceName
            );

        /// same as Ntdll
        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnmapViewOfSection(
            IntPtr ProcessHandle,
            IntPtr BaseAddress
            );

        /// same as Ntdll
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
