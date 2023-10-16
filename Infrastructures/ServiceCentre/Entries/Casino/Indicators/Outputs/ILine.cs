namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 指标线
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ILine<T>
{
    /// <summary>
    /// 周期
    /// </summary>
    int Duration { get; set; }

    /// <summary>
    /// 取值
    /// </summary>
    T Value { get; set; }
}

