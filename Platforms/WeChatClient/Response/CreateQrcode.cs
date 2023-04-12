using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Contracts.Responses.Platforms.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateQrcode
    {
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expire_seconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }
}