using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Requests.Normals
{
    /// <summary>
    /// 登录请求
    /// </summary>
    public class Signin
    {
        public string LoginName { get; set; }

        public string LoginPassword { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}