//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:27
//  function:	DownloadNotionStocks.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sohu
{
	public class DownloadNotionStocks
        :NormalRequest
	{
		public DownloadNotionStocks()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        public int NotionId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Charset = "gb2312",
                Url = Servers.Sohu.UrlForNotionStocks(NotionId)
            };
        }
    }
}

