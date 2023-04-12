// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Sina/GetBonus.cs
// ——————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sina
{
    ///
    public class DownloadEvents
        :NormalRequest
    {
        ///
		public DownloadEvents(string code)
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
                Charset = "gb2312",
                Url = Servers.Sina.UrlForEvents(Code)
            };
        }
    }
}

