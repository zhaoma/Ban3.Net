using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// This enumeration is not supported.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_image_policy_entry_type
    /// </summary>
    public enum IMAGE_POLICY_ENTRY_TYPE
    {
        ImagePolicyEntryTypeNone,
        ImagePolicyEntryTypeBool,
        ImagePolicyEntryTypeInt8,
        ImagePolicyEntryTypeUInt8,
        ImagePolicyEntryTypeInt16,
        ImagePolicyEntryTypeUInt16,
        ImagePolicyEntryTypeInt32,
        ImagePolicyEntryTypeUInt32,
        ImagePolicyEntryTypeInt64,
        ImagePolicyEntryTypeUInt64,
        ImagePolicyEntryTypeAnsiString,
        ImagePolicyEntryTypeUnicodeString,
        ImagePolicyEntryTypeOverride,
        ImagePolicyEntryTypeMaximum
    }
}
