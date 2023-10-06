using System;
using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums;

/// <summary>
/// 缓存依赖条件
/// </summary>
public enum CacheDependency
{
    [Description("持久缓存")]
    None=0,

    [Description("绝对时间")]
    AbsoluteTime=1,

    [Description("相对时间")]
    RelativeTime=2,

    [Description("文件变化")]
    File=3
}

