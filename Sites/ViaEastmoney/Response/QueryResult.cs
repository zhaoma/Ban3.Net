using System;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Response;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class QueryResult<T>
{
	/// <summary>
	/// 
	/// </summary>
	public QueryResult()
	{
	}

	/// <summary>
	/// 
	/// </summary>
	[JsonProperty("version")]
	public string Version { get; set; } = string.Empty;

	/// <summary>
	/// 
	/// </summary>
	[JsonProperty("result")]
	public Entries.QueryDataPackage<T> Result { get; set; } = new Entries.QueryDataPackage<T>();
}

