using System;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Request;

namespace Ban3.Productions.Casino.Contracts.Response;

public class RenderViewResult<T>
{
	public Dictionary<string, int> Counter { get; set; }

	public RenderView Request { get; set; }

	public List<T> ShowData { get; set; }
}

