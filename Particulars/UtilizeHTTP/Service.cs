/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            WEB服务器访问接口RestSharp实现
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Net;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Interfaces.Particulars;
using Ban3.Infrastructures.Common.Contracts.Servers;
using Ban3.Infrastructures.Common.Contracts.Responses;
using log4net;
using System.Text;

namespace Ban3.Infrastructures.Particulars.UtilizeHTTP
{
    /// <summary>
    /// WEB服务器访问接口RestSharp实现
    /// </summary>
    public class Service
            : IHTTP
    {
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service( ILog logger )
        {
            _logger = logger;
        }

        internal static readonly object Locker = new object();
        internal static RestClient? _instance;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static RestClient Instance
        {
            get
            {
                if( _instance == null )
                {
                    lock( Locker )
                    {
                        if( _instance == null )
                        {
                            _instance = new RestClient();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResource"></param>
        /// <returns></returns>
        public string GetContent(NetResource netResource)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var resp = GetResponse(netResource);
            var content = resp.StatusCode == HttpStatusCode.OK
                           ? Encoding.GetEncoding(netResource.Charset).GetString(resp.RawBytes!)
                           : string.Empty;

            if (netResource.ResourceIsJsonp)
                content = content.JsonpParse(netResource.JsonpPrefix);

            return content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="netResource"></param>
        /// <returns></returns>
        public T Get<T>( NetResource netResource )
        {
            var content = GetContent(netResource);
            
            return !string.IsNullOrEmpty(content)
                           ? content.JsonToObj<T>()
                           : default(T);
        }

        /// <summary>
        /// 返回Common.Contracts.Responses中定义的结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="netResource"></param>
        /// <returns></returns>
        public GenericSingleCallback<T> GetCallback<T>(NetResource netResource)
        {
            var result = new GenericSingleCallback<T>();

            try
            {
                result.Data = Get<T>(netResource);
                result.Success = true;
            }catch(Exception ex)
            {
                _logger.Error(ex);

                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResource"></param>
        /// <returns></returns>
        public byte[] Download( NetResource netResource )
        {
            return Instance.DownloadData( PrepareRequest( netResource ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResource"></param>
        /// <returns></returns>
        RestResponse GetResponse( NetResource netResource )
        {
            return Instance.Execute( PrepareRequest( netResource ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResource"></param>
        /// <returns></returns>
        async Task<RestResponse> GetResponseAsync( NetResource netResource )
        {
            return await Instance.ExecuteAsync( PrepareRequest( netResource ) );
        }

        RestRequest PrepareRequest( NetResource netResource )
        {
            if( netResource.BasicAuthentication != null )
                Instance.Authenticator = new HttpBasicAuthenticator(
                    netResource.BasicAuthentication.UserName,
                    netResource.BasicAuthentication.Password );

            /*
             * TODO
             * 增加OAuth1支持
             * if(netResource.OAuth1!=null)
             */

            if( !string.IsNullOrEmpty( netResource.OAuth2Token ) )
                Instance.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator( netResource.OAuth2Token );

            if( !string.IsNullOrEmpty( netResource.JWTToken ) )
                Instance.Authenticator = new JwtAuthenticator( netResource.JWTToken );

            var request = new RestRequest( netResource.Url, netResource.Method.StringToEnum<Method>() );

            if( netResource.QueryParameters != null )
            {
                foreach( var netResourceParameter in netResource.QueryParameters )
                {
                    if( netResourceParameter.Value != null )
                        request.AddQueryParameter( netResourceParameter.Key, netResourceParameter.Value.ToString() );
                }
            }

            if( netResource.HeaderParameters != null )
            {
                foreach( var netResourceParameter in netResource.HeaderParameters )
                {
                    if( netResourceParameter.Value != null )
                        request.AddHeader( netResourceParameter.Key, netResourceParameter.Value.ToString() );
                }
            }

            if( !string.IsNullOrEmpty( netResource.Body ) )
                request.AddBody( netResource.Body, netResource.ContentType );

            return request;
        }
    }
}