using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The CLFS_MGMT_POLICY_TYPE enumeration type identifies the type of a CLFS management policy.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_clfs_mgmt_policy_type
    /// </summary>
    public enum CLFS_MGMT_POLICY_TYPE
    {
        /// <summary>
        /// Indicates a policy that specifies the maximum size of a log.
        /// </summary>
        ClfsMgmtPolicyMaximumSize,

        /// <summary>
        /// Indicates a policy that specifies the minimum size of a log.
        /// </summary>
        ClfsMgmtPolicyMinimumSize,

        /// <summary>
        /// Indicates a policy that specifies the size of new containers that are created.
        /// </summary>
        ClfsMgmtPolicyNewContainerSize,

        /// <summary>
        /// Indicates a policy that specifies how many new containers will be added to the log each time the log grows.
        /// </summary>
        ClfsMgmtPolicyGrowthRate,

        /// <summary>
        /// Indicates a policy that specifies how much free space will be requested when a client is notified to move its log tail.
        /// </summary>
        ClfsMgmtPolicyLogTail,

        /// <summary>
        /// Indicates a policy that specifies when the log will shrink based on the percentage of the log that is free.
        /// </summary>
        ClfsMgmtPolicyAutoShrink,

        /// <summary>
        /// Indicates a policy that specifies whether the log should grow when fewer than two containers are free.
        /// </summary>
        ClfsMgmtPolicyAutoGrow,

        /// <summary>
        /// Indicates a policy that specifies a prefix for the file name of each container,
        /// as well as the full path to the directory where the containers will be placed.
        /// </summary>
        ClfsMgmtPolicyNewContainerPrefix,

        /// <summary>
        /// Indicates a policy that specifies a number to use as the starting suffix for container file names.
        /// </summary>
        ClfsMgmtPolicyNewContainerSuffix,

        /// <summary>
        /// Indicates a policy that specifies an extension for the file name of each container.
        /// </summary>
        ClfsMgmtPolicyNewContainerExtension,

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        ClfsMgmtPolicyInvalid
    }
}
