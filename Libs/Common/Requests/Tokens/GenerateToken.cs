using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Requests.Tokens
{
    public class GenerateToken
    {
        public Models.TokenCreator Creator { get; set; }

        public bool IsAccessToken { get; set; }
    }
}