// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Netease/GetPrices.cs
// ——————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Netease
{
	public class DownloadDailyPrices
		:NormalRequest
	{
		public DownloadDailyPrices(string code)
		{
            Code = code;
		}


        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Url = Servers.Netease.UrlForDailyPricesFull(Code)
            };
        }
    }
}

