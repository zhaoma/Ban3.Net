using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 趋向指标
/// </summary>
public interface IDmi
{
    decimal PDI { get; set; }

    decimal MDI { get; set; }

    decimal ADX { get; set; }

    decimal ADXR { get; set; }
}

