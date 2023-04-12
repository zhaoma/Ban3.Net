//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 08:08
//  function:	DownloadFinancesResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Netease;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Netease
{
	public class DownloadFinancesResult
		:GenericListCallback<StockFinance>
	{
		public DownloadFinancesResult()
		{
		}
	}
}

