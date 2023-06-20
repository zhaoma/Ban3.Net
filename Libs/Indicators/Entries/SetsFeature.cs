namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 特征定义
/// </summary>
public class SetsFeature
{
    public SetsFeature(string key, string subject,  int value)
    {
        Key = key;
        Subject = subject;
        Value = value;
    }

    /// <summary>
    /// 特征值
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Subject { get; set; }
    
    /// <summary>
    /// 评分
    /// </summary>
    public int Value { get; set; } 
}
