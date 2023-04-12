// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Sohu/GetNotions.cs
// ——————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sohu
{
    public class DownloadAllNotions
        : NormalRequest
    {
        public DownloadAllNotions()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public int SohuId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Charset = "gb2312",
                Url = Servers.Sohu.UrlForNotions(SohuId)
            };
        }
    }
}

