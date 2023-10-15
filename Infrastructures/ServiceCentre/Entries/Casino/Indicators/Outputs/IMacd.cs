using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

public interface IMacd
{
    decimal DIF { get; set; }

    decimal DEA { get; set; }

    decimal MACD { get; set; }
}

