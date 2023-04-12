// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Netease/GetRealTime.cs
// ——————————————————————————————————————
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Netease
{
	public class ReadRealTime
        :NormalRequest
	{
		public ReadRealTime(IEnumerable<string> codes)
		{
            Codes = codes;
		}

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Codes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Url = Servers.Netease.UrlForReadRealtime(Codes),

            };
        }
    }
}

