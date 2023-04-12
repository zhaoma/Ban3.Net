using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class KERNEL32
    {
        /*
         
        1 (0x0001),  (0x), AcquireSRWLockExclusive, NTDLL.RtlAcquireSRWLockExclusive, None
        2 (0x0002),  (0x), AcquireSRWLockShared, NTDLL.RtlAcquireSRWLockShared, None
        121 (0x0079),  (0x), CancelWaitableTimer, 0x000250e0, None
        192 (0x00c0),  (0x), CreateEventA, 0x000250f0, None
        193 (0x00c1),  (0x), CreateEventExA, 0x00025100, None
        194 (0x00c2),  (0x), CreateEventExW, 0x00025110, None
        195 (0x00c3),  (0x), CreateEventW, 0x00025120, None
        219 (0x00db),  (0x), CreateMutexA, 0x00025130, None
        220 (0x00dc),  (0x), CreateMutexExA, 0x00025140, None
        221 (0x00dd),  (0x), CreateMutexExW, 0x00025150, None
        222 (0x00de),  (0x), CreateMutexW, 0x00025160, None
        239 (0x00ef),  (0x), CreateSemaphoreExW, 0x00025170, None
        240 (0x00f0),  (0x), CreateSemaphoreW, 0x00025180, None
        258 (0x0102),  (0x), CreateWaitableTimerA, 0x00063770, None
        259 (0x0103),  (0x), CreateWaitableTimerExA, 0x00063790, None
        260 (0x0104),  (0x), CreateWaitableTimerExW, 0x00025190, None
        261 (0x0105),  (0x), CreateWaitableTimerW, 0x000010b0, None
        277 (0x0115),  (0x), DeleteCriticalSection, NTDLL.RtlDeleteCriticalSection, None
        284 (0x011c),  (0x), DeleteSynchronizationBarrier, 0x0003b2b0, None
        313 (0x0139),  (0x), EnterCriticalSection, NTDLL.RtlEnterCriticalSection, None
        314 (0x013a),  (0x), EnterSynchronizationBarrier, 0x0003b2f0, None
        872 (0x0368),  (0x), InitializeConditionVariable, NTDLL.RtlInitializeConditionVariable, None
        875 (0x036b),  (0x), InitializeCriticalSection, NTDLL.RtlInitializeCriticalSection, None
        876 (0x036c),  (0x), InitializeCriticalSectionAndSpinCount, 0x000251a0, None
        877 (0x036d),  (0x), InitializeCriticalSectionEx, 0x000251b0, None
        881 (0x0371),  (0x), InitializeSRWLock, NTDLL.RtlInitializeSRWLock, None
        882 (0x0372),  (0x), InitializeSynchronizationBarrier, 0x0003bd10, None
        868 (0x0364),  (0x), InitOnceBeginInitialize, api-ms-win-core-synch-l1-2-0.InitOnceBeginInitialize, None
        869 (0x0365),  (0x), InitOnceComplete, api-ms-win-core-synch-l1-2-0.InitOnceComplete, None
        870 (0x0366),  (0x), InitOnceExecuteOnce, api-ms-win-core-synch-l1-2-0.InitOnceExecuteOnce, None
        871 (0x0367),  (0x), InitOnceInitialize, NTDLL.RtlRunOnceInitialize, None
        965 (0x03c5),  (0x), LeaveCriticalSection, NTDLL.RtlLeaveCriticalSection, None
        966 (0x03c6),  (0x), LeaveCriticalSectionWhenCallbackReturns, NTDLL.TpCallbackLeaveCriticalSectionOnCompletion, None
        1030 (0x0406),  (0x), OpenEventA, 0x000251c0, None
        1031 (0x0407),  (0x), OpenEventW, 0x000251d0, None
        1038 (0x040e),  (0x), OpenMutexA, 0x0001c7e0, None
        1039 (0x040f),  (0x), OpenMutexW, 0x000251e0, None
        1046 (0x0416),  (0x), OpenSemaphoreA, 0x00063820, None
        1047 (0x0417),  (0x), OpenSemaphoreW, 0x000251f0, None
        1052 (0x041c),  (0x), OpenWaitableTimerA, 0x00063890, None
        1053 (0x041d),  (0x), OpenWaitableTimerW, 0x00025200, None
        1207 (0x04b7),  (0x), ReleaseMutex, 0x00025210, None
        1208 (0x04b8),  (0x), ReleaseMutexWhenCallbackReturns, NTDLL.TpCallbackReleaseMutexOnCompletion, None
        1209 (0x04b9),  (0x), ReleaseSRWLockExclusive, NTDLL.RtlReleaseSRWLockExclusive, None
        1210 (0x04ba),  (0x), ReleaseSRWLockShared, NTDLL.RtlReleaseSRWLockShared, None
        1211 (0x04bb),  (0x), ReleaseSemaphore, 0x00025220, None
        1212 (0x04bc),  (0x), ReleaseSemaphoreWhenCallbackReturns, NTDLL.TpCallbackReleaseSemaphoreOnCompletion, None
        1229 (0x04cd),  (0x), ResetEvent, 0x00025230, None
        1303 (0x0517),  (0x), SetCriticalSectionSpinCount, NTDLL.RtlSetCriticalSectionSpinCount, None
        1319 (0x0527),  (0x), SetEvent, 0x00025240, None
        1320 (0x0528),  (0x), SetEventWhenCallbackReturns, NTDLL.TpCallbackSetEventOnCompletion, None
        1417 (0x0589),  (0x), SetWaitableTimer, 0x00025250, None
        1418 (0x058a),  (0x), SetWaitableTimerEx, api-ms-win-core-synch-l1-1-0.SetWaitableTimerEx, None
        1422 (0x058e),  (0x), SignalObjectAndWait, 0x0003cfe0, None
        1424 (0x0590),  (0x), Sleep, 0x0001b570, None
        1425 (0x0591),  (0x), SleepConditionVariableCS, api-ms-win-core-synch-l1-2-0.SleepConditionVariableCS, None
        1426 (0x0592),  (0x), SleepConditionVariableSRW, api-ms-win-core-synch-l1-2-0.SleepConditionVariableSRW, None
        1427 (0x0593),  (0x), SleepEx, 0x00025260, None
        1464 (0x05b8),  (0x), TryAcquireSRWLockExclusive, NTDLL.RtlTryAcquireSRWLockExclusive, None
        1465 (0x05b9),  (0x), TryAcquireSRWLockShared, NTDLL.RtlTryAcquireSRWLockShared, None
        1466 (0x05ba),  (0x), TryEnterCriticalSection, NTDLL.RtlTryEnterCriticalSection, None
        1513 (0x05e9),  (0x), WaitForMultipleObjects, 0x00025270, None
        1514 (0x05ea),  (0x), WaitForMultipleObjectsEx, 0x00025280, None
        1515 (0x05eb),  (0x), WaitForSingleObject, 0x00025290, None
        1516 (0x05ec),  (0x), WaitForSingleObjectEx, 0x000252a0, None
        1523 (0x05f3),  (0x), WakeAllConditionVariable, NTDLL.RtlWakeAllConditionVariable, None
        1524 (0x05f4),  (0x), WakeConditionVariable, NTDLL.RtlWakeConditionVariable, None

         */

        /// <summary>
        /// Acquires a slim reader/writer (SRW) lock in exclusive mode.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockexclusive
        /// </summary>
        /// <param name="srwLock">A pointer to the SRW lock.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void AcquireSRWLockExclusive(ref IntPtr srwLock);

        /// <summary>
        /// Acquires a slim reader/writer (SRW) lock in shared mode.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockshared
        /// </summary>
        /// <param name="srwLock">A pointer to the SRW lock.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void AcquireSRWLockShared(ref IntPtr srwLock);

        /// <summary>
        /// Sets the specified waitable timer to the inactive state.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-cancelwaitabletimer
        /// </summary>
        /// <param name="hTimer">
        /// A handle to the timer object.
        /// The CreateWaitableTimer or OpenWaitableTimer function returns this handle.
        /// The handle must have the TIMER_MODIFY_STATE access right.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelWaitableTimer(IntPtr hTimer);

        /// <summary>
        /// Creates or opens a named or unnamed event object.
        /// CreateEventA/CreateEventW
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventa
        /// </summary>
        /// <param name="lpEventAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure. 
        /// If this parameter is NULL, the handle cannot be inherited by child processes.</param>
        /// <param name="bManualReset">If this parameter is TRUE, the function creates a manual-reset event object, 
        /// which requires the use of the ResetEvent function to set the event state to nonsignaled. 
        /// If this parameter is FALSE, the function creates an auto-reset event object, 
        /// and system automatically resets the event state to nonsignaled after a single waiting thread has been released.</param>
        /// <param name="bInitialState">If this parameter is TRUE, the initial state of the event object is signaled; otherwise, it is nonsignaled.</param>
        /// <param name="lpName">The name of the event object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If lpName matches the name of an existing named event object, 
        /// this function requests the EVENT_ALL_ACCESS access right. In this case, 
        /// the bManualReset and bInitialState parameters are ignored because they have already been set by the creating process. 
        /// If the lpEventAttributes parameter is not NULL, it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If lpName is NULL, the event object is created without a name.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateEvent(
            IntPtr lpEventAttributes,
            bool bManualReset,
            bool bInitialState,
            string lpName);

        /// <summary>
        /// Creates or opens a named or unnamed event object and returns a handle to the object.
        /// CreateEventExA/CreateEventExW
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventexa
        /// </summary>
        /// <param name="lpEventAttributes"></param>
        /// <param name="lpName"></param>
        /// <param name="dwFlags">
        /// This parameter can be one or more of the following values.
        /// CREATE_EVENT_INITIAL_SET        0x00000002      The initial state of the event object is signaled; 
        ///                                                 otherwise, it is nonsignaled.
        /// CREATE_EVENT_MANUAL_RESET       0x00000001      The event must be manually reset using the ResetEvent function.
        ///                                                 Any number of waiting threads, or threads that subsequently 
        ///                                                 begin wait operations for the specified event object, 
        ///                                                 can be released while the object's state is signaled.
        ///                                                 If this flag is not specified, the system automatically 
        ///                                                 resets the event after releasing a single waiting thread.
        /// </param>
        /// <param name="dwDesiredAccess">The access mask for the event object. 
        /// For a list of access rights, see Synchronization Object Security and Access Rights.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateEventEx(
            IntPtr lpEventAttributes,
            string lpName,
            uint dwFlags,
            uint dwDesiredAccess);

        /// <summary>
        /// Creates or opens a named or unnamed mutex object.
        /// </summary>
        /// <param name="lpMutexAttributes"></param>
        /// <param name="bInitialOwner"></param>
        /// <param name="lpName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateMutex(
            IntPtr lpMutexAttributes,
            bool bInitialOwner,
            string lpName);

        /// <summary>
        /// Creates or opens a named or unnamed mutex object and returns a handle to the object.
        /// </summary>
        /// <param name="lpMutexAttributes"></param>
        /// <param name="lpName"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateMutexEx(
            IntPtr lpMutexAttributes,
            string lpName,
            uint dwFlags,
            uint dwDesiredAccess);

        /// <summary>
        /// Creates or opens a named or unnamed semaphore object.
        /// </summary>
        /// <param name="lpSemaphoreAttributes"></param>
        /// <param name="lInitialCount"></param>
        /// <param name="lMaximumCount"></param>
        /// <param name="lpName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateSemaphore(
            SECURITY_ATTRIBUTES lpSemaphoreAttributes,
            int lInitialCount,
            int lMaximumCount,
            string lpName);

        /// <summary>
        /// Creates or opens a named or unnamed semaphore object and returns a handle to the object.
        /// </summary>
        /// <param name="lpSemaphoreAttributes"></param>
        /// <param name="lInitialCount"></param>
        /// <param name="lMaximumCount"></param>
        /// <param name="lpName"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateSemaphoreEx(
            SECURITY_ATTRIBUTES lpSemaphoreAttributes,
            int lInitialCount,
            int lMaximumCount,
            string lpName,
            uint dwFlags,
            uint dwDesiredAccess);

        /// <summary>
        /// Creates or opens a waitable timer object.
        /// </summary>
        /// <param name="lpTimerAttributes"></param>
        /// <param name="bManualReset"></param>
        /// <param name="lpTimerName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateWaitableTimer(
            SECURITY_ATTRIBUTES lpTimerAttributes,
            bool bManualReset,
            string lpTimerName);

        /// <summary>
        /// Creates or opens a waitable timer object and returns a handle to the object.
        /// </summary>
        /// <param name="lpTimerAttributes"></param>
        /// <param name="lpTimerName"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr CreateWaitableTimerEx(
            SECURITY_ATTRIBUTES lpTimerAttributes,
            string lpTimerName,
            uint dwFlags,
            uint dwDesiredAccess);

        /// <summary>
        /// Releases all resources used by an unowned critical section object.
        /// </summary>
        /// <param name="lpCriticalSection"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void DeleteCriticalSection(CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// Deletes a synchronization barrier.
        /// </summary>
        /// <param name="lpBarrier"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool DeleteSynchronizationBarrier(IntPtr lpBarrier);

        /// <summary>
        /// Waits for ownership of the specified critical section object. 
        /// The function returns when the calling thread is granted ownership.
        /// </summary>
        /// <param name="lpCriticalSection"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void EnterCriticalSection(CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// Causes the calling thread to wait at a synchronization barrier 
        /// until the maximum number of threads have entered the barrier.
        /// </summary>
        /// <param name="lpBarrier"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool EnterSynchronizationBarrier(
            IntPtr lpBarrier,
            uint dwFlags);

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeConditionVariable();

        /// <summary>
        /// Initializes a critical section object.
        /// </summary>
        /// <param name="lpCriticalSection">A pointer to the critical section object.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeCriticalSection(ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// Initializes a critical section object and sets the spin count for the critical section. 
        /// When a thread tries to acquire a critical section that is locked, 
        /// the thread spins: it enters a loop which iterates spin count times, checking to see if the lock is released. 
        /// If the lock is not released before the loop finishes, 
        /// the thread goes to sleep to wait for the lock to be released.
        /// </summary>
        /// <param name="lpCriticalSection">A pointer to the critical section object.</param>
        /// <param name="dwSpinCount">The spin count for the critical section object.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeCriticalSectionAndSpinCount(
            ref CRITICAL_SECTION lpCriticalSection,
            int dwSpinCount
            );

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeCriticalSectionEx();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeSRWLock();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitializeSynchronizationBarrier();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitOnceBeginInitialize();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitOnceComplete();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitOnceExecuteOnce();

        [DllImport(Dll, SetLastError = true)]
        public static extern void InitOnceInitialize();

        [DllImport(Dll, SetLastError = true)]
        public static extern void LeaveCriticalSection();

        [DllImport(Dll, SetLastError = true)]
        public static extern void LeaveCriticalSectionWhenCallbackReturns();

        /// <summary>
        /// Opens an existing named event object.
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the event object. 
        /// The function fails if the security descriptor of the specified object does not permit 
        /// the requested access for the calling process. 
        /// For a list of access rights, /Enums/SyncObjectAccess
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is TRUE, processes created by this process will inherit the handle. 
        /// Otherwise, the processes do not inherit this handle.</param>
        /// <param name="lpName">The name of the event to be opened. Name comparisons are case sensitive.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenEvent(
            uint dwDesiredAccess, 
            bool bInheritHandle, 
            string lpName
            );

        /// <summary>
        /// Opens an existing named mutex object.
        /// </summary>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="lpName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenMutex(
            uint dwDesiredAccess,
            bool bInheritHandle,
            string lpName
            );

        /// <summary>
        /// Opens an existing named semaphore object.
        /// </summary>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="lpName"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenSemaphore(
            uint dwDesiredAccess,
            bool bInheritHandle,
            string lpName
            );

        /// <summary>
        /// Opens an existing named waitable timer object.
        /// </summary>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="lpName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr OpenWaitableTimer(
            uint dwDesiredAccess,
            bool bInheritHandle,
            string lpName
            );

        /// <summary>
        /// Releases ownership of the specified mutex object.
        /// </summary>
        /// <param name="hMutex"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool ReleaseMutex(IntPtr hMutex);

        /// <summary>
        /// Specifies the mutex that the thread pool will release when the current callback completes.
        /// threadpoolapiset.h
        /// </summary>
        /// <param name="pci">A pointer to a TP_CALLBACK_INSTANCE structure that defines the callback instance. 
        /// The pointer is passed to the callback function.</param>
        /// <param name="hMutex"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void ReleaseMutexWhenCallbackReturns(
            ref IntPtr pci,
            IntPtr hMutex
            );

        /// <summary>
        /// Increases the count of the specified semaphore object by a specified amount.
        /// </summary>
        /// <param name="hSemaphore"></param>
        /// <param name="lReleaseCount"></param>
        /// <param name="lpPreviousCount"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool ReleaseSemaphore(
            IntPtr hSemaphore, 
            int lReleaseCount, 
            ref int lpPreviousCount);

        /// <summary>
        /// Specifies the semaphore that the thread pool will release when the current callback completes.
        /// threadpoolapiset.h
        /// https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-releasesemaphorewhencallbackreturns
        /// </summary>
        /// <param name="pci"></param>
        /// <param name="sem"></param>
        /// <param name="crel"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void ReleaseSemaphoreWhenCallbackReturns(
            ref IntPtr pci,
            IntPtr sem,
            int crel
            );

        /// <summary>
        /// Releases a slim reader/writer (SRW) lock that was acquired in exclusive mode.
        /// </summary>
        /// <param name="srwLock">[in, out] SRWLock:A pointer to the SRW lock.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void ReleaseSRWLockExclusive(ref IntPtr srwLock);

        /// <summary>
        /// Releases a slim reader/writer (SRW) lock that was acquired in shared mode.
        /// </summary>
        /// <param name="srwLock">[in, out] SRWLock:A pointer to the SRW lock.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void ReleaseSRWLockShared(ref IntPtr srwLock);

        /// <summary>
        /// Sets the specified event object to the nonsignaled state.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object. 
        /// The CreateEvent or OpenEvent function returns this handle.
        /// The handle must have the EVENT_MODIFY_STATE access right.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool ResetEvent(ref IntPtr hEvent);

        /// <summary>
        /// Sets the spin count for the specified critical section. 
        /// Spinning means that when a thread tries to acquire a critical section that is locked, the thread enters a loop, 
        /// checks to see if the lock is released, and if the lock is not released, the thread goes to sleep.
        /// The function returns the previous spin count for the critical section.
        /// </summary>
        /// <param name="lpCriticalSection"></param>
        /// <param name="dwSpinCount"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern int SetCriticalSectionSpinCount(
            ref CRITICAL_SECTION lpCriticalSection,
            int dwSpinCount);

        /// <summary>
        /// Sets the specified event object to the signaled state.
        /// </summary>
        /// <param name="hEvent"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool SetEvent(IntPtr hEvent);

        /// <summary>
        /// Specifies the event that the thread pool will set when the current callback completes.
        /// </summary>
        /// <param name="pci"></param>
        /// <param name="evt"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void SetEventWhenCallbackReturns(
            ref IntPtr pci,
            IntPtr evt
            );

        /// <summary>
        /// Activates the specified waitable timer. 
        /// When the due time arrives, the timer is signaled and the thread that set the timer calls the optional completion routine.
        /// </summary>
        /// <param name="hTimer">
        /// A handle to the timer object. The CreateWaitableTimer or OpenWaitableTimer function returns this handle.
        /// The handle must have the TIMER_MODIFY_STATE access right. 
        /// </param>
        /// <param name="lpDueTime">The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals.</param>
        /// <param name="lPeriod">
        /// The period of the timer, in milliseconds. If lPeriod is zero, the timer is signaled once. 
        /// If lPeriod is greater than zero, the timer is periodic.
        /// </param>
        /// <param name="pfnCompletionRoutine">
        /// A pointer to an optional completion routine. 
        /// The completion routine is application-defined function of type PTIMERAPCROUTINE to be executed when the timer is signaled.
        /// </param>
        /// <param name="lpArgToCompletionRoutine">A pointer to a structure that is passed to the completion routine.</param>
        /// <param name="fResume">If this parameter is TRUE, restores a system in suspended power conservation mode when the timer state is set to signaled. </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool SetWaitableTimer(
            IntPtr hTimer,
            ref LARGE_INTEGER lpDueTime,
            int lPeriod,
            IntPtr pfnCompletionRoutine,
            IntPtr lpArgToCompletionRoutine,
            [MarshalAsAttribute(UnmanagedType.Bool)]
            bool fResume
            );

        /// <summary>
        /// Activates the specified waitable timer and provides context information for the timer. 
        /// When the due time arrives, the timer is signaled and the thread that set the timer calls the optional completion routine.
        /// </summary>
        /// <param name="hTimer"></param>
        /// <param name="lpDueTime"></param>
        /// <param name="lPeriod"></param>
        /// <param name="pfnCompletionRoutine"></param>
        /// <param name="lpArgToCompletionRoutine"></param>
        /// <param name="WakeContext"></param>
        /// <param name="TolerableDelay"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool SetWaitableTimerEx(
            IntPtr hTimer,
            LARGE_INTEGER lpDueTime,
            int lPeriod,
            IntPtr pfnCompletionRoutine,
            IntPtr lpArgToCompletionRoutine,
            REASON_CONTEXT WakeContext,
            int TolerableDelay
            );

        /// <summary>
        /// Signals one object and waits on another object as a single operation.
        /// </summary>
        /// <param name="hObjectToSignal">A handle to the object to be signaled. This object can be a semaphore, a mutex, or an event.</param>
        /// <param name="hObjectToWaitOn">A handle to the object to wait on. The SYNCHRONIZE access right is required.</param>
        /// <param name="dwMilliseconds">The time-out interval, in milliseconds.</param>
        /// <param name="bAlertable">
        /// If this parameter is TRUE, the function returns when the system queues an I/O completion routine or APC function, 
        /// and the thread calls the function. 
        /// If FALSE, the function does not return, and the thread does not call the completion routine or APC function.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern SIGNAL_WAIT SignalObjectAndWait(
            IntPtr hObjectToSignal,
            IntPtr hObjectToWaitOn,
            int dwMilliseconds,
            bool bAlertable
            );

        /// <summary>
        /// Suspends the execution of the current thread until the time-out interval elapses.
        /// </summary>
        /// <param name="dwMilliseconds">The time interval for which execution is to be suspended, in milliseconds.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void Sleep(uint dwMilliseconds);

        /// <summary>
        /// Sleeps on the specified condition variable and releases the specified critical section as an atomic operation.
        /// </summary>
        /// <param name="ConditionVariable"></param>
        /// <param name="CriticalSection"></param>
        /// <param name="dwMilliseconds"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void SleepConditionVariableCS(
            ref IntPtr ConditionVariable,
            ref CRITICAL_SECTION CriticalSection,
            uint dwMilliseconds
            );

        /// <summary>
        /// Sleeps on the specified condition variable and releases the specified lock as an atomic operation.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleepconditionvariablesrw
        /// </summary>
        /// <param name="ConditionVariable">A pointer to the condition variable. This variable must be initialized using the InitializeConditionVariable function.</param>
        /// <param name="SRWLock">A pointer to the lock. This lock must be held in the manner specified by the Flags parameter.</param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds. 
        /// The function returns if the interval elapses. 
        /// If dwMilliseconds is zero, the function tests the states of the specified objects and returns immediately. 
        /// If dwMilliseconds is INFINITE, the function's time-out interval never elapses.
        /// </param>
        /// <param name="Flags">
        /// If this parameter is CONDITION_VARIABLE_LOCKMODE_SHARED, 
        /// the SRW lock is in shared mode. Otherwise, the lock is in exclusive mode.
        /// </param>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool SleepConditionVariableSRW(
            ref IntPtr ConditionVariable,
            ref IntPtr SRWLock,
            uint dwMilliseconds,
            uint Flags
            );

        /// <summary>
        /// Suspends the current thread until the specified condition is met. 
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleepex
        /// </summary>
        /// <param name="dwMilliseconds"></param>
        /// <param name="bAlertable"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint SleepEx(
            uint dwMilliseconds,
            bool bAlertable
            );

        /// <summary>
        /// Attempts to acquire a slim reader/writer (SRW) lock in exclusive mode. 
        /// If the call is successful, the calling thread takes ownership of the lock.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-tryacquiresrwlockexclusive
        /// </summary>
        /// <param name="SRWLock">A pointer to the SRW lock.</param>
        /// <returns>
        /// If the lock is successfully acquired, the return value is nonzero.
        /// if the current thread could not acquire the lock, the return value is zero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool TryAcquireSRWLockExclusive(
            ref IntPtr SRWLock
            );


        /// <summary>
        /// Attempts to acquire a slim reader/writer (SRW) lock in shared mode. 
        /// If the call is successful, the calling thread takes ownership of the lock.
        /// https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-tryacquiresrwlockshared
        /// </summary>
        /// <param name="SRWLock">A pointer to the SRW lock.</param>
        /// <returns>
        /// If the lock is successfully acquired, the return value is nonzero.
        /// if the current thread could not acquire the lock, the return value is zero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool TryAcquireSRWLockShared(
            ref IntPtr SRWLock
            );

        /// <summary>
        /// Attempts to enter a critical section without blocking. 
        /// If the call is successful, the calling thread takes ownership of the critical section.
        /// </summary>
        /// <param name="lpCriticalSection">A pointer to the critical section object.</param>
        /// <returns>
        /// If the critical section is successfully entered or the current thread already owns the critical section, the return value is nonzero.
        /// If another thread already owns the critical section, the return value is zero.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool TryEnterCriticalSection(
            ref CRITICAL_SECTION lpCriticalSection
            );

        /// <summary>
        /// Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.
        /// </summary>
        /// <param name="nCount"></param>
        /// <param name="lpHandles"></param>
        /// <param name="bWaitAll"></param>
        /// <param name="dwMilliseconds"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int WaitForMultipleObjects(
            uint nCount,
            IntPtr[] lpHandles,
            bool bWaitAll,
            int dwMilliseconds
            );

        /// <summary>
        /// Waits until one or all of the specified objects are in the signaled state, 
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, 
        /// or the time-out interval elapses.
        /// </summary>
        /// <param name="nCount"></param>
        /// <param name="lpHandles"></param>
        /// <param name="bWaitAll"></param>
        /// <param name="dwMilliseconds"></param>
        /// <param name="bAlertable"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int WaitForMultipleObjectsEx(
            uint nCount,
            IntPtr[] lpHandles,
            bool bWaitAll,
            int dwMilliseconds,
            bool bAlertable
            );

        /// <summary>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// </summary>
        /// <param name="hHandle"></param>
        /// <param name="dwMilliseconds"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int WaitForSingleObject(
            IntPtr hHandle,
            int dwMilliseconds
            );

        /// <summary>
        /// Waits until the specified object is in the signaled state, 
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, 
        /// or the time-out interval elapses.
        /// </summary>
        /// <param name="hHandle"></param>
        /// <param name="dwMilliseconds"></param>
        /// <param name="bAlertable"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void WaitForSingleObjectEx(
            IntPtr hHandle,
            int dwMilliseconds,
            bool bAlertable
            );

        /// <summary>
        /// Wake all threads waiting on the specified condition variable.
        /// </summary>
        /// <param name="ConditionVariable"></param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void WakeAllConditionVariable(
            ref IntPtr ConditionVariable
            );

        /// <summary>
        /// Wake a single thread waiting on the specified condition variable.
        /// </summary>
        /// <param name="ConditionVariable">A pointer to the condition variable.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void WakeConditionVariable(
            ref IntPtr ConditionVariable
            );
    }
}
