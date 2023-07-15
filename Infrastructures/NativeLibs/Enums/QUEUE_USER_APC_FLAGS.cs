namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies the modifier flags for user-mode asynchronous procedure call (APC) objects.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ne-processthreadsapi-queue_user_apc_flags
    /// </summary>
    public enum QUEUE_USER_APC_FLAGS
    {
        /// <summary>
        /// No flags are passed. Behavior is identical to QueueUserAPC function.
        /// </summary>
        QUEUE_USER_APC_FLAGS_NONE,

        /// <summary>
        /// Queue a special user-mode APC instead of a regular user-mode APC.
        /// </summary>
        QUEUE_USER_APC_FLAGS_SPECIAL_USER_APC,

        /// <summary>
        /// Receive the processor context that was interrupted when the thread was directed to call the APC function.
        /// </summary>
        QUEUE_USER_APC_CALLBACK_DATA_CONTEXT
    }
}