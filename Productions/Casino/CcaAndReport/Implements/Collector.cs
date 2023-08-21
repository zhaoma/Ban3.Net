using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.CcaAndReport.Implements;

/// <summary>
/// 采集器
/// </summary>
public class Collector : ICollector
{
	/// <summary>
	/// 
	/// </summary>
	public ISites Sites { get; set; } = new Sites();
}
