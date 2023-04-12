using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Response
{
	public class CountedResult<T>
	{
		public CountedResult()
		{
		}


		[JsonProperty("count")]
		public int Count { get; set; }


		[JsonProperty("value")]
		public List<T> Value { get; set; } 
	}
}

