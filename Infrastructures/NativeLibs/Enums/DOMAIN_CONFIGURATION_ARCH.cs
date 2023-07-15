using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for type of system architecture specified in the IOMMU_DOMAIN_CONFIGURE callback function.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_domain_configuration_arch
    /// </summary>
    public enum DOMAIN_CONFIGURATION_ARCH
    {
        /// <summary>
        /// ARM64 architecture.
        /// </summary>
        DomainConfigurationArm64,

        /// <summary>
        /// x64 architecture. Reserved for system use only.
        /// </summary>
        DomainConfigurationX64,

        /// <summary>
        /// The architecture type is not valid.
        /// </summary>
        DomainConfigurationInvalid
    }
}
