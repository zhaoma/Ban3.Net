using System;
using Ban3.Infrastructures.ServiceCentre.Enums;

namespace Ban3.Infrastructures.ServiceCentre.Entries;

/// <summary>
/// 缓存策略
/// </summary>
public class CacheProfile
{
    /// <summary>
    /// 默认持久
    /// </summary>
    public CacheProfile()
    {
        CacheDependency = CacheDependency.None;
    }

    /// <summary>
    /// 绝对时间型
    /// </summary>
    /// <param name="expireTime"></param>
    public CacheProfile(DateTime expireTime)
    {
        CacheDependency = CacheDependency.AbsoluteTime;
        AbsoluteTime= expireTime;
    }

    /// <summary>
    /// 相对时间型
    /// </summary>
    /// <param name="remainTimeSpan"></param>
    public CacheProfile(TimeSpan remainTimeSpan)
    {
        CacheDependency = CacheDependency.RelativeTime;
        RelativeTime=remainTimeSpan;
    }

    /// <summary>
    /// 监视文件型
    /// </summary>
    /// <param name="monitorFile"></param>
    public CacheProfile(string monitorFile)
    {
        CacheDependency = CacheDependency.File;
        File= monitorFile;
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
