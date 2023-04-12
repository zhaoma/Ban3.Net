//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:12
//  function:	DownloadLifts.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sina
{
	public class DownloadLifts
        :NormalRequest
	{
		public DownloadLifts()
		{
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
                Url = Servers.Sina.UrlForLifts(Code)
            };
        }
    }
}

