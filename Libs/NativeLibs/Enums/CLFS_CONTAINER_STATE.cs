using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// specifies the state of the container.
    /// </summary>
    public enum CLFS_CONTAINER_STATE:uint
    {
        /// <summary>
        /// The container has not yet been initialized.
        /// </summary>
        ClfsContainerInitializing,

        /// <summary>
        /// The container has been initialized but does not hold any records that are in the active portion of the log.
        /// </summary>
        ClfsContainerInactive,

        /// <summary>
        /// The container is being used to hold records that belong to the active portion of the log.
        /// </summary>
        ClfsContainerActive,

        /// <summary>
        /// The container is marked for deletion, but still holds records that belong to the active portion of the log.
        /// </summary>
        ClfsContainerActivePendingDelete,

        /// <summary>
        /// The container is pending archival.
        /// </summary>
        ClfsContainerPendingArchive,

        /// <summary>
        /// The container is marked for deletion, but still contains records that are pending archival.
        /// </summary>
        ClfsContainerPendingArchiveAndDelete
    }
}
