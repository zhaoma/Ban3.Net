using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum WORK_QUEUE_TYPE
    {
        /// <summary>
        /// Indicates a real-time system worker thread. The assigned priority level is 13.
        /// </summary>
        CriticalWorkQueue,

        /// <summary>
        /// Indicates an ordinary worker thread. The assigned priority level is 12.
        /// </summary>
        DelayedWorkQueue,

        /// <summary>
        /// System priority level. The assigned priority level is 15.
        /// </summary>
        HyperCriticalWorkQueue,

        /// <summary>
        /// System priority level. The assigned priority level is 8
        /// </summary>
        NormalWorkQueue,

        /// <summary>
        /// System priority level. The assigned priority level is 7.
        /// </summary>
        BackgroundWorkQueue,

        /// <summary>
        /// System priority level. The assigned priority level is18.
        /// </summary>
        RealTimeWorkQueue,

        /// <summary>
        /// System priority level. The assigned priority level is 14.
        /// </summary>
        SuperCriticalWorkQueue,

        /// <summary>
        /// System priority maximum. No priority level assigned.
        /// </summary>
        MaximumWorkQueue,

        /// <summary>
        /// The queue has a custom priority level assigned by the caller.
        /// The CustomPriorityWorkQueue value is the base priority level for the custom priority queue. 
        /// Work items are queued at a particular priority by setting QueueType to CustomPriorityWorkQueue + Priority where Priority is the KPRIORITY value for the work item.
        /// This queue type is valid starting with Windows 8.1.
        /// </summary>
        CustomPriorityWorkQueue
    }
}
