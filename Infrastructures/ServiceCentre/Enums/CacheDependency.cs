using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums;

/// <summary>
/// 缓存依赖条件
/// </summary>
public enum CacheDependency
{
    /// <summary>
    /// 无依赖，长期存活
    /// </summary>
    [Description("持久缓存")]
    None=0,

    /// <summary>
    /// 绝对时间过期
    /// </summary>
    [Description("绝对时间")]
    AbsoluteTime=1,

    /// <summary>
    /// 相对时间过期
    /// </summary>
    [Description("相对时间")]
    RelativeTime=2,

    /// <summary>
    /// 依赖文件变化失效
    /// </summary>
    [Description("文件变化")]
    File=3
}

