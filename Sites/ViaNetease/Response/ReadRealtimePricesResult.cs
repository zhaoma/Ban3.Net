//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 08:09
//  function:	ReadRealtimePricesResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Netease
{
	public class ReadRealtimePricesResult
		: GenericSingleCallback<Dictionary<string, StockRecord>>
	{
		public ReadRealtimePricesResult()
		{
		}
	}
}

