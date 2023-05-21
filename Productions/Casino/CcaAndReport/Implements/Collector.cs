using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.CcaAndReport.Implements;

public class Collector : ICollector
{
	public ISites Sites { get; set; } = new Sites();
}
