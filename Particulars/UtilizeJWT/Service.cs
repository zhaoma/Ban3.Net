/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * Json Web Tokens方法接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

using Ban3.Infrastructures.Common;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Contracts.Responses.Tokens;
using Ban3.Infrastructures.Common.Contracts.Requests.Tokens;
using Ban3.Infrastructures.Common.Contracts.Models;
using log4net;

namespace Ban3.Infrastructures.Particulars.UtilizeJWT
{
    /// <summary>
    /// Json Web Tokens方法接口实现
    /// </summary>
    public class Service
            : Interfaces.Particulars.IJWT
    {
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service(ILog logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GenerateTokenResult GenerateToken(GenerateToken request)
        {
            var claims = new Claim[]
            {
                    new Claim( ClaimTypes.Sid, request.Creator.Identity + "" ),
                    new Claim( ClaimTypes.Name, request.Creator.Name ),
                    new Claim( ClaimTypes.UserData, request.Creator.Data + "" )
            };

            var key = new SymmetricSecurityKey(Config.CurrrentEnvironment.Particulars.JWT.Secret.StringToBytes());

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                                                Config.CurrrentEnvironment.Particulars.JWT.Issuer,
                                                Config.CurrrentEnvironment.Particulars.JWT.Audience,
                                                claims,
                                                expires:
                                                request.IsAccessToken
                                                        ? DateTime.Now.AddMinutes(Config.CurrrentEnvironment.Particulars.JWT.AccessExpiration)
                                                        : DateTime.Now.AddMinutes(Config.CurrrentEnvironment.Particulars.JWT.RefreshExpiration),
                                                signingCredentials: credentials);

            return new GenerateTokenResult
            {
                Data = new GuestToken
                {
                    Identity = request.Creator.Identity,
                    Name = request.Creator.Name,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    ExpireTime = DateTime.Now.AddMinutes(Config.CurrrentEnvironment.Particulars.JWT.AccessExpiration).DatetimeToTimestamp()
                }
            };
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DecodeTokenResult DecodeToken(DecodeToken request)
        {
            var result = new DecodeTokenResult { Success = false };

            if (!string.IsNullOrEmpty(request.Token))
            {
                var key = new SymmetricSecurityKey(Config.CurrrentEnvironment.Particulars.JWT.Secret.StringToBytes());
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(request.Token);

                result.Success = true;
                result.Data = new TokenCreator
                {
                    Identity = jwtToken.Claims.First(o => o.Type == ClaimTypes.Sid).Value.ToInt(),
                    Name = jwtToken.Claims.First(o => o.Type == ClaimTypes.Name).Value,
                    Data = jwtToken.Claims.First(o => o.Type == ClaimTypes.UserData).Value
                };
            }

            return result;
        }
    }
}