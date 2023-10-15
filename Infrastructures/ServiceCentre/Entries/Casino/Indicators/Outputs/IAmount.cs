using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

public interface IAmount:IOutput
{
    IEnumerable<ILine> Lines { get; set; }
}

