namespace Ban3.Infrastructures.NativeLibs.Enums;

/// <summary>
/// The HTTP_AUTH_STATUS enumeration defines the authentication state of a request.
/// This enumeration is used in the HTTP_REQUEST_AUTH_INFO structure.
/// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_auth_status
/// </summary>
public enum HTTP_AUTH_STATUS
{
    /// <summary>
    /// The request was successfully authenticated for the authentication type indicated in the HTTP_REQUEST_AUTH_INFO structure.
    /// </summary>
    HttpAuthStatusSuccess,

    /// <summary>
    /// Authentication was configured on the URL group for this request, however, the HTTP Server API did not handle the authentication.
    /// This could be because of one of the following reasons:
    /// 
    /// The scheme defined in the HttpHeaderAuthorization header of the request is not supported by the HTTP Server API,
    ///     or it is not enabled on the URL Group. If the scheme is not enabled,
    ///     the AuthType member of HTTP_REQUEST_AUTH_INFO is set to the appropriate type,
    ///     otherwise AuthType will have the value HttpRequestAuthTypeNone.
    /// The authorization header is not present, however, authentication is enabled on the URL Group.
    ///
    /// The application should either proceed with its own authentication or respond with the initial 401 challenge containing the desired set of authentication schemes.
    /// </summary>
    HttpAuthStatusNotAuthenticated,

    /// <summary>
    /// Authentication for the authentication type listed in the HTTP_REQUEST_AUTH_INFO structure failed, possibly due to one of the following reasons:
    ///
    /// The Security Service Provider Interface (SSPI) based authentication scheme failed to successfully return from a call to AcceptSecurityContext.
    ///     The error returned AcceptSecurityContext is indicated in the SecStatus member of the HTTP_REQUEST_AUTH_INFO structure.
    /// The finalized client context is for a Null NTLM session. Null sessions are treated as authentication failures.
    /// The call to LogonUser failed for the Basic authentication.
    /// </summary>
    HttpAuthStatusFailure
}