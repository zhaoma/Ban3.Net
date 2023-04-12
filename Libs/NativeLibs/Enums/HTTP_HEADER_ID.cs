namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_HEADER_ID enumeration type lists known headers for HTTP requests and responses, and associates an array index with each such header.
    /// It is used to size and access the KnownHeaders array members of the HTTP_REQUEST_HEADERS and HTTP_RESPONSE_HEADERS structures.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_header_id
    /// </summary>
    public enum HTTP_HEADER_ID
    {
        /// <summary>
        /// Used to specify caching behavior along the request or response chain, overriding the default caching algorithm.
        /// </summary>
        HttpHeaderCacheControl = 0,

        /// <summary>
        /// Allows the sender to specify options that are desired for that particular connection.
        /// These are used for a single connection only and must not be communicated by proxies over further connections.
        /// </summary>
        HttpHeaderConnection = 1,

        /// <summary>
        /// The Date is a general header field that indicates the time that the request or response was sent.
        /// </summary>
        HttpHeaderDate = 2,

        /// <summary>
        /// Based on the keepalive XML element (see RFC 2518, section 12.12.1, page 66);
        /// a list of URIs included in the KeepAlive header must be "live" after they are copied (moved) to the destination.
        /// </summary>
        HttpHeaderKeepAlive = 3,

        /// <summary>
        /// Used to include optional, implementation-specific directives that might apply to any recipient along the request/response chain.
        /// </summary>
        HttpHeaderPragma = 4,

        /// <summary>
        /// Indicates that specified header fields are present in the trailer of a message encoded with chunked transfer-coding.
        /// </summary>
        HttpHeaderTrailer = 5,

        /// <summary>
        /// Indicates what, if any, transformations have been applied to the message body in transit.
        /// </summary>
        HttpHeaderTransferEncoding = 6,

        /// <summary>
        /// Allows the client to specify one or more other communication protocols it would prefer to use if the server can comply.
        /// </summary>
        HttpHeaderUpgrade = 7,

        /// <summary>
        /// The Via header field indicates the path taken by the request.
        /// </summary>
        HttpHeaderVia = 8,

        /// <summary>
        /// This is a response header that contains the 3-digit warn code along with the reason phrase.
        /// </summary>
        HttpHeaderWarning = 9,

        /// <summary>
        /// Lists the set of methods supported by the resource identified by the Request-URI.
        /// </summary>
        HttpHeaderAllow = 10,

        /// <summary>
        /// The size of the message body in decimal bytes.
        /// </summary>
        HttpHeaderContentLength = 11,

        /// <summary>
        /// The media type of the message body.
        /// </summary>
        HttpHeaderContentType = 12,

        /// <summary>
        /// The encoding scheme for the message body.
        /// </summary>
        HttpHeaderContentEncoding = 13,

        /// <summary>
        /// Provides the natural language of the intended audience.
        /// </summary>
        HttpHeaderContentLanguage = 14,

        /// <summary>
        /// Location of the resource for the entity enclosed in the message when that entity is accessible from a location separate from the requested resource's URI.
        /// </summary>
        HttpHeaderContentLocation = 15,

        /// <summary>
        /// An MD5 digest of the entity-body used to provide end-to-end message integrity check (MIC) of the entity-body.
        /// </summary>
        HttpHeaderContentMd5 = 16,

        /// <summary>
        /// The content range header is sent with a partial entity body to specify where in the full entity body the partial body should be applied.
        /// </summary>
        HttpHeaderContentRange = 17,

        /// <summary>
        /// The date and time after which the message content expires.
        /// </summary>
        HttpHeaderExpires = 18,

        /// <summary>
        /// Indicates the date and time at which the origin server believes the variant was last modified.
        /// </summary>
        HttpHeaderLastModified = 19,

        /// <summary>
        /// Used with the INVITE, OPTIONS, and REGISTER methods to indicate what media types are acceptable in the response.
        /// </summary>
        HttpHeaderAccept = 20,

        /// <summary>
        /// Indicates the character sets that are acceptable for the response.
        /// </summary>
        HttpHeaderAcceptCharset = 21,

        /// <summary>
        /// The content encodings that are acceptable in the response.
        /// </summary>
        HttpHeaderAcceptEncoding = 22,

        /// <summary>
        /// Used by the client to indicate to the server which language it would prefer to receive reason phrases, session descriptions, or status responses.
        /// </summary>
        HttpHeaderAcceptLanguage = 23,

        /// <summary>
        /// The user-agent can authenticate itself with a server by sending the Authorization request header field with the request.
        /// The field contains the credentials for the domain that the user is requesting.
        /// </summary>
        HttpHeaderAuthorization = 24,

        /// <summary>
        /// The cookie request header contains data used to maintain client state with the server.
        /// Cookie data is obtained from a response sent with HttpHeaderSetCookie.
        /// </summary>
        HttpHeaderCookie = 25,

        /// <summary>
        /// Indicates the specific server behaviors that are required by the client.
        /// </summary>
        HttpHeaderExpect = 26,

        /// <summary>
        /// The From header field specifies the initiator of the SIP request or response message.
        /// </summary>
        HttpHeaderFrom = 27,

        /// <summary>
        /// Specifies the Internet host and port number of the requested resource.
        /// This is obtained from the original URI given by the user or referring resource.
        /// </summary>
        HttpHeaderHost = 28,

        /// <summary>
        /// The If-Match request header field is used with a method to make it conditional.
        /// A client that has one or more entities previously obtained from the resource can verify that one of those entities is current by including a list of their associated entity tags in the If-Match header field.
        /// </summary>
        HttpHeaderIfMatch = 29,

        /// <summary>
        /// The If-Modified-Since request header field is used with a method to make it conditional.
        /// If the requested variant has not been modified since the time specified in this field, an entity is not returned from the server; instead, a 304 (not modified) response is returned without any message-body.
        /// </summary>
        HttpHeaderIfModifiedSince = 30,

        /// <summary>
        /// 
        /// </summary>
        HttpHeaderIfNoneMatch = 31,
        HttpHeaderIfRange = 32,
        HttpHeaderIfUnmodifiedSince = 33,
        HttpHeaderMaxForwards = 34,
        HttpHeaderProxyAuthorization = 35,
        HttpHeaderReferer = 36,
        HttpHeaderRange = 37,
        HttpHeaderTe = 38,
        HttpHeaderTranslate = 39,
        HttpHeaderUserAgent = 40,
        HttpHeaderRequestMaximum = 41,
        HttpHeaderAcceptRanges = 20,
        HttpHeaderAge = 21,
        HttpHeaderEtag = 22,
        HttpHeaderLocation = 23,
        HttpHeaderProxyAuthenticate = 24,
        HttpHeaderRetryAfter = 25,
        HttpHeaderServer = 26,
        HttpHeaderSetCookie = 27,
        HttpHeaderVary = 28,
        HttpHeaderWwwAuthenticate = 29,
        HttpHeaderResponseMaximum = 30,
        HttpHeaderMaximum = 41
    }
}