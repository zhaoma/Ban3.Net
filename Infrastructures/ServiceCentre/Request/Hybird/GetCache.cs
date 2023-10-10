namespace Ban3.Infrastructures.ServiceCentre.Request.Hybird;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class GetCache<T>
{
    /// <summary>
    /// 
    /// </summary>
    public GetCache()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    public GetCache(string key)
    {
        Key = key;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Key { get; set; }
}
