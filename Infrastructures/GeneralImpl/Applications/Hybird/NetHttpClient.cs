// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Linq;
using System.Net.Http;

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;

using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

public class NetHttpClient : OneImplement, IInternetsHelper
{
    public NetHttpClient() {}

    public async Task<bool> TryRequest(
        IInternetHost internetHost,
        IInternetResource internetResource,
        Action<IInternetResponse> action
    )
    {
        try
        {
            var client = Client( internetHost );

            if( !string.IsNullOrEmpty( internetResource.Accept ) )
            {
                client.DefaultRequestHeaders.Add( "Accept", internetResource.Accept );
            }

            var request = Request( internetResource );

            Logger.Debug( $"{request.Method}:{request.RequestUri.AbsoluteUri}" );

            var response = await client.SendAsync( request );

            action( new InternetResponse
            {
                StatusCode = response.StatusCode == HttpStatusCode.OK ? HttpStatus.Ok : HttpStatus.Error,
                Response = new InternetData
                {
                    StringContent = await response.Content.ReadAsStringAsync(),
                    StreamContent = await response.Content.ReadAsStreamAsync(),
                    Bytes = await response.Content.ReadAsByteArrayAsync()
                }
            } );

            return true;
        }
        catch( HttpRequestException ex )
            when( ex.InnerException is OperationCanceledException tex )
        {
            Logger.Error( tex.Message );
        }
        catch( Exception ex )
        {
            Logger.Error( ex.Message );
        }

        return false;
    }

    static readonly object ObjectLock = new();

    private HttpClient Client( IInternetHost internetHost )
    {
        if( _client != null ) return _client;

        lock( ObjectLock )
        {
            _client ??= internetHost.AuthenticationType == AuthenticationType.None
                ? new HttpClient { Timeout = TimeSpan.FromMinutes( 5 ) }
                : new HttpClient( Handler( internetHost ) )
                {
                    BaseAddress = new Uri( internetHost.BaseUrl ),
                    Timeout = TimeSpan.FromMinutes( 5 )
                };
        }

        return _client;
    }

    private static HttpClient _client;

    private HttpClientHandler Handler( IInternetHost internetHost )
    {
        var defaultCredential = string.IsNullOrEmpty( internetHost.Domain )
            ? new NetworkCredential( internetHost.UserName, internetHost.Password )
            : new NetworkCredential( internetHost.UserName, internetHost.Password, internetHost.Domain );

        return new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            AllowAutoRedirect = true,
            MaxConnectionsPerServer = 100,

            Credentials = new CredentialCache
            {
                { new Uri( internetHost.BaseUrl ), internetHost.AuthenticationType.ToString(), defaultCredential }
            }
        };
    }

    private HttpContent Content( IInternetResource internetResource )
    {
        if( internetResource.Request.Bytes != null )
        {
            return new ByteArrayContent( internetResource.Request.Bytes );
        }

        if( internetResource.Request.StreamContent != null )
        {
            return new StreamContent( internetResource.Request.StreamContent );
        }

        return !string.IsNullOrEmpty( internetResource.Request.StringContent )
            ? new StringContent( internetResource.Request.StringContent, Encoding.GetEncoding( internetResource.Request.ContentEncoding ), internetResource.Request.ContentMediaType )
            : null;
    }

    private HttpRequestMessage Request( IInternetResource internetResource )
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri( internetResource.Url ),
            Method = new System.Net.Http.HttpMethod( internetResource.Method.ToString() ),
            Content = Content( internetResource )
        };

        if( internetResource.Headers != null && internetResource.Headers.Any() )
        {
            foreach( var header in internetResource.Headers )
            {
                request.Headers.Add( header.Key, header.Value );
            }
        }

        if( !string.IsNullOrEmpty( internetResource.Charset ) )
        {
            System.Text.Encoding.RegisterProvider( System.Text.CodePagesEncodingProvider.Instance );
            request.Headers.Add( "Accept-Charset", internetResource.Charset );
        }

        return request;
    }
}