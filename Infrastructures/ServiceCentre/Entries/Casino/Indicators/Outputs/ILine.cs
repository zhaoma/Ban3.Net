using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

public interface ILine
{
    int Duration { get; set; }

    decimal Value { get; set; }
}

