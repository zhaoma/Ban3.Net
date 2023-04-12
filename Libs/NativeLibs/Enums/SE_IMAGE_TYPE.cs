using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines values for type of image used for image verification.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_se_image_type
    /// </summary>
    public enum SE_IMAGE_TYPE
    {
        SeImageTypeElamDriver,
        SeImageTypeDriver  ,
        SeImageTypePlatformSecureFile  ,
        SeImageTypeDynamicCodeFile  ,
        SeImageTypeMax 
    }
}
