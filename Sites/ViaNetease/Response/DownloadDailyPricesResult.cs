//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 08:08
//  function:	DownloadDailyPricesResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Netease
{
	/// <summary>
	/// 下载日行情结果，获取byte[]
	/// </summary>
	public class DownloadDailyPricesResult
		: GenericSingleCallback<byte[]>
	{
		public DownloadDailyPricesResult()
		{
		}
	}
}

