namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_VERB enumeration type defines values that are used to specify known, standard HTTP verbs in the HTTP_REQUEST structure.
    /// The majority of these known verbs are documented in RFC 2616 and RFC 2518, as indicated below.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_verb
    /// </summary>
    public enum HTTP_VERB
    {
        HttpVerbUnparsed,
        HttpVerbUnknown,
        HttpVerbInvalid,
        HttpVerbOPTIONS,
        HttpVerbGET,
        HttpVerbHEAD,
        HttpVerbPOST,
        HttpVerbPUT,
        HttpVerbDELETE,
        HttpVerbTRACE,
        HttpVerbCONNECT,
        HttpVerbTRACK,
        HttpVerbMOVE,
        HttpVerbCOPY,
        HttpVerbPROPFIND,
        HttpVerbPROPPATCH,
        HttpVerbMKCOL,
        HttpVerbLOCK,
        HttpVerbUNLOCK,
        HttpVerbSEARCH,
        HttpVerbMaximum
    }
}