using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// This enumeration is not supported.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_image_policy_id
    /// </summary>
    public enum IMAGE_POLICY_ID
    {
        ImagePolicyIdNone,
        ImagePolicyIdEtw,
        ImagePolicyIdDebug,
        ImagePolicyIdCrashDump,
        ImagePolicyIdCrashDumpKey,
        ImagePolicyIdCrashDumpKeyGuid,
        ImagePolicyIdParentSd,
        ImagePolicyIdParentSdRev,
        ImagePolicyIdSvn,
        ImagePolicyIdDeviceId,
        ImagePolicyIdCapability,
        ImagePolicyIdScenarioId,
        ImagePolicyIdMaximum
    }
}
