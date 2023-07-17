using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Request;

namespace Ban3.Productions.Casino.Contracts.Response;

/// <summary>
/// 常用分拣条件
/// </summary>
/// <typeparam name="T"></typeparam>
public class RenderViewResult<T>
{
	/// <summary>
	/// 
	/// </summary>
	public Dictionary<string, int> Counter { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public RenderView Request { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public List<T> ShowData { get; set; }

	/// <summary>
	/// 
	/// </summary>
	public string Pagination { get; set; }


}

