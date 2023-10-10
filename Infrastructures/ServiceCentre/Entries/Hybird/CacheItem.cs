namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 缓存条目
/// </summary>
/// <typeparam name="T"></typeparam>
public class CacheItem<T>
{
    /// <summary>
    /// ctor
    /// </summary>
    public CacheItem()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="profile"></param>
    public CacheItem(string key, T value, CacheProfile profile = null)
    {
        Key = key;
        Value = value;
        Profile = profile ?? new CacheProfile();
    }

    /// <summary>
    /// 缓存键名
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// 缓存值
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// 策略
    /// </summary>
    public CacheProfile Profile { get; set; }
}

