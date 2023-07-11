using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;

namespace Ban3.Productions.Casino.CcaAndReport.Models;

public class CompositeRecords
{
	public Profile Profile { get; set; }

	public List<StockOperationRecord> Records { get; set; }

	public Dictionary<string,int> RightKeys { get; set; }

	public Dictionary<string,int> WrongKeys { get; set; }
}

