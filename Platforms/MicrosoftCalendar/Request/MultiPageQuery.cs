using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request
{
	public class MultiPageQuery
	{
		public MultiPageQuery()
		{
		}


		/// <summary>
		/// Number of results to skip. Default: null
		/// </summary>
		[JsonProperty("$skip")]
		public int Skip { get; set; }

		/// <summary>
		/// The maximum number of results to return. Default: null
		/// </summary>
		[JsonProperty("$top")]
		public int Top { get; set; }

	}
}

