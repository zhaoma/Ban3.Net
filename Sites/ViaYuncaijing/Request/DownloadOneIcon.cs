using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Yuncaijing
{
    public class DownloadOneIcon
        :NormalRequest
     {
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
                Url = Servers.Yuncaijing.UrlForOneIcon(Code)
            };
        }
    
    
    }
}