using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IAmount
{
    IEnumerable<int> Durations { get; set; }
}

