using System;
using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

public interface IInput
{
    IStock Stock { get; set; }

    IEnumerable<IStockPrice> stockPrices { get; set; }

    IFormulas Formulas { get; set; }
}

