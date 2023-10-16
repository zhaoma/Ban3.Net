namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 
/// </summary>
public interface IBias
{
    /// <summary>
    /// 乖离
    /// </summary>
    decimal BIAS { get; set; }

    /// <summary>
    /// 平均乖离
    /// </summary>
    decimal BIASMA { get; set; }
}

