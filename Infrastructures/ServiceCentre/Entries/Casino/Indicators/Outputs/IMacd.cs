namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 异同移动平均线
/// </summary>
public interface IMacd
{
    /// <summary>
    /// 快线
    /// </summary>
    decimal DIF { get; set; }

    /// <summary>
    /// 加权移动均线
    /// </summary>
    decimal DEA { get; set; }

    /// <summary>
    /// MACD柱
    /// </summary>
    decimal MACD { get; set; }
}

