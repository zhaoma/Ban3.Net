using System;
using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

public interface IOutput:IStockRecord
{
    IEnumerable<IComputedResult> ComputedResults { get; set; }


}

