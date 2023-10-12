using System;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 缓存策略
/// </summary>
public class CachesProfile
{
    /// <summary>
    /// 默认持久
    /// </summary>
    public CachesProfile()
    {
        CacheDependency = CacheDependency.None;
    }

    /// <summary>
    /// 绝对时间型
    /// </summary>
    /// <param name="expireTime"></param>
    public CachesProfile(DateTime expireTime)
    {
        CacheDependency = CacheDependency.AbsoluteTime;
        AbsoluteTime = expireTime;
    }

    /// <summary>
    /// 相对时间型
    /// </summary>
    /// <param name="remainTimeSpan"></param>
    public CachesProfile(TimeSpan remainTimeSpan)
    {
        CacheDependency = CacheDependency.RelativeTime;
        RelativeTime = remainTimeSpan;
    }

    /// <summary>
    /// 监视文件型
    /// </summary>
    /// <param name="monitorFile"></param>
    public CachesProfile(string monitorFile)
    {
        CacheDependency = CacheDependency.File;
        File = monitorFile;
    }

    /// <summary>
    /// 存活依赖
    /// </summary>
    public CacheDependency CacheDependency { get; set; }

    /// <summary>
    /// 绝对过期时间
    /// </summary>
    public DateTime? AbsoluteTime { get; set; }

    /// <summary>
    /// 相对存活时间
    /// </summary>
    public TimeSpan? RelativeTime { get; set; }

    /// <summary>
    /// 监视文件变化
    /// </summary>
    public string File { get; set; }
}
