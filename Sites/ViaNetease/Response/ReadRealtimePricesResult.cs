//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 08:09
//  function:	ReadRealtimePricesResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Sites.ViaNetease.Entries;

namespace Ban3.Sites.ViaNetease.Response
{
	public class ReadRealtimePricesResult
	{
		public Dictionary<string, StockRecord> Data { get; set; }
    }
}

