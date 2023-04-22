using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Core
{
	public class GetPortraitResult
		:IResponse
	{
		public bool Success { get; set; }

		public string SavedPath { get; set; } = string.Empty;
	}
}

