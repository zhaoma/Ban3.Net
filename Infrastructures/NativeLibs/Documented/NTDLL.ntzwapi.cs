using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class NTDLL
    {

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAcceptConnectPort(
            ref IntPtr PortHandle,
            IntPtr PortContext,
            IntPtr ConnectionRequest,
            bool AcceptConnection,
            IntPtr ServerView,
            ref IntPtr ClientView
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheck(
            IntPtr SecurityDescriptor,
            IntPtr ClientToken,
            ACCESS_MASK DesiredAccess,
            IntPtr GenericMapping,
            ref IntPtr PrivilegeSet,
            uint PrivilegeSetLength,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckAndAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ObjectTypeName,
            IntPtr ObjectName,
            IntPtr SecurityDescriptor,
            ACCESS_MASK DesiredAccess,
            IntPtr GenericMapping,
            bool ObjectCreation,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus,
            ref IntPtr GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckByType(
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            IntPtr ClientToken,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectTypeList,
            uint ObjectTypeListLength,
            IntPtr GenericMapping,
            ref IntPtr PrivilegeSet,
            ref uint PrivilegeSetLength,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckByTypeAndAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ObjectTypeName,
            IntPtr ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            ACCESS_MASK DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            IntPtr ObjectTypeList,
            uint ObjectTypeListLength,
            IntPtr GenericMapping,
            bool ObjectCreation,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus,
            ref IntPtr GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckByTypeResultList(
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            IntPtr ClientToken,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectTypeList,
            uint ObjectTypeListLength,
            IntPtr GenericMapping,
            ref IntPtr PrivilegeSet,
            ref uint PrivilegeSetLength,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckByTypeResultListAndAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ObjectTypeName,
            IntPtr ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            ACCESS_MASK DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            IntPtr ObjectTypeList,
            uint ObjectTypeListLength,
            IntPtr GenericMapping,
            bool ObjectCreation,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus,
            ref IntPtr GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAccessCheckByTypeResultListAndAuditAlarmByHandle(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ClientToken,
            IntPtr ObjectTypeName,
            IntPtr ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr PrincipalSelfSid,
            ACCESS_MASK DesiredAccess,
            AUDIT_EVENT_TYPE AuditType,
            uint Flags,
            IntPtr ObjectTypeList,
            uint ObjectTypeListLength,
            IntPtr GenericMapping,
            bool ObjectCreation,
            ref IntPtr GrantedAccess,
            ref IntPtr AccessStatus,
            ref IntPtr GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAcquireCMFViewOwnership(
            ref IntPtr TimeStamp,
            ref IntPtr tokenTaken,
            bool replaceExisting
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAddAtom(
            IntPtr AtomName,
            uint Length,
            ref IntPtr Atom
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAddAtomEx(
            IntPtr AtomName,
            uint Length,
            ref IntPtr Atom,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAddBootEntry(
            IntPtr BootEntry,
            ref uint Id
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAddDriverEntry(
            IntPtr DriverEntry,
            ref uint Id
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAdjustGroupsToken(
            IntPtr TokenHandle,
            bool ResetToDefault,
            IntPtr NewState,
            uint BufferLength,
            ref IntPtr PreviousState,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAdjustPrivilegesToken(
            IntPtr TokenHandle,
            bool DisableAllPrivileges,
            IntPtr NewState,
            uint BufferLength,
            ref IntPtr PreviousState,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAdjustTokenClaimsAndDeviceGroups(
            IntPtr TokenHandle,
            bool UserResetToDefault,
            bool DeviceResetToDefault,
            bool DeviceGroupsResetToDefault,
            IntPtr NewUserState,
            IntPtr NewDeviceState,
            IntPtr NewDeviceGroupsState,
            uint UserBufferLength,
            ref IntPtr PreviousUserState,
            uint DeviceBufferLength,
            ref IntPtr PreviousDeviceState,
            uint DeviceGroupsBufferLength,
            ref IntPtr PreviousDeviceGroups,
            ref uint UserReturnLength,
            ref uint DeviceReturnLength,
            ref uint DeviceGroupsReturnBufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlertResumeThread(
            IntPtr ThreadHandle,
            ref uint PreviousSuspendCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlertThread(
            IntPtr ThreadHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlertThreadByThreadId(
            IntPtr ThreadId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateLocallyUniqueId(
            ref IntPtr Luid
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateReserveObject(
            ref IntPtr MemoryReserveHandle,
            IntPtr ObjectAttributes,
            uint Type
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateUserPhysicalPages(
            IntPtr ProcessHandle,
            ref uint NumberOfPages,
            ref IntPtr UserPfnArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateUserPhysicalPagesEx(
            IntPtr ProcessHandle,
            ref uint NumberOfPages,
            ref IntPtr UserPfnArray,
            ref IntPtr ExtendedParameters,
            uint ExtendedParameterCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateUuids(
            ref IntPtr Time,
            ref IntPtr Range,
            ref IntPtr Sequence,
            ref IntPtr Seed
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAllocateVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint ZeroBits,
            uint RegionSize,
            uint AllocationType,
            uint Protect
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcAcceptConnectPort(
            ref IntPtr PortHandle,
            IntPtr ConnectionPortHandle,
            uint Flags,
            IntPtr ObjectAttributes,
            IntPtr PortAttributes,
            IntPtr PortContext,
            IntPtr ConnectionRequest,
            IntPtr ConnectionMessageAttributes,
            bool AcceptConnection
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCancelMessage(
            IntPtr PortHandle,
            uint Flags,
            IntPtr MessageContext
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcConnectPort(
            ref IntPtr PortHandle,
            IntPtr PortName,
            IntPtr ObjectAttributes,
            IntPtr PortAttributes,
            uint Flags,
            IntPtr RequiredServerSid,
            IntPtr ConnectionMessage,
            IntPtr BufferLength,
            IntPtr OutMessageAttributes,
            IntPtr InMessageAttributes,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcConnectPortEx(
            ref IntPtr PortHandle,
            IntPtr ConnectionPortObjectAttributes,
            IntPtr ClientPortObjectAttributes,
            IntPtr PortAttributes,
            uint Flags,
            IntPtr ServerSecurityRequirements,
            IntPtr ConnectionMessage,
            IntPtr BufferLength,
            IntPtr OutMessageAttributes,
            IntPtr InMessageAttributes,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCreatePort(
            ref IntPtr PortHandle,
            IntPtr ObjectAttributes,
            IntPtr PortAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCreatePortSection(
            IntPtr PortHandle,
            uint Flags,
            IntPtr SectionHandle,
            uint SectionSize,
            ref IntPtr AlpcSectionHandle,
            ref IntPtr ActualSectionSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCreateResourceReserve(
            IntPtr PortHandle,
            uint Flags,
            uint MessageSize,
            ref IntPtr ResourceId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCreateSectionView(
            IntPtr PortHandle,
            uint Flags,
            IntPtr ViewAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcCreateSecurityContext(
            IntPtr PortHandle,
            uint Flags,
            IntPtr SecurityAttribute
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcDeletePortSection(
            IntPtr PortHandle,
            uint Flags,
            IntPtr SectionHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcDeleteResourceReserve(
            IntPtr PortHandle,
            uint Flags,
            IntPtr ResourceId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcDeleteSectionView(
            IntPtr PortHandle,
            uint Flags,
            IntPtr ViewBase
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcDeleteSecurityContext(
            IntPtr PortHandle,
            uint Flags,
            IntPtr ContextHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcDisconnectPort(
            IntPtr PortHandle,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcImpersonateClientContainerOfPort(
            IntPtr PortHandle,
            IntPtr Message,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcImpersonateClientOfPort(
            IntPtr PortHandle,
            IntPtr Message,
            IntPtr Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcOpenSenderProcess(
            ref IntPtr ProcessHandle,
            IntPtr PortHandle,
            IntPtr PortMessage,
            uint Flags,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcOpenSenderThread(
            ref IntPtr ThreadHandle,
            IntPtr PortHandle,
            IntPtr PortMessage,
            uint Flags,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcQueryInformation(
            IntPtr PortHandle,
            IntPtr PortInformationClass,
            IntPtr PortInformation,
            uint Length,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcQueryInformationMessage(
            IntPtr PortHandle,
            IntPtr PortMessage,
            IntPtr MessageInformationClass,
            ref IntPtr MessageInformation,
            ref uint Length,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcRevokeSecurityContext(
            IntPtr PortHandle,
            uint Flags,
            IntPtr ContextHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcSendWaitReceivePort(
            IntPtr PortHandle,
            uint Flags,
            IntPtr SendMessage,
            IntPtr SendMessageAttributes,
            ref IntPtr ReceiveMessage,
            IntPtr BufferLength,
            IntPtr ReceiveMessageAttributes,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAlpcSetInformation(
            IntPtr PortHandle,
            IntPtr PortInformationClass,
            IntPtr PortInformation,
            uint Length
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAreMappedFilesTheSame(
            IntPtr File1MappedAsAnImage,
            IntPtr File2MappedAsFile
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAssignProcessToJobObject(
            IntPtr JobHandle,
            IntPtr ProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwAssociateWaitCompletionPacket(
            IntPtr WaitCompletionPacketHandle,
            IntPtr IoCompletionHandle,
            IntPtr TargetObjectHandle,
            IntPtr KeyContext,
            IntPtr ApcContext,
            IntPtr IoStatus,
            uint IoStatusInformation,
            ref IntPtr AlreadySignaled
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCallbackReturn(
            IntPtr OutputBuffer,
            uint OutputLength,
            IntPtr Status
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCallEnclave(
            IntPtr Routine,
            IntPtr Parameter,
            bool WaitForThread,
            ref IntPtr ReturnValue
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelIoFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelIoFileEx(
            IntPtr FileHandle,
            IntPtr IoRequestToCancel,
            ref IntPtr IoStatusBlock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelSynchronousIoFile(
            IntPtr ThreadHandle,
            IntPtr IoRequestToCancel,
            ref IntPtr IoStatusBlock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelTimer(
            IntPtr TimerHandle,
            ref IntPtr CurrentState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelTimer2(
            IntPtr TimerHandle,
            IntPtr Parameters
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCancelWaitCompletionPacket(
            IntPtr WaitCompletionPacketHandle,
            bool RemoveSignaledPacket
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwChangeProcessState(
            IntPtr ProcessStateChangeHandle,
            IntPtr ProcessHandle,
            IntPtr StateChangeType,
            IntPtr ExtendedInformation,
            uint ExtendedInformationLength,
            ulong Reserved
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwChangeThreadState(
            IntPtr ThreadStateChangeHandle,
            IntPtr ThreadHandle,
            IntPtr StateChangeType,
            IntPtr ExtendedInformation,
            uint ExtendedInformationLength,
            ulong Reserved
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwClearEvent(
            IntPtr EventHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCloseObjectAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            bool GenerateOnClose
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompactKeys(
            uint Count,
            IntPtr KeyArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompareObjects(
            IntPtr FirstObjectHandle,
            IntPtr SecondObjectHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompareSigningLevels(
            IntPtr FirstSigningLevel,
            IntPtr SecondSigningLevel
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompareTokens(
            IntPtr FirstTokenHandle,
            IntPtr SecondTokenHandle,
            ref IntPtr Equal
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompleteConnectPort(
            IntPtr PortHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCompressKey(
            IntPtr Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwConnectPort(
            ref IntPtr PortHandle,
            IntPtr PortName,
            IntPtr SecurityQos,
            IntPtr ClientView,
            IntPtr ServerView,
            ref uint MaxMessageLength,
            IntPtr ConnectionInformation,
            IntPtr ConnectionInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwContinue(
            IntPtr ContextRecord,
            bool TestAlert
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwContinueEx(
            IntPtr ContextRecord,
            IntPtr valid
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateDebugObject(
            ref IntPtr DebugObjectHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateDirectoryObjectEx(
            ref IntPtr DirectoryHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ShadowDirectoryHandle,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateEnclave(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint ZeroBits,
            uint Size,
            uint InitialCommitment,
            uint EnclaveType,
            IntPtr EnclaveInformation,
            uint EnclaveInformationLength,
            ref uint EnclaveError
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateEnlistment(
            ref IntPtr EnlistmentHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ResourceManagerHandle,
            IntPtr TransactionHandle,
            IntPtr ObjectAttributes,
            uint CreateOptions,
            uint NotificationMask,
            IntPtr EnlistmentKey
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateEvent(
            ref IntPtr EventHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint EventType,
            bool InitialState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateEventPair(
            ref IntPtr EventPairHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateFile(
            ref IntPtr FileHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            ref IntPtr IoStatusBlock,
            IntPtr AllocationSize,
            uint FileAttributes,
            uint ShareAccess,
            uint CreateDisposition,
            uint CreateOptions,
            IntPtr EaBuffer,
            uint EaLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateIoCompletion(
            ref IntPtr IoCompletionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint Count
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateIRTimer(
            ref IntPtr TimerHandle,
            ACCESS_MASK DesiredAccess
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateJobObject(
            ref IntPtr JobHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateJobSet(
            uint NumJob,
            IntPtr UserJobSet,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateKey(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint TitleIndex,
            IntPtr Class,
            uint CreateOptions,
            ref uint Disposition
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateKeyedEvent(
            ref IntPtr KeyedEventHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateKeyTransacted(
            ref IntPtr KeyHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint TitleIndex,
            IntPtr Class,
            uint CreateOptions,
            IntPtr TransactionHandle,
            ref uint Disposition
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateLowBoxToken(
            ref IntPtr TokenHandle,
            IntPtr ExistingTokenHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr PackageSid,
            uint CapabilityCount,
            IntPtr Capabilities,
            uint HandleCount,
            IntPtr Handles
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateMailslotFile(
            ref IntPtr FileHandle,
            uint DesiredAccess,
            IntPtr ObjectAttributes,
            ref IntPtr IoStatusBlock,
            uint CreateOptions,
            uint MailslotQuota,
            uint MaximumMessageSize,
            IntPtr ReadTimeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateMutant(
            ref IntPtr MutantHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            bool InitialOwner
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateNamedPipeFile(
            ref IntPtr FileHandle,
            uint DesiredAccess,
            IntPtr ObjectAttributes,
            ref IntPtr IoStatusBlock,
            uint ShareAccess,
            uint CreateDisposition,
            uint CreateOptions,
            uint NamedPipeType,
            uint ReadMode,
            uint CompletionMode,
            uint MaximumInstances,
            uint InboundQuota,
            uint OutboundQuota,
            IntPtr DefaultTimeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreatePagingFile(
            IntPtr PageFileName,
            IntPtr MinimumSize,
            IntPtr MaximumSize,
            uint Priority
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreatePartition(
            IntPtr ParentPartitionHandle,
            ref IntPtr PartitionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint PreferredNode
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreatePort(
            ref IntPtr PortHandle,
            IntPtr ObjectAttributes,
            uint MaxConnectionInfoLength,
            uint MaxMessageLength,
            uint MaxPoolUsage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreatePrivateNamespace(
            ref IntPtr NamespaceHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr BoundaryDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateProcess(
            ref IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ParentProcess,
            bool InheritObjectTable,
            IntPtr SectionHandle,
            IntPtr DebugPort,
            IntPtr TokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateProcessEx(
            ref IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ParentProcess,
            uint Flags, // PROCESS_CREATE_FLAGS_*
            IntPtr SectionHandle,
            IntPtr DebugPort,
            IntPtr TokenHandle,
            uint Reserved // JobMemberLevel
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateProcessStateChange(
            ref IntPtr ProcessStateChangeHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ProcessHandle,
            ulong Reserved
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateProfile(
            ref IntPtr ProfileHandle,
            IntPtr Process,
            IntPtr ProfileBase,
            uint ProfileSize,
            uint BucketSize,
            ref uint Buffer,
            uint BufferSize,
            IntPtr ProfileSource,
            IntPtr Affinity
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateProfileEx(
            ref IntPtr ProfileHandle,
            IntPtr Process,
            IntPtr ProfileBase,
            uint ProfileSize,
            uint BucketSize,
            ref uint Buffer,
            uint BufferSize,
            IntPtr ProfileSource,
            uint GroupCount,
            uint GroupAffinity
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateResourceManager(
            ref IntPtr ResourceManagerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr TmHandle,
            IntPtr RmGuid,
            IntPtr ObjectAttributes,
            uint CreateOptions,
            IntPtr Description
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateSectionEx(
            ref IntPtr SectionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr MaximumSize,
            uint SectionPageProtection,
            uint AllocationAttributes,
            IntPtr FileHandle,
            IntPtr ExtendedParameters,
            uint ExtendedParameterCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateSemaphore(
            ref IntPtr SemaphoreHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint InitialCount,
            uint MaximumCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateSymbolicLinkObject(
            ref IntPtr LinkHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr LinkTarget
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateThread(
            ref IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ProcessHandle,
            ref IntPtr ClientId,
            IntPtr ThreadContext,
            IntPtr InitialTeb,
            bool CreateSuspended
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateThreadEx(
            ref IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ProcessHandle,
            IntPtr PUSER_THREAD_START_ROUTINE,
            IntPtr Argument,
            uint CreateFlags, // THREAD_CREATE_FLAGS_*
            uint ZeroBits,
            uint StackSize,
            uint MaximumStackSize,
            IntPtr AttributeList
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateThreadStateChange(
            ref IntPtr ThreadStateChangeHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ThreadHandle,
            ulong Reserved
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTimer(
            ref IntPtr TimerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            uint TimerType
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTimer2(
            ref IntPtr TimerHandle,
            IntPtr Reserved1,
            IntPtr ObjectAttributes,
            uint Attributes,
            ACCESS_MASK DesiredAccess
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateToken(
            ref IntPtr TokenHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            TOKEN_TYPE Type,
            IntPtr AuthenticationId,
            IntPtr ExpirationTime,
            IntPtr User,
            IntPtr Groups,
            IntPtr Privileges,
            IntPtr Owner,
            IntPtr PrimaryGroup,
            IntPtr DefaultDacl,
            IntPtr Source
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTokenEx(
            ref IntPtr TokenHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            TOKEN_TYPE Type,
            IntPtr AuthenticationId,
            IntPtr ExpirationTime,
            IntPtr User,
            IntPtr Groups,
            IntPtr Privileges,
            IntPtr UserAttributes,
            IntPtr DeviceAttributes,
            IntPtr DeviceGroups,
            IntPtr MandatoryPolicy,
            IntPtr Owner,
            IntPtr PrimaryGroup,
            IntPtr DefaultDacl,
            IntPtr Source
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTransaction(
            ref IntPtr TransactionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            GUID Uow,
            IntPtr TmHandle,
            uint CreateOptions,
            uint IsolationLevel,
            uint IsolationFlags,
            IntPtr Timeout,
            IntPtr Description
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateTransactionManager(
            ref IntPtr TmHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr LogFileName,
            uint CreateOptions,
            uint CommitStrength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateUserProcess(
            ref IntPtr ProcessHandle,
            ref IntPtr ThreadHandle,
            ACCESS_MASK ProcessDesiredAccess,
            ACCESS_MASK ThreadDesiredAccess,
            IntPtr ProcessObjectAttributes,
            IntPtr ThreadObjectAttributes,
            uint ProcessFlags, // PROCESS_CREATE_FLAGS_*
            uint ThreadFlags, // THREAD_CREATE_FLAGS_*
            IntPtr ProcessParameters, // PRTL_USER_PROCESS_PARAMETERS
            IntPtr CreateInfo,
            IntPtr AttributeList
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateWaitablePort(
            ref IntPtr PortHandle,
            IntPtr ObjectAttributes,
            uint MaxConnectionInfoLength,
            uint MaxMessageLength,
            uint MaxPoolUsage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateWaitCompletionPacket(
            ref IntPtr WaitCompletionPacketHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateWnfStateName(
            ref IntPtr StateName,
            uint NameLifetime,
            uint DataScope,
            bool PersistData,
            IntPtr TypeId,
            uint MaximumStateSize,
            IntPtr SecurityDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwCreateWorkerFactory(
            ref IntPtr WorkerFactoryHandleReturn,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr CompletionPortHandle,
            IntPtr WorkerProcessHandle,
            IntPtr StartRoutine,
            IntPtr StartParameter,
            uint MaxThreadCount,
            uint StackReserve,
            uint StackCommit
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDebugActiveProcess(
            IntPtr ProcessHandle,
            IntPtr DebugObjectHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDebugContinue(
            IntPtr DebugObjectHandle,
            IntPtr ClientId,
            IntPtr ContinueStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDelayExecution(
            bool Alertable,
            IntPtr DelayInterval
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteAtom(
            uint Atom
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteBootEntry(
            uint Id
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteDriverEntry(
            uint Id
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteFile(
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteObjectAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            bool GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeletePrivateNamespace(
            IntPtr NamespaceHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteWnfStateData(
            IntPtr StateName,
            IntPtr ExplicitScope
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeleteWnfStateName(
            IntPtr StateName
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDeviceIoControlFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            uint IoControlCode,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr OutputBuffer,
            uint OutputBufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDisableLastKnownGood(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDisplayString(
            IntPtr String
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDrawText(
            IntPtr Text
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDuplicateObject(
            IntPtr SourceProcessHandle,
            IntPtr SourceHandle,
            IntPtr TargetProcessHandle,
            ref IntPtr TargetHandle,
            ACCESS_MASK DesiredAccess,
            uint HandleAttributes,
            uint Options
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwDuplicateToken(
            IntPtr ExistingTokenHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            bool EffectiveOnly,
            uint Type,
            ref IntPtr NewTokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnableLastKnownGood(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateBootEntries(
            IntPtr Buffer,
            ref uint BufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateDriverEntries(
            IntPtr Buffer,
            ref uint BufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateKey(
            IntPtr KeyHandle,
            uint Index,
            KEY_INFORMATION_CLASS KeyInformationClass,
            IntPtr KeyInformation,
            uint Length,
            ref IntPtr ResultLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateSystemEnvironmentValuesEx(
            uint InformationClass, // SYSTEM_ENVIRONMENT_INFORMATION_CLASS
            ref IntPtr Buffer,
            ref uint BufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateTransactionObject(
            IntPtr RootObjectHandle,
            KTMOBJECT_TYPE QueryType,
            IntPtr ObjectCursor,
            uint ObjectCursorLength,
            ref IntPtr ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwEnumerateValueKey(
            IntPtr KeyHandle,
            uint Index,
            IntPtr KeyValueInformationClass,
            IntPtr KeyValueInformation,
            uint Length,
            ref IntPtr ResultLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwExtendSection(
            IntPtr SectionHandle,
            IntPtr NewSectionSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFilterBootOption(
            IntPtr FilterOperation,
            uint ObjectType,
            uint ElementType,
            IntPtr Data,
            uint DataSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFilterToken(
            IntPtr ExistingTokenHandle,
            uint Flags,
            IntPtr SidsToDisable,
            IntPtr PrivilegesToDelete,
            IntPtr RestrictedSids,
            ref IntPtr NewTokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFilterTokenEx(
            IntPtr ExistingTokenHandle,
            uint Flags,
            IntPtr SidsToDisable,
            IntPtr PrivilegesToDelete,
            IntPtr RestrictedSids,
            uint DisableUserClaimsCount,
            IntPtr UserClaimsToDisable,
            uint DisableDeviceClaimsCount,
            IntPtr DeviceClaimsToDisable,
            IntPtr DeviceGroupsToDisable,
            IntPtr RestrictedUserAttributes,
            IntPtr RestrictedDeviceAttributes,
            IntPtr RestrictedDeviceGroups,
            ref IntPtr NewTokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFindAtom(
            IntPtr AtomName,
            uint Length,
            ref IntPtr Atom
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushBuffersFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushBuffersFileEx(
            IntPtr FileHandle,
            uint Flags,
            IntPtr Parameters,
            uint ParametersSize,
            ref IntPtr IoStatusBlock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushInstallUILanguage(
            IntPtr InstallUILanguage,
            uint SetComittedFlag
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushInstructionCache(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint Length
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern void ZwFlushProcessWriteBuffers(
            IntPtr ProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr RegionSize,
            IntPtr IoStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFlushWriteBuffer(
            IntPtr ProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFreeUserPhysicalPages(
            IntPtr ProcessHandle,
            ref uint NumberOfPages,
            IntPtr UserPfnArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFreeVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr RegionSize,
            uint FreeType
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFreezeRegistry(
            uint TimeOutInSeconds
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFreezeTransactions(
            IntPtr FreezeTimeout,
            IntPtr ThawTimeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwFsControlFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            uint FsControlCode,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr OutputBuffer,
            uint OutputBufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetCachedSigningLevel(
            IntPtr File,
            ref IntPtr Flags,
            ref IntPtr SigningLevel,
            IntPtr Thumbprint,
            IntPtr ThumbprintSize,
            ref uint ThumbprintAlgorithm
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetCompleteWnfStateSubscription(
            IntPtr OldDescriptorStateName,
            IntPtr OldSubscriptionId,
            uint OldDescriptorEventMask,
            uint OldDescriptorStatus,
            IntPtr NewDeliveryDescriptor,
            uint DescriptorSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetContextThread(
            IntPtr ThreadHandle,
            IntPtr ThreadContext
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint ZwGetCurrentProcessorNumber(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern uint ZwGetCurrentProcessorNumberEx(
            ref IntPtr ProcessorNumber
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetDevicePowerState(
            IntPtr Device,
            ref IntPtr State
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetMUIRegistryInfo(
            uint Flags,
            ref uint DataSize,
            ref IntPtr Data
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetNextProcess(
            IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            uint HandleAttributes,
            uint Flags,
            ref IntPtr NewProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetNextThread(
            IntPtr ProcessHandle,
            IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            uint HandleAttributes,
            uint Flags,
            ref IntPtr NewThreadHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetNlsSectionPtr(
            uint SectionType,
            uint SectionData,
            IntPtr ContextData,
            ref IntPtr SectionPointer,
            ref IntPtr SectionSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetNotificationResourceManager(
            IntPtr ResourceManagerHandle,
            ref IntPtr TransactionNotification,
            uint NotificationLength,
            IntPtr Timeout,
            ref uint ReturnLength,
            uint Asynchronous,
            uint AsynchronousContext
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetPlugPlayEvent(
            IntPtr EventHandle,
            IntPtr Context,
            IntPtr EventBlock,
            uint EventBufferSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwGetWriteWatch(
            IntPtr ProcessHandle,
            uint Flags,
            IntPtr BaseAddress,
            uint RegionSize,
            IntPtr UserAddressArray,
            ref uint EntriesInUserAddressArray,
            ref IntPtr Granularity
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwImpersonateAnonymousToken(
            IntPtr ThreadHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwImpersonateClientOfPort(
            IntPtr PortHandle,
            IntPtr Message
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwImpersonateThread(
            IntPtr ServerThreadHandle,
            IntPtr ClientThreadHandle,
            IntPtr SecurityQos
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwInitializeEnclave(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr EnclaveInformation,
            uint EnclaveInformationLength,
            ref uint EnclaveError
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwInitializeNlsFiles(
            ref IntPtr BaseAddress,
            ref IntPtr DefaultLocaleId,
            ref IntPtr DefaultCasingTableSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwInitializeRegistry(
            uint BootCondition
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwInitiatePowerAction(
            IntPtr SystemAction,
            SYSTEM_POWER_STATE LightestSystemState,
            uint Flags, // POWER_ACTION_* flags
            bool Asynchronous
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwIsProcessInJob(
            IntPtr ProcessHandle,
            IntPtr JobHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern bool ZwIsSystemResumeAutomatic(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwIsUILanguageComitted(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwListenPort(
            IntPtr PortHandle,
            ref IntPtr ConnectionRequest
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadEnclaveData(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr Buffer,
            uint BufferSize,
            uint Protect,
            IntPtr PageInformation,
            uint PageInformationLength,
            ref uint NumberOfBytesWritten,
            ref uint EnclaveError
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadKey(
            IntPtr TargetKey,
            IntPtr SourceFile
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadKey2(
            IntPtr TargetKey,
            IntPtr SourceFile,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadKey3(
            IntPtr TargetKey,
            IntPtr SourceFile,
            uint Flags,
            IntPtr LoadEntries,
            uint LoadEntryCount,
            ACCESS_MASK DesiredAccess,
            ref IntPtr RootHandle,
            IntPtr Reserved
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLoadKeyEx(
            IntPtr TargetKey,
            IntPtr SourceFile,
            uint Flags,
            IntPtr TrustClassKey, // this and below were added on Win10
            IntPtr Event,
            ACCESS_MASK DesiredAccess,
            ref IntPtr RootHandle,
            IntPtr Reserved // previously PIO_STATUS_BLOCK
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLockFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr ByteOffset,
            IntPtr Length,
            uint Key,
            bool FailImmediately,
            bool ExclusiveLock
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLockProductActivationKeys(
            IntPtr pPrivateVer,
            IntPtr pSafeMode
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLockRegistryKey(
            IntPtr KeyHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwLockVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr RegionSize,
            uint MapType
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMakePermanentObject(
            IntPtr Handle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwManagePartition(
            IntPtr TargetHandle,
            IntPtr SourceHandle,
            IntPtr PartitionInformationClass,
            IntPtr PartitionInformation,
            uint PartitionInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMapCMFModule(
            uint What,
            uint Index,
            ref uint CacheIndexOut,
            ref uint CacheFlagsOut,
            ref uint ViewSizeOut,
            ref IntPtr BaseAddress
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMapUserPhysicalPages(
            IntPtr VirtualAddress,
            uint NumberOfPages,
            uint UserPfnArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMapUserPhysicalPagesScatter(
            IntPtr VirtualAddresses,
            uint NumberOfPages,
            IntPtr UserPfnArray
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwMapViewOfSection(
            IntPtr SectionHandle,
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint ZeroBits,
            uint CommitSize,
            IntPtr SectionOffset,
            uint ViewSize,
            uint InheritDisposition,
            uint AllocationType,
            uint Win32Protect
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwModifyBootEntry(
            IntPtr BootEntry
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwModifyDriverEntry(
            IntPtr DriverEntry
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwNotifyChangeDirectoryFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer, // FILE_NOTIFY_INFORMATION
            uint Length,
            uint CompletionFilter,
            bool WatchTree
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwNotifyChangeDirectoryFileEx(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            uint CompletionFilter,
            bool WatchTree,
            IntPtr DirectoryNotifyInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwNotifyChangeKey(
            IntPtr KeyHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            uint CompletionFilter,
            bool WatchTree,
            IntPtr Buffer,
            uint BufferSize,
            bool Asynchronous
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwNotifyChangeMultipleKeys(
            IntPtr MasterKeyHandle,
            uint Count,
            IntPtr SubordinateObjects,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            uint CompletionFilter,
            bool WatchTree,
            IntPtr Buffer,
            uint BufferSize,
            bool Asynchronous
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwNotifyChangeSession(
            IntPtr SessionHandle,
            uint ChangeSequenceNumber,
            IntPtr ChangeTimeStamp,
            IO_SESSION_EVENT Event,
            IO_SESSION_STATE NewState,
            IO_SESSION_STATE PreviousState,
            IntPtr Payload,
            uint PayloadSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenDirectoryObject(
            ref IntPtr DirectoryHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );



        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenEventPair(
            ref IntPtr EventPairHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenIoCompletion(
            ref IntPtr IoCompletionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenJobObject(
            ref IntPtr JobHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenKeyedEvent(
            ref IntPtr KeyedEventHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenMutant(
            ref IntPtr MutantHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenObjectAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ObjectTypeName,
            IntPtr ObjectName,
            IntPtr SecurityDescriptor,
            IntPtr ClientToken,
            ACCESS_MASK DesiredAccess,
            ACCESS_MASK GrantedAccess,
            IntPtr Privileges,
            bool ObjectCreation,
            bool AccessGranted,
            ref IntPtr GenerateOnClose
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenPartition(
            ref IntPtr PartitionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenPrivateNamespace(
            ref IntPtr NamespaceHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr BoundaryDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenProcess(
            ref IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ClientId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenProcessToken(
            IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            ref IntPtr TokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenProcessTokenEx(
            IntPtr ProcessHandle,
            ACCESS_MASK DesiredAccess,
            uint HandleAttributes,
            ref IntPtr TokenHandle
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenSemaphore(
            ref IntPtr SemaphoreHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenSession(
            ref IntPtr SessionHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenThread(
            ref IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes,
            IntPtr ClientId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenThreadToken(
            IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            bool OpenAsSelf,
            ref IntPtr TokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenThreadTokenEx(
            IntPtr ThreadHandle,
            ACCESS_MASK DesiredAccess,
            bool OpenAsSelf,
            uint HandleAttributes,
            ref IntPtr TokenHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwOpenTimer(
            ref IntPtr TimerHandle,
            ACCESS_MASK DesiredAccess,
            IntPtr ObjectAttributes
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPlugPlayControl(
            IntPtr PnPControlClass,
            IntPtr PnPControlData,
            uint PnPControlDataLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPowerInformation(
            IntPtr InformationLevel,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr OutputBuffer,
            uint OutputBufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrivilegeCheck(
            IntPtr ClientToken,
            IntPtr RequiredPrivileges,
            ref IntPtr Result
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrivilegedServiceAuditAlarm(
            IntPtr SubsystemName,
            IntPtr ServiceName,
            IntPtr ClientToken,
            IntPtr Privileges,
            bool AccessGranted
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPrivilegeObjectAuditAlarm(
            IntPtr SubsystemName,
            IntPtr HandleId,
            IntPtr ClientToken,
            ACCESS_MASK DesiredAccess,
            IntPtr Privileges,
            bool AccessGranted
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPropagationComplete(
            IntPtr ResourceManagerHandle,
            uint RequestCookie,
            uint BufferLength,
            IntPtr Buffer
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPropagationFailed(
            IntPtr ResourceManagerHandle,
            uint RequestCookie,
            IntPtr PropStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwProtectVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr RegionSize,
            uint NewProtect,
            ref IntPtr OldProtect
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwPulseEvent(
            IntPtr EventHandle,
            ref IntPtr PreviousState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryAttributesFile(
            IntPtr ObjectAttributes,
            ref IntPtr FileInformation
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryBootEntryOrder(
            IntPtr Ids,
            ref uint Count
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryBootOptions(
            IntPtr BootOptions,
            ref uint BootOptionsLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDebugFilterState(
            uint ComponentId,
            uint Level
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDefaultLocale(
            bool UserProfile,
            ref IntPtr DefaultLocaleId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDefaultUILanguage(
            IntPtr DefaultUILanguageId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDirectoryFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            IntPtr FileInformationClass,
            bool ReturnSingleEntry,
            IntPtr FileName,
            bool RestartScan
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDirectoryFileEx(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass,
            uint QueryFlags,
            IntPtr FileName
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDirectoryObject(
            IntPtr DirectoryHandle,
            IntPtr Buffer,
            uint Length,
            bool ReturnSingleEntry,
            bool RestartScan,
            ref uint Context,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryDriverEntryOrder(
            IntPtr Ids,
            ref uint Count
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryEaFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            bool ReturnSingleEntry,
            IntPtr EaList,
            uint EaListLength,
            IntPtr EaIndex,
            bool RestartScan
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryEvent(
            IntPtr EventHandle,
            EVENT_INFO_CLASS EventInformationClass,
            IntPtr EventInformation,
            uint EventInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryFullAttributesFile(
            IntPtr ObjectAttributes,
            ref IntPtr FileInformation
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationAtom(
            uint Atom,
            uint AtomInformationClass,
            IntPtr AtomInformation,
            uint AtomInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationByName(
            IntPtr ObjectAttributes,
            ref IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationJobObject(
            IntPtr JobHandle,
            uint JobObjectInformationClass,
            IntPtr JobObjectInformation,
            uint JobObjectInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationPort(
            IntPtr PortHandle,
            IntPtr PortInformationClass,
            IntPtr PortInformation,
            uint Length,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationProcess(
            IntPtr ProcessHandle,
            IntPtr ProcessInformationClass,
            IntPtr ProcessInformation,
            uint ProcessInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationThread(
            IntPtr ThreadHandle,
            uint ThreadInformationClass,
            IntPtr ThreadInformation,
            uint ThreadInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationToken(
            IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            uint TokenInformationLength,
            ref IntPtr ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInformationWorkerFactory(
            IntPtr WorkerFactoryHandle,
            uint WorkerFactoryInformationClass,
            IntPtr WorkerFactoryInformation,
            uint WorkerFactoryInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryInstallUILanguage(
            ref GUID InstallUILanguageId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryIntervalProfile(
            uint ProfileSource,
            ref IntPtr Interval
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryIoCompletion(
            IntPtr IoCompletionHandle,
            uint IoCompletionInformationClass,
            IntPtr IoCompletionInformation,
            uint IoCompletionInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryKey(
            IntPtr KeyHandle,
            KEY_INFORMATION_CLASS KeyInformationClass,
            IntPtr KeyInformation,
            uint Length,
            ref IntPtr ResultLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryLicenseValue(
            IntPtr ValueName,
            ref uint Type,
            IntPtr Data,
            uint DataSize,
            ref IntPtr ResultDataSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryMultipleValueKey(
            IntPtr KeyHandle,
            IntPtr ValueEntries,
            uint EntryCount,
            IntPtr ValueBuffer,
            ref uint BufferLength,
            ref uint RequiredBufferLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryMutant(
            IntPtr MutantHandle,
            uint MutantInformationClass,
            IntPtr MutantInformation,
            uint MutantInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryObject(
            IntPtr Handle,
            uint ObjectInformationClass,
            IntPtr ObjectInformation,
            uint ObjectInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryOpenSubKeys(
            IntPtr TargetKey,
            ref IntPtr HandleCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryOpenSubKeysEx(
            IntPtr TargetKey,
            uint BufferLength,
            IntPtr Buffer,
            ref IntPtr RequiredSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryPerformanceCounter(
            ref IntPtr PerformanceCounter,
            ref IntPtr PerformanceFrequency
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryQuotaInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            bool ReturnSingleEntry,
            IntPtr SidList,
            uint SidListLength,
            IntPtr StartSid,
            bool RestartScan
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySection(
            IntPtr SectionHandle,
            uint SectionInformationClass,
            IntPtr SectionInformation,
            uint SectionInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySecurityAttributesToken(
            IntPtr TokenHandle,
            IntPtr Attributes,
            uint NumberOfAttributes,
            IntPtr Buffer, // PTOKEN_SECURITY_ATTRIBUTES_INFORMATION
            uint Length,
            ref IntPtr ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySecurityObject(
            IntPtr Handle,
            SECURITY_INFORMATION SecurityInformation,
            IntPtr SecurityDescriptor,
            uint Length,
            ref IntPtr LengthNeeded
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySemaphore(
            IntPtr SemaphoreHandle,
            IntPtr SemaphoreInformationClass,
            IntPtr SemaphoreInformation,
            uint SemaphoreInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySystemEnvironmentValue(
            IntPtr VariableName,
            IntPtr VariableValue,
            uint ValueLength,
            ref IntPtr ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySystemEnvironmentValueEx(
            IntPtr VariableName,
            IntPtr VendorGuid,
            IntPtr Value,
            ref uint ValueLength,
            ref uint Attributes // EFI_VARIABLE_*
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySystemInformation(
            SYSTEM_INFORMATION_CLASS SystemInformationClass,
            IntPtr SystemInformation,
            uint SystemInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySystemInformationEx(
            SYSTEM_INFORMATION_CLASS SystemInformationClass,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr SystemInformation,
            uint SystemInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQuerySystemTime(
            ref IntPtr SystemTime
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryTimer(
            IntPtr TimerHandle,
            IntPtr TimerInformationClass,
            IntPtr TimerInformation,
            uint TimerInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryTimerResolution(
            ref IntPtr MaximumTime,
            ref IntPtr MinimumTime,
            ref IntPtr CurrentTime
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryValueKey(
            IntPtr KeyHandle,
            IntPtr ValueName,
            KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
            IntPtr KeyValueInformation,
            uint Length,
            ref IntPtr ResultLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr MemoryInformationClass,
            IntPtr MemoryInformation,
            uint MemoryInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryVolumeInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr FsInformation,
            uint Length,
            IntPtr FsInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryWnfStateData(
            IntPtr StateName,
            IntPtr TypeId,
            IntPtr ExplicitScope,
            ref IntPtr ChangeStamp,
            IntPtr Buffer,
            ref uint BufferSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueryWnfStateNameInformation(
            IntPtr StateName,
            IntPtr NameInfoClass,
            IntPtr ExplicitScope,
            IntPtr InfoBuffer,
            uint InfoBufferSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueueApcThread(
            IntPtr ThreadHandle,
            IntPtr ApcRoutine,
            IntPtr ApcArgument1,
            IntPtr ApcArgument2,
            IntPtr ApcArgument3
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueueApcThreadEx(
            IntPtr ThreadHandle,
            IntPtr ReserveHandle, // NtAllocateReserveObject
            IntPtr ApcRoutine,
            IntPtr ApcArgument1,
            IntPtr ApcArgument2,
            IntPtr ApcArgument3
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwQueueApcThreadEx2(
            IntPtr ThreadHandle,
            IntPtr ReserveHandle, // NtAllocateReserveObject
            uint ApcFlags, // QUEUE_USER_APC_FLAGS
            IntPtr ApcRoutine,
            IntPtr ApcArgument1,
            IntPtr ApcArgument2,
            IntPtr ApcArgument3
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRaiseException(
            IntPtr ExceptionRecord,
            IntPtr ContextRecord,
            bool FirstChance
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRaiseHardError(
            IntPtr ErrorStatus,
            uint NumberOfParameters,
            uint UnicodeStringParameterMask,
            uint Parameters,
            uint ValidResponseOptions,
            ref IntPtr Response
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            IntPtr ByteOffset,
            IntPtr Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadFileScatter(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr SegmentArray,
            uint Length,
            IntPtr ByteOffset,
            IntPtr Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadRequestData(
            IntPtr PortHandle,
            IntPtr Message,
            uint DataEntryIndex,
            IntPtr Buffer,
            uint BufferSize,
            ref uint NumberOfBytesRead
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReadVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr Buffer,
            uint BufferSize,
            ref uint NumberOfBytesRead
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRegisterProtocolAddressInformation(
            IntPtr ResourceManager,
            IntPtr ProtocolId,
            uint ProtocolInformationSize,
            IntPtr ProtocolInformation,
            uint CreateOptions
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRegisterThreadTerminatePort(
            IntPtr PortHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReleaseCMFViewOwnership(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReleaseKeyedEvent(
            IntPtr KeyedEventHandle,
            IntPtr KeyValue,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReleaseMutant(
            IntPtr MutantHandle,
            ref IntPtr PreviousCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReleaseSemaphore(
            IntPtr SemaphoreHandle,
            uint ReleaseCount,
            ref IntPtr PreviousCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReleaseWorkerFactoryWorker(
            IntPtr WorkerFactoryHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRemoveIoCompletion(
            IntPtr IoCompletionHandle,
            ref IntPtr KeyContext,
            ref IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRemoveIoCompletionEx(
            IntPtr IoCompletionHandle,
            IntPtr IoCompletionInformation,
            uint Count,
            ref IntPtr NumEntriesRemoved,
            IntPtr Timeout,
            bool Alertable
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRemoveProcessDebug(
            IntPtr ProcessHandle,
            IntPtr DebugObjectHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRenameKey(
            IntPtr KeyHandle,
            IntPtr NewName
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRenameTransactionManager(
            IntPtr LogFileName,
            GUID ExistingTransactionManagerGuid
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplaceKey(
            IntPtr NewFile,
            IntPtr TargetHandle,
            IntPtr OldFile
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplacePartitionUnit(
            IntPtr TargetInstancePath,
            IntPtr SpareInstancePath,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplyPort(
            IntPtr PortHandle,
            IntPtr ReplyMessage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplyWaitReceivePort(
            IntPtr PortHandle,
            ref IntPtr PortContext,
            IntPtr ReplyMessage,
            ref IntPtr ReceiveMessage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplyWaitReceivePortEx(
            IntPtr PortHandle,
            ref IntPtr PortContext,
            IntPtr ReplyMessage,
            ref IntPtr ReceiveMessage,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwReplyWaitReplyPort(
            IntPtr PortHandle,
            IntPtr ReplyMessage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRequestPort(
            IntPtr PortHandle,
            IntPtr RequestMessage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRequestWaitReplyPort(
            IntPtr PortHandle,
            IntPtr RequestMessage,
            ref IntPtr ReplyMessage
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRequestWakeupLatency(
            uint latency
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwResetEvent(
            IntPtr EventHandle,
            ref IntPtr PreviousState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwResetWriteWatch(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint RegionSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRestoreKey(
            IntPtr KeyHandle,
            IntPtr FileHandle,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwResumeProcess(
            IntPtr ProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwResumeThread(
            IntPtr ThreadHandle,
            ref uint PreviousSuspendCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwRevertContainerImpersonation(
            IntPtr hHandle
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSaveKey(
            IntPtr KeyHandle,
            IntPtr FileHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSaveKeyEx(
            IntPtr KeyHandle,
            IntPtr FileHandle,
            uint Format
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSaveMergedKeys(
            IntPtr HighPrecedenceKeyHandle,
            IntPtr LowPrecedenceKeyHandle,
            IntPtr FileHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSecureConnectPort(
            ref IntPtr PortHandle,
            IntPtr PortName,
            IntPtr SecurityQos,
            IntPtr ClientView,
            IntPtr RequiredServerSid,
            IntPtr ServerView,
            ref uint MaxMessageLength,
            IntPtr ConnectionInformation,
            IntPtr ConnectionInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSerializeBoot(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetBootEntryOrder(
            IntPtr Ids,
            uint Count
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetBootOptions(
            IntPtr BootOptions,
            uint FieldsToChange
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetCachedSigningLevel(
            uint Flags,
            uint InputSigningLevel,
            IntPtr SourceFiles,
            uint SourceFileCount,
            IntPtr TargetFile
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetContextThread(
            IntPtr ThreadHandle,
            IntPtr ThreadContext
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetDebugFilterState(
            uint ComponentId,
            uint Level,
            bool State
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetDefaultHardErrorPort(
            IntPtr DefaultHardErrorPort
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetDefaultLocale(
            bool UserProfile,
            uint DefaultLocaleId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetDefaultUILanguage(
            uint DefaultUILanguageId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetDriverEntryOrder(
            IntPtr Ids,
            uint Count
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetEaFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetEvent(
            IntPtr EventHandle,
            ref IntPtr PreviousState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetEventBoostPriority(
            IntPtr EventHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetHighEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetHighWaitLowEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationDebugObject(
            IntPtr DebugObjectHandle,
            uint DebugObjectInformationClass,
            IntPtr DebugInformation,
            uint DebugInformationLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr FileInformation,
            uint Length,
            FILE_INFORMATION_CLASS FileInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationJobObject(
            IntPtr JobHandle,
            uint JobObjectInformationClass,
            IntPtr JobObjectInformation,
            uint JobObjectInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationKey(
            IntPtr KeyHandle,
            KEY_SET_INFORMATION_CLASS KeySetInformationClass,
            IntPtr KeySetInformation,
            uint KeySetInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationObject(
            IntPtr Handle,
            uint ObjectInformationClass,
            IntPtr ObjectInformation,
            uint ObjectInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationProcess(
            IntPtr ProcessHandle,
            IntPtr ProcessInformationClass,
            IntPtr ProcessInformation,
            uint ProcessInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationSymbolicLink(
            IntPtr LinkHandle,
            uint SymbolicLinkInformationClass,
            IntPtr SymbolicLinkInformation,
            uint SymbolicLinkInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationThread(
            IntPtr ThreadHandle,
            uint ThreadInformationClass,
            IntPtr ThreadInformation,
            uint ThreadInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationToken(
            IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            uint TokenInformationLength
        );


        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationTransactionManager(
            IntPtr TmHandle,
            TRANSACTIONMANAGER_INFORMATION_CLASS TransactionManagerInformationClass,
            IntPtr TransactionManagerInformation,
            uint TransactionManagerInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationVirtualMemory(
            IntPtr ProcessHandle,
            uint VmInformationClass,
            uint NumberOfEntries,
            IntPtr VirtualAddresses,
            IntPtr VmInformation,
            uint VmInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetInformationWorkerFactory(
            IntPtr WorkerFactoryHandle,
            uint WorkerFactoryInformationClass,
            IntPtr WorkerFactoryInformation,
            uint WorkerFactoryInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetIntervalProfile(
            uint Interval,
            uint Source
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetIoCompletion(
            IntPtr IoCompletionHandle,
            IntPtr KeyContext,
            IntPtr ApcContext,
            IntPtr IoStatus,
            uint IoStatusInformation
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetIoCompletionEx(
            IntPtr IoCompletionHandle,
            IntPtr IoCompletionPacketHandle,
            IntPtr KeyContext,
            IntPtr ApcContext,
            IntPtr IoStatus,
            uint IoStatusInformation
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetIRTimer(
            IntPtr TimerHandle,
            IntPtr DueTime
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetLdtEntries(
            uint Selector0,
            uint Entry0Low,
            uint Entry0Hi,
            uint Selector1,
            uint Entry1Low,
            uint Entry1Hi
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetLowEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetLowWaitHighEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetQuotaInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSecurityObject(
            IntPtr Handle,
            SECURITY_INFORMATION SecurityInformation,
            IntPtr SecurityDescriptor
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSystemEnvironmentValue(
            IntPtr VariableName,
            IntPtr VariableValue
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSystemEnvironmentValueEx(
            IntPtr VariableName,
            IntPtr VendorGuid,
            IntPtr Value,
            uint ValueLength, // 0 = delete variable
            uint Attributes // EFI_VARIABLE_*
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSystemInformation(
            SYSTEM_INFORMATION_CLASS SystemInformationClass,
            IntPtr SystemInformation,
            uint SystemInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSystemPowerState(
            IntPtr SystemAction,
            SYSTEM_POWER_STATE LightestSystemState,
            uint Flags // POWER_ACTION_* flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetSystemTime(
            IntPtr SystemTime,
            ref IntPtr PreviousTime
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetThreadExecutionState(
            uint NewFlags, // ES_* flags
            IntPtr PreviousFlags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetTimer(
            IntPtr TimerHandle,
            IntPtr DueTime,
            IntPtr TimerApcRoutine,
            IntPtr TimerContext,
            bool ResumeTimer,
            uint Period,
            ref IntPtr PreviousState
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetTimer2(
            IntPtr TimerHandle,
            IntPtr DueTime,
            IntPtr Period,
            IntPtr Parameters
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetTimerEx(
            IntPtr TimerHandle,
            uint TimerSetInformationClass,
            IntPtr TimerSetInformation,
            uint TimerSetInformationLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetTimerResolution(
            uint DesiredTime,
            bool SetResolution,
            ref IntPtr ActualTime
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetUuidSeed(
            IntPtr Seed
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetValueKey(
            IntPtr KeyHandle,
            IntPtr ValueName,
            uint TitleIndex,
            uint Type,
            IntPtr Data,
            uint DataSize
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetVolumeInformationFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr FsInformation,
            uint Length,
            uint FsInformationClass
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSetWnfProcessNotificationEvent(
            IntPtr NotificationEvent
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwShutdownSystem(
            uint Action
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwShutdownWorkerFactory(
            IntPtr WorkerFactoryHandle,
            IntPtr PendingWorkerCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSignalAndWaitForSingleObject(
            IntPtr SignalHandle,
            IntPtr WaitHandle,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwStartProfile(
            IntPtr ProfileHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwStopProfile(
            IntPtr ProfileHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSubscribeWnfStateChange(
            IntPtr StateName,
            uint ChangeStamp,
            uint EventMask,
            ref ulong SubscriptionId
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSuspendProcess(
            IntPtr ProcessHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSuspendThread(
            IntPtr ThreadHandle,
            ref uint PreviousSuspendCount
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwSystemDebugControl(
            uint Command,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr OutputBuffer,
            uint OutputBufferLength,
            ref uint ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTerminateEnclave(
            IntPtr BaseAddress,
            bool WaitForThread
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTerminateJobObject(
            IntPtr JobHandle,
            IntPtr ExitStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTerminateProcess(
            IntPtr ProcessHandle,
            IntPtr ExitStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTerminateThread(
            IntPtr ThreadHandle,
            IntPtr ExitStatus
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTestAlert(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwThawRegistry(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwThawTransactions(
            IntPtr hHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTraceControl(
            uint TraceInformationClass,
            IntPtr InputBuffer,
            uint InputBufferLength,
            IntPtr TraceInformation,
            uint TraceInformationLength,
            ref IntPtr ReturnLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTraceEvent(
            IntPtr TraceHandle,
            uint Flags,
            uint FieldSize,
            IntPtr Fields
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwTranslateFilePath(
            IntPtr InputFilePath,
            uint OutputType,
            IntPtr OutputFilePath,
            IntPtr OutputFilePathLength
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUmsThreadYield(
            IntPtr SchedulerParam
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnloadKey(
            IntPtr TargetKey
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnloadKey2(
            IntPtr TargetKey,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnloadKeyEx(
            IntPtr TargetKey,
            IntPtr Event
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnlockFile(
            IntPtr FileHandle,
            ref IntPtr IoStatusBlock,
            IntPtr ByteOffset,
            IntPtr Length,
            uint Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnlockVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint RegionSize,
            uint MapType
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnmapViewOfSectionEx(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            uint Flags
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUnsubscribeWnfStateChange(
            IntPtr StateName
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwUpdateWnfStateData(
            IntPtr StateName,
            IntPtr Buffer,
            uint Length,
            IntPtr TypeId,
            IntPtr ExplicitScope,
            uint MatchingChangeStamp,
            uint CheckStamp
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwVdmControl(
            IntPtr Service,
            IntPtr ServiceData
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForAlertByThreadId(
            IntPtr Address,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForDebugEvent(
            IntPtr DebugObjectHandle,
            bool Alertable,
            IntPtr Timeout,
            ref IntPtr WaitStateChange
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForKeyedEvent(
            IntPtr KeyedEventHandle,
            IntPtr KeyValue,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForMultipleObjects(
            uint Count,
            IntPtr[] Handles,
            uint WaitType,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForMultipleObjects32(
            uint Count,
            IntPtr[] Handles,
            uint WaitType,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForSingleObject(
            IntPtr Handle,
            bool Alertable,
            IntPtr Timeout
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitForWorkViaWorkerFactory(
            IntPtr WorkerFactoryHandle,
            IntPtr MiniPackets,
            uint Count,
            ref IntPtr PacketsReturned,
            IntPtr DeferredWork
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitHighEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWaitLowEventPair(
            IntPtr EventPairHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWorkerFactoryWorkerReady(
            IntPtr WorkerFactoryHandle
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWriteFile(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr Buffer,
            uint Length,
            IntPtr ByteOffset,
            IntPtr Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWriteFileGather(
            IntPtr FileHandle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            ref IntPtr IoStatusBlock,
            IntPtr SegmentArray,
            uint Length,
            IntPtr ByteOffset,
            IntPtr Key
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWriteRequestData(
            IntPtr PortHandle,
            IntPtr Message,
            uint DataEntryIndex,
            IntPtr Buffer,
            uint BufferSize,
            ref uint NumberOfBytesWritten
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwWriteVirtualMemory(
            IntPtr ProcessHandle,
            IntPtr BaseAddress,
            IntPtr Buffer,
            uint BufferSize,
            ref uint NumberOfBytesWritten
        );

        [DllImport(Dll, SetLastError = true)]
        public static extern NTSTATUS ZwYieldExecution(
            IntPtr hHandle
        );
    }
}
